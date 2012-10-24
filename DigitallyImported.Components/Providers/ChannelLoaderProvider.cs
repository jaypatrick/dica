#region using declarations

using System.Configuration.Provider;

#endregion

namespace DigitallyImported.Components
{
    public abstract class ChannelLoaderProvider<TChannel> : ProviderBase
        where TChannel : IChannel
    {
        public abstract string ChannelsLocation { get; }

        public abstract ChannelCollection<TChannel> LoadChannels(bool bypassCache);
    }
}