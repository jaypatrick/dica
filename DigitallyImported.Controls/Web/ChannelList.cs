#region using declarations

using System;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;
using DigitallyImported.Components;

#endregion

namespace DigitallyImported.Controls.Web
{
    /// <summary>
    /// </summary>
    [DefaultProperty("Text")]
    [ToolboxData("<{0}:ChannelList runat=server></{0}:ChannelList>")]
    public class ChannelList : WebControl //, IChannel
    {
        private Repeater _channelRepeater;

        /// <summary>
        /// </summary>
        [Bindable(true)]
        [Category("Appearance")]
        [DefaultValue("")]
        [Localizable(true)]
        public string Text
        {
            get
            {
                var s = (String) ViewState["Text"];
                return s ?? string.Empty;
            }

            set { ViewState["Text"] = value; }
        }

        /// <summary>
        /// </summary>
        public ChannelCollection<IChannel> Channels { get; set; }

        /// <summary>
        /// </summary>
        /// <param name="output"> </param>
        protected override void RenderContents(HtmlTextWriter output)
        {
            output.Write(Text);
        }

        //public override void DataBind()
        //{
        //    base.DataBind();
        //    _channelRepeater.DataSource = ChannelLoader<IChannel>.LoadChannels();
        //    _channelRepeater.DataBind();
        //}
        //protected override void OnLoad(EventArgs e)
        //{
        //    base.OnLoad(e);
        //    _channelRepeater.DataSource = ChannelLoader<IChannel>.LoadChannels();
        //    _channelRepeater.DataBind();
        //}
        /// <summary>
        /// </summary>
        /// <summary>
        /// </summary>
        protected override void CreateChildControls()
        {
            base.CreateChildControls();
            _channelRepeater = FindControl("ChannelRepeater") as Repeater;

            if (_channelRepeater != null)
            {
                _channelRepeater.ItemCreated += ChannelRepeater_ItemCreated;
            }
        }

        private void ChannelRepeater_ItemCreated(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) // change this
            {
                var channel = e.Item.DataItem as IChannel;
                if (channel != null)
                {
                }
            }
        }
    }
}