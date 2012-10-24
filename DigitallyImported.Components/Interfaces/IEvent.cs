#region using declarations

using System;

#endregion

namespace DigitallyImported.Components
{
    public interface IEvent : IContent
    {
        DateTime EventDate { get; set; }
        DateTime StartTime { get; set; }
        DateTime EndTime { get; set; }
        Uri EventUrl { get; set; }
        // IChannel Channel { get; set; }
        string Channel { get; set; }
        DayOfWeek Day { get; set; }
        string Title { get; set; }
        string Subtitle { get; set; }
    }
}