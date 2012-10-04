using System;
using System.Collections.Generic;
using System.Text;

using DigitallyImported.Components;
using System.ComponentModel;

namespace DigitallyImported.Components
{
    /// <summary>
    /// 
    /// </summary>
    public class Track : ITrack
    {
        # region ITrack Members

        private IChannel _channel;

        /// <summary>
        /// 
        /// </summary>
        public IChannel Channel
        {
            get { return _channel; }
            set { _channel = value; }
        }

        private string _trackTitle;
        /// <summary>
        /// 
        /// </summary>
        public string TrackTitle
        {
            get { return _trackTitle; }
            set 
            { 
                _trackTitle = value;
                Name = value.Replace(" ", "").ToLower();
            }
        }


        private string _artistName;

        /// <summary>
        /// 
        /// </summary>
        public string ArtistName
        {
            get { return _artistName; }
            set { _artistName = value; }
        }


        private DateTime _startTime;

        /// <summary>
        /// 
        /// </summary>
        public DateTime StartTime
        {
            get { return _startTime; }
            set { _startTime = value; }
        }
        private string _trackName;

        /// <summary>
        /// 
        /// </summary>
        public string SongName
        {
            get { return _trackName; }
            set { _trackName = value; }
        }
        private Uri _artistUri;

        /// <summary>
        /// 
        /// </summary>
        public Uri ArtistUri
        {
            get { return _artistUri; }
            set { _artistUri = value; }
        }
        private Uri _forumUrl;

        /// <summary>
        /// 
        /// </summary>
        public Uri ForumUrl
        {
            get { return _forumUrl; }
            set { _forumUrl = value; }
        }
        private Uri _trackUrl;

        /// <summary>
        /// 
        /// </summary>
        public Uri TrackUrl
        {
            get { return _trackUrl; }
            set { _trackUrl = value; }
        }
        private string _recordLabel;

        /// <summary>
        /// 
        /// </summary>
        public string RecordLabel
        {
            get { return _recordLabel; }
            set { _recordLabel = value; }
        }
        private int _commentCount;

        /// <summary>
        /// 
        /// </summary>
        public int CommentCount
        {
            get { return _commentCount; }
            set { _commentCount = value; }
        }
        private bool _isPlaying = false;

        /// <summary>
        /// 
        /// </summary>
        public bool IsPlaying
        {
            get { return _isPlaying; }
            set { _isPlaying = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(true)]
        public event EventHandler<CommentCountChangedEventArgs<IChannel>> CommentCountChanged
        {
            add
            {
                lock (_commentCountChangedLock)
                {
                    _commentCountChanged += value;
                }
            }
            remove
            {
                lock (_commentCountChangedLock)
                {
                    _commentCountChanged -= value;
                }
            }
        }
        internal EventHandler<CommentCountChangedEventArgs<IChannel>> _commentCountChanged;
        private readonly object _commentCountChangedLock = new object();

        /// <summary>
        /// 
        /// </summary>
        [Browsable(true)]
        public event EventHandler<TrackChangedEventArgs<IChannel>> TrackChanged
        {
            add
            {
                lock (_trackChangedLock)
                {
                    {
                        _trackChanged += value;
                    }
                }
            }
            remove
            {
                lock (_trackChangedLock)
                {
                    _trackChanged -= value;
                }
            }
        }
        internal EventHandler<TrackChangedEventArgs<IChannel>> _trackChanged;
        private readonly object _trackChangedLock = new object();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">EventArgs</param>
        protected internal virtual void OnTrackChanged(object sender, TrackChangedEventArgs<IChannel> e)
        {
            if (_trackChanged != null)
            {
                _trackChanged(this, e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected internal virtual void OnCommentCountChanged(object sender, CommentCountChangedEventArgs<IChannel> e)
        {
            if (_commentCountChanged != null)
            {
                _commentCountChanged(this, e);
            }
        }

        # endregion

        # region IContent Members

        private string _name;

        /// <summary>
        /// 
        /// </summary>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        private PlaylistTypes _playlistType;

        /// <summary>
        /// 
        /// </summary>
        public PlaylistTypes PlaylistType
        {
            get { return _playlistType; }
            set { _playlistType = value; }
        }
        private SubscriptionLevel _subscriptionLevel;   // this should be at the site level, not channel or content

        /// <summary>
        /// 
        /// </summary>
        public SubscriptionLevel SubscriptionLevel
        {
            get { return _subscriptionLevel; }
            set { _subscriptionLevel = value; }
        }
        private bool _isSelected;

        /// <summary>
        /// 
        /// </summary>
        public bool IsSelected
        {
            get { return _isSelected; }
            set { _isSelected = value; }
        }

        # endregion

        public override string ToString()
        {
            return _trackTitle;
        }
    }
}
