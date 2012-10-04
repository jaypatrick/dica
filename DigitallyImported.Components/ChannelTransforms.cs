using System.Xml;
using System.Xml.XPath;

namespace DigitallyImported.Components
{
    public class ChannelTransforms : IContentTransform
    {
        public virtual T TransformContent<T>(T reader) where T: XmlReader
        {
            XmlReaderSettings readerSettings = new XmlReaderSettings();

            readerSettings.IgnoreComments = true;
            readerSettings.IgnoreWhitespace = true;
            readerSettings.ProhibitDtd = false;
            readerSettings.ConformanceLevel = ConformanceLevel.Auto;

            XmlDocument doc = new XmlDocument();
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
    }
}
