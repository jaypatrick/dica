#region using declarations

using System;
using System.Drawing;

#endregion

namespace DigitallyImported.Components
{
    /// <summary>
    /// </summary>
    public interface IPlaylist : IContent
    {
        /// <summary>
        /// </summary>
        Uri SiteUri { get; set; }

        /// <summary>
        /// </summary>
        Bitmap PlaylistIcon { get; set; }

        /// <summary>
        /// </summary>
        ChannelCollection<IChannel> SiteChannels { get; set; }

        /// <summary>
        /// </summary>
        EventCollection<IEvent> SiteEvents { get; set; }
    }
}