using System;
using System.Runtime.Caching;
using DigitallyImported.Configuration.Properties;

namespace DigitallyImported.Components.Caching
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    internal class Cache<TKey, TValue>
    {
        private static MemoryCache _cache;

        /// <summary>
        /// Static initializer should ensure we only have to look up the current cache
        /// instance once.
        /// </summary>
        static Cache()
        {
            _cache = MemoryCache.Default;
        }

        private Cache()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cacheKey"></param>
        /// <returns></returns>
        internal TValue this[TKey cacheKey]
        {
            get { return this[cacheKey]; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cacheKey"></param>
        /// <param name="cacheItem"></param>
        /// <returns></returns>
        internal TValue this[TKey cacheKey, TValue cacheItem]
        {
            get { return Get(cacheKey); }
            private set { Insert(cacheKey, cacheItem); }
        }

        /// <summary>
        /// 
        /// </summary>
        internal static int Count
        {
            get { return (int) _cache.GetCount(); }
        }

        /// <summary>
        /// 
        /// </summary>
        internal static void Clear()
        {
            _cache.Dispose();
            _cache = MemoryCache.Default;
        }

        /// <summary>
        /// Removes the specified cacheKey from the cache
        /// </summary>
        /// <param name="cacheKey"></param>
        internal static void Remove(TKey cacheKey)
        {
            if (_cache.Contains(cacheKey as string))
                _cache.Remove(cacheKey as string);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cacheKey"></param>
        /// <param name="cacheItem"></param>
        internal static void Insert(TKey cacheKey, TValue cacheItem)
        {
            Insert(cacheKey
                   , cacheItem
                   , CacheItem<IContent>.GetExpirationTime());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cacheKey"></param>
        /// <param name="cacheItem"></param>
        /// <param name="expirationTime"> </param>
        internal static void Insert(TKey cacheKey, TValue cacheItem, DateTime expirationTime)
        {
            _cache.Add(cacheKey as string
                       , cacheItem
                       , new DateTimeOffset().AddMilliseconds
                             (Settings.Default.PlaylistRefreshInterval.TotalMilliseconds/2));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cacheKey"></param>
        /// <returns></returns>
        internal static TValue Get(TKey cacheKey)
        {
            return _cache.Contains(cacheKey as string)
                       ? (TValue) _cache[cacheKey as string]
                       : default(TValue);
        }
    }
}