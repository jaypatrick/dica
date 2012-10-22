using System;
using System.Collections.Generic;
using DigitallyImported.Data;

namespace DigitallyImported.Components
{
    // DI

    /// <summary>
    /// 
    /// </summary>
    public class ChannelLoader<TChannel, TTrack> : ChannelListLoader<TChannel>
        where TChannel : class, IChannel, new()
        where TTrack : class, ITrack, new()
    {
        private readonly TrackLoader<TTrack> _trackLoader;
        private TChannel _channel;
        private List<TChannel> _channelArray;
        private ChannelData _channelData; // NEEDS TO BE A DATASET
        private ChannelCollection<TChannel> _channels; // new ChannelCollection<T>();

        /// <summary>
        /// Default constructor.
        /// </summary>
        public ChannelLoader()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="channelsLocation"></param>
        public ChannelLoader(string channelsLocation)
            : base(channelsLocation)
        {
            _trackLoader = new TrackLoader<TTrack>();
        }

        /// <summary>
        /// Method to get an array of DI Channels.
        /// </summary>
        /// <param name="bypassCache">Specifies whether the collection should be retrieved from the cache.</param>
        /// <returns>An array of DI Channel controls.</returns>
        public virtual ChannelCollection<TChannel> LoadChannels(bool bypassCache)
        {
            var channels = new ChannelCollection<TChannel>();

            if (_channels != null)
                _channels.ForEach(t => channels.Add(t));

            if ((bypassCache) || (channels.Count == 0))
            {
                channels = new ChannelCollection<TChannel>();
            }

            _channelData = LoadPlaylist(false) as ChannelData;

            if (_channelData != null) _channelArray = new List<TChannel>(_channelData.Tables["CHANNEL"].Rows.Count);

            int i = 0;

            // Parallel.ForEach(_channelData.Tables["CHANNEL"].Rows.Cast<ChannelData.CHANNELRow>(), rowItem =>

            if (_channelData != null)
                foreach (ChannelData.CHANNELRow rowItem in _channelData.Tables["CHANNEL"].Rows)
                {
                    ChannelData.CHANNELRow item = rowItem;
                    _channel =
                        channels.Find(
                            t =>
                            t.Name.Equals(item.CHANNELTITLE.Replace(" ", ""), StringComparison.CurrentCultureIgnoreCase)) ??
                        new TChannel();

                    string siteName = Resources.Properties.Resources.UrlContainer;
                    _channel.ChannelName = Utilities.SplitName(rowItem.CHANNELTITLE);


                    // Parallel.ForEach(rowItem.GetTRACKSRows().Cast<ChannelData.TRACKRow>(), tracksRow =>

                    foreach (ChannelData.TRACKSRow tracksRow in rowItem.GetTRACKSRows())
                    {
                        ChannelData.TRACKSRow tr = tracksRow;

                        _channel.Tracks = _trackLoader.LoadTracks(tr, false, ref siteName, _channel);
                    }

                    if (rowItem.CHANNELTITLE != null)
                    {
                        _channel.SiteName = siteName;
                        string channelUrl = string.Format("{0}{1}", siteName, rowItem.CHANNELTITLE.ToLower().Trim());

                        try
                        {
                            _channel.PlaylistHistoryUrl = new Uri(channelUrl);
                            _channel.ChannelInfoUrl = new Uri(string.Format("{0}", channelUrl));

                            _channelArray.Insert(i, _channel);
                            i++;
                        }
                        catch (UriFormatException)
                        {
                            _channel.PlaylistHistoryUrl = new Uri("http://www.google.com");
                            _channel.ChannelInfoUrl = new Uri("http://www.google.com");
                        }
                    }
                }

            channels.Clear();
            channels.AddRange(_channelArray);

            if (_channels == null)
                _channels = new ChannelCollection<TChannel>();

            _channels.Clear();
            channels.Clone(_channels);

            return channels;
        }
    }
}