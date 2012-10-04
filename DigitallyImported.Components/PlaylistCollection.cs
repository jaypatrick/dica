using System.Collections.Generic;

namespace DigitallyImported.Components
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PlaylistCollection<T> : ContentCollection<T> where T: IPlaylist
    {
        /// <summary>
        /// 
        /// </summary>
        public PlaylistCollection() : base() { }
    }


    public class PlaylistDictionary<K, V> : Dictionary<K, V>
        where K: ChannelCollection<IChannel>
        where V: EventCollection<IEvent>
    {
        // only add channels/events that have specific PlaylistType.
        // define base ContentDictionary type.

        K _channel = default(K);

        public PlaylistDictionary()
        {

        }
    }
}
