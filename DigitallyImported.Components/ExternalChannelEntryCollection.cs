using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

namespace DigitallyImported.Components
{
    public class ExternalChannelEntryCollection<T> : Dictionary<string, Uri>, IXmlSerializable
        where T: ExternalChannelEntry<string, Uri>, new()
    {
        public ExternalChannelEntryCollection() { }

        [Obsolete("Obsolete. Use WriteXml method instead", true)]
        public void Serialize(XmlWriter writer, IDictionary<string, Uri> channels)
        {
            List<T> entries = new List<T>(channels.Count);

            //channels.ForEach(delegate(IChannel t)
            //{
            //    entries.Add(t);
            //});

            foreach (string key in channels.Keys)
            {
                entries.Add(new ExternalChannelEntry<string, Uri>(key, channels[key]) as T);
            }

            XmlSerializer serializer = new XmlSerializer(typeof(List<T>));
            serializer.Serialize(writer, entries);
            //WriteToFile(writer);
        }

        [Obsolete("Obsolete. Use ReadXml method instead", true)]
        public void Deserialize(XmlReader reader, IDictionary<string, Uri> channels)
        {
            channels.Clear();
            XmlSerializer serializer = new XmlSerializer(typeof(List<T>));
            List<T> list = (List<T>)serializer.Deserialize(reader);

            //list.ForEach(delegate(IChannel t)
            //{
            //    channels.Add(t);
            //});

            foreach (T entry in list)
            {
                channels[entry.ChannelName] = entry.ChannelUri;
            }
        }

        #region IXmlSerializable Members

        public System.Xml.Schema.XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {
            XmlSerializer keySer = new XmlSerializer(typeof(string));

            XmlSerializer valueSer = new XmlSerializer(typeof(string));

            try
            {
                reader.Read();
                reader.ReadStartElement("ExternalChannels");
                while (reader.NodeType != System.Xml.XmlNodeType.EndElement)
                {
                    reader.ReadStartElement("Channel");

                    reader.ReadStartElement("Name");
                    string key = (string)keySer.Deserialize(reader);
                    reader.ReadEndElement();

                    reader.ReadStartElement("Location");
                    Uri value = new Uri((string)valueSer.Deserialize(reader));
                    reader.ReadEndElement();

                    this.Add(key, value);

                    reader.ReadEndElement();
                    reader.MoveToContent();
                }
                reader.ReadEndElement();
            }
            catch
            {
                // eat it for now
            }
            finally
            {
                reader.Close();
            }
        }

        public void WriteXml(XmlWriter writer)
        {
            XmlSerializer keySer = new XmlSerializer(typeof(string));
            
            XmlSerializer valueSer = new XmlSerializer(typeof(string));

            try
            {
                writer.WriteStartElement("ExternalChannels");

                foreach (string key in this.Keys)
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
            catch
            {
                throw;
            }
            finally
            {
                writer.Close();
            }
        }

        #endregion
    }
}
