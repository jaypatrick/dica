namespace DigitallyImported.Controls
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Resources;
    using System.Windows.Forms;

    /// <summary>
    /// Summary description for ChannelSection.
    /// </summary>
    public partial class ChannelSection : Channel
    {
        private System.Windows.Forms.PictureBox pic96k;
        private System.Windows.Forms.PictureBox picAac;
        private System.Windows.Forms.PictureBox pic32k;
        private System.Windows.Forms.PictureBox picMp3;
        private System.Windows.Forms.PictureBox picWmp;
        private System.Windows.Forms.PictureBox pic24k;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblChannelName;
        private System.Windows.Forms.LinkLabel lnkTrackTitle;
        private System.Windows.Forms.LinkLabel lnkPostComments;
        private System.Windows.Forms.Label lblRecordLabel;
        private System.Windows.Forms.LinkLabel lnkRefreshPlaylist;
        private System.Windows.Forms.ToolTip toolTipLinks;
        private System.Windows.Forms.LinkLabel lnkPlaylistHistory;
        private System.Windows.Forms.LinkLabel lnkChannelInfo;

        /// <summary>
        /// 
        /// </summary>
        public static event EventHandler<EventArgs> PlaylistRefreshed
        {
            add
            {
                _playlistRefreshed += value;
            }
            remove
            {
                _playlistRefreshed -= value;
            }
        }
        static EventHandler<EventArgs> _playlistRefreshed;

        /// <summary>
        /// 
        /// </summary>
        /// 
        // todo refactor this out into it's own EventArgs class, pass link as e.Message
        public static event EventHandler<EventArgs> PopulateToolBarLink
        {
            add
            {
                _populateToolBarLink += value;
            }
            remove
            {
                _populateToolBarLink -= value;
            }
        }
        static EventHandler<EventArgs> _populateToolBarLink;

        /// <summary>
        /// 
        /// </summary>
        public static event EventHandler<TrackChangedEventArgs> TrackChanged
        {
            add
            {
                _trackChanged += value;
            }
            remove
            {
                _trackChanged -= value;
            }
        }
        static EventHandler<TrackChangedEventArgs> _trackChanged;

        private IDictionary<string, string> _channelInfo;

        /// <summary>
        /// Default constructor to initialize the control.
        /// </summary>
        public ChannelSection()
            : this(new Dictionary<string, string>())
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="channelInfo"></param>
        public ChannelSection(IDictionary<string, string> channelInfo)
        {
            // This call is required by the Windows.Forms Form Designer.
            InitializeComponent();

            loadImages();

            _channelInfo = channelInfo;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="channelName"></param>
        /// <returns></returns>
        public static ChannelSection Instance(string channelName)
        {
            return new ChannelSection();
        }

        /// <summary>
        /// Method to initialize the image controls.
        /// </summary>
        private void loadImages()
        {
            this.pic24k.Image = Properties.Resources.blue_24k;
            this.pic32k.Image = Properties.Resources.blue_32k;
            this.pic96k.Image = Properties.Resources.blue_96k;
            this.picAac.Image = Properties.Resources.icon_trans_aacplus;
            this.picMp3.Image = Properties.Resources.icon_mp3;
            this.picWmp.Image = Properties.Resources.icon_wm;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="channelName"></param>
        /// <returns></returns>
        public ChannelSection this[string channelName]
        {
            get { return ChannelSection.Instance(channelName); }
        }

        /// <summary>
        /// Property to get/set the channel name
        /// </summary>
        public string ChannelName
        {
            get { return this.lblChannelName.Text; }
            set
            {
                this.Name = value.Replace(" ", "").ToLower(); // unique key for control

                this.lblChannelName.Text = value;
                this.channelName = value;
                toolTipLinks.SetToolTip(this.lblChannelName, value);
            }
        }
        private string channelName = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public string ChannelInfoUrl
        {
            get { return this.channelInfoUrl; }
            set
            {
                this.channelInfoUrl = value;
                toolTipLinks.SetToolTip(this.lnkChannelInfo, value);
            }
        }
        private string channelInfoUrl = string.Empty;

        /// <summary>
        /// Property to get/set the name of the track being played
        /// </summary>
        public string TrackTitle
        {
            get { return this.lnkTrackTitle.Text; }
            set
            {
                this.lnkTrackTitle.Text = value;
                toolTipLinks.SetToolTip(this.lnkTrackTitle, value);
                this.trackTitle = value;
            }
        }
        private string trackTitle = string.Empty;

        /// <summary>
        /// Property to get/set the number of comments on a given track
        /// </summary>
        public string BoardCount
        {
            get { return boardCount; }
            set
            {
                this.boardCount = value;
                this.lnkPostComments.Text += string.Format(" {0}{1} {2}{3}", "(", value, "comments", ")");
            }
        }
        private string boardCount = string.Empty;

        /// <summary>
        /// Property to get/set the link to the DI forums discussion on a given track
        /// </summary>
        public string TrackUrl
        {
            get { return this.trackUrl; }
            set
            {
                this.trackUrl = value;
                toolTipLinks.SetToolTip(this.lnkPostComments, value);
            }
        }
        private string trackUrl = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public string PlaylistHistoryUrl
        {
            get { return this.playListHistoryUrl; }
            set
            {
                this.playListHistoryUrl = value;
                toolTipLinks.SetToolTip(this.lnkPlaylistHistory, value);
            }
        }
        private string playListHistoryUrl = string.Empty;

        /// <summary>
        /// Property to get/set the link to a given track's artist homepage
        /// </summary>
        public string ExtraUrl
        {
            get { return this.extraUrl; }
            set
            {
                this.extraUrl = value;
                this.lnkTrackTitle.LinkBehavior = LinkBehavior.AlwaysUnderline;
                this.lnkTrackTitle.LinkColor = Color.RoyalBlue;
                toolTipLinks.SetToolTip(this.lnkTrackTitle, value);
            }
        }
        private string extraUrl = string.Empty;

        /// <summary>
        /// Property to get/set the record label of a given track
        /// </summary>
        public string RecordLabel
        {
            get { return this.lblRecordLabel.Text; }
            set
            {
                this.lblRecordLabel.Text = value;
                this.recordLabel = value;
            }
        }
        private string recordLabel = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public ChannelSection Selected
        {
            get { return this[this.Name]; }
        }
        private bool isPlaying;

        /// <summary>
        /// Event to set the mouse cursor to hand upon entering a picture box
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">EventArgs</param>
        private void pictureBox_MouseEnter(object sender, System.EventArgs e)
        {
            this.Cursor = Cursors.Hand;

            switch (((Control)sender).Name.ToLower())
            {
                case ("picmp3"):
                    {
                        toolTipLinks.SetToolTip((Control)sender, Properties.Resources.DIMediaTypeMp3About);
                        break;
                    }
                case ("picwmp"):
                    {
                        toolTipLinks.SetToolTip((Control)sender, Properties.Resources.DIMediaTypeWmaAbout);
                        break;
                    }
                case ("picaac"):
                    {
                        toolTipLinks.SetToolTip((Control)sender, Properties.Resources.DIMediaTypeAacAbout);
                        break;
                    }

                // testing, delete and refactor
                case ("pic24k"):
                    {
                        toolTipLinks.SetToolTip((Control)sender, string.Format(Properties.Resources.DIMediaTypeAac,
                            this.channelName.Replace(" ", "").Trim().ToLower()));
                        break;
                    }
                case ("pic32k"):
                    {
                        toolTipLinks.SetToolTip((Control)sender, string.Format(Properties.Resources.DIMediaTypeWma,
                            this.channelName.Replace(" ", "").Trim().ToLower()));
                        break;
                    }
                case ("pic96k"):
                    {
                        toolTipLinks.SetToolTip((Control)sender, string.Format(Properties.Resources.DIMediaTypeMp3,
                            this.channelName.Replace(" ", "").Trim().ToLower()));
                        break;
                    }
                // end testing

                default:
                    {
                        break;
                    }
            }
        }

        /// <summary>
        /// Event to set the mouse cursor to arrow upon leaving a picture box
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">EventArgs</param>
        private void pictureBox_MouseLeave(object sender, System.EventArgs e)
        {
            this.Cursor = Cursors.Arrow;
        }

        /// <summary>
        /// Event to start the process for the link clicked to post comments to the DI forum
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">EventArgs</param>
        private void lnkPostComments_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Utilities.StartProcess(this.trackUrl);
        }

        /// <summary>
        /// Event to start the process for the link clicked to view the artist's homepage
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">EventArgs</param>
        private void lnkTrackTitle_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Utilities.StartProcess(this.extraUrl);
        }

        /// <summary>
        /// Event to start the process for the channel information page.
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">EventArgs</param>
        private void lnkChannelInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Utilities.StartProcess(this.channelInfoUrl);
        }

        /// <summary>
        /// Event to start the process for the playlist history page.
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">EventArgs</param>
        private void lnkPlaylistHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Utilities.StartProcess(this.playListHistoryUrl);
        }

        /// <summary>
        /// Event to refresh the main page's playlist
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">EventArgs</param>
        private void lnkRefreshPlaylist_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_playlistRefreshed != null)
                _playlistRefreshed(this, e);
        }


        private void OnTrackChanged(object sender, TrackChangedEventArgs e)
        {
            if (_trackChanged != null)
            {
                // TrackChangedEventArgs trackArgs = new TrackChangedEventArgs(this.channelName, uri, this.trackTitle);
                _trackChanged(this, e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolTipLinks_Popup(object sender, PopupEventArgs e)
        {
            if (_populateToolBarLink != null)
                _populateToolBarLink(this, e);
        }

        /// <summary>
        /// Method to launch the stream for the given stream's link
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">EventArgs</param>
        private void streamType_Click(object sender, System.EventArgs e)
        {
            // refactor into property
            Uri linkUri = null;

            switch (((Control)sender).Name.ToLower())
            {
                case ("pic24k"):
                    {
                        linkUri = new Uri(string.Format(Properties.Resources.DIMediaTypeAac,
                            this.channelName.Replace(" ", "").Trim().ToLower()));
                        break;
                    }
                case ("pic32k"):
                    {
                        linkUri = new Uri(string.Format(Properties.Resources.DIMediaTypeWma,
                            this.channelName.Replace(" ", "").Trim().ToLower()));
                        break;
                    }
                case ("pic96k"):
                    {
                        linkUri = new Uri(string.Format(Properties.Resources.DIMediaTypeMp3,
                            this.channelName.Replace(" ", "").Trim().ToLower()));
                        break;
                    }
                case ("picmp3"):
                    {
                        Utilities.StartProcess(Properties.Resources.DIMediaTypeMp3About);
                        break;
                    }
                case ("picwmp"):
                    {
                        Utilities.StartProcess(Properties.Resources.DIMediaTypeWmaAbout);
                        break;
                    }
                case ("picaac"):
                    {
                        Utilities.StartProcess(Properties.Resources.DIMediaTypeAacAbout);
                        break;
                    }
                default:
                    {
                        break;
                    }
            }

#if !DEBUG
                OnTrackChanged(sender, new TrackChangedEventArgs(this.channelName, linkUri, this.trackTitle));
#endif

            Selected.BackColor = Color.Beige;

            //foreach (Control control in this.Controls)
            //{
            //    if (control is LinkLabel || control is Label)
            //        control.Font = new Font(control.Font, FontStyle.Regular);
            //}
        }
    }
}