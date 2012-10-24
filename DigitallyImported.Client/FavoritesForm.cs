#region using declarations

using System;
using System.Collections;
using System.Collections.Specialized;
using System.Windows.Forms;
using DigitallyImported.Components;
using DigitallyImported.Configuration.Properties;
using DigitallyImported.Controls.Windows;
using P = DigitallyImported.Resources.Properties;

#endregion

namespace DigitallyImported.Client
{
    public partial class FavoritesForm<TChannel, TTrack> : BaseForm
        where TChannel : UserControl, IChannel, new()
        where TTrack : UserControl, ITrack, new()
    {
        private readonly ChannelView<TChannel, TTrack> _channelView;
        private ExternalChannelsForm form;

        public FavoritesForm()
        {
            InitializeComponent();
        }

        [CLSCompliant(false)]
        public FavoritesForm(ChannelView<TChannel, TTrack> channelView)
        {
            InitializeComponent();

            _channelView = channelView;
        }

        private void FavoritesForm_Load(object sender, EventArgs e)
        {
            RemoveExternalButton.Enabled = false;

            LoadFavoritesLists();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            var favorites = new StringCollection();

            IEnumerator diEnum = DIPlaylistCheckedList.CheckedItems.GetEnumerator();
            IEnumerator skyEnum = SkyPlaylistCheckedList.CheckedItems.GetEnumerator();
            IEnumerator extEnum = ExternalPlaylistCheckBox.CheckedItems.GetEnumerator();

            while (diEnum.MoveNext())
            {
                favorites.Add((string) diEnum.Current);
            }

            while (skyEnum.MoveNext())
            {
                favorites.Add((string) skyEnum.Current);
            }

            while (extEnum.MoveNext())
            {
                favorites.Add((string) skyEnum.Current);
            }

            Settings.Default.PlaylistFavorites = favorites;
            Settings.Default.Save();
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            // Settings.Default.

            //Settings.Default.PlaylistFavorites.Clear();
            //Settings.Default.Save();

            //LoadFavoritesLists();
        }

        protected virtual void LoadFavoritesLists()
        {
            ChannelCollection<TChannel> channels = _channelView.GetView(true, StationType.All);

            ChannelCountLabel.Text = string.Format(P.Resources.ChannelsAvailableNumber, channels.Count.ToString());

            channels.ForEach(channel =>
                {
                    switch (channel.PlaylistType)
                    {
                        case StationType.DI:
                            {
                                PlaylistLabel1.Text = string.Format("{0} {1}", channel.PlaylistType.ToString(),
                                                                    "Channels");
                                DIPlaylistCheckedList.Items.Add(channel.ChannelName,
                                                                Settings.Default.PlaylistFavorites.Contains(
                                                                    channel.ChannelName));
                                break;
                            }
                        case StationType.Sky:
                            {
                                PlaylistLabel2.Text = string.Format("{0} {1}", channel.PlaylistType.ToString(),
                                                                    "Channels");
                                SkyPlaylistCheckedList.Items.Add(channel.ChannelName,
                                                                 Settings.Default.PlaylistFavorites.Contains(
                                                                     channel.ChannelName));
                                break;
                            }
                            //case PlaylistTypes.External:
                        default:
                            {
                                PlaylistLabel3.Text = string.Format("{0} {1}", channel.PlaylistType.ToString(),
                                                                    "Channels");
                                ExternalPlaylistCheckBox.Items.Add(channel.ChannelName,
                                                                   Settings.Default.PlaylistFavorites.Contains(
                                                                       channel.ChannelName));
                                break;
                            }
                    }
                });
        }

        private void AddExternalButton_Click(object sender, EventArgs e)
        {
            form = new ExternalChannelsForm();

            switch (form.ShowDialog(this))
            {
                case DialogResult.OK:
                    {
                        foreach (var entry in form.ExternalEntries)
                        {
                            if (!ExternalPlaylistCheckBox.Items.Contains(entry.Key))
                            {
                                ExternalPlaylistCheckBox.Items.Add(entry.Key,
                                                                   Settings.Default.PlaylistFavorites.Contains(entry.Key));
                            }
                        }

                        break;
                    }
                case DialogResult.Cancel:
                    {
                        break;
                    }
            }
        }

        // i don't know aobut this...perhaps just allow removal via the ExternalChannelForm...
        private void RemoveExternalButton_Click(object sender, EventArgs e)
        {
            //Settings.Default.ExternalFavorites.Remove(ExternalPlaylistCheckBox.SelectedItem.ToString());

            Settings.Default.PlaylistFavorites.Remove(ExternalPlaylistCheckBox.SelectedItem.ToString());
            form.RemoveChannel(ExternalPlaylistCheckBox.SelectedItem.ToString());
        }
    }
}