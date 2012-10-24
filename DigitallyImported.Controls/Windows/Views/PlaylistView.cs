#region using declarations

using System;
using System.ComponentModel;
using DigitallyImported.Components;

#endregion

namespace DigitallyImported.Controls.Windows
{
    /// <summary>
    /// </summary>
    /// <typeparam name="TPlaylist"> </typeparam>
    public class PlaylistView<TPlaylist> : ContentView<TPlaylist>, ISiteView<TPlaylist>
        where TPlaylist : IPlaylist, new()
    {
        private readonly PlaylistLoader<TPlaylist> _loader;
        private PlaylistCollection<TPlaylist> _sites;

        /// <summary>
        /// </summary>
        public PlaylistView()
        {
            _loader = new PlaylistLoader<TPlaylist>();
        }

        #region ISiteView<TPlaylist> Members

        /// <summary>
        /// </summary>
        /// <param name="bypassCache"> </param>
        /// <returns> </returns>
        public virtual PlaylistCollection<TPlaylist> GetView(bool bypassCache)
        {
            _sites = GetItem(_sites);

            if (bypassCache || _sites == null)
            {
                _sites = _loader.LoadSites(false);

                const string tldEnd = ".fm";

                _sites.ForEach(t =>
                    {
                        t.SiteUri =
                            new Uri(string.Format(Resources.Properties.Resources.UrlContainer, (t.Name + tldEnd)));

                        if (t.SiteUri.AbsoluteUri.Contains(Resources.Properties.Resources.DIHomePage))
                        {
                            t.PlaylistType = StationType.DI;
                            t.PlaylistIcon = Resources.Properties.Resources.DIIconNew.ToBitmap();
                        }
                        else if (t.SiteUri.AbsoluteUri.Contains(Resources.Properties.Resources.SkyHomePage))
                        {
                            t.PlaylistType = StationType.Sky;
                            t.PlaylistIcon = Resources.Properties.Resources.SkyIcon.ToBitmap();
                        }
                        else if (t.Name.Contains("Custom"))
                        {
                            t.PlaylistType = StationType.Custom;
                            t.PlaylistIcon = Resources.Properties.Resources.icon_web;
                        }

                        else if (t.Name.Contains("External"))
                        {
                            t.PlaylistType = StationType.External;
                            t.PlaylistIcon = Resources.Properties.Resources.icon_web;
                        }

                        else
                        {
                            t.PlaylistType = StationType.All;
                            t.PlaylistIcon = Resources.Properties.Resources.icon_web;
                        }
                    });

                Sort(_sites);

                InsertItem(_sites);
            }

            return _sites;
        }

        /// <summary>
        /// </summary>
        public PlaylistCollection<TPlaylist> Sites
        {
            get { return _sites; }
        }

        /// <summary>
        /// </summary>
        public override void Save()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public override void Sort(ContentCollection<TPlaylist> contentCollection)
        {
            // base.Sort(contentCollection);

            contentCollection.Sort((list1, list2) => list1.Name.CompareTo(list2.Name));
        }

        #endregion

        /// <summary>
        /// </summary>
        /// <param name="sender"> </param>
        /// <param name="e"> </param>
        protected override void Global_SettingsSaving(object sender, CancelEventArgs e)
        {
        }
    }
}