#region using declarations

using System;

#endregion

namespace DigitallyImported.Components
{
    /// <summary>
    /// </summary>
    [Serializable]
    public class ChannelChangedEventArgs<T> : ContentChangedEventArgs<T>
        where T : IChannel
    {
        /// <summary>
        /// </summary>
        public ChannelChangedEventArgs()
            : this(default(T))
        {
        }

        /// <summary>
        /// </summary>
        /// <param name="refreshedChannel"> </param>
        public ChannelChangedEventArgs(T refreshedChannel)
            : base(refreshedChannel)
        {
            RefreshedContent = refreshedChannel;
        }

        public override T RefreshedContent { get; set; }
    }
}