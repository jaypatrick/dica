
using DigitallyImported.Components;

namespace DigitallyImported.Utilities
{
    public class ChannelViewChangedEventArgs<T> : ViewChangedEventArgs<T>
        where T: ChannelCollection<IChannel>
    {
        private T _changedChannelView = default(T);

        public ChannelViewChangedEventArgs()
            : this(default(T))
        {

        }

        public ChannelViewChangedEventArgs(T changedChannelView)
            : base(changedChannelView)
        {
            _changedChannelView = changedChannelView;
        }

        public override T ChangedContent
        {
            get
            {
                return this._changedChannelView;
            }
        }
    }
}
