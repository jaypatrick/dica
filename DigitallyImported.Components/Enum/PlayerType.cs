using System;

namespace DigitallyImported.Components
{
    /// <summary>
    /// 
    /// </summary>
    /// 
    [Flags()]
    public enum PlayerTypes
    {
        Default     = 0,
        WMP         = 1,
        iTunes      = 2,
        Winamp      = 4,
        Zune        = 8
    }
}
