using System;
using System.Runtime.Caching;

namespace DigitallyImported.Components.Caching
{
    /// <summary>
    /// 
    /// </summary>
    /// 
    [Serializable]
    public class ItemExpiredEventArgs<TItem> : EventArgs
        where TItem : IContent
    {
        private readonly TItem _cachedItem;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="removedKey"></param>
        public ItemExpiredEventArgs(string removedKey)
            : this(removedKey, default(TItem))
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="removedKey"></param>
        /// <param name="expiredValue"></param>
        public ItemExpiredEventArgs(string removedKey, TItem expiredValue)
            : this(removedKey
                   , expiredValue
                   , CacheEntryRemovedReason.Expired)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="removedKey"></param>
        /// <param name="expiredValue"></param>
        /// <param name="removalReason"></param>
        public ItemExpiredEventArgs(string removedKey, TItem expiredValue, CacheEntryRemovedReason removalReason)
            : this(removedKey
                   , expiredValue
                   , removalReason
                   , CacheItem<TItem>.ExpirationCallback)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="removedKey"></param>
        /// <param name="expiredValue"></param>
        /// <param name="removalReason"></param>
        /// <param name="callbackFunction"></param>
        public ItemExpiredEventArgs(string removedKey, TItem expiredValue, CacheEntryRemovedReason removalReason,
                                    CacheEntryRemovedCallback callbackFunction)
        {
            RemovedKey = removedKey;
            ExpiredValue = expiredValue;
            RemovalReason = removalReason;
            CallbackFunction = callbackFunction;
            ExpirationTime = DateTime.Now;
            _cachedItem = expiredValue;
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual string RemovedKey { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual TItem ExpiredValue { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual CacheEntryRemovedReason RemovalReason { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual CacheEntryRemovedCallback CallbackFunction { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime ExpirationTime { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime ExpirationInterval { get; set; }

        public override string ToString()
        {
            return _cachedItem.ToString();
        }
    }
}