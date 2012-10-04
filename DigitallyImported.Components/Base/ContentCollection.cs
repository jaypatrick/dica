using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using System.Threading.Tasks;

namespace DigitallyImported.Components
{
    [Serializable()]
    public abstract class ContentCollection<T> : List<T>, IContentCollection<T>, IXmlSerializable
        where T: IContent
    {
        protected ContentCollection() { }

        protected ContentCollection(int capacity)
            : base(capacity)
        {
        }

        public virtual T this[string name]
        {
            get
            {
                return this.Find(t => 
                            { 
                                return (t.Name.Replace(" ", "").Trim().ToLower() == name.Replace(" ", "").Trim().ToLower()); 
                            });
            }
        }

        public virtual SortOrder SortOrder { get; set; }

        public virtual SortBy SortBy { get; set; }

        public virtual PlaylistTypes PlaylistTypes { get; set; }

        #region ICloneable Members

        public void Clone<U>(U targetClone) where U: ContentCollection<T>
        {
            try
            {
                var t = this.ToArray();
                targetClone.AddRange(t);
                t = null;                
            }
            catch
            {
                throw;
            }
        }

        #endregion

        public static ContentCollection<T> operator +(ContentCollection<T> collection1, ContentCollection<T> collection2)
        {
            //ContentCollection<T> col = new Conten

            collection1.AddRange(collection2);
            return collection1;
        }

        #region IXmlSerializable Members

        public virtual XmlSchema GetSchema()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public virtual void ReadXml(XmlReader reader)
        {
            var serializer = new XmlSerializer(typeof(T));
            var channel = default(T);

            try
            {
                reader.Read();
                reader.ReadStartElement("Channels");
                while (reader.NodeType != System.Xml.XmlNodeType.EndElement)
                {
                    reader.ReadStartElement("Channel");

                    reader.ReadStartElement("Name");
                    channel.Name = (string)serializer.Deserialize(reader);
                    reader.ReadEndElement();



                    reader.ReadStartElement("PlaylistType");
                    channel.PlaylistType = (PlaylistTypes)Enum.Parse((typeof(PlayerTypes)), (string)serializer.Deserialize(reader));
                    reader.ReadEndElement();

                    this.Add(channel);

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
            var serializer = new XmlSerializer(typeof(T));

            try
            {
                writer.WriteStartElement("Channels");

                this.ForEach(t =>


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
