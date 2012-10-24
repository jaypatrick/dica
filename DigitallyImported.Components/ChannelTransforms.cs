#region using declarations

using System.Xml;
using System.Xml.XPath;

#endregion

namespace DigitallyImported.Components
{
    public class ChannelTransforms : IContentTransform
    {
        #region IContentTransform Members

        public virtual T TransformContent<T>(T reader) where T : XmlReader
        {
            var readerSettings = new XmlReaderSettings
                {
                    IgnoreComments = true,
                    IgnoreWhitespace = true,
                    ConformanceLevel = ConformanceLevel.Auto,
                    ProhibitDtd = false
                };

            var doc = new XmlDocument();
            doc.Load(reader);

            XPathNavigator titleNodes = doc.CreateNavigator();

            foreach (XPathNavigator n in titleNodes.Select("//CHANNELTITLE"))
            {
                // should be offloaded to config file

                if (n.Value == "Goa")
                    n.SetValue("GoaPsy");
                if (n.Value == "80s")
                    n.SetValue("The 80s");
                if (n.Value == "70s")
                    n.SetValue("Hit 70s");
            }

            // reader.Settings.ConformanceLevel = ConformanceLevel.Auto;

            return XmlReader.Create(titleNodes.ReadSubtree(), readerSettings) as T;
        }

        #endregion
    }
}