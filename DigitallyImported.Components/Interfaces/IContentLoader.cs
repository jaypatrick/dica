using System.Xml;

namespace DigitallyImported.Components
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IContentLoader<T> where T : IContent
    {
        bool IsNetworkAvailable { get; }
        XmlReader LoadContentFromXml(XmlReaderSettings settings);
    }
}