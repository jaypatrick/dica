#region using declarations

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DigitallyImported.Components;
using DigitallyImported.Controls.Windows;

#endregion

namespace DigitallyImported.Client
{
    /// <summary>
    /// </summary>
    public partial class HistoryForm : BaseForm
    {
        /// <summary>
        /// </summary>
        public HistoryForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// </summary>
        /// <param name="channel"> </param>
        public HistoryForm(IChannel channel)
        {
            InitializeComponent();

            Channel = channel;
        }

        /// <summary>
        /// </summary>
        public IChannel Channel { get; set; }

        /// <summary>
        /// </summary>
        /// <param name="e"> </param>
        protected override void OnLoad(EventArgs e)
        {
            if (Channel != null)
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

                foreach (Control control in Controls)
                {
                    control.DoubleClick += (s, ee) => Hide();
                }

                foreach (Control control in HistoryPanel.Controls)
                {
                    control.DoubleClick += (s, ee) => Hide();
                }

                FormClosing += (s, ee) =>
                    {
                        ee.Cancel = true;
                        Hide();
                    };

                Activated += LoadForm;
            }

            base.OnLoad(e);
        }

        private void LoadForm(object sender, EventArgs e)
        {
            var tracks = new TrackCollection<Track>();

            lnkTitle.Text = string.Format("Last {0} tracks played:", Channel.Tracks.Count);
            Text = string.Format("{0} Playlist History", Channel.ChannelName);

            List<Track> list = Channel.Tracks.ConvertAll(TrackConverter);
            list.ForEach(tracks.Add);

            HistoryPanel.Controls.Clear();
            GC.Collect();
            GC.WaitForPendingFinalizers();
            HistoryPanel.Controls.AddRange(tracks.ToArray());
        }

        private static Track TrackConverter(ITrack track)
        {
            return track as Track;
        }
    }
}