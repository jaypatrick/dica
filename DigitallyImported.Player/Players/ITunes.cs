#region using declarations

using System;
using System.Drawing;
using System.Threading;
using DigitallyImported.Components;
using DigitallyImported.Configuration.Properties;
using iTunesLib;
using P = DigitallyImported.Resources.Properties;

#endregion

namespace DigitallyImported.Player
{
    /// <summary>
    /// </summary>
    public class ITunes : Player, IITunes, IPlayerFactory
    {
        /// <summary>
        /// </summary>
        public ITunes()
            : base(PlayerType.iTunes)
        {
            //if (!IsInstalled) throw new PlayerNotInstalledException("ITunes Player is not installed");
        }

        #region IITunes Members

        /// <summary>
        ///   Player U
        /// </summary>
        public override PlayerType PlayerType
        {
            get { return PlayerType.iTunes; }
        }

        /// <summary>
        /// </summary>
        public override Icon PlayerIcon
        {
            get { return P.Resources.icon_itunes; }
        }

        /// <summary>
        /// </summary>
        public override bool IsInstalled
        {
            get { return Type.GetTypeFromProgID(Settings.Default.ITunesProgID, false) != null; }
        }

        #endregion

        /// <summary>
        /// </summary>
        /// <param name="channel"> </param>
        protected override void Play(IChannel channel)
        {
            // REALLY NEED TO CHANGE THIS IOC/TEMPLATE METHOD IN BASE CLASS

            // http://blogs.msdn.com/danielfe/archive/2004/06/08/151212.aspx
            // _channel = channel;
            //if (channel == null) throw new ArgumentNullException("channel", "Must specify a channel to play. ");

            Uri url = channel.CurrentTrack.TrackUrl;

            if (!IsInstalled) return;
            //Trace.WriteLine(string.Format("{0} will attempt to stream {1}", this.PlayerType.ToString(), url));

            var thread = new Thread
                (() =>
                    {
                        iTunesApp player = new iTunesAppClass();
                        player.OpenURL(ParseStreamUri(url).AbsoluteUri);
                        player.Play();
                    });
            thread.Start();

            //Parallel.Invoke(
            //    () => startPlayer(url));
        }

        /// <summary>
        /// </summary>
        /// <param name="streamUri"> </param>
        /// <returns> </returns>
        protected override Uri ParseStreamUri(Uri streamUri)
        {
            // throw new NotImplementedException();
            return streamUri;
        }
    }
}