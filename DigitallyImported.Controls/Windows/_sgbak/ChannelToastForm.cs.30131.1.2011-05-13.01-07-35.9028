using System.ComponentModel;
using DigitallyImported.Components;

namespace DigitallyImported.Utilities
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public partial class ChannelToastForm<T> : ToastForm<T> where T: IChannel
    {
        private T _channel = default(T);
        private string _bodyText = string.Empty;
        private string _titleText = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public ChannelToastForm()
            : base()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="container"></param>
        public ChannelToastForm(IContainer container)
            : base(container)
        {
            container.Add(this);

            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="channel"></param>
        public ChannelToastForm(T channel)
            : base(channel)
        {
            InitializeComponent();

            _channel = channel;
        }

        /// <summary>
        /// 
        /// </summary>
        public override T Content
        {
            get
            {
                return this._channel;
            }
            set
            {
                this._channel = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public override string BodyText
        {
            get
            {
                return this._bodyText;
            }
            set
            {
                this._bodyText = value;
                base.DefaultText = GetFormattedBody();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public override string TitleText
        {
            get
            {
                return _titleText;
            }
            set
            {
                _titleText = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected internal void ChannelToastForm_Click(object sender, System.EventArgs e)
        {
            // string toastText = string.Format("Track changed on channel {0} to {1}", _channel.ChannelName, _channel.TrackTitle);
            DigitallyImported.Components.Utilities.StartProcess(_channel.CurrentTrack.ForumUrl.AbsoluteUri);
        }
    }
}
