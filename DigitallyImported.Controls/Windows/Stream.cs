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
        private readonly object _streamChangedLock = new object();
        private EventHandler<StreamChangedEventArgs<IStream>> _streamChanged;

        /// <summary>
        /// 
        /// </summary>
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
        public virtual StreamType StreamType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual StreamBitrate StreamBitrate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual IChannel Channel { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual Uri StreamUri { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual Image PlayerImage { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual Image BitrateImage { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual bool IsEnabled { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual StationType PlaylistType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual SubscriptionLevel SubscriptionLevel { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual bool IsSelected { get; set; }

        public bool Equals(IContent other)
        {
            return Name.Equals(other.Name, StringComparison.CurrentCultureIgnoreCase);
        }

        #endregion

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
    }
}