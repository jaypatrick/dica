//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Runtime.InteropServices;
//using System.Threading;

//using DigitallyImported.Components;
//using DigitallyImported.Configuration.Properties;

//using QuickTimePlayerLib;

//namespace DigitallyImported.Player
//{
//    /// <summary>
//    /// 
//    /// </summary>
//    public class Quicktime : Player, IQuicktime, IPlayerFactory
//    {
//        /// <summary>
//        /// 
//        /// </summary>
//        public Quicktime()
//        {
//            if (!IsInstalled) throw new PlayerNotInstalledException("Quicktime Player is not installed");
//        }

//        #region IPlayer Members

//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="channel"></param>
//        public override void Play(DigitallyImported.Components.IChannel channel)
//        {
//            if (channel == null) throw new ArgumentNullException("channel", "Must specify a channel to play. ");

//            Channel = channel;

//            Uri url = channel.CurrentTrack.TrackUrl;

//            try
//            {
//                if (IsInstalled)
//                {
//                    Thread thread = new Thread(delegate()
//                    {
//                        QuickTimePlayerApp qtPlayerapp = new QuickTimePlayerApp();
//                        QuickTimePlayer qtPlayer = qtPlayerapp.Players[1];

//                        qtPlayer.OpenURL(ParseStreamUri(url).AbsoluteUri);

//                    });
//                    thread.Start();
//                }
//            }
//            catch
//            {
//                throw;
//            }
//        }

//        /// <summary>
//        /// 
//        /// </summary>
//        public override DigitallyImported.Components.PlayerTypes PlayerType
//        {
//            get
//            {
//                return DigitallyImported.Components.PlayerTypes.Quicktime;
//            }
//        }

//        /// <summary>
//        /// 
//        /// </summary>
//        public override System.Drawing.Icon PlayerIcon
//        {
//            get
//            {
//                throw new Exception("The method or operation is not implemented.");
//            }
//        }

//        #endregion

//        /// <summary>
//        /// 
//        /// </summary>
//        public override bool IsInstalled
//        {
//            get
//            {
//                return Type.GetTypeFromProgID(Settings.Default.QuickTimeProgID, false) == null ? false : true;
//            }
//        }
//    }
//}
