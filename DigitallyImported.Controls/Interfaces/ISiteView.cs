#region using declarations

using DigitallyImported.Components;

#endregion

namespace DigitallyImported.Controls
{
    /// <summary>
    /// </summary>
    /// <typeparam name="T"> </typeparam>
    public interface ISiteView<T> : IContentView<T> where T : IPlaylist
    {
        PlaylistCollection<T> Sites { get; }

        SortOrder SortOrder { get; set; }
        SortBy SortBy { get; set; }
        PlaylistCollection<T> GetView(bool bypassCache);
    }
}