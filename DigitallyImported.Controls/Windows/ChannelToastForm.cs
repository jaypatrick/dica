using System;
using System.ComponentModel;
using DigitallyImported.Components;

namespace DigitallyImported.Utilities
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public partial class ChannelToastForm<T> : ToastForm<T> where T : IChannel
    {
        private string _bodyText = string.Empty;
        private T _channel;
        private string _titleText = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public ChannelToastForm()
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
            get { return _channel; }
            set { _channel = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public override string BodyText
        {
            get { return _bodyText; }
            set
            {
                _bodyText = value;
                base.DefaultText = GetFormattedBody();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public override string TitleText
        {
            get { return _titleText; }
            set { _titleText = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected internal void ChannelToastForm_Click(object sender, EventArgs e)
        {
            // string toastText = string.Format("Track changed on channel {0} to {1}", _channel.ChannelName, _channel.TrackTitle);
            Components.Utilities.StartProcess(_channel.CurrentTrack.ForumUrl.AbsoluteUri);
        }
    }
}