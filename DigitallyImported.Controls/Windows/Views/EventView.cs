using System;
using DigitallyImported.Components;

namespace DigitallyImported.Utilities
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class EventView<T> : ContentView<T>, IEventView<T> 
        where T: IEvent, new()
    {
        private EventLoader<T> _loader = null;

        /// <summary>
        /// 
        /// </summary>
        public EventView() 
            : this(new EventCollection<T>()) 
        { }


        public EventView(EventCollection<T> events) // NEED A SPECIFIC VIEW TYPE SERVED UP (WEB, WINFORMS, ETC)
            : base(events)
        {
            _loader = new EventLoader<T>();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public EventCollection<T> GetView(bool bypassCache)
        {
            return _loader.LoadEvents(bypassCache) as EventCollection<T>;
        }

        /// <summary>
        /// 
        /// </summary>
        public EventCollection<T> Events
        {
            get { return this._events; }
        }
        private EventCollection<T> _events;

        public override void Save()
        {
            throw new Exception("The method or operation is not implemented.");
        }
    }
}
