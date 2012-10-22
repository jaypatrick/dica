using DigitallyImported.Components;

namespace DigitallyImported.Utilities
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ISiteView<T> : IContentView<T> where T : IPlaylist
    {
        PlaylistCollection<T> Sites { get; }

        SortOrder SortOrder { get; set; }
        SortBy SortBy { get; set; }
        PlaylistCollection<T> GetView(bool bypassCache);
    }
}