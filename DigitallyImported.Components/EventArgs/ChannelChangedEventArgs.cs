using System;

namespace DigitallyImported.Components
{
    /// <summary>
    /// 
    /// </summary>
    /// 
    [Serializable]
    public class ChannelChangedEventArgs<T> : ContentChangedEventArgs<T>
        where T : IChannel
    {
        private T _refreshedChannel;

        public ChannelChangedEventArgs()
            : this(default(T))
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="refreshedChannel"></param>
        public ChannelChangedEventArgs(T refreshedChannel)
            : base(refreshedChannel)
        {
            _refreshedChannel = refreshedChannel;
        }

        public override T RefreshedContent
        {
            get { return _refreshedChannel; }
            set { _refreshedChannel = value; }
        }
    }
}