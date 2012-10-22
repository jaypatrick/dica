using System;
using System.Drawing;
using DigitallyImported.Components;

namespace DigitallyImported.Player
{
    /// <summary>
    /// 
    /// </summary>
    public class WebPlayer : Player
    {
        /// <summary>
        /// 
        /// </summary>
        public WebPlayer()
            : base(PlayerType.Default)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public override bool IsInstalled
        {
            get { return true; }
        }

        /// <summary>
        /// 
        /// </summary>
        public override Icon PlayerIcon
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        /// <summary>
        /// 
        /// </summary>
        public override PlayerType PlayerType
        {
            get { return PlayerType.Default; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="channel"></param>
        protected override void Play(IChannel channel)
        {
            //if (channel == null) throw new ArgumentNullException("channel", "Must specify a channel to play. ");
            // REALLY NEED TO CHANGE THIS IOC/TEMPLATE METHOD IN BASE CLASS\

            var url = channel.CurrentTrack.TrackUrl.AbsoluteUri;

            if (IsInstalled)
                Components.Utilities.StartProcess(url);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="streamUri"></param>
        /// <returns></returns>
        protected override Uri ParseStreamUri(Uri streamUri)
        {
            return streamUri;
        }
    }
}