#region using declarations

using System;
using DigitallyImported.Components;
using DigitallyImported.Controls.Windows;

#endregion

namespace DigitallyImported.Controls
{
    /// <summary>
    /// </summary>
    /// <typeparam name="T"> </typeparam>
    public interface IChannelView<T> : IContentView<T>
        where T : class, IChannel, new()
    {
        /// <summary>
        /// </summary>
        ChannelCollection<T> Channels { get; }

        /// <summary>
        /// </summary>
        T SelectedChannel { get; set; }

        /// <summary>
        /// </summary>
        SortOrder SortOrder { get; set; }

        /// <summary>
        /// </summary>
        SortBy SortBy { get; set; }

        /// <summary>
        /// </summary>
        event EventHandler<ChannelViewChangedEventArgs<ChannelCollection<IChannel>>> ChannelViewChanged;

        /// <summary>
        /// </summary>
        /// <param name="bypassCache"> </param>
        /// <returns> </returns>
        ChannelCollection<T> GetView(bool bypassCache);
    }
}