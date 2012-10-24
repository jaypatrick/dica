#region using declarations

using System;
using System.Configuration.Provider;

#endregion

namespace DigitallyImported.Components
{
    public class ChannelLoaderProviderCollection<TProvider, TChannel> : ProviderCollection
        where TProvider : ProviderBase
        where TChannel : IChannel, new()
    {
        public new ChannelLoaderProvider<TChannel> this[string name]
        {
            get { return (ChannelLoaderProvider<TChannel>) base[name]; }
        }

        public override void Add(ProviderBase provider)
        {
            if (provider == null)
                throw new ArgumentNullException("provider");

            if (!(provider is ChannelLoaderProvider<TChannel>))
                throw new ArgumentException
                    ("Invalid provider type", "provider");

            base.Add(provider);
        }
    }
}