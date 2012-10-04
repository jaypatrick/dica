using System;
using System.Collections.Generic;
using System.Text;

namespace DigitallyImported.Components
{
    public interface IChannelView<T> : IContentView<T> where T: IChannel
    {
        ChannelCollection<T> GetView(bool BypassCache);
        U GetView<U>(U channels, bool BypassCache) where U : ChannelCollection<T>;
        ChannelCollection<T> Channels { get; set; }
        T SelectedChannel { get; set; }

        SortOrder SortOrder { get; set; }
        SortBy SortBy { get; set; }
    }
}
