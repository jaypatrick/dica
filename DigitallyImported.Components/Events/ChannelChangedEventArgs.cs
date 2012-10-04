using System;

namespace DigitallyImported.Components
{
    /// <summary>
    /// 
    /// </summary>
    public class ChannelChangedEventArgs : EventArgs
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="channelName"></param>
        /// <param name="channelUri"></param>
        /// <param name="trackTitle"></param>
        public ChannelChangedEventArgs(MediaType mediaType, string channelName, Uri channelUri, string trackTitle)
        {
            _mediaType = mediaType;
            _trackName = trackTitle;
            _channelUri = channelUri;
            _channelName = channelName;
        }

        /// <summary>
        /// 
        /// </summary>
        public MediaType MediaType
        {
            get { return this._mediaType; }
            set { this._mediaType = value; }
        }
        private MediaType _mediaType;

        /// <summary>
        /// 
        /// </summary>
        public string TrackName
        {
            get { return this._trackName; }
            set { this._trackName = value; }
        }
        private string _trackName;

        /// <summary>
        /// 
        /// </summary>
        public Uri ChannelUri
        {
            get { return _channelUri; }
            set { _channelUri = value; }
        }
        private Uri _channelUri;

        /// <summary>
        /// 
        /// </summary>
        public string ChannelName
        {
            get { return _channelName; }
            set { _channelName = value; }
        }
        private string _channelName;
    }
}
