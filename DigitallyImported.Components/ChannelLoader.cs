namespace DigitallyImported.Components
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Threading.Tasks;
	using DigitallyImported.Data;
	// DI
	using DigitallyImported.Resources.Properties;
	using System.Data;

	/// <summary>
	/// 
	/// </summary>
	public class ChannelLoader<TChannel, TTrack> : ChannelListLoader<TChannel> 
		where TChannel  : class, IChannel, new()
		where TTrack    : class, ITrack, new()
	{
		private ChannelData _channelData                = null; // NEEDS TO BE A DATASET
		private TChannel _channel                       = default(TChannel);
		private List<TChannel> _channelArray            = null;
		private ChannelCollection<TChannel> _channels   = null;// new ChannelCollection<T>();
		private TrackLoader<TTrack> _trackLoader        = null;

		/// <summary>
		/// Default constructor.
		/// </summary>
		public ChannelLoader()
			: base()
		{

		}

		/// <summary>
		/// Overloaded constructor. Initializes a new ChannelLoader instance with the specified subscription level.
		/// </summary>
		/// <param name="subscriptionLevel">The subscription level of the user.</param>
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
				_channels.ForEach(t =>
			{
				channels.Add(t);
			});
			
			if ((bypassCache) || (channels.Count == 0))
			{
				channels = new ChannelCollection<TChannel>();
			}

			_channelData = LoadPlaylist(false) as ChannelData;

			var channelTable = _channelData.CHANNEL;


			_channelArray = new List<TChannel>(_channelData.Tables["CHANNEL"].Rows.Count);

			var i = 0;

			// Parallel.ForEach(_channelData.Tables["CHANNEL"].Rows.Cast<ChannelData.CHANNELRow>(), rowItem =>

			foreach (ChannelData.CHANNELRow rowItem in _channelData.Tables["CHANNEL"].Rows)
			{

				_channel = channels.Find((Predicate<TChannel>)(t =>
				{
					return t.Name.Equals(rowItem.CHANNELTITLE.Replace(" ", ""), StringComparison.CurrentCultureIgnoreCase);
				}));
				if (_channel == null)
				{
					_channel = new TChannel();
				}

				var siteName = Resources.UrlContainer;
				_channel.ChannelName = Utilities.SplitName(rowItem.CHANNELTITLE);


				// Parallel.ForEach(rowItem.GetTRACKSRows().Cast<ChannelData.TRACKRow>(), tracksRow =>

				foreach (var tracksRow in rowItem.GetTRACKSRows())
				{
					var tracks = new TrackCollection<ITrack>();

					ChannelData.TRACKSRow tr = tracksRow;

					_channel.Tracks = _trackLoader.LoadTracks(tr, false, ref siteName, _channel);
				}

                if (rowItem.CHANNELTITLE != null)
                {
                    _channel.SiteName = siteName;
                    var channelUrl = string.Format("{0}{1}", siteName, rowItem.CHANNELTITLE.ToLower());

                    try
                    {
                        _channel.PlaylistHistoryUrl = new Uri(channelUrl);
                        _channel.ChannelInfoUrl = new Uri(string.Format("{0}{1}", channelUrl, "/info/"));

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
			channels.Clone<ChannelCollection<TChannel>>(_channels);

			return channels;
		}

		private static IChannel ChannelConverter(TChannel channel)
		{
			return channel as IChannel;
		}

		private static ITrack TrackConverter(TTrack track)
		{
			return track as ITrack;
		}
	}
}
