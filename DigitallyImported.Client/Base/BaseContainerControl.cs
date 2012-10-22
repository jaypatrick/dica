using System;
using System.Windows.Forms;

namespace DigitallyImported.Client.Controls
{
    /// <summary>
    /// 
    /// </summary>
    public partial class BaseContainerControl : UserControl
    {
        /// <summary>
        /// 
        /// </summary>
        public BaseContainerControl()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (ParentForm == null) return;
            ParentForm.Text = Resources.Properties.Resources.ApplicationTitle;
            ParentForm.Icon = Resources.Properties.Resources.DIIconNew;
        }
    }
}