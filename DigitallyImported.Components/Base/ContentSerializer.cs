#region using declarations

using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using DigitallyImported.Components.Caching;

#endregion

namespace DigitallyImported.Components
{
    /// <summary>
    /// </summary>
    /// <typeparam name="T"> </typeparam>
    public abstract class ContentSerializer<T> : CacheItem<T>, IXmlSerializable
        where T : IContent
    {
        #region IXmlSerializable Members

        /// <summary>
        /// </summary>
        /// <returns> </returns>
        public XmlSchema GetSchema()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// </summary>
        /// <param name="reader"> </param>
        public void ReadXml(XmlReader reader)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// </summary>
        /// <param name="writer"> </param>
        public void WriteXml(XmlWriter writer)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }
}