using System;
using System.Collections.Generic;
using System.Text;

namespace DigitallyImported.Components
{
    /// <summary>
    /// 
    /// </summary>
    public class PlaylistRefreshedEventArgs : EventArgs
    {
        /// <summary>
        /// 
        /// </summary>
        public PlaylistRefreshedEventArgs() : this(string.Empty) { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="channelName"></param>
        public PlaylistRefreshedEventArgs(string channelName)
        {
            _channelName = channelName;
        }

        /// <summary>
        /// 
        /// </summary>
        public string ChannelName
        {
            get { return this._channelName; }
            set { this._channelName = value; }
        }
        private string _channelName;

        /// <summary>
        /// 
        /// </summary>
        public Channel Channel
        {
            get { return this._channel; }
            set { this._channel = value; }
        }

        private Channel _channel;
    }
}
