using System;

namespace DigitallyImported.Components
{
    [Serializable]
    public class StreamChangedEventArgs<T> : ContentChangedEventArgs<T>
        where T : IStream
    {
        public StreamChangedEventArgs()
            : this(default(T))
        {
        }

        public StreamChangedEventArgs(T refreshedStream)
            : base(refreshedStream)
        {
            RefreshedContent = refreshedStream;
        }

        public override T RefreshedContent { get; set; }
    }
}