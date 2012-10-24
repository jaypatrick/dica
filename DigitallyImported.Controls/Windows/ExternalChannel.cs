#region using declarations

using System;
using DigitallyImported.Components;

#endregion

namespace DigitallyImported.Controls.Windows
{
    /// <summary>
    /// </summary>
    public partial class ExternalChannel : Channel, IExternalContent
    {
        #region IExternalContent Members

        public new Uri Location
        {
            get { throw new Exception("The method or operation is not implemented."); }
            set { throw new Exception("The method or operation is not implemented."); }
        }

        #endregion

        protected internal override void LoadImages()
        {
            picPlay.Image = Resources.Properties.Resources.icon_play;
        }
    }
}