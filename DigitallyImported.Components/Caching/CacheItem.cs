#region using declarations

using System;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.Caching;
using DigitallyImported.Configuration.Properties;
using DigitallyImported.Data;

#endregion

namespace DigitallyImported.Components.Caching
{
    /// <summary>
    /// </summary>
    /// <typeparam name="T"> </typeparam>
    public abstract class CacheItem<T> : ICacheable
        where T : IContent
        // wrapper around Cache object
        // ...inherit from this for caching ability
    {
        private static EventHandler<ItemExpiredEventArgs<T>> _itemExpired;
        private static readonly object _itemExpiredLock = new object();

        /// <summary>
        /// </summary>
        protected CacheItem()
        {
        }

        /// <summary>
        /// </summary>
        /// <param name="value"> </param>
        protected CacheItem(CacheItem<T> value)
        {
            if (value == null) throw new ArgumentNullException("value");
            var instance = value;
        }

        /// <summary>
        /// </summary>
        /// <param name="item"> </param>
        /// <returns> </returns>
        protected virtual T this[T item]
        {
            get { return GetItem(item); }
            set { InsertItem(item); }
        }

        #region ICacheable Members

        /// <summary>
        /// </summary>
        /// <typeparam name="TItem"> </typeparam>
        /// <param name="cacheItem"> </param>
        public virtual void InsertItem<TItem>(TItem cacheItem)
        {
            InsertItem(cacheItem, GetExpirationTime());
        }

        /// <summary>
        /// </summary>
        /// <param name="cacheItem"> </param>
        /// <returns> </returns>
        public virtual TItem GetItem<TItem>(TItem cacheItem)
        {
            return cacheItem != null ? Cache<string, TItem>.Get(cacheItem.GetHashCode().ToString()) : default(TItem);
        }

        /// <summary>
        /// </summary>
        /// <typeparam name="TItem"> </typeparam>
        /// <param name="cacheItem"> </param>
        public virtual void RemoveItem<TItem>(TItem cacheItem)
        {
            Cache<string, TItem>.Remove(cacheItem.GetHashCode().ToString());
        }

        /// <summary>
        /// </summary>
        /// <typeparam name="TItems"> </typeparam>
        public virtual void ClearItems<TItems>()
        {
            Cache<string, TItems>.Clear();
        }

        #endregion

        /// <summary>
        /// </summary>
        /// <param name="cacheItem"> </param>
        /// <param name="expirationTime"> </param>
        protected virtual void InsertItem<TItem>(TItem cacheItem, DateTime expirationTime)
        {
            Trace.WriteLine(
                string.Format("Inserting cache key {0} of type {1}", cacheItem.GetHashCode().ToString(),
                              cacheItem.GetType().UnderlyingSystemType.Name), TraceCategory.Caching.ToString());
            Cache<string, TItem>.Insert(cacheItem.GetHashCode().ToString(), cacheItem, expirationTime);
        }

        /// <summary>
        /// </summary>
        /// <returns> </returns>
        public static DateTime GetExpirationTime()
        {
            return DateTime.Now.AddMilliseconds(Settings.Default.PlaylistRefreshInterval.TotalMilliseconds/2);
        }


        /// <summary>
        /// </summary>
        /// <param name="arguments"> </param>
        public static void ExpirationCallback(CacheEntryRemovedArguments arguments)
        {
            if (arguments == null) throw new ArgumentNullException("arguments");
            // ItemExpiredEventArgs eventArgs = new ItemExpiredEventArgs(removedKey, expiredValue, removalReason);
            var eventArgs = new ItemExpiredEventArgs<T>(arguments.CacheItem.Key
                                                        , (T) arguments.CacheItem.Value
                                                        , arguments.RemovedReason);

            Trace.WriteLine(string.Format("Item {0} was {1} from cache."
                                          , arguments.CacheItem.Value.GetType().Name
                                          , arguments.RemovedReason.ToString()
                                          , TraceCategory.Caching.ToString()));

            if (arguments.RemovedReason == CacheEntryRemovedReason.Expired)
            {
                Trace.WriteLine(string.Format("Cache has {0} items before callback: {1} was {2} from cache."
                                              , Cache<string, T>.Count
                                              , arguments.CacheItem.Value.GetType().Name
                                              , arguments.RemovedReason.ToString()
                                              , TraceCategory.Caching.ToString()));

                lock (_itemExpiredLock)
                {
                    Trace.WriteLine(string.Format("{0}: {1} {2} {3}"
                                                  , arguments.RemovedReason.ToString()
                                                  , arguments.CacheItem.Key
                                                  , arguments.CacheItem.Value.GetType().Name
                                                  , "callback started. ")
                                    , TraceCategory.Caching.ToString());

                    //Trace.WriteLine(string.Format("Cache has {0} items after pruning. ", Cache<string, object>.Count));

                    // testing, filter out critical cache values and refresh them
                    // need to run tests to see if dependencies perform better (memory-wise)
                    if (arguments.CacheItem.Value.GetType() == typeof (ChannelData))
                    {
                        arguments.CacheItem.Value = new ChannelListLoader<IChannel>().LoadPlaylist(true);
                        arguments.CacheItem.Key =
                            arguments.CacheItem.Value.GetHashCode().ToString(CultureInfo.InvariantCulture);
                        Cache<string, T>.Insert(arguments.CacheItem.Key, (T) arguments.CacheItem.Value);
                    }
                }

                Trace.WriteLine(string.Format("{0}: {1} {2} {3}"
                                              , arguments.RemovedReason.ToString()
                                              , arguments.CacheItem.Key
                                              , arguments.CacheItem.Value.GetType().Name
                                              , "callback completed. "), TraceCategory.Caching.ToString());

                Trace.WriteLine(string.Format("Cache has {0} items after callback. ", Cache<string, T>.Count)
                                , TraceCategory.Caching.ToString());

                // raise the event; can use this elsewhere to trigger callbacks, which YOU SHOULD DO!
                if (_itemExpired != null)
                    _itemExpired(default(T), eventArgs);
            }
        }

        /// <summary>
        /// </summary>
        public static event EventHandler<ItemExpiredEventArgs<T>> ItemExpired
        {
            add
            {
                lock (_itemExpiredLock)
                {
                    if (_itemExpired != null) _itemExpired += value;
                }
            }
            remove
            {
                lock (_itemExpiredLock)
                {
                    if (_itemExpired != null) _itemExpired -= value;
                }
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="sender"> </param>
        /// <param name="e"> </param>
        protected internal virtual void OnItemExpired(object sender, ItemExpiredEventArgs<T> e)
        {
            if (sender == null) throw new ArgumentNullException("sender");
            if (e == null) throw new ArgumentNullException("e");
            if (_itemExpired != null)
                _itemExpired(sender, e);
        }
    }
}