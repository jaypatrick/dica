using System;

namespace DigitallyImported.Components
{
    public interface IContent : IEquatable<IContent>
    {
        string Name { get; set; }
        PlaylistTypes PlaylistType { get; set; }
        SubscriptionLevel SubscriptionLevel { get; set; }   // this should be at the site level, not channel or content
        bool IsSelected { get; set; }
        // bool IsSubscribed { get; set; }
        // DateTime StartTime { get; set; }
        // Uri ContentUrl { get; set; } REFACTOR THIS INT SOLUTION
    }
}
