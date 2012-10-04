using System;
using System.Drawing;

namespace DigitallyImported.Components
{
    public interface IChannel : IContent
    {
        string SiteName { get; set; }
        Icon SiteIcon { get; set; }
        ITrack CurrentTrack { get; }
        string ChannelName { get; set;}
        Uri PlaylistHistoryUrl { get; set; }
        Uri ChannelInfoUrl { get; set; }
        bool IsAlternating { get; set; }
        StreamType StreamType { get; set; }
        StreamCollection<IStream> Streams { get; set; }
        TrackCollection<ITrack> Tracks { get; set; }  // IChannel for now, CHANGE TO ITrack!
        IPlaylist Playlist { get; set; }
        
        event EventHandler<TrackChangedEventArgs<ITrack>> TrackChanged;
    }
}
