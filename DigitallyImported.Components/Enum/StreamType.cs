using System;

namespace DigitallyImported.Components
{
    /// <summary>
    /// 
    /// </summary>
    [FlagsAttribute()]
    public enum StreamType
    {
        None = 0,
        AacPlus = 1,
        Mp3 = 2,
        Wma = 4,
        Aac = 8
    }
}
