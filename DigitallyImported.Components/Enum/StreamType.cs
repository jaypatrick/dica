#region using declarations

using System;

#endregion

namespace DigitallyImported.Components
{
    /// <summary>
    /// </summary>
    [Flags]
    public enum StreamType
    {
        None = 0,
        AacPlus = 1,
        Mp3 = 2,
        Wma = 4,
        Aac = 8
    }
}