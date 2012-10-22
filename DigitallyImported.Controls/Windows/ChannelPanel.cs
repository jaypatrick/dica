using System.Windows.Forms;
using DigitallyImported.Components;

namespace DigitallyImported.Utilities
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TChannel"></typeparam>
    public partial class ChannelPanel<TChannel> : FlowLayoutPanel
        where TChannel : UserControl, IChannel, new()
    {
        /// <summary>
        /// 
        /// </summary>
        public ChannelPanel()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        public ChannelCollection<TChannel> Channels { get; set; }
    }
}