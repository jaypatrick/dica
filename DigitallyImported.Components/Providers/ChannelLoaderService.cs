//using System.Configuration;
//using System.Configuration.Provider;
//using System.Web.Configuration;

//namespace DigitallyImported.Components
//{
//    public class ChannelLoaderService<TChannel>
//        where TChannel: class, IChannel, new()
//    {
//        private static ChannelLoaderProvider<TChannel> _provider = null;
//        private static ChannelLoaderProviderCollection<ChannelLoaderProvider<TChannel>, TChannel> _providers = null;
//        private static object _lock = new object();

//        public ChannelLoaderProvider<TChannel> Provider
//        {
//            get { return _provider; }
//        }

//        public ChannelLoaderProviderCollection<ChannelLoaderProvider<TChannel>, TChannel> Providers
//        {
//            get { return _providers; }
//        }

//        public static ChannelCollection<TChannel> LoadChannels(bool bypassCache)
//        {
//            LoadProviders();

//            return _provider.LoadChannels(bypassCache);
//        }


//        private static void LoadProviders()
//        {
//            // Avoid claiming lock if providers are already loaded
//            if (_provider == null)
//            {
//                lock (_lock)
//                {
//                    // Do this again to make sure _provider is still null
//                    if (_provider == null)
//                    {
//                        // Get a reference to the <imageService> section
//                        ChannelLoaderServiceSection section = (ChannelLoaderServiceSection)
//                            ConfigurationManager.GetSection
//                            ("channelProviders");

//                        // Load registered providers and point _provider
//                        // to the default provider
//                        _providers = new ChannelLoaderProviderCollection<ChannelLoaderProvider<TChannel>, TChannel>();
//                        ProvidersHelper.InstantiateProviders(section.Providers, _providers, typeof(ChannelLoaderProvider<TChannel>));

//                        //ProvidersHelper.InstantiateProviders(section.Providers, _providers, 

//                        // check the type of the TChannel to get the correct provider
//                        // TODO!
//                        _provider = _providers[section.DefaultProvider];

//                        if (_provider == null)
//                            throw new ProviderException
//                                ("Unable to load default ChannelLoaderProvider");
//                    }
//                }
//            }
//        }
//    }
//}
