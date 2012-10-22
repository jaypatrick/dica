using System;
using System.Collections.Specialized;
using System.Configuration.Provider;
using DigitallyImported.Configuration.Properties;

namespace DigitallyImported.Components
{
    public class DIChannelProvider<TChannel, TTrack> : ChannelLoaderProvider<TChannel>
        where TChannel : class, IChannel, new()
        where TTrack : class, ITrack, new()
    {
        private string _channelsLocation;

        public override string ChannelsLocation
        {
            get { return _channelsLocation; }
        }

        public override void Initialize(string name, NameValueCollection config)
        {
            // Verify that config isn't null
            if (config == null)
                throw new ArgumentNullException("config");

            // Assign the provider a default name if it doesn't have one
            if (String.IsNullOrEmpty(name))
                name = "ChannelLoaderProvider";

            // Add a default "description" attribute to config if the
            // attribute doesn't exist or is empty
            if (string.IsNullOrEmpty(config["description"]))
            {
                config.Remove("description");
                config.Add("description",
                           "Channel Loader Provider");
            }

            // Call the base class's Initialize method
            base.Initialize(name, config);

            _channelsLocation = config["channelsLocation"];

            if (string.IsNullOrEmpty(_channelsLocation))
                _channelsLocation = Settings.Default.DIPlaylistXml;

            config.Remove("channelsLocation");

            // Throw an exception if unrecognized attributes remain
            if (config.Count > 0)
            {
                string attr = config.GetKey(0);
                if (!String.IsNullOrEmpty(attr))
                    throw new ProviderException
                        ("Unrecognized attribute: " + attr);
            }
        }

        public override ChannelCollection<TChannel> LoadChannels(bool bypassCache)
        {
            return new ChannelLoader<TChannel, TTrack>(_channelsLocation).LoadChannels(bypassCache);
        }
    }
}