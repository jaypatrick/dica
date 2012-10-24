#region using declarations

using System;
using DigitallyImported.Components;

#endregion

namespace DigitallyImported.Controls.Windows
{
    /// <summary>
    /// </summary>
    /// <typeparam name="T"> </typeparam>
    public class EventView<T> : ContentView<T>, IEventView<T>
        where T : IEvent, new()
    {
        private readonly EventLoader<T> _loader;

        /// <summary>
        /// </summary>
        public EventView()
            : this(new EventCollection<T>())
        {
        }

        /// <summary>
        /// </summary>
        /// <param name="events"> </param>
        public EventView(EventCollection<T> events) // NEED A SPECIFIC VIEW TYPE SERVED UP (WEB, WINFORMS, ETC)
            : base(events)
        {
            Events = events;
            _loader = new EventLoader<T>();
        }

        #region IEventView<T> Members

        /// <summary>
        /// </summary>
        /// <returns> </returns>
        public EventCollection<T> GetView(bool bypassCache)
        {
            return _loader.LoadEvents(bypassCache);
        }

        /// <summary>
        /// </summary>
        public EventCollection<T> Events { get; set; }

        /// <summary>
        /// </summary>
        public override void Save()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }
}