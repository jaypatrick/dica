using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace DigitallyImported.Components
{
    [Serializable]
    public abstract class ContentCollection<T> : List<T>, IContentCollection<T>, IXmlSerializable
        where T : IContent
    {
        protected ContentCollection()
        {
        }

        protected ContentCollection(int capacity)
            : base(capacity)
        {
        }

        #region IContentCollection<T> Members

        public virtual T this[string name]
        {
            get
            {
                return
                    Find(
                        t => (t.Name.Replace(" ", "").Trim().ToLower() ==
                              name.Replace(" ", "").Trim().ToLower()));
            }
        }

        public virtual SortOrder SortOrder { get; set; }

        public virtual SortBy SortBy { get; set; }

        public virtual StationType PlaylistTypes { get; set; }

        #endregion

        #region IXmlSerializable Members

        public virtual XmlSchema GetSchema()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public virtual void ReadXml(XmlReader reader)
        {
            var serializer = new XmlSerializer(typeof (T));
            T channel = default(T);

            try
            {
                reader.Read();
                reader.ReadStartElement("Channels");
                while (reader.NodeType != XmlNodeType.EndElement)
                {
                    reader.ReadStartElement("Channel");

                    reader.ReadStartElement("Name");
                    channel.Name = (string) serializer.Deserialize(reader);
                    reader.ReadEndElement();


                    reader.ReadStartElement("PlaylistType");
                    channel.PlaylistType =
                        (StationType) Enum.Parse((typeof (PlayerType)), (string) serializer.Deserialize(reader));
                    reader.ReadEndElement();

                    Add(channel);

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
            var serializer = new XmlSerializer(typeof (T));

            try
            {
                writer.WriteStartElement("Channels");

                ForEach(t =>


                    {
                        writer.WriteStartElement("Channel");

                        // name of the channel
                        writer.WriteStartElement("Name");
                        serializer.Serialize(writer, t.Name);
                        writer.WriteEndElement();

                        // check for external content marker
                        // if it exists, write out the location element
                        //IExternalContent ec = t as IExternalContent;
                        //if (ec != null)
                        //{
                        //    writer.WriteStartElement("Location");
                        //    serializer.Serialize(writer, ec.Location.AbsoluteUri);
                        //    writer.WriteEndElement();
                        //}

                        // playlist type of the channel
                        writer.WriteStartElement("PlaylistType");
                        serializer.Serialize(writer, t.PlaylistType.ToString());
                        writer.WriteEndElement();

                        //writer.WriteEndElement();
                    });

                writer.WriteEndElement();
            }
            finally
            {
                writer.Close();
            }
        }

        #endregion

        public void Clone<U>(U targetClone) where U : ContentCollection<T>
        {
            T[] t = ToArray();
            targetClone.AddRange(t);
        }

        public static ContentCollection<T> operator +(ContentCollection<T> collection1, ContentCollection<T> collection2
            )
        {
            //ContentCollection<T> col = new Conten

            collection1.AddRange(collection2);
            return collection1;
        }
    }
}