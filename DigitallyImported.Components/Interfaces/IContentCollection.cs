using System.Collections.Generic;

namespace DigitallyImported.Components
{
    public interface IContentCollection<T> : IList<T> where T : IContent
    {
        T this[string name] { get; }
        // IContentCollection<T> Create(); // FOLLOW CS PATTERN FOR THIS, featch from cache, etc. let all low level collection classes handle their own caching, no effort from the client!
        SortOrder SortOrder { get; set; }
        SortBy SortBy { get; set; }
        StationType PlaylistTypes { get; set; }
    }
}