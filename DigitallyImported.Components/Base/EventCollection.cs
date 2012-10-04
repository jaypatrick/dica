using System;
using System.Collections.Generic;
using System.Text;

namespace DigitallyImported.Components
{
    [Serializable]
    public class EventCollection<T> : List<T> where T: IEvent
    {

    }
}
