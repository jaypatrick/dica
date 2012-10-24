#region using declarations

using System;

#endregion

namespace DigitallyImported.Components
{
    [Flags]
    public enum StationType
    {
        // None = 0,
        Sky = 1,
        DI = 2,
        Custom = 4,
        External = 8,
        All = Sky | DI | External
    }
}