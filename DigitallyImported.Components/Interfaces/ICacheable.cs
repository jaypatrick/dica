namespace DigitallyImported.Components.Caching
{
    public interface ICacheable
    {
        void ClearItems<T>();
        T GetItem<T>(T cacheItem);
        void InsertItem<T>(T cacheItem);
        void RemoveItem<T>(T cacheItem);
    }
}