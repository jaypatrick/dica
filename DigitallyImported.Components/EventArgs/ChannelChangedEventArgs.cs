using System;

namespace DigitallyImported.Components
{
    /// <summary>
    /// 
    /// </summary>
    /// 

    [Serializable]
    public class ChannelChangedEventArgs<T> : ContentChangedEventArgs<T> where T: IChannel
    {
        public ChannelChangedEventArgs()
            : this(default(T))
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="channel"></param>
        public ChannelChangedEventArgs(T refreshedChannel)
            : base(refreshedChannel)
        {
            _refreshedChannel = refreshedChannel;
        }

        public override T  RefreshedContent
        {
            get { return this._refreshedChannel; }
            set { this._refreshedChannel = value; }
        }
        private T _refreshedChannel;
    }
}
