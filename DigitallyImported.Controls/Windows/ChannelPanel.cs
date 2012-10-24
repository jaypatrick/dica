#region using declarations

using System.Windows.Forms;
using DigitallyImported.Components;

#endregion

namespace DigitallyImported.Controls.Windows
{
    /// <summary>
    /// </summary>
    /// <typeparam name="TChannel"> </typeparam>
    public partial class ChannelPanel<TChannel> : FlowLayoutPanel
        where TChannel : UserControl, IChannel, new()
    {
        /// <summary>
        /// </summary>
        public ChannelPanel()
        {
            InitializeComponent();
        }

        /// <summary>
        /// </summary>
        public ChannelCollection<TChannel> Channels { get; set; }
    }
}