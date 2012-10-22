using System;
using DigitallyImported.Components;
using P = DigitallyImported.Resources.Properties;

namespace DigitallyImported.Utilities.Windows
{
    /// <summary>
    /// 
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
            picPlay.Image = P.Resources.icon_play;
        }
    }
}