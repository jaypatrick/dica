#region using declarations

using System.Configuration.Provider;

#endregion

namespace DigitallyImported.Components
{
    /// <summary>
    /// </summary>
    /// <typeparam name="T"> </typeparam>
    /// <typeparam name="U"> </typeparam>
    public abstract class ContentLoaderProvider<T, U> : ProviderBase
        where T : IContent
        where U : IContent
    {
    }
}