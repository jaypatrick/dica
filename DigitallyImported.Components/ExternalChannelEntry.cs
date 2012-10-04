using System.Xml.Serialization;

namespace DigitallyImported.Components
{
    [XmlRoot("ExternalChannel")]
    public class ExternalChannelEntry<K, V>
        //where K: string
        //where V: Uri
    {
        private K _channelName = default(K);
        private V _channelUri = default(V);

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
