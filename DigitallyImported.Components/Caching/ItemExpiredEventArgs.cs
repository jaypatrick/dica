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
        where TItem: IContent
    {

        private TItem _cachedItem;
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
                , new CacheEntryRemovedCallback(CacheItem<TItem>.ExpirationCallback))
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="removedKey"></param>
        /// <param name="expiredValue"></param>
        /// <param name="removalReason"></param>
        /// <param name="callbackFunction"></param>
        public ItemExpiredEventArgs(string removedKey, TItem expiredValue, CacheEntryRemovedReason removalReason, CacheEntryRemovedCallback callbackFunction)
        {
            _removedKey         = removedKey;
            _expiredValue       = expiredValue;
            _removalReason      = removalReason;
            _callbackFunction   = callbackFunction;
            _expirationTime     = DateTime.Now;
            _cachedItem         = expiredValue;

            _cachedItem.ToString();

        }

        /// <summary>
        /// 
        /// </summary>
        public virtual string RemovedKey
        {
            get { return _removedKey; }
            set { _removedKey = value; }
        }
        private string _removedKey;

        /// <summary>
        /// 
        /// </summary>
        public virtual TItem ExpiredValue
        {
            get { return _expiredValue; }
            set { _expiredValue = value; }
        }
        private TItem _expiredValue;

        /// <summary>
        /// 
        /// </summary>
        public virtual CacheEntryRemovedReason RemovalReason
        {
            get { return _removalReason; }
            set { _removalReason = value; }
        }
        private CacheEntryRemovedReason _removalReason;

        /// <summary>
        /// 
        /// </summary>
        public virtual CacheEntryRemovedCallback CallbackFunction
        {
            get { return _callbackFunction; }
            set { _callbackFunction = value; }
        }
        private CacheEntryRemovedCallback _callbackFunction;

        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime ExpirationTime
        {
            get { return _expirationTime; }
        }
        private DateTime _expirationTime;

        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime ExpirationInterval
        {
            get { return _expirationInterval; }
            set { _expirationInterval = value; }
        }
        private DateTime _expirationInterval;

        public override string ToString()
        {
            return _cachedItem.ToString();
        }
    }
}
