#region using declarations

using System;
using System.Configuration.Provider;

#endregion

namespace DigitallyImported.Components
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TProvider"></typeparam>
    /// <typeparam name="TChannel"></typeparam>
    public class ChannelLoaderProviderCollection<TProvider, TChannel> : ProviderCollection
        where TProvider : ProviderBase
        where TChannel : IChannel, new()
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public new ChannelLoaderProvider<TChannel> this[string name]
        {
            get
            {
                if (name == null) throw new ArgumentNullException("name");
                return (ChannelLoaderProvider<TChannel>) base[name];
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="provider"></param>
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