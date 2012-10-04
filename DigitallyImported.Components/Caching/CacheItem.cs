using System;
using System.Diagnostics;
using System.Runtime.Caching;

using DigitallyImported.Configuration.Properties;

namespace DigitallyImported.Components.Caching
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class CacheItem<T> : ICacheable
        where T: IContent
        // wrapper around Cache object
        // ...inherit from this for caching ability
    {
        /// <summary>
        /// 
        /// </summary>
        protected CacheItem()
        { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        protected CacheItem(CacheItem<T> value) 
        { 
            var instance = value; 
        
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        protected virtual T this[T item]
        {
            get { return this.GetItem(item); }
            set { InsertItem(item); }
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="Item"></typeparam>
        /// <param name="cacheItem"></param>
        /// <param name="cacheDependency"></param>
        public virtual void InsertItem<TItem>(TItem cacheItem)
        {
            InsertItem(cacheItem, CacheItem<T>.GetExpirationTime());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="Item"></typeparam>
        /// <param name="cacheItem"></param>
        /// <param name="cacheDependency"></param>
        /// <param name="expirationInterval"></param>
        public virtual void InsertItem<TItem>(TItem cacheItem, DateTime expirationTime)
        {
            Trace.WriteLine(string.Format("Inserting cache key {0} of type {1}", cacheItem.GetHashCode().ToString(), cacheItem.GetType().UnderlyingSystemType.Name), TraceCategories.Caching.ToString());
            Cache<string, TItem>.Insert(cacheItem.GetHashCode().ToString(), cacheItem, expirationTime);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="Item"></typeparam>
        /// <param name="cacheItem"></param>
        /// <returns></returns>
        public virtual TItem GetItem<TItem>(TItem cacheItem)
        {
            if (cacheItem != null)
                return Cache<string, TItem>.Get(cacheItem.GetHashCode().ToString());
            else
                return default(TItem);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="Item"></typeparam>
        /// <param name="cacheItem"></param>
        public virtual void RemoveItem<TItem>(TItem cacheItem)
        {
            Cache<string, TItem>.Remove(cacheItem.GetHashCode().ToString());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TItems"></typeparam>
        public virtual void ClearItems<TItems>()
        {
            Cache<string, TItems>.Clear();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static DateTime GetExpirationTime()
        {
            return DateTime.Now.AddMilliseconds(Settings.Default.PlaylistRefreshInterval.TotalMilliseconds / 2);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="removedKey"></param>
        /// <param name="expiredValue"></param>
        /// <param name="removalReason"></param>
        public static void ExpirationCallback(CacheEntryRemovedArguments arguments)
        {
            // ItemExpiredEventArgs eventArgs = new ItemExpiredEventArgs(removedKey, expiredValue, removalReason);
            ItemExpiredEventArgs<T> eventArgs = new ItemExpiredEventArgs<T>(arguments.CacheItem.Key
                , (T)arguments.CacheItem.Value
                , arguments.RemovedReason);

            Trace.WriteLine(string.Format("Item {0} was {1} from cache."
                , arguments.CacheItem.Value.GetType().Name
                , arguments.RemovedReason.ToString()
                , TraceCategories.Caching.ToString()));

            if (arguments.RemovedReason == CacheEntryRemovedReason.Expired)
            {
                Trace.WriteLine(string.Format("Cache has {0} items before callback: {1} was {2} from cache."
                    , Cache<string, T>.Count
                    , arguments.CacheItem.Value.GetType().Name
                    , arguments.RemovedReason.ToString()
                    , TraceCategories.Caching.ToString()));

                lock (_itemExpiredLock)
                {
                    Trace.WriteLine(string.Format("{0}: {1} {2} {3}"
                        , arguments.RemovedReason.ToString()
                        , arguments.CacheItem.Key
                        , arguments.CacheItem.Value.GetType().Name
                        , "callback started. ")
                        , TraceCategories.Caching.ToString());

                    //Trace.WriteLine(string.Format("Cache has {0} items after pruning. ", Cache<string, object>.Count));

                    // testing, filter out critical cache values and refresh them
                    // need to run tests to see if dependencies perform better (memory-wise)
                    if (arguments.CacheItem.Value.GetType() == typeof(DigitallyImported.Data.ChannelData))
                    {
                        arguments.CacheItem.Value = new ChannelListLoader<IChannel>().LoadPlaylist(true);
                        arguments.CacheItem.Key = arguments.CacheItem.Value.GetHashCode().ToString();
                        Cache<string, T>.Insert(arguments.CacheItem.Key, (T)arguments.CacheItem.Value);
                    }
                }

                Trace.WriteLine(string.Format("{0}: {1} {2} {3}"
                        , arguments.RemovedReason.ToString()
                        , arguments.CacheItem.Key
                        , arguments.CacheItem.Value.GetType().Name
                        , "callback completed. "), TraceCategories.Caching.ToString());

                Trace.WriteLine(string.Format("Cache has {0} items after callback. ", Cache<string, T>.Count)
                    , TraceCategories.Caching.ToString());

                // raise the event; can use this elsewhere to trigger callbacks, which YOU SHOULD DO!
                if (_itemExpired != null)
                    _itemExpired(default(T), eventArgs);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static event EventHandler<ItemExpiredEventArgs<T>> ItemExpired
        {
            add
            {
                lock (_itemExpiredLock)
                {
                    _itemExpired += value;
                }
            }
            remove
            {
                lock (_itemExpiredLock)
                {
                    _itemExpired -= value;
                }
            }
        }
        private static EventHandler<ItemExpiredEventArgs<T>> _itemExpired;
        private static readonly object _itemExpiredLock = new object();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected internal virtual void OnItemExpired(object sender, ItemExpiredEventArgs<T> e)
        {
            if (_itemExpired != null)
                _itemExpired(sender, e);
        }
    }
}
