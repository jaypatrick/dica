using System;
using System.Collections.Generic;
using System.Windows.Forms;

using DigitallyImported.Components;
using DigitallyImported.Utilities;

namespace DigitallyImported.Client
{
    /// <summary>
    /// 
    /// </summary>
    public partial class HistoryForm : BaseForm
    {
        /// <summary>
        /// 
        /// </summary>
        public HistoryForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="channel"></param>
        public HistoryForm(IChannel channel)
        {
            InitializeComponent();

            _channel = channel;
        }

        /// <summary>
        /// 
        /// </summary>
        public IChannel Channel
        {
            get { return _channel; }
            set { _channel = value; }
        }
        private IChannel _channel;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLoad(EventArgs e)
        {
            if (_channel != null)
            {
                LoadForm(this, e);

                //this.lnkTitle.Text = string.Format("{0} Playlist History", _channel.ChannelName);
                //this.Text = _channel.ChannelName;

                //List<Track> list = _channel.Tracks.ConvertAll<Track>(new Converter<ITrack, Track>(TrackConverter));
                //list.ForEach(delegate(Track t)
                //{
                //    _tracks.Add(t);
                //});

                //this.HistoryPanel.Controls.AddRange(_tracks.ToArray());

                foreach (Control control in this.Controls)
                {
                    control.DoubleClick += (s, ee) =>
                    {
                        this.Hide();
                    };
                }

                foreach (Control control in this.HistoryPanel.Controls)
                {
                    control.DoubleClick += (s, ee) =>
                    {
                        this.Hide();
                    };
                };

                this.FormClosing += (s, ee) =>
                {
                    ee.Cancel = true;
                    this.Hide();
                };

                this.Activated += new EventHandler(LoadForm);
            }

            base.OnLoad(e);
        }

        private void LoadForm(object sender, EventArgs e)
        {
            TrackCollection<Track> tracks = new TrackCollection<Track>();

            this.lnkTitle.Text = string.Format("Last {0} tracks played:", _channel.Tracks.Count);
            this.Text = string.Format("{0} Playlist History", _channel.ChannelName);

            List<Track> list = _channel.Tracks.ConvertAll<Track>(new Converter<ITrack, Track>(TrackConverter));
            list.ForEach(t =>
            {
                tracks.Add(t);
            });

            this.HistoryPanel.Controls.Clear();
            GC.Collect(); GC.WaitForPendingFinalizers();
            this.HistoryPanel.Controls.AddRange(tracks.ToArray());
        }

        private static Track TrackConverter(ITrack track)
        {
            return track as Track;
        }
    }
}