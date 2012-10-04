using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using DigitallyImported.Components.Caching;

namespace DigitallyImported.Components
{
    public abstract class ContentSerializer<T> : CacheItem<T>, IXmlSerializable
        where T: IContent
    {

        #region IXmlSerializable Members

        public XmlSchema GetSchema()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void ReadXml(XmlReader reader)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void WriteXml(XmlWriter writer)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }
}
