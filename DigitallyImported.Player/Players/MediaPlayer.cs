#region using declarations

using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading;
using DigitallyImported.Components;
using DigitallyImported.Configuration.Properties;
using WMPLib;
using P = DigitallyImported.Resources.Properties;

#endregion

namespace DigitallyImported.Player
{
    /// <summary>
    /// </summary>
    public class WMediaPlayer : Player, IMediaPlayer
    {
        private readonly WindowsMediaPlayerClass _mediaPlayer = new WindowsMediaPlayerClass();

        /// <summary>
        /// </summary>
        public WMediaPlayer()
            : base(PlayerType.WMP)
        {
            // if (!IsInstalled) throw new PlayerNotInstalledException("Windows Media Player is not installed");
        }

        #region IMediaPlayer Members

        /// <summary>
        /// </summary>
        public override PlayerType PlayerType
        {
            get { return PlayerType.WMP; }
        }

        /// <summary>
        /// </summary>
        public override Icon PlayerIcon
        {
            get { return P.Resources.icon_wmp; }
        }

        /// <summary>
        /// </summary>
        public override bool IsInstalled
        {
            get { return Type.GetTypeFromProgID(Settings.Default.WMPProgID, true) != null; }
        }

        #endregion

        /// <summary>
        /// </summary>
        /// <param name="channel"> </param>
        protected override void Play(IChannel channel)
        {
            // REALLY NEED TO CHANGE THIS IOC/TEMPLATE METHOD IN BASE CLASS

            var url = channel.CurrentTrack.TrackUrl;

            // Trace.WriteLine(string.Format("{0} received request to play {1}", this.PlayerType.ToString(), url), TraceCategories.PlaylistParsing.ToString());

            if (!IsInstalled) return;
            //Trace.WriteLine(string.Format("{0} will attempt to stream {1}", this.PlayerType.ToString(), url));

            var thread = new Thread(() => { if (url != null) startPlayer(url); });
            thread.Start();

            //Parallel.Invoke(
            //    () => startPlayer(url)
            //);
        }

        /// <summary>
        /// </summary>
        /// <param name="streamUri"> </param>
        /// <returns> </returns>
        //protected override Uri ParseStreamUri(Uri streamUri)
        protected override Uri ParseStreamUri(Uri streamUri)
        {
            if (streamUri == null) throw new ArgumentNullException("streamUri");
            Uri returnUri = null;

            var request = (HttpWebRequest) WebRequest.Create(streamUri);

            // DEPRECATING PREMIUM LOGIN
            //if (Settings.Default.SubscriptionType == SubscriptionLevel.Premium.ToString())
            //    request.Headers.Add(string.Format(P.Resources.PremiumStreamCookieHeader, Settings.Default.Username, Settings.Default.Password));

            using (var response = request.GetResponse())
            {
                using (var contentReader = new StreamReader(response.GetResponseStream()))
                {
                    var contents = contentReader.ReadToEnd();

                    var mms = new Regex(@"mms://(.*)", RegexOptions.IgnoreCase);
                    var http = new Regex(@"http://(.*)", RegexOptions.IgnoreCase);

                    var file = new Regex(@"file(.*)", RegexOptions.IgnoreCase);

                    // JK fix for parsing out filename extension after LK was introduced by DI.fm
                    // the LK is a query path of the URL
                    if (streamUri.AbsolutePath.ToLower().EndsWith(string.Format("a{0}sx", "ARG0"), StringComparison.CurrentCultureIgnoreCase))
                    {
                        var url = mms.Match(contents).Success
                                         ? mms.Match(contents).Value
                                         : http.Match(contents).Value; // might contain http links instead of mms

                        //if (Settings.Default.SubscriptionType == SubscriptionLevel.Premium.ToString())
                        //    url = url.Remove(url.IndexOf(Settings.Default.Password) + Settings.Default.Password.Length);

                        url = url.Remove(url.LastIndexOf('"'));

                        returnUri = new Uri(url);
                    }

                    // JK fix for parsing out filename extension after LK was introduced by DI.fm
                    // the LK is a query path of the URL
                    if (streamUri.AbsolutePath.ToLower().EndsWith("pls", StringComparison.CurrentCultureIgnoreCase))
                    {
                        //if (file.IsMatch(contents))
                        //{
                        var url = file.Matches(contents)[new Random().Next(file.Matches(contents).Count)].Value;
                        url = http.Match(url).Value;

                        //string url = http.Matches(contents)[new Random().Next(http.Matches(contents).Count)].Value;

                        if (url.EndsWith("\r")) url = url.Replace("\r", "");

                        // WMP cannot parse the UN:PW out of the URL, so strip it out
                        // parse for aac headers as well.
                        //if (this.PlayerType == PlayerTypes.WMP)// != PlayerTypes.Winamp && this.PlayerType != PlayerTypes.Itunes)
                        //{
                        var req = (HttpWebRequest) WebRequest.Create(url);
                        //req.Headers.Add(P.Resources.PremiumStreamCookieHeaderFormat(Settings.Default.Username, Settings.Default.Password));
                        var wres = (HttpWebResponse) req.GetResponse();

                        // if aac+ stream replace http with icyx to play with orban
                        // http://www.free-codecs.com/aac_aacplus_player_plugin_download.htm
                        // http://wiki.cdyne.com/index.php/Playing_PLS_Winamp_files_in_Windows_Media
                        if (wres.Headers.Get("content-type") == "audio/aacp")
                            url = url.Replace("http", "icyx");

                        if (Channel.StreamType == StreamType.AacPlus || Channel.StreamType == StreamType.Aac)
                        {
                            url = url.Replace("http", "icyx");
                        }

                        // strip out username and password
                        // url = new Uri(url).GetComponents(UriComponents.SchemeAndServer, UriFormat.UriEscaped);
                        //}

                        // replace http w/ icy: http://developer.apple.com/documentation/QuickTime/QT6WhatsNew/Chap1/chapter_1_section_58.html
                        //if (this.PlayerType == PlayerTypes.Quicktime)
                        //{
                        //    url = url.Replace("http", "icy");
                        //}

                        returnUri = new Uri(url);
                    }
                }
            }

            return returnUri;
        }

        private void startPlayer(Uri url)
        {
            // _mediaPlayer.openPlayer(ParseStreamUri(url).AbsoluteUri);

            _mediaPlayer.openPlayer(ParseStreamUri(url).AbsoluteUri);
        }
    }
}