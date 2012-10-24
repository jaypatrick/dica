#region using declarations

using System;

#endregion

namespace DigitallyImported.Components
{
    /// <summary>
    /// </summary>
    /// <typeparam name="T"> </typeparam>
    [Serializable]
    public class StreamChangedEventArgs<T> : ContentChangedEventArgs<T>
        where T : IStream
    {
        /// <summary>
        /// </summary>
        public StreamChangedEventArgs()
            : this(default(T))
        {
        }

        /// <summary>
        /// </summary>
        /// <param name="refreshedStream"> </param>
        public StreamChangedEventArgs(T refreshedStream)
            : base(refreshedStream)
        {
            RefreshedContent = refreshedStream;
        }

        /// <summary>
        /// </summary>
        public override T RefreshedContent { get; set; }
    }
}