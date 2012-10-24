#region using declarations

using System;
using System.ComponentModel;
using System.Windows.Forms;

#endregion

namespace DigitallyImported.Client.Controls
{
    /// <summary>
    /// </summary>
    public partial class ExternalChannelPickerControl : UserControl
    {
        private string _channelName;
        private EventHandler<EventArgs> _channelRemoved;
        private EventHandler<EventArgs> _channelSaved;
        private Uri _channelUri;

        /// <summary>
        /// </summary>
        public ExternalChannelPickerControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// </summary>
        /// <param name="channelName"> </param>
        /// <param name="channelUri"> </param>
        public ExternalChannelPickerControl(string channelName, Uri channelUri)
        {
            InitializeComponent();

            ChannelName = channelName;
            ChannelUri = channelUri;
        }

        /// <summary>
        /// </summary>
        public virtual string ChannelName
        {
            get { return _channelName; }

            protected internal set
            {
                _channelName = value.Trim();

                NameTextBox.Text = _channelName;
            }
        }

        /// <summary>
        /// </summary>
        public virtual Uri ChannelUri
        {
            get { return _channelUri; }

            protected internal set
            {
                _channelUri = value;

                LocationTextBox.Text = _channelUri.AbsoluteUri;
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="sender"> </param>
        /// <param name="e"> </param>
        protected virtual void SaveButton_Click(object sender, EventArgs e)
        {
            OnChannelSaved(sender, e);
        }

        /// <summary>
        /// </summary>
        /// <param name="sender"> </param>
        /// <param name="e"> </param>
        protected virtual void RemoveButton_Click(object sender, EventArgs e)
        {
            OnChannelRemoved(sender, e);
        }

        /// <summary>
        /// </summary>
        [Browsable(true)]
        public virtual event EventHandler<EventArgs> ChannelSaved
        {
            add { _channelSaved += value; }
            remove { _channelSaved -= value; }
        }

        /// <summary>
        /// </summary>
        [Browsable(true)]
        public virtual event EventHandler<EventArgs> ChannelRemoved
        {
            add { _channelRemoved += value; }
            remove { _channelRemoved -= value; }
        }

        /// <summary>
        /// </summary>
        /// <param name="sender"> </param>
        /// <param name="e"> </param>
        protected virtual void OnChannelSaved(object sender, EventArgs e)
        {
            if (_channelSaved != null)
            {
                _channelSaved(sender, e);
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="sender"> </param>
        /// <param name="e"> </param>
        protected virtual void OnChannelRemoved(object sender, EventArgs e)
        {
            if (_channelRemoved != null)
            {
                _channelRemoved(sender, e);
            }
        }

        private void NameTextBox_Leave(object sender, EventArgs e)
        {
            _channelName = NameTextBox.Text;
        }

        private void LocationTextBox_Leave(object sender, EventArgs e)
        {
            if (!Uri.TryCreate(LocationTextBox.Text, UriKind.Absolute, out _channelUri))
            {
            }
        }
    }
}