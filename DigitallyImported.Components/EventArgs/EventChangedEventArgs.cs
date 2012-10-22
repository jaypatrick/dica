using System;

namespace DigitallyImported.Components
{
    [Serializable]
    public class EventChangedEventArgs<T> : ContentChangedEventArgs<T>
        where T : IEvent
    {
        private T _refreshedEvent;

        /// <summary>
        /// 
        /// </summary>
        public EventChangedEventArgs()
            : this(default(T))
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="refreshedEvent"></param>
        public EventChangedEventArgs(T refreshedEvent)
            : base(refreshedEvent)
        {
            _refreshedEvent = refreshedEvent;
        }

        /// <summary>
        /// 
        /// </summary>
        public override T RefreshedContent
        {
            get { return _refreshedEvent; }
            set { _refreshedEvent = value; }
        }
    }
}