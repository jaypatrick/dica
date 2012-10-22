using System.Configuration.Provider;

namespace DigitallyImported.Components
{
    public abstract class ContentLoaderProvider<T, U> : ProviderBase
        where T : IContent
        where U : IContent
    {
    }
}