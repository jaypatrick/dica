namespace DigitallyImported.Components
{
    using System;

    // DI

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class EventLoader<T> : EventListLoader<T> 
        where T: IEvent, new()
    {
        private EventData _eventData        = null; // NEEDS TO BE DATASET FOR INHERITANCE
        private T _event                    = default(T);
        private T[] _eventArray             = null;
        private EventCollection<T> _events  = null;

        public EventLoader()
            : base()
        { }

        public EventLoader(string eventsLocation)
            : base(eventsLocation)
        {

        }

        public virtual EventCollection<T> LoadEvents(bool bypassCache)
        {
            EventCollection<T> events = new EventCollection<T>();
            if (_events != null)
            {
                _events.ForEach(t =>
                {
                    events.Add(t);
                });
            }

            if ((bypassCache) || (events.Count == 0))
            {
                events = new EventCollection<T>();
            }


            _eventData = LoadEventList(false) as EventData; // CAST HERE from base type class

            EventData.EVENTDataTable eventTable = _eventData.EVENT;

            _eventArray = new T[_eventData.Tables["EVENT"].Rows.Count];
            int i = 0;

            foreach (EventData.EVENTRow eventRow in _eventData.Tables["EVENT"].Rows)
            {
                // _event = Activator.CreateInstance<T>();

                if (events.Contains(events[eventRow.TITLE]))
                {
                    _event = events[eventRow.TITLE];
                }
                else
                {
                    _event = new T();
                }

                if (!eventRow.IsDATENull())
                {
                    DateTime date;
                    _event.EventDate = DateTime.TryParse(eventRow.DATE, out date) ? date : DateTime.Now;
                    _event.Day = _event.EventDate.DayOfWeek;
                }

                if (!eventRow.IsTITLENull())
                    _event.Title = eventRow.TITLE;

                if (!eventRow.Is_TITLE_SECONDARYNull())
                    _event.Subtitle = eventRow._TITLE_SECONDARY;

                // if (!eventRow.Is_GMT_TIMENull)
                // _event.GmtTime = WORK ON THIS
                // _event.GmtTime = 
                if (!eventRow.Is_START_TIMENull())
                {
                    DateTime startTime;
                    _event.StartTime = DateTime.TryParse(eventRow._START_TIME, out startTime) ? startTime : DateTime.Now;
                }

                if (!eventRow.Is_END_TIMENull())
                {
                    DateTime endTime;
                    _event.EndTime = DateTime.TryParse(eventRow._END_TIME, out endTime) ? endTime : DateTime.Now;

                }
                    // _event.EndTime = DateTime.Parse(eventRow._END_TIME);

                if (!eventRow.IsWHERENull())
                    _event.Channel = eventRow.WHERE; // won't be an exact match, work on routine to match them.
                // _event.Channel = new ChannelCollection<IChannel>()[eventRow.WHERE] as IChannel;

                if (!eventRow.IsCALENDAR_URLNull())
                {
                    if (Uri.IsWellFormedUriString(eventRow.CALENDAR_URL, UriKind.Absolute))
                    {
                        _event.EventUrl = new Uri(eventRow.CALENDAR_URL);
                    }
                }

                _eventArray[i] = _event;
                i++;

                //_events.Add(_event);
            }

            events.Clear();
            events.AddRange(_eventArray);

            if (_events == null) 
                _events = new EventCollection<T>();

            _events.Clear();
            events.Clone<EventCollection<T>>(_events);
            
            return events;
        }
    }
}
