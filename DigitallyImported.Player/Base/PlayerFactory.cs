#region using declarations

using System;
using System.Diagnostics;
using DigitallyImported.Components;

#endregion

namespace DigitallyImported.Player
{
    /// <summary>
    /// </summary>
    /// <typeparam name="T"> </typeparam>
    /// <typeparam name="TPlayer"> </typeparam>
    public class PlayerFactory<T, TPlayer> : IPlayerFactory
        // http://weblogs.asp.net/whaggard/archive/2004/09/05/225955.aspx
        where T : IPlayer // http://www.codeproject.com/useritems/GenericsFactory.asp
        where TPlayer : T, new()
    {
        #region Singleton Pattern

        //private static volatile PlayerFactory<T, TPlayer> _instance;
        //private static object _syncRoot = new object();

        private static readonly PlayerFactory<T, TPlayer> _instance = new PlayerFactory<T, TPlayer>();
        private readonly PlayerCollection<IChannel, TPlayer> _playerChannels;
        private TPlayer _player;

        /// <summary>
        /// </summary>
        public static PlayerFactory<T, TPlayer> Instance
        {
            get
            {
                _instance.Initialize();
                return _instance;
            }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// </summary>
        protected PlayerFactory()
        {
            _playerChannels = new PlayerCollection<IChannel, TPlayer>();
        }

        #endregion

        #region Methods

        /// <summary>
        /// </summary>
        protected virtual void Initialize()
        {
            _player = new TPlayer();

            var instance = _player as IPlayerFactory;

            if (instance == null) return;
            var channel = instance.GetPlayerKey();

            if (!_playerChannels.ContainsKey(channel))
            {
                _playerChannels.Add(channel, _player);
                Trace.WriteLine(string.Format("Channel '{0}' added to {1} channel cache: {2} channels cached."
                                              , channel.ChannelName
                                              , _player.PlayerType.ToString()
                                              , _playerChannels.Count), TraceCategory.PlayerLoading.ToString());

                // Channel foo added to player bar. Bar has x channels cached.
            }
            else
            {
                Trace.WriteLine(string.Format("Channel '{0}' retrieved from {1} cache"
                                              , channel.ChannelName
                                              , _player.PlayerType.ToString()),
                                TraceCategory.PlayerLoading.ToString());
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="channel"> </param>
        /// <returns> </returns>
        public virtual TPlayer CreatePlayer(IChannel channel)
        {
            if (channel == null)
                throw new ArgumentNullException("channel", "Invalid channel supplied, must be non-null.");

            var player = _playerChannels[channel];
            if (player == null)
            {
                return default(TPlayer);
            }
            Trace.WriteLine(string.Format("Attempting {0} instantiation for streaming of channel '{1}'"
                                          , player.PlayerType.ToString()
                                          , channel.ChannelName), TraceCategory.PlayerLoading.ToString());

            return Activator.CreateInstance<TPlayer>();
        }

        #endregion

        #region IPlayerFactory Members

        public virtual IChannel GetPlayerKey()
        {
            return _player.Channel;
        }

        #endregion
    }
}