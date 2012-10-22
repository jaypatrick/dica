using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace DigitallyImported.Components
{
    public class ExternalChannelEntryCollection<T> : Dictionary<string, Uri>, IXmlSerializable
        where T : ExternalChannelEntry<string, Uri>, new()
    {
        #region IXmlSerializable Members

        public XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {
            var keySer = new XmlSerializer(typeof (string));

            var valueSer = new XmlSerializer(typeof (string));

            try
            {
                reader.Read();
                reader.ReadStartElement("ExternalChannels");
                while (reader.NodeType != XmlNodeType.EndElement)
                {
                    reader.ReadStartElement("Channel");

                    reader.ReadStartElement("Name");
                    var key = (string) keySer.Deserialize(reader);
                    reader.ReadEndElement();

                    reader.ReadStartElement("Location");
                    var value = new Uri((string) valueSer.Deserialize(reader));
                    reader.ReadEndElement();

                    Add(key, value);

                    reader.ReadEndElement();
                    reader.MoveToContent();
                }
                reader.ReadEndElement();
            }
            finally
            {
                reader.Close();
            }
        }

        public void WriteXml(XmlWriter writer)
        {
            var keySer = new XmlSerializer(typeof (string));

            var valueSer = new XmlSerializer(typeof (string));

            try
            {
                writer.WriteStartElement("ExternalChannels");

                foreach (var key in Keys)
                {
                    writer.WriteStartElement("Channel");

                    writer.WriteStartElement("Name");
                    keySer.Serialize(writer, key);
                    writer.WriteEndElement();

                    writer.WriteStartElement("Location");
                    string value = this[key].AbsoluteUri;
                    valueSer.Serialize(writer, value);
                    writer.WriteEndElement();

                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
            }
            finally
            {
                writer.Close();
            }
        }

        #endregion

        [Obsolete("Obsolete. Use WriteXml method instead", true)]
        public void Serialize(XmlWriter writer, IDictionary<string, Uri> channels)
        {
            var entries = new List<T>(channels.Count);
            entries.AddRange(channels.Keys.Select(key => new ExternalChannelEntry<string, Uri>(key, channels[key]) as T));

            //channels.ForEach(delegate(IChannel t)
            //{
            //    entries.Add(t);
            //});

            var serializer = new XmlSerializer(typeof (List<T>));
            serializer.Serialize(writer, entries);
            //WriteToFile(writer);
        }

        [Obsolete("Obsolete. Use ReadXml method instead", true)]
        public void Deserialize(XmlReader reader, IDictionary<string, Uri> channels)
        {
            channels.Clear();
            var serializer = new XmlSerializer(typeof (List<T>));
            var list = (List<T>) serializer.Deserialize(reader);

            //list.ForEach(delegate(IChannel t)
            //{
            //    channels.Add(t);
            //});

            foreach (T entry in list)
            {
                channels[entry.ChannelName] = entry.ChannelUri;
            }
        }
    }
}