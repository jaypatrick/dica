using System;

namespace DigitallyImported.Components
{
    [Serializable]
    public class EventCollection<T> : ContentCollection<T> where T: IEvent
    {

    }
}
