using System;
using DigitallyImported.Components;

namespace DigitallyImported.Utilities
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IChannelView<T> : IContentView<T>
        where T : class, IChannel, new()
    {
        ChannelCollection<T> Channels { get; }
        T SelectedChannel { get; set; }

        SortOrder SortOrder { get; set; }
        SortBy SortBy { get; set; }
        event EventHandler<ChannelViewChangedEventArgs<ChannelCollection<IChannel>>> ChannelViewChanged;

        ChannelCollection<T> GetView(bool bypassCache);
    }
}