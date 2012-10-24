#region using declarations

using System;

#endregion

namespace DigitallyImported.Components
{
    /// <summary>
    /// </summary>
    /// <typeparam name="T"> </typeparam>
    [Serializable]
    public class TrackCollection<T> : ContentCollection<T>
        where T : ITrack
    {
        /// <summary>
        /// </summary>
        public virtual T Channel { get; set; }

        /// <summary>
        /// </summary>
        public bool HasNewTracks { get; set; }

        /// <summary>
        /// </summary>
        public TrackCollection<T> NewTracks { get; set; }
    }
}