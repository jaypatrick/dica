namespace DigitallyImported.Components.Caching
{
    /// <summary>
    /// </summary>
    public interface ICacheable
    {
        /// <summary>
        /// </summary>
        /// <typeparam name="T"> </typeparam>
        void ClearItems<T>();

        /// <summary>
        /// </summary>
        /// <typeparam name="T"> </typeparam>
        /// <param name="cacheItem"> </param>
        /// <returns> </returns>
        T GetItem<T>(T cacheItem);

        /// <summary>
        /// </summary>
        /// <typeparam name="T"> </typeparam>
        /// <param name="cacheItem"> </param>
        void InsertItem<T>(T cacheItem);

        /// <summary>
        /// </summary>
        /// <typeparam name="T"> </typeparam>
        /// <param name="cacheItem"> </param>
        void RemoveItem<T>(T cacheItem);
    }
}