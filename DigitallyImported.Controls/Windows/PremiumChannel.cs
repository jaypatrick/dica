using System;
using System.Web;
using System.Windows.Forms;
using DigitallyImported.Components;
using DigitallyImported.Configuration.Properties;
using P = DigitallyImported.Resources.Properties;

namespace DigitallyImported.Utilities
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public partial class PremiumChannel : Channel
    {
        private Uri playListHistoryUrl;

        /// <summary>
        /// 
        /// </summary>
        public override Uri PlaylistHistoryUrl
        {
            get { return playListHistoryUrl; }
            set
            {
                value = new Uri(value + "/pro/");

                playListHistoryUrl = value;

                if (InvokeRequired)
                {
                    BeginInvoke((Action) delegate
                        {
                            lnkPlaylistHistory.Links[0].LinkData = value.AbsoluteUri;
                            toolTipLinks.SetToolTip(lnkPlaylistHistory, value.AbsoluteUri);
                        });
                }
                else
                {
                    lnkPlaylistHistory.Links[0].LinkData = value.AbsoluteUri;
                    toolTipLinks.SetToolTip(lnkPlaylistHistory, value.AbsoluteUri);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        protected internal override void LoadImages()
        {
            picAac.Image = P.Resources.icon_trans_aac;
            pic256k.Image = P.Resources.blue_256k;
            pic128kAac.Image = P.Resources.blue_128k;
            pic128kWmp.Image = P.Resources.blue_128k;
            pic64k.Image = P.Resources.blue_64k;

            base.LoadImages();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected internal override void PictureBox_MouseEnter(object sender, EventArgs e)
        {
            base.PictureBox_MouseEnter(sender, e);

            Cursor = Cursors.Hand;

            var c = (Control) sender;
            string name = c.Name.ToLower();
            string listenKey = Settings.Default.ListenKey;

            //switch (c.Name.ToLower().Substring(0, c.Name.Length - base.ChannelName.Replace(" ", "").Length))
            //{
            if (name.Contains("picaac"))
            {
                toolTipLinks.SetToolTip(c, P.Resources.MediaTypeAacPlus);
                //break;
            }

            if (name.Contains("pic256k"))
            {
                toolTipLinks.SetToolTip(c, Components.Utilities.GetPremiumChannelUri(StreamType.Mp3,
                                                                                     base.SiteName, base.ChannelName,
                                                                                     listenKey).AbsoluteUri);
                //break;
            }
            if (name.Contains("pic128kaac"))
            {
                toolTipLinks.SetToolTip(c, Components.Utilities.GetPremiumChannelUri(StreamType.Aac,
                                                                                     base.SiteName, base.ChannelName,
                                                                                     listenKey).AbsoluteUri);
                //break;
            }
            if (name.Contains("pic128kwmp"))
            {
                toolTipLinks.SetToolTip(c, Components.Utilities.GetPremiumChannelUri(StreamType.Wma,
                                                                                     base.SiteName, base.ChannelName,
                                                                                     listenKey).AbsoluteUri);
                //break;
            }
            if (name.Contains("pic64k"))
            {
                toolTipLinks.SetToolTip(c, Components.Utilities.GetPremiumChannelUri(StreamType.AacPlus,
                                                                                     base.SiteName, base.ChannelName,
                                                                                     listenKey).AbsoluteUri);
                // break;
            }
            //}
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected internal override void StreamType_MouseClick(object sender, MouseEventArgs e)
        {
            if ((Settings.Default.Username == string.Empty
                 || Settings.Default.Password == string.Empty)
                && Settings.Default.ListenKey != string.Empty)
            {
                // base.StreamType_MouseClick(sender, e);

                Uri linkUri = null;
                // MediaType mediaType = MediaType.None;
                var c = (Control) sender;
                string name = c.Name.ToLower();
                string listenKey = Settings.Default.ListenKey;

                //switch (c.Name.ToLower().Substring(0, c.Name.Length - base.ChannelName.Replace(" ", "").Length))
                //{
                if (name.Contains("pic256k"))
                {
                    linkUri = Components.Utilities.GetPremiumChannelUri(StreamType.Mp3, base.SiteName, base.ChannelName,
                                                                        listenKey);
                    StreamType = StreamType.Mp3;
                    //break;
                }
                if (name.Contains("pic128kaac"))
                {
                    linkUri = Components.Utilities.GetPremiumChannelUri(StreamType.Aac, base.SiteName, base.ChannelName,
                                                                        listenKey);
                    StreamType = StreamType.Aac;
                    //break;
                }
                if (name.Contains("pic128kwmp"))
                {
                    linkUri = Components.Utilities.GetPremiumChannelUri(StreamType.Wma, base.SiteName, base.ChannelName,
                                                                        listenKey);
                    base.StreamType = StreamType.Wma;
                    //break;
                }
                if (name.Contains("pic64k"))
                {
                    linkUri = Components.Utilities.GetPremiumChannelUri(StreamType.AacPlus, base.SiteName,
                                                                        base.ChannelName, listenKey);
                    base.StreamType = StreamType.AacPlus;
                    //break;
                }
                //}

                CurrentTrack.TrackUrl = linkUri;
                c.Tag = linkUri != null ? linkUri.AbsoluteUri : string.Empty;

                if (e.Button == MouseButtons.Left)
                    OnChannelChanged(this, new ChannelChangedEventArgs<IChannel>(this));
            }
            else
            {
                throw new HttpException(401, P.Resources.PremiumServiceAuthorizationException);
            }
        }
    }
}