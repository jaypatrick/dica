using System;
using DigitallyImported.Components;
using DigitallyImported.Configuration.Properties;

namespace DigitallyImported.Utilities
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T">IChannel</typeparam>
    public class ChannelView<TChannel, TTrack> : ContentView<TChannel>, IChannelView<TChannel>
        where TChannel : class, IChannel, new()
        where TTrack : class, ITrack, new()
    {
        // private CacheManager _viewCache = CacheFactory.GetCacheManager();
        private readonly object _viewChangedLock = new object();
        private EventHandler<ChannelViewChangedEventArgs<ChannelCollection<IChannel>>> _channelViewChanged;
        private ChannelCollection<TChannel> _channels;
        private ChannelLoader<TChannel, TTrack> _loader;
        private TChannel _selectedChannel;

        /// <summary>
        /// 
        /// </summary>
        public ChannelView() // DEFAULT VIEW
            : this(new ChannelCollection<TChannel>())
        {
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="channels"></param>
        public ChannelView(ChannelCollection<TChannel> channels)
            // NEED A SPECIFIC VIEW TYPE SERVED UP (WEB, WINFORMS, ETC)
            : base(channels)
        {
            if (channels == null) throw new ArgumentNullException("channels");
            ParseSortSettings();

            Settings.Default.SettingsSaving += (sender, e) =>
                {
                    ClearItems<object>();
                    ParseSortSettings();
                    IsViewSet = false;
                };
        }

        #region IChannelView<TChannel> Members

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bypassCache"></param>
        /// <returns></returns>
        public virtual ChannelCollection<TChannel> GetView(bool bypassCache)
        {
            return GetView(bypassCache, PlaylistTypes);
        }

        /// <summary>
        /// 
        /// </summary>
        public override void Save()
        {
            Settings.Default.PlaylistTypes.Clear();
            Settings.Default.PlaylistTypes.Add(PlaylistTypes.ToString());
            Settings.Default.ChannelSortBy = SortBy.ToString();
            Settings.Default.ChannelSortOrder = SortOrder.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual ChannelCollection<TChannel> Channels
        {
            get
            {
                Sort(_channels); // sort first???
                return _channels;
            }
        }

        public override StationType PlaylistTypes
        {
            get { return base.PlaylistTypes; }
            set
            {
                IsViewSet = false;
                base.PlaylistTypes = value;
                Settings.Default.PlaylistTypes.Clear();
                Settings.Default.PlaylistTypes.Add(value.ToString());
                // Save();   // HACK!
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual TChannel SelectedChannel
        {
            get { return _selectedChannel; }
            set
            {
                _selectedChannel = value;
                (_selectedChannel).IsSelected = true;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        public virtual event EventHandler<ChannelViewChangedEventArgs<ChannelCollection<IChannel>>> ChannelViewChanged
        {
            add
            {
                lock (_viewChangedLock)
                {
                    _channelViewChanged += value;
                }
            }
            remove
            {
                lock (_viewChangedLock)
                {
                    _channelViewChanged -= value;
                }
            }
        }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bypassCache"></param>
        /// <param name="playlistTypes"></param>
        /// <returns></returns>
        public virtual ChannelCollection<TChannel> GetView(bool bypassCache, StationType playlistTypes)
        {
            // assume view is set
            IsViewSet = true;

            _channels = GetItem(_channels);

            if ((bypassCache) || (_channels == null))
            {
                _loader = new ChannelLoader<TChannel, TTrack>(Settings.Default.DIPlaylistXml);
                // this should not be hardcoded
                //_channels = ChannelLoaderService<TChannel>.LoadChannels(bypassCache);  
                _channels = _loader.LoadChannels(bypassCache);

                //if (!IsViewSet)
                //{
                // ParseSortSettings();
                IsViewSet = false;
                //}

                // assign siteIcons
                _channels.ForEach(t =>
                    {
                        if (t.SiteName.Contains(Resources.Properties.Resources.DIHomePage))
                        {
                            t.PlaylistType = StationType.DI;
                            t.SiteIcon = Resources.Properties.Resources.DIIconNew;
                        }
                        else if (t.SiteName.Contains(Resources.Properties.Resources.SkyHomePage))
                        {
                            t.PlaylistType = StationType.Sky;
                            t.SiteIcon = Resources.Properties.Resources.SkyIcon;
                        }
                        else
                        {
                            t.PlaylistType = StationType.External;
                            // t.SiteIcon = Resources.Properties.Resources.
                        }
                    });

                // now remove channels that aren't favorites specified in settings
                if (playlistTypes == StationType.Custom)
                {
                    _channels.RemoveAll(t => !Settings.Default.PlaylistFavorites.Contains(t.ChannelName));
                }
                else
                {
                    _channels.RemoveAll(t => (t.PlaylistType & playlistTypes) == 0);
                }

                Sort(_channels);
                _channels.ForEach(t => { t.IsAlternating = (_channels.IndexOf(t)%2 == 0); });

                InsertItem(_channels);

                // only fire the event if the view changed, cache was bypassed on purpose
                // OnChannelViewChanged(this, new ChannelViewChangedEventArgs<ChannelCollection<IChannel>>(_channels as ChannelCollection<IChannel>));
            }

            return _channels;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="action">Summary for action</param>
        /// <returns></returns>
        public virtual ChannelCollection<TChannel> GetView(Predicate<TChannel> action)
        {
            // foreach (T t in 
            return null;
        }

        private void ParseSortSettings()
        {
            SortOrder = Utilities.ParseEnum<SortOrder>(Settings.Default.ChannelSortOrder);
            SortBy = Utilities.ParseEnum<SortBy>(Settings.Default.ChannelSortBy);
            PlaylistTypes = Utilities.GetPlaylistTypes<StationType>(Settings.Default.PlaylistTypes);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void OnChannelViewChanged(object sender,
                                                    ChannelViewChangedEventArgs<ChannelCollection<IChannel>> e)
        {
            if (_channelViewChanged != null)
                _channelViewChanged(sender, e);
        }
    }
}