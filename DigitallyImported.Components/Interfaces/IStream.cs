using System;
using System.Drawing;

namespace DigitallyImported.Components
{
    public interface IStream : IContent
    {
        event EventHandler<StreamChangedEventArgs<IStream>> StreamChanged;
        void OpenStream();  // i.e. click, see Channel.StreamType_MouseClick

        StreamType StreamType { get; set; }
        StreamBitrate StreamBitrate { get; set; }

        IChannel Channel { get; set; }
        Uri StreamUri { get; set; }
        Image PlayerImage { get; set; }
        Image BitrateImage { get; set; }
        bool IsEnabled { get; set; }

        // !!! NOTE: if subscriptionType is premium, stream should do it's own URL parsing,
        // like what is in PremiumChannel click event
        
        // optional, might need to move to concret implementation of stream
        // Uri PlaylistUri { get; set; } this would be the result of the parsing for Premium Streams
        // also associate specific IPlayer with concrete implementation for easy reusing and parsing.
    }
}
