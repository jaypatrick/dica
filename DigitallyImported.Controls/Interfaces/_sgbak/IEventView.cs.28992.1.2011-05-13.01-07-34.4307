using System.Collections.Generic;

using DigitallyImported.Components;

namespace DigitallyImported.Utilities
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IEventView<T> : IContentView<T>, IComparer<T> where T: IEvent
    {
        EventCollection<T> GetView(bool bypassCache);
        EventCollection<T> Events { get; }


    }
}
