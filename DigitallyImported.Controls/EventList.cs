#region using declarations

using DigitallyImported.Components;

#endregion

namespace DigitallyImported.Controls
{
    /// <summary>
    /// </summary>
    /// <typeparam name="T"> </typeparam>
    public class EventList<T> : EventCollection<T> where T : IEvent
    {
    }
}