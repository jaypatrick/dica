using System;
using System.ComponentModel;
using DigitallyImported.Components.Caching;

// using DigitallyImported.Configuration.Properties;

namespace DigitallyImported.Components
{
    public abstract class ContentView<T> : CacheItem<T>, IContentView<T>
        where T : IContent
    {
        private ContentCollection<T> _contents;

        /// <summary>
        /// 
        /// </summary>
        protected ContentView()
            // : this(new ContentCollection<T>())
        {
            IsViewSet = false;
            // Settings.Default.SettingsSaving += new System.Configuration.SettingsSavingEventHandler(Global_SettingsSaving);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="contents"> </param>
        protected ContentView(ContentCollection<T> contents)
        {
            IsViewSet = false;
            _contents = contents;
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual SortOrder SortOrder { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual SortBy SortBy { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual ContentCollection<T> Contents
        {
            get { return _contents; }
            set { _contents = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual bool IsViewSet { get; protected set; }

        #region IContentView<T> Members

        public abstract void Save();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public int Compare(T x, T y)
        {
            switch (SortBy)
            {
                case SortBy.ChannelName:
                    {
                        if (SortOrder == SortOrder.Ascending)
                        {
                            return String.Compare(x.Name, y.Name, StringComparison.Ordinal);
                            //break;
                        }
                        return String.Compare(y.Name, x.Name, StringComparison.Ordinal);
                        //break;
                    }
                case SortBy.SiteName:
                    {
                        return SortOrder == SortOrder.Ascending
                                   ? x.PlaylistType.CompareTo(y.PlaylistType)
                                   : y.PlaylistType.CompareTo(x.PlaylistType);
                        //break;
                    }

                    // TESTING, kinda sloppy as you are testing conditionals via casting
                    // handle in uplevel class!
                case SortBy.TrackTitle:
                    {
                        // T a, b;

                        if (x as IChannel != null)
                        {
                            if (SortOrder == SortOrder.Ascending)
                            {
                                return String.Compare(((IChannel) x).CurrentTrack.TrackTitle,
                                                      ((IChannel) y).CurrentTrack.TrackTitle, StringComparison.Ordinal);
                            }
                            return String.Compare(((IChannel) y).CurrentTrack.TrackTitle,
                                                  ((IChannel) x).CurrentTrack.TrackTitle, StringComparison.Ordinal);
                        }
                        break;
                    }
            }

            return 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="contentCollection"></param>
        public virtual void Sort(ContentCollection<T> contentCollection)
        {
            contentCollection.Sort(this);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="contentType"></param>
        /// <returns></returns>
        public virtual ContentCollection<T> GetView(ContentType contentType)
        {
            return null;

            // TODO move to base class, infer type of T to get correct collection back.
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public virtual ContentCollection<T> GetView(T t)
        {
            // you don't even need to pass in T t, just use class level T type to infer type of collection to return, then cast accordingly.
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual StationType PlaylistTypes { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual ViewType ViewType { get; set; }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void Global_SettingsSaving(object sender, CancelEventArgs e)
        {
            // invalidate the cache for now, but find a workaround
            //Globals.Cache.Remove(Globals.DIChannelView);
            //Globals.Cache.Remove(Globals.DIChannelList); 
            ClearItems<object>();
        }
    }
}