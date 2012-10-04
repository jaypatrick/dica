using System;
using System.Drawing;

namespace DigitallyImported.Components
{
    public interface IPlaylist : IContent
    {
        Uri SiteUri { get; set; }
        Bitmap PlaylistIcon { get; set; }

        ChannelCollection<IChannel> SiteChannels { get; set; }
        EventCollection<IEvent> SiteEvents { get; set; }
    }
}
