#region using declarations

using System.Xml;

#endregion

namespace DigitallyImported.Components
{
    public interface IContentTransform
    {
        T TransformContent<T>(T reader) where T : XmlReader;
    }
}