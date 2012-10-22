using System;

namespace DigitallyImported.Components
{
    public interface ITrack : IContent
    {
        IChannel ParentChannel { get; set; }
        string ArtistName { get; set; } //
        DateTime StartTime { get; set; } //
        string SongName { get; set; } //
        string TrackTitle { get; set; }
        Uri ArtistUri { get; set; } //
        Uri ForumUrl { get; set; } //
        Uri TrackUrl { get; set; } // move to IStream object, StreamUrl // this is set in the control itself
        string RecordLabel { get; set; } // 
        int CommentCount { get; set; } //
        bool IsPlaying { get; set; } // this is set in the control itself

        event EventHandler<eeEventArgs<ITrack>> ee;
    }
}