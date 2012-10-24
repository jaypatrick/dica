#region using declarations

using DigitallyImported.Components;

#endregion

namespace DigitallyImported.Controls.Windows
{
    /// <summary>
    /// </summary>
    /// <typeparam name="T"> </typeparam>
    public class ChannelViewChangedEventArgs<T> : ViewChangedEventArgs<T>
        where T : ChannelCollection<IChannel>
    {
        private readonly T _changedChannelView;

        /// <summary>
        /// </summary>
        public ChannelViewChangedEventArgs()
            : this(default(T))
        {
        }

        /// <summary>
        /// </summary>
        /// <param name="changedChannelView"> </param>
        public ChannelViewChangedEventArgs(T changedChannelView)
            : base(changedChannelView)
        {
            _changedChannelView = changedChannelView;
        }

        /// <summary>
        /// </summary>
        public override T ChangedContent
        {
            get { return _changedChannelView; }
        }
    }
}