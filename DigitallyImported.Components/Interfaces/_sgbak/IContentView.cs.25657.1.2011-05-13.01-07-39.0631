using System.Collections.Generic;

namespace DigitallyImported.Components
{
    public interface IContentView<T> : IComparer<T> where T: IContent
    {
        void Sort(ContentCollection<T> contentCollection);
        void Save();
        ContentCollection<T> GetView(ContentType contentType);
        ContentCollection<T> GetView(T t);

        ViewType ViewType { get; set; }
        PlaylistTypes PlaylistTypes { get; set; }
    }
}
