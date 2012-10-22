using System;
using System.Xml.Serialization;

namespace DigitallyImported.Components
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// 
    [Serializable]
    [XmlRoot("Channels")]
    public class ChannelCollection<T> : ContentCollection<T> where T : IChannel
    {
        /// <summary>
        /// 
        /// </summary>
        public ChannelCollection()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="capacity"></param>
        public ChannelCollection(int capacity)
            : base(capacity)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// 
        [XmlElement("Playlist")]
        public IPlaylist Playlist { get; set; }

        /// <summary>
        /// I have no idea if this works.
        /// </summary>
        /// <param name="track"></param>
        /// <returns></returns>
        public T FindTrack(ITrack track)
        {
            return Find(t => Contains((T) t.Tracks[track.Name].ParentChannel));
        }
    }
}