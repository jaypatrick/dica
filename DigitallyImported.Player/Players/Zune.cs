using System;
using System.Drawing;
using DigitallyImported.Components;

namespace DigitallyImported.Player
{
    /// <summary>
    /// 
    /// </summary>
    public class Zune : Player, IZune, IPlayerFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public Zune()
            : base(PlayerType.Zune)
        {
            //if (!IsInstalled) throw new PlayerNotInstalledException("Zune Player is not installed");
        }

        #region IZune Members

        /// <summary>
        /// 
        /// </summary>
        public override PlayerType PlayerType
        {
            get { return PlayerType.Zune; }
        }

        /// <summary>
        /// 
        /// </summary>
        public override Icon PlayerIcon
        {
            get { throw new NotImplementedException(); }
        }

        /// <summary>
        /// 
        /// </summary>
        public override bool IsInstalled
        {
            get { throw new NotImplementedException(); }
        }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="channel"></param>
        protected override void Play(IChannel channel)
        {
            //if (channel == null) throw new ArgumentNullException("channel", "Must specify a channel to play. ");

            // base.Play(channel);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="streamUri"></param>
        /// <exception cref="NotImplementedException"></exception>
        /// <returns></returns>
        protected override Uri ParseStreamUri(Uri streamUri)
        {
            throw new NotImplementedException();
        }
    }
}