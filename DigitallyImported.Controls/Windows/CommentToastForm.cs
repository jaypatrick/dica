using System.ComponentModel;

using DigitallyImported.Components;

namespace DigitallyImported.Utilities
{
    /// <summary>
    /// 
    /// </summary>
    public partial class CommentToastForm<T> : ToastForm<T> where T: IChannel
    {
        private string _bodyText = string.Empty;
        private string _titleText = string.Empty;
        private T _channel = default(T);

        /// <summary>
        /// 
        /// </summary>
        public CommentToastForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="container"></param>
        public CommentToastForm(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="channel"></param>
        public CommentToastForm(T channel)
        {
            _channel = channel;

            InitializeComponent();
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
        protected internal virtual void BoardToastForm_Click(object sender, System.EventArgs e)
        {
            DigitallyImported.Components.Utilities.StartProcess(_channel.CurrentTrack.ForumUrl.AbsoluteUri);
        }
    }
}
