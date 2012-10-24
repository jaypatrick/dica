#region using declarations

using System.Xml.Serialization;

#endregion

namespace DigitallyImported.Components
{
    [XmlRoot("ExternalChannel")]
    public class ExternalChannelEntry<K, V>
        //where K: string
        //where V: Uri
    {
        private K _channelName;
        private V _channelUri;

        public ExternalChannelEntry()
        {
        }

        public ExternalChannelEntry(K channelName, V channelUri)
        {
            _channelName = channelName;
            _channelUri = channelUri;
        }

        [XmlElement("ChannelName")]
        public K ChannelName
        {
            get { return _channelName; }
        }

        [XmlElement("ChannelUri")]
        public V ChannelUri
        {
            get { return _channelUri; }
        }
    }
}