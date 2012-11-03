#region using declarations

using System.Configuration.Provider;

#endregion

namespace DigitallyImported.Components
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TChannel"></typeparam>
    public abstract class ChannelLoaderProvider<TChannel> : ProviderBase
        where TChannel : IChannel
    {
        /// <summary>
        /// 
        /// </summary>
        public abstract string ChannelsLocation { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bypassCache"></param>
        /// <returns></returns>
        public abstract ChannelCollection<TChannel> LoadChannels(bool bypassCache);
    }
}