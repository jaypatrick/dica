// READ: http://wiki.cdyne.com/index.php/Playing_PLS_Winamp_files_in_Windows_Media

using System;
using System.Diagnostics;
using System.Threading;
using DigitallyImported.Configuration.Properties;
using WMPLib;
using P = DigitallyImported.Resources.Properties;
using System.Threading.Tasks;

namespace DigitallyImported.Player
{
    /// <summary>
    /// 
    /// </summary>
    public class WMediaPlayer : DefaultPlayer, IMediaPlayer, IPlayerFactory
    {

        WindowsMediaPlayerClass _mediaPlayer = new WindowsMediaPlayerClass();

        public WMediaPlayer()
        {
            if (!IsInstalled) throw new PlayerNotInstalledException("Windows Media Player is not installed");
        }

        #region IPlayer Members

        /// <summary>
        /// 
        /// </summary>
        /// <param name="channel"></param>
        public override void Play(DigitallyImported.Components.IChannel channel)
        {
            if (channel == null) throw new ArgumentNullException("channel", "Must specify a channel to play. ");

            Channel = channel;

            Uri url = channel.CurrentTrack.TrackUrl;

            // Trace.WriteLine(string.Format("{0} received request to play {1}", this.PlayerType.ToString(), url), TraceCategories.PlaylistParsing.ToString());

            try
            {
                if (IsInstalled)
                {
                    Trace.WriteLine(string.Format("{0} will attempt to stream {1}", this.PlayerType.ToString(), url));

                    Thread thread = new Thread(delegate()
                    {
                        startPlayer(url);
                    });
                    thread.Start();
                    return;

                    //Parallel.Invoke(
                    //    () => startPlayer(url)
                    //);
                }
            }
            catch
            {
                throw;
            }
        }

        private void startPlayer(Uri url)
        {
            // _mediaPlayer.openPlayer(ParseStreamUri(url).AbsoluteUri);

            _mediaPlayer.openPlayer(ParseStreamUri(url).AbsoluteUri);
        }

        /// <summary>
        /// 
        /// </summary>
        public override DigitallyImported.Components.PlayerTypes PlayerType
        {
            get
            {
                return DigitallyImported.Components.PlayerTypes.MediaPlayer;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public override System.Drawing.Icon PlayerIcon
        {
            get
            {
                return P.Resources.icon_wmp;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public override bool IsInstalled
        {
            get
            {
                return Type.GetTypeFromProgID(Settings.Default.WMPProgID, true) == null ? false : true;
            }
        }

        #endregion
    }
}
