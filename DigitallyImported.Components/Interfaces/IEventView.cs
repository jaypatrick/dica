using System;
using System.Collections.Generic;
using System.Text;

namespace DigitallyImported.Components
{
    public interface IEventView<T> : IContentView<T>, IComparer<T> where T: IEvent
    {
        EventCollection<T> GetView(bool BypassCache);
        EventCollection<T> Events { get; set; }


    }
}
