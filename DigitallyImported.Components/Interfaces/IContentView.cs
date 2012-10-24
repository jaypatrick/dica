#region using declarations

using System.Collections.Generic;

#endregion

namespace DigitallyImported.Components
{
    public interface IContentView<T> : IComparer<T> where T : IContent
    {
        ViewType ViewType { get; set; }
        StationType PlaylistTypes { get; set; }
        void Sort(ContentCollection<T> contentCollection);
        void Save();
        ContentCollection<T> GetView(ContentType contentType);
        ContentCollection<T> GetView(T t);
    }
}