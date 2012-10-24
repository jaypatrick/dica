#region using declarations

using System;
using System.Runtime.Caching;

#endregion

namespace DigitallyImported.Components.Caching
{
    /// <summary>
    /// </summary>
    /// <typeparam name="TItem"> </typeparam>
    [Serializable]
    public class ItemExpiredEventArgs<TItem> : EventArgs
        where TItem : IContent
    {
        private readonly TItem _cachedItem;

        /// <summary>
        /// </summary>
        /// <param name="removedKey"> </param>
        /// <param name="expiredValue"> </param>
        public ItemExpiredEventArgs(string removedKey, TItem expiredValue = default(TItem))
            : this(removedKey
                   , expiredValue
                   , CacheEntryRemovedReason.Expired)
        {
            if (removedKey == null) throw new ArgumentNullException("removedKey");
        }

        /// <summary>
        /// </summary>
        /// <param name="removedKey"> </param>
        /// <param name="expiredValue"> </param>
        /// <param name="removalReason"> </param>
        public ItemExpiredEventArgs(string removedKey, TItem expiredValue, CacheEntryRemovedReason removalReason)
            : this(removedKey
                   , expiredValue
                   , removalReason
                   , CacheItem<TItem>.ExpirationCallback)
        {
            if (removedKey == null) throw new ArgumentNullException("removedKey");
        }

        /// <summary>
        /// </summary>
        /// <param name="removedKey"> </param>
        /// <param name="expiredValue"> </param>
        /// <param name="removalReason"> </param>
        /// <param name="callbackFunction"> </param>
        public ItemExpiredEventArgs(string removedKey, TItem expiredValue, CacheEntryRemovedReason removalReason,
                                    CacheEntryRemovedCallback callbackFunction)
        {
            if (removedKey == null) throw new ArgumentNullException("removedKey");
            if (callbackFunction == null) throw new ArgumentNullException("callbackFunction");
            RemovedKey = removedKey;
            ExpiredValue = expiredValue;
            RemovalReason = removalReason;
            CallbackFunction = callbackFunction;
            ExpirationTime = DateTime.Now;
            _cachedItem = expiredValue;
        }

        /// <summary>
        /// </summary>
        protected virtual string RemovedKey { get; set; }

        /// <summary>
        /// </summary>
        protected virtual TItem ExpiredValue { get; set; }

        /// <summary>
        /// </summary>
        protected virtual CacheEntryRemovedReason RemovalReason { get; set; }

        /// <summary>
        /// </summary>
        protected virtual CacheEntryRemovedCallback CallbackFunction { get; set; }

        /// <summary>
        /// </summary>
        protected virtual DateTime ExpirationTime { get; set; }

        /// <summary>
        /// </summary>
        public virtual DateTime ExpirationInterval { get; set; }

        public override string ToString()
        {
            return _cachedItem.ToString();
        }
    }
}