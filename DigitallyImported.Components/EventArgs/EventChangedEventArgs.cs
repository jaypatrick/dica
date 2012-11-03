#region using declarations

using System;

#endregion

namespace DigitallyImported.Components
{
    /// <summary>
    /// </summary>
    /// <typeparam name="T"> </typeparam>
    [Serializable]
    public class EventChangedEventArgs<T> : ContentChangedEventArgs<T>
        where T : IEvent
    {
        /// <summary>
        /// </summary>
        public EventChangedEventArgs()
            : this(default(T))
        {
        }

        /// <summary>
        /// </summary>
        /// <param name="refreshedEvent"> </param>
        public EventChangedEventArgs(T refreshedEvent)
            : base(refreshedEvent)
        {
            RefreshedContent = refreshedEvent;
        }

        /// <summary>
        /// </summary>
        public override T RefreshedContent { get; set; }
    }
}