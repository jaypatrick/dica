using System;
using System.Threading;
using DigitallyImported.Configuration.Properties;
using iTunesLib;
using P = DigitallyImported.Resources.Properties;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace DigitallyImported.Player
{
    /// <summary>
    /// 
    /// </summary>
    public class ITunes : Player, IITunes, IPlayerFactory
    {

        /// <summary>
        /// 
        /// </summary>
        public ITunes()
            :base(Components.PlayerTypes.iTunes)
        {
            
            //if (!IsInstalled) throw new PlayerNotInstalledException("ITunes Player is not installed");
        }

        #region IPlayer Members

        /// <summary>
        /// 
        /// </summary>
        /// <param name="channel"></param>
        protected override void Play(DigitallyImported.Components.IChannel channel)
        {
            // REALLY NEED TO CHANGE THIS IOC/TEMPLATE METHOD IN BASE CLASS

            // http://blogs.msdn.com/danielfe/archive/2004/06/08/151212.aspx
            // _channel = channel;
            //if (channel == null) throw new ArgumentNullException("channel", "Must specify a channel to play. ");

            var url = channel.CurrentTrack.TrackUrl;

            try
            {
                if (IsInstalled)
                {
                    //Trace.WriteLine(string.Format("{0} will attempt to stream {1}", this.PlayerType.ToString(), url));

                    Thread thread = new Thread
                    (delegate()
                        {
                            iTunesApp player = new iTunesAppClass();
                            player.OpenURL(ParseStreamUri(url).AbsoluteUri);
                            player.Play();
                        });
                    thread.Start();

                    //Parallel.Invoke(
                    //    () => startPlayer(url));
                }
            }
            catch
            {
                throw;
            }
        }

        /// <summary>Player U
        /// 
        /// </summary>
        public override DigitallyImported.Components.PlayerTypes PlayerType
        {
            get
            {
                return DigitallyImported.Components.PlayerTypes.iTunes;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public override System.Drawing.Icon PlayerIcon
        {
            get
            {
                return P.Resources.icon_itunes;
            }
        }

        #endregion

        #region IPlayer Members

        /// <summary>
        /// 
        /// </summary>
        public override bool IsInstalled
        {
            get
            {
                try
                {
                    return Type.GetTypeFromProgID(Settings.Default.ITunesProgID, false) == null ? false : true;
                }
                catch (COMException)
                {
                    throw;
                }
            }
        }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="streamUri"></param>
        /// <returns></returns>
        protected override Uri ParseStreamUri(Uri streamUri)
        {
            // throw new NotImplementedException();
            return streamUri;
        }
    }
}
