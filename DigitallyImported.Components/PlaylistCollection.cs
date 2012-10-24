#region using declarations

using System.Collections.Generic;

#endregion

namespace DigitallyImported.Components
{
    /// <summary>
    /// </summary>
    /// <typeparam name="T"> </typeparam>
    public class PlaylistCollection<T> : ContentCollection<T> where T : IPlaylist
    {
    }


    public class PlaylistDictionary<K, V> : Dictionary<K, V>
        where K : ChannelCollection<IChannel>
        where V : EventCollection<IEvent>
    {
        // only add channels/events that have specific PlaylistType.
        // define base ContentDictionary type.

        private K _channel = default(K);
    }
}