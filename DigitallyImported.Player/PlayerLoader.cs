using System;
using System.Globalization;
using System.Runtime.InteropServices;
using DigitallyImported.Components;
using DigitallyImported.Configuration.Properties;

namespace DigitallyImported.Player
{
    /// <summary>
    /// TODO: Make this an instance class
    /// </summary>
    public class PlayerLoader
    {
        private static EventHandler<PlayerNotInstalledExceptionEventArgs<IPlayer>> _playerNotInstalledException;

        private readonly PlayerController _player = new PlayerController();
        // use factory to get correct player type, then call play.

        /// <summary>
        /// 
        /// </summary>
        /// <param name="channel"></param>
        public PlayerLoader(IChannel channel)
        {
            if (channel == null) throw new ArgumentNullException("channel", "Must supply a valid IChannel. ");
            Channel = channel;

            Utilities.Channel.ChannelChanged += ChannelSection_TrackChanged;

            PlayerType = Components.Utilities.ParseEnum<PlayerType>(Settings.Default.PlayerType);

            if (Settings.Default.RememberPreviousChannel)
            {
                Play(channel, StreamType.None);
            }
        }

        internal static IChannel Channel { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public PlayerType PlayerType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public static event EventHandler<PlayerNotInstalledExceptionEventArgs<IPlayer>> PlayerNotInstalledException
        {
            add { _playerNotInstalledException += value; }
            remove { if (_playerNotInstalledException != null) _playerNotInstalledException -= value; }
        }

        protected virtual void OnPlayerNotInstalledException(object sender,
                                                             PlayerNotInstalledExceptionEventArgs<IPlayer> e)
        {
            if (_playerNotInstalledException != null)
            {
                _playerNotInstalledException(sender, e);
            }
        }

        // this is such a hack, i hate it.

        /// <summary>
        /// 
        /// </summary>
        /// <param name="channel"></param>
        /// <param name="type"></param>
        public void Play(IChannel channel, StreamType type)
        {
            _player.Play(channel, PlayerType);
        }

        private void ChannelSection_TrackChanged(object sender, ChannelChangedEventArgs<IChannel> e)
        {
            Channel = e.RefreshedContent;

            try
            {
                _player.Play(e.RefreshedContent, PlayerType);

                // save settings
                Settings.Default.SelectedChannelName = e.RefreshedContent.ChannelName;
                Settings.Default.SelectedChannelUri = e.RefreshedContent.CurrentTrack.TrackUrl;
            }
            catch (COMException exc)
            {
                int hr = exc.ErrorCode;
                string message = String.Format("There was an error.\nHRESULT = {0}\n{1}",
                                               hr.ToString(CultureInfo.InvariantCulture), exc.Message);

                throw new COMException(message, exc);
            }
            catch (PlayerNotInstalledException exc)
            {
                OnPlayerNotInstalledException(this, new PlayerNotInstalledExceptionEventArgs<IPlayer>(exc));
            }
        }
    }
}