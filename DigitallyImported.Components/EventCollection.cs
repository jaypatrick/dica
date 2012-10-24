#region using declarations

using System;

#endregion

namespace DigitallyImported.Components
{
    [Serializable]
    public class EventCollection<T> : ContentCollection<T> where T : IEvent
    {
    }
}