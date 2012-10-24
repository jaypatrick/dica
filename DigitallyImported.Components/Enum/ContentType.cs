#region using declarations

using System;

#endregion

namespace DigitallyImported.Components
{
    /// <summary>
    /// </summary>
    [Flags]
    public enum ContentType
    {
        None = 0,
        Channels = 1,
        Events = 2
    }
}