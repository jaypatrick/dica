namespace DigitallyImported.Player
{
    using System;

    using DigitallyImported.Components;
    using DigitallyImported.Configuration.Properties;

    /// <summary>
    /// TODO: Make this an instance class
    /// </summary>
    public class PlayerLoader
    {
        private PlayerController _player = new PlayerController(); // use factory to get correct player type, then call play.

        /// <summary>
        /// 
        /// </summary>
        /// <param name="channel"></param>
        public PlayerLoader(IChannel channel) 
        {
            if (channel == null) throw new ArgumentNullException("channel", "Must supply a valid IChannel. ");
            Channel = channel;

            DigitallyImported.Utilities.Channel.ChannelChanged += new EventHandler<ChannelChangedEventArgs<IChannel>>(ChannelSection_TrackChanged);

            PlayerType = DigitallyImported.Components.Utilities.ParseEnum<PlayerTypes>(Settings.Default.PlayerType);

            if (Settings.Default.RememberPreviousChannel)
            {
                Play(channel, StreamType.None);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static event EventHandler<PlayerNotInstalledExceptionEventArgs<IPlayer>> PlayerNotInstalledException
        {
            add
            {
                _playerNotInstalledException += value;
            }
            remove
            {
                _playerNotInstalledException -= value;
            }
        }
        private static EventHandler<PlayerNotInstalledExceptionEventArgs<IPlayer>> _playerNotInstalledException;

        protected virtual void OnPlayerNotInstalledException(object sender, PlayerNotInstalledExceptionEventArgs<IPlayer> e)
        {
            if (_playerNotInstalledException != null)
            {
                _playerNotInstalledException(sender, e);
            }
        }

        // this is such a hack, i hate it.
        internal static IChannel Channel { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="channel"></param>
        /// <param name="type"></param>
        public void Play(IChannel channel, StreamType type)
        {
            _player.Play(channel, PlayerType);
        }

        /// <summary>
        /// 
        /// </summary>
        public PlayerTypes PlayerType { get; set; }

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
            catch (System.Runtime.InteropServices.COMException exc)
            {
                int hr = exc.ErrorCode;
                String message = String.Format("There was an error.\nHRESULT = {0}\n{1}", hr.ToString(), exc.Message) ?? string.Empty;

                throw new System.Runtime.InteropServices.COMException(message, exc);
            }
            catch (PlayerNotInstalledException exc)
            {
                OnPlayerNotInstalledException(this, new PlayerNotInstalledExceptionEventArgs<IPlayer>(exc));
            }
        }
    }
}
