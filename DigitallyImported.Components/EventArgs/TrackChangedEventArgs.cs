using System;

namespace DigitallyImported.Components
{
    /// <summary>
    /// 
    /// </summary>
    /// 

    [Serializable]
    public class TrackChangedEventArgs<T> : ContentChangedEventArgs<T> 
        where T: ITrack
    {
        private T _refreshedTrack = default(T);

        /// <summary>
        /// 
        /// </summary>
        public TrackChangedEventArgs() : this(default(T)) { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="channelName"></param>
        public TrackChangedEventArgs(T refreshedTrack)
            : base(refreshedTrack)
        {
            _refreshedTrack = refreshedTrack;
        }

        public override T RefreshedContent
        {
            get
            {
                return _refreshedTrack;
            }
            set
            {
                _refreshedTrack = value;
            }
        }
    }
}
