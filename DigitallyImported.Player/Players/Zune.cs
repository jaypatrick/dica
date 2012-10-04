using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DigitallyImported.Components;

namespace DigitallyImported.Player
{
    public class Zune : Player, IZune, IPlayerFactory
    {
        public Zune()
            : base(PlayerTypes.Zune)
        {
            //if (!IsInstalled) throw new PlayerNotInstalledException("Zune Player is not installed");
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="channel"></param>
        protected override void Play(Components.IChannel channel)
        {
            //if (channel == null) throw new ArgumentNullException("channel", "Must specify a channel to play. ");

            // base.Play(channel);
        }

        /// <summary>
        /// 
        /// </summary>
        public override PlayerTypes PlayerType
        {
            get
            {
                return PlayerTypes.Zune;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public override System.Drawing.Icon PlayerIcon
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="streamUri"></param>
        /// <returns></returns>
        protected override Uri ParseStreamUri(Uri streamUri)
        {
            throw new NotImplementedException();
        }
    }
}
