#region using declarations

using System;

#endregion

namespace DigitallyImported.Components
{
    /// <summary>
    /// </summary>
    [Serializable]
    public class TrackChangedEventArgs<T> : ContentChangedEventArgs<T>
        where T : ITrack
    {
        /// <summary>
        /// </summary>
        public TrackChangedEventArgs() : this(default(T))
        {
        }

        /// <summary>
        /// </summary>
        /// <param name="refreshedTrack"> </param>
        public TrackChangedEventArgs(T refreshedTrack)
            : base(refreshedTrack)
        {
            RefreshedContent = refreshedTrack;
        }

        /// <summary>
        /// </summary>
        public override T RefreshedContent { get; set; }
    }
}