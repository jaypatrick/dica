#region using declarations

using System;

#endregion

namespace DigitallyImported.Components
{
    [Flags]
    public enum TraceCategory
    {
        Caching = 0,
        ContentChangedEvents = 1,
        StreamParsing = 2,
        PlayerLoading = 4,
        Exception = 8
    }
}