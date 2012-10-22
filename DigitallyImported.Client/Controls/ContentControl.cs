// DI

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using System.Xml;
using DigitallyImported.Components;
using DigitallyImported.Configuration.Properties;
using DigitallyImported.Player;
using DigitallyImported.Utilities;
using P = DigitallyImported.Resources.Properties;

// using DigitallyImported.Client.PlaylistService;

namespace DigitallyImported.Client.Controls
{
    /// <summary>
    /// 
    /// </summary>
    public partial class ContentControl<TChannel, TTrack> : UserControl
        where TChannel : UserControl, IChannel, new()
        where TTrack : UserControl, ITrack, new()
    {
        // value types

        private const string serviceOfflineMessage = "DI.fm playlist service is currently offline.";

        private readonly string _eventsUrl = string.Format("{0}{1}/{2}/{3}", "http://", P.Resources.DIHomePage,
                                                           "calendar", Settings.Default.CalendarFormat.ToLower());

        private readonly RefreshCounter _refreshCounter = new RefreshCounter();

        // reference types
        private TChannel _channel;

        // views
        private ChannelView<TChannel, TTrack> _channelView;
        private EventView<Event> _eventView;
        private bool _isFirstRun = true;

        // players
        private PlayerLoader _playerLoader;
        private HistoryForm _trackHistory;


        /// <summary>
        /// 
        /// </summary>
        public ContentControl()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
        }

        private void ContentControl_Load(object sender, EventArgs e)
        {
            _channelView = new ChannelView<TChannel, TTrack>();
            _eventView = new EventView<Event>();

            // check network status
            UpdateNetworkStatus(NetworkInterface.GetIsNetworkAvailable());

            Task.Factory.StartNew(BindEvents);


            // local properties
            RefreshPlaylistButton.Image = P.Resources.icon_repeat;
            ViewEventsSplitButton.Image = P.Resources.icon_calendar;
            ViewPlaylistsSplitButton.Image = P.Resources.icon_web;
            SortPlaylistSplitButton.Image = P.Resources.icon_sort;
            PlayerTypeSplitButton.Image = P.Resources.icon_sound.ToBitmap();
            OptionsButton.Image = P.Resources.icon_options;
            ExceptionStatusMessage.Image = P.Resources.icon_warning;

            MainNotifyIcon.Icon = P.Resources.DIIconOld; // SWITCH DYNAMICALLY BASED ON CHANNEL LISTENING TO
            MainNotifyIcon.ContextMenuStrip = ChannelsContextMenu;
            MainNotifyIcon.Text = P.Resources.ApplicationTitle;
            RefreshCounterLabel.Text = P.Resources.PlaylistRefreshText;

            _refreshCounter.Stop();

            ViewPlaylistsSplitButton.DropDown = PlaylistsContextMenu;
            SortPlaylistSplitButton.DropDown = SortContextMenu;
            PlayerTypeSplitButton.DropDown = PlayersContextMenu;
            PlayerTypeSplitButton.Text = Components.Utilities.SplitName(Settings.Default.PlayerType);
            FeedbackButton.ToolTipText = P.Resources.SupportPageUrl;


            // memory counter
            //System.Windows.Forms.Timer t = new System.Windows.Forms.Timer();
            //t.Interval = 1000;
            //t.Start();
            //t.Tick += (s, ea) =>
            //{
            //    MemoryStatus.Text = string.Format("{0} {1}", ((long)Process.GetCurrentProcess(). / 1024).ToString(), "KB");
            //};
            // end
        }

        /// <summary>
        /// 
        /// </summary>
        protected virtual void BindEvents()
        {
            // BIND GLOBAL EVENTS
            Channel.ChannelChanged += ChannelChanged;
            RefreshCounter.CounterRefreshed += RefreshPlaylist;

            Settings.Default.SettingsSaving += (sender, e) =>
                {
                    if (Parent != null && !e.Cancel)
                        RefreshPlaylist(sender, e);
                };

            NetworkChange.NetworkAvailabilityChanged +=
                (sender, e) => BeginInvoke(new WaitCallback(UpdateNetworkStatus), e.IsAvailable);

            if (ParentForm != null)
            {
                ParentForm.FormClosing += (sender, e) =>
                    {
                        if (!e.Cancel)
                            _channelView.Save();
                    };
                ParentForm.Resize += (sender, e) =>
                    {
                        if (!_isFirstRun)
                            UpdateVisualCues();
                    };

                MainNotifyIcon.MouseDoubleClick += (sender, e) =>
                    {
                        if (e.Button == MouseButtons.Left)
                            ParentForm.WindowState = FormWindowState.Normal;
                    };
            }

            // player isn't installed?
            PlayerLoader.PlayerNotInstalledException += (sender, e) => MessageBox.Show(e.Exception.Message);

            // testing custom border
            PlaylistPanel.Paint += (s, pea) =>
                {
                    // ControlPaint.DrawBorder(pea.Graphics, pea.ClipRectangle, Color.Gray, ButtonBorderStyle.Solid);
                };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="state"></param>
        protected virtual void UpdateNetworkStatus(object state)
        {
            if ((bool) state)
            {
                ConnectionStatusLabel.Text = P.Resources.NetworkOnline;
                ConnectionStatusLabel.ToolTipText = P.Resources.NetworkAvailable;
                ConnectionStatusLabel.Image = P.Resources.icon_connected.ToBitmap();
                Enabled = true;
            }
            else
            {
                ConnectionStatusLabel.Text = P.Resources.NetworkOffline;
                ConnectionStatusLabel.ToolTipText = P.Resources.NetworkUnavailable;
                ConnectionStatusLabel.Image = P.Resources.icon_disconnected.ToBitmap();
                Enabled = false; // DON"T DISABLE THE ENTIRE F'ING THING...and do this from the base form class.
            }
        }

        private void ChannelChanged(object sender, ChannelChangedEventArgs<IChannel> e)
        {
            SetTrackText(e.RefreshedContent.CurrentTrack);

            foreach (var control in PlaylistPanel.Controls.OfType<TChannel>())
            {
                if (control.Equals(e.RefreshedContent))
                {
                    _channel = e.RefreshedContent as TChannel;
                    UpdateVisualCues();
                }
                else
                {
                    (control).IsSelected = false;
                }
            }
        }

        private void RefreshPlaylist(object sender, EventArgs e)
        {
            RefreshPlaylistButton.Enabled = false;
            PlaylistRefreshProgress.Visible = true;
            PlaylistRefreshProgress.Enabled = false;
            ExceptionStatusMessage.Visible = false;
            PlaylistPanel.Enabled = false;

            if (!NetworkInterface.GetIsNetworkAvailable()) return;
            try
            {
                if (!RefreshPlaylistWorker.IsBusy)
                    RefreshPlaylistWorker.RunWorkerAsync();

                if (!RefreshEventlistWorker.IsBusy)
                    RefreshEventlistWorker.RunWorkerAsync(); // OFFLOAD ELSEWHERE
            }
            catch (Exception exc)
            {
                RefreshPlaylistButton.Enabled = true;
                PlaylistRefreshProgress.Visible = false;
                ExceptionStatusMessage.Visible = true;
                ExceptionStatusMessage.ToolTipText = exc.ToString();
                Trace.WriteLine(exc.ToString());
            }
        }

        private ChannelCollection<TChannel> RefreshPlaylistAsync(BackgroundWorker worker, DoWorkEventArgs e)
        {
            if (worker == null) throw new ArgumentNullException("worker");
            var channels = new ChannelCollection<TChannel>();

            int percentageComplete = 0;

            worker.ReportProgress(0);
            worker.ReportProgress(50);

            worker.ReportProgress(100);

            try
            {
                channels = _channelView.GetView(false);
            }
            catch (XmlException)
            {
                DISiteUnavailable();
            }

            return channels;
        }

        private EventCollection<Event> RefreshEventlistAsync(BackgroundWorker worker, DoWorkEventArgs e)
        {
            if (worker == null) throw new ArgumentNullException("worker");
            var events = new EventCollection<Event>();

            worker.ReportProgress(0);
            try
            {
                events = _eventView.GetView(false);
            }
            catch (XmlException)
            {
                DISiteUnavailable();
            }

            return events;
        }

        private void RefreshPlaylistWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var bw = sender as BackgroundWorker;
            e.Result = RefreshPlaylistAsync(bw, e);
        }

        private void RefreshEventlistWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var bw = sender as BackgroundWorker;
            e.Result = RefreshEventlistAsync(bw, e);
        }

        private void RefreshPlaylistWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            PlaylistRefreshProgress.Value = e.ProgressPercentage;
        }

        private void RefreshEventlistWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // TODO, implement
        }

        private void RefreshPlaylistWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            var channels = e.Result as ChannelCollection<TChannel>;

            PlaylistPanel.Channels = channels != null && channels.Count > 0 ? channels : _channelView.GetView(false);
            ChannelsContextMenu.Channels = PlaylistPanel.Channels;
            ViewChannelSplitButton.DropDown = ChannelsContextMenu;

            BindChannelPlaylistPanel();

            // PlaylistPanel.RefreshPlaylist(sender, e);

            if (_isFirstRun)
            {
                // IF NULL, GENERATE RANDOM NUMBER AND PLAY THAT CHANNEL INDEX
                if (channels != null)
                    _channel = channels[Settings.Default.SelectedChannelName] ??
                               channels[new Random().Next(channels.Count > 0 ? channels.Count : 0)];

                _playerLoader = new PlayerLoader(_channel);
                _isFirstRun = false;

                _refreshCounter.CounterTick +=
                    (s, ea) =>
                        {
                            RefreshCounterLabel.Text = string.Format("{0} {1}", "Refreshing in",
                                                                     _refreshCounter.Value);
                        };

                _refreshCounter.Start();
            }

            UpdateVisualCues();

            // fucking around w/ opacity
            if (ParentForm != null) ParentForm.Opacity = Settings.Default.FormOpacityValue;
        }

        private void RefreshEventlistWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result != null) EventsContextMenu.Events = (EventCollection<Event>) e.Result;
            ViewEventsSplitButton.DropDown = EventsContextMenu;

            ViewEventsSplitButton.Enabled = true;
            ViewEventsSplitButton.ToolTipText = _eventsUrl;
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var about = new AboutForm();
            about.Show(this);
        }

        private void OptionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var admin = new AdminForm();
            var result = admin.ShowDialog();
        }

        private void ViewChannelSplitButton_ButtonClick(object sender, EventArgs e)
        {
            Parallel.Invoke(() => {
                                      if (_channel != null)
                                          Components.Utilities.StartProcess(_channel.ChannelInfoUrl.AbsoluteUri);
            });
        }

        private void ViewSitesSplitButton_ButtonClick(object sender, EventArgs e)
        {
            if (ViewPlaylistsSplitButton.Tag != null)
            {
                Parallel.Invoke(
                    () => Components.Utilities.StartProcess(((Uri) ViewPlaylistsSplitButton.Tag).AbsoluteUri));
            }
        }

        private void ViewChannel_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            _channel = ChannelsContextMenu.Channels[e.ClickedItem.Text.Replace(" ", "").ToLower().Trim()];
            // _channel.IsSelected = true;

            // TESTING
            for (var index = 0; index < PlaylistPanel.Controls.Count; index++)
            {
                var control = PlaylistPanel.Controls[index];
                if (!(control is TChannel)) continue;
                var c = (TChannel) control;

                if (_channel != null && c.Equals(_channel))
                {
                    // PlayerLoader.Load(_channel); THIS WILL PLAY THE SELECTED CHANNEL AUTOMATICALLY
                    _channel.IsSelected = true;
                }
                else
                {
                    c.IsSelected = false;
                }
            }
            if (_channel == null) return;
            ViewChannelSplitButton.Text = _channel.ChannelName;
            // ViewChannelSplitButton.ToolTipText = _channel.ChannelInfoUrl.AbsoluteUri;
            ViewChannelSplitButton.Image = _channel.SiteIcon.ToBitmap();
        }

        private void ViewChannelSplitButton_TextChanged(object sender, EventArgs e)
        {
            if (_channel != null) ViewChannelSplitButton.ToolTipText = _channel.ChannelInfoUrl.AbsoluteUri;
        }

        private void ViewEventsSplitButton_ButtonClick(object sender, EventArgs e)
        {
            Parallel.Invoke(() => Components.Utilities.StartProcess(_eventsUrl));
        }

        // powerful pattern
        private void PlaylistsMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            PlaylistsContextMenu.Close(ToolStripDropDownCloseReason.ItemClicked);

            var playlist = e.ClickedItem as PlaylistList;

            if (playlist == null) return;
            _channelView.PlaylistTypes = playlist.PlaylistType;

            // temporary, i don't like this...not intuitive to have to select Custom as the playlist type
            if (playlist.PlaylistType == StationType.Custom)
            {
                var ff = new FavoritesForm<TChannel, TTrack>(_channelView);
                var result = ff.ShowDialog();
            }
            else
            {
                if (PlaylistPanel != null) PlaylistPanel.Channels = _channelView.GetView(true);

                if (InvokeRequired)
                {
                    Invoke((Action) (() =>
                        {
                            BindChannelPlaylistPanel();
                            UpdateVisualCues();

                            if (ViewPlaylistsSplitButton != null)
                            {
                                ViewPlaylistsSplitButton.Text = playlist.Name;
                                ViewPlaylistsSplitButton.Image = playlist.Image;
                                ViewPlaylistsSplitButton.Tag = playlist.SiteUri; // HACK
                                ViewPlaylistsSplitButton.ToolTipText = playlist.SiteUri.AbsoluteUri;
                            }
                        }));
                }
                else
                {
                    BindChannelPlaylistPanel();
                    UpdateVisualCues();

                    if (ViewPlaylistsSplitButton != null)
                    {
                        ViewPlaylistsSplitButton.Text = playlist.Name;
                        ViewPlaylistsSplitButton.Image = playlist.Image;
                        ViewPlaylistsSplitButton.Tag = playlist.SiteUri; // HACK
                        ViewPlaylistsSplitButton.ToolTipText = playlist.SiteUri.AbsoluteUri;
                    }
                }
            }
        }

        private void SortPlaylist_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (_channelView != null)
            {
                _channelView.SortBy = SortContextMenu.SortBy;
                if (PlaylistPanel != null)
                {
                    PlaylistPanel.Channels = _channelView.Channels;

                    PlaylistPanel.Refresh();
                }
            }

            BeginInvoke((Action) (() =>
                {
                    if (SortPlaylistSplitButton != null) SortPlaylistSplitButton.Text = e.ClickedItem.Text;
                    // SortPlaylist_Click(sender, e);
                }));
            UpdateVisualCues();
        }

        // implement
        private void SortPlaylist_ButtonClick(object sender, EventArgs e)
        {
        }

        private void PlayerType_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            BeginInvoke((Action) (() =>
                {
                    if (PlayerTypeSplitButton != null) PlayerTypeSplitButton.Text = e.ClickedItem.Text;
                    if (_playerLoader != null)
                        _playerLoader.PlayerType = Utilities.Utilities.ParseEnum<PlayerType>(e.ClickedItem.Name);
                }));
        }

        /// <summary>
        /// 
        /// </summary>
        protected internal void UpdateVisualCues()
        {
            if (PlaylistPanel != null)
            {
                PlaylistPanel.Enabled = true;

                if (PlaylistPanel.Channels.Count > 0)
                {
                    if (_channel != null)
                        _channel = PlaylistPanel.Channels[_channel.Name]
                                   ??
                                   PlaylistPanel.Channels[
                                       new Random().Next(PlaylistPanel.Channels.Count > 0 ? PlaylistPanel.Channels.Count : 0)
                                       ];

                    _channel.IsSelected = true;
                }

                ConnectionStatusLabel.Text = string.Format("{0} {1}", PlaylistPanel.Channels.Count, "channels loaded");
            }
            ViewChannelSplitButton.Text = _channel.ChannelName;
            ViewChannelSplitButton.Image = _channel.SiteIcon.ToBitmap();
            ViewPlaylistsSplitButton.Text =
                Utilities.Utilities.GetPlaylistTypes<StationType>(Settings.Default.PlaylistTypes).ToString();
            ViewPlaylistsSplitButton.Image = _channel.SiteIcon.ToBitmap();
            //MainNotifyIcon.Icon          = _channel.SiteIcon;
            if (ParentForm != null) ParentForm.Icon = _channel.SiteIcon;

            // do all of these need to be here?
            RefreshPlaylistButton.Text = "Refresh Playlist";
            PlaylistRefreshProgress.Visible = false;
            RefreshPlaylistButton.Enabled = true;
            ViewChannelSplitButton.Enabled = true;
            ViewPlaylistsSplitButton.Enabled = true;
            SortPlaylistSplitButton.Enabled = true;
            PlayerTypeSplitButton.Enabled = true;

            SetTrackText(_channel.CurrentTrack);
        }

        // this method is a performance sucking machine
        private void BindChannelPlaylistPanel()
        {
            // if (PlaylistPanel.Controls.Count == 0 || !_channelView.IsViewSet)
            if (PlaylistPanel.Controls.Count == PlaylistPanel.Channels.Count) return;
            PlaylistPanel.Controls.Clear();
            PlaylistPanel.Controls.AddRange(PlaylistPanel.Channels.ToArray());

            // subscribe to the TrackChanged events here:
            // this will run EVERY TIME PLAYLIST IS REFRESHED...very expensive, so move elsewhere
            // PlaylistPanel.Channels.ForEach(delegate(TChannel channel)
            Parallel.ForEach<IChannel>(PlaylistPanel.Channels, channel =>
                {
                    channel.TrackChanged -= (s, ee) =>
                        {
                            GC.Collect();
                            GC.WaitForPendingFinalizers();
                        };
                    channel.TrackChanged += (s, ee) => Invoke((Action) (() =>
                        {
                            // first change the title of the window
                            if (
                                ee.RefreshedContent.TrackTitle.Equals(_channel.CurrentTrack.TrackTitle,
                                                                      StringComparison.
                                                                          CurrentCultureIgnoreCase) &&
                                _channel.IsSelected)
                                SetTrackText(ee.RefreshedContent);

                            // show some toast to the user
                            if (!Settings.Default.ShowUserToast) return;
                            var toast = new ChannelToastForm<IChannel>(ee.RefreshedContent.ParentChannel)
                                {
                                    TitleText = ee.RefreshedContent.ParentChannel.ChannelName,
                                    BodyText = string.Format("Track changed to {0}",
                                                             ee.RefreshedContent.TrackTitle),
                                    ForeColor = Color.Black
                                };
                            toast.Notify();
                        }));
                    channel.Tracks[0].ee -= (s, ee) =>
                        {
                            GC.Collect();
                            GC.WaitForPendingFinalizers();
                        };
                    channel.Tracks[0].ee += (s, ee) => Invoke((Action) (() =>
                        {
                            var toast = new CommentToastForm<IChannel>(ee.RefreshedContent.ParentChannel)
                                {
                                    TitleText = ee.RefreshedContent.ParentChannel.ChannelName,
                                    BodyText =
                                        string.Format("{0} new comments for track {1}", ee.NewComments,
                                                      ee.RefreshedContent.TrackTitle),
                                    ForeColor = Color.Black
                                };
                            toast.Notify();
                        }));
                });

            foreach (var control in PlaylistPanel.Controls)
            {
                if (control is TChannel)
                {
                    ((Channel) control).PlaylistHistoryClicked -= (sender, e) => { };
                    ((Channel) control).PlaylistHistoryClicked += (sender, e) =>
                        {
                            var channel = sender as TChannel;

                            if (channel != null)
                            {
                                if (_trackHistory == null)
                                {
                                    _trackHistory = new HistoryForm(channel);
                                    _trackHistory.Show();
                                }
                                else
                                {
                                    _trackHistory.Channel = channel;
                                    _trackHistory.Show();
                                }
                                _trackHistory.Activate();
                                // _trackHistory.Location = this.PointToScreen(this.PlaylistPanel.Controls[((Control)c).Name].Location);
                            }
                        };
                }
            }
        }

        private void SetTrackText(ITrack track)
        {
            if (track == null) throw new ArgumentNullException("track");
            string displayText =
                string.Format("{0} {1} {2}", track.ParentChannel.ChannelName, P.Resources.ColonSeparator,
                              track.TrackTitle);

            MainNotifyIcon.Text = (displayText.Length > 63) ? displayText.Remove(63) : displayText;
            if (ParentForm != null) ParentForm.Text = displayText;
        }

        private void ExitApplication(object sender, EventArgs e)
        {
            Dispose();
            Application.Exit();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (!keyData.Equals(Keys.F5))
                return false;
            RefreshPlaylistButton.PerformClick();
            return true;
        }

        private void FeedbackButton_Click(object sender, EventArgs e)
        {
            Components.Utilities.StartProcess(P.Resources.SupportPageUrl);
        }

        private void DISiteUnavailable()
        {
            if (InvokeRequired)
            {
                BeginInvoke((Action) (() =>
                    {
                        ConnectionStatusLabel.Visible = false;
                        PlaylistRefreshProgress.Visible = false;
                        ExceptionStatusMessage.Visible = true;
                        ExceptionStatusMessage.Text = serviceOfflineMessage;
                    }));
            }
            else
            {
                ConnectionStatusLabel.Visible = false;
                PlaylistRefreshProgress.Visible = false;
                ExceptionStatusMessage.Visible = true;
                ExceptionStatusMessage.Text = serviceOfflineMessage;
            }
        }

        private void PremiumAuthenticationFailure(HttpException exc)
        {
            if (InvokeRequired)
            {
                BeginInvoke((Action) (() =>
                    {
                        ConnectionStatusLabel.Visible = false;
                        PlaylistRefreshProgress.Visible = false;
                        ExceptionStatusMessage.Visible = true;
                        ExceptionStatusMessage.Text = string.Format("{0}: {1}", exc.GetHttpCode().ToString(),
                                                                    exc.Message);
                    }));
            }
            else
            {
                ConnectionStatusLabel.Visible = false;
                PlaylistRefreshProgress.Visible = false;
                ExceptionStatusMessage.Visible = true;
                ExceptionStatusMessage.Text = string.Format("{0}: {1}", exc.GetHttpCode().ToString(), exc.Message);
            }
        }
    }
}