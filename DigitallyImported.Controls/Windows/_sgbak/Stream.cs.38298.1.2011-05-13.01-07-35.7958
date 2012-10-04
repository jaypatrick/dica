using System;
using System.Drawing;
using System.Windows.Forms;

using DigitallyImported.Components;

namespace DigitallyImported.Utilities.Windows
{
    /// <summary>
    /// 
    /// </summary>
    public partial class Stream : UserControl, IStream
    {
        public Stream()
        {
            InitializeComponent();
        }

        #region IStream Members

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual event EventHandler<StreamChangedEventArgs<IStream>> StreamChanged
        {
            add
            {
                lock (_streamChangedLock)
                {
                    _streamChanged += value;
                }
            }
            remove
            {
                lock (_streamChangedLock)
                {
                    _streamChanged -= value;
                }
            }
        }
        private EventHandler<StreamChangedEventArgs<IStream>> _streamChanged;
        private object _streamChangedLock = new object();

        /// <summary>
        /// 
        /// </summary>
        public virtual void OpenStream()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected internal virtual void OnStreamChanged(object sender, StreamChangedEventArgs<IStream> e)
        {
            if (_streamChanged != null)
            {
                _streamChanged(sender, e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual StreamType StreamType
        {
            get { return _streamType; }
            set { _streamType = value; }
        }
        private StreamType _streamType;

        /// <summary>
        /// 
        /// </summary>
        public virtual StreamBitrate StreamBitrate
        {
            get { return _streamBitrate; }
            set { _streamBitrate = value; }
        }
        private StreamBitrate _streamBitrate;

        /// <summary>
        /// 
        /// </summary>
        public virtual IChannel Channel
        {
            get { return _channel; }
            set { _channel = value; }
        }
        private IChannel _channel;

        /// <summary>
        /// 
        /// </summary>
        public virtual Uri StreamUri
        {
            get { return _streamUri; }
            set { _streamUri = value; }
        }
        private Uri _streamUri;

        /// <summary>
        /// 
        /// </summary>
        public virtual Image PlayerImage
        {
            get { return _playerImage; }
            set { _playerImage = value; }
        }
        private Image _playerImage;

        /// <summary>
        /// 
        /// </summary>
        public virtual Image BitrateImage
        {
            get { return _bitrateImage; }
            set { _bitrateImage = value; }
        }
        private Image _bitrateImage;

        /// <summary>
        /// 
        /// </summary>
        public virtual bool IsEnabled
        {
            get { return _isEnabled; }
            set { _isEnabled = value; }
        }
        private bool _isEnabled;

        #endregion

        #region IContent Members

        /// <summary>
        /// 
        /// </summary>
        public virtual PlaylistTypes PlaylistType
        {
            get { return _PlaylistType; }
            set { _PlaylistType = value; }
        }
        private PlaylistTypes _PlaylistType;

        /// <summary>
        /// 
        /// </summary>
        public virtual SubscriptionLevel SubscriptionLevel
        {
            get { return _subscriptionLevel; }
            set { _subscriptionLevel = value; }
        }
        private SubscriptionLevel _subscriptionLevel;

        /// <summary>
        /// 
        /// </summary>
        public virtual bool IsSelected
        {
            get { return _isSelected; }
            set { _isSelected = value; }
        }
        private bool _isSelected;


        #endregion

        #region IEquatable<IContent> Members

        public bool Equals(IContent other)
        {
            return this.Name.Equals(other.Name, StringComparison.CurrentCultureIgnoreCase);
        }

        #endregion
    }
}
