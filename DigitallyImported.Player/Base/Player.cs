using System;
using System.Diagnostics;
using System.Drawing;
using DigitallyImported.Components;
using P = DigitallyImported.Resources.Properties;


namespace DigitallyImported.Player
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class Player : IPlayer, IPlayerFactory
    {
        /// <summary>
        /// 
        /// </summary>
        protected Player()
            : this(PlayerType.Default)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="playerType"></param>
        protected Player(PlayerType playerType)
        {
            if (!IsInstalled)
                throw new PlayerNotInstalledException
                    (string.Format("{0} {1}", playerType.ToString(), "is not installed."));
        }

        #region IPlayer Members

        /// <summary>
        /// 
        /// </summary>
        /// <param name="channel"></param>
        public void OpenPlayer(IChannel channel)
        {
            if (channel == null)
                throw new ArgumentNullException(string.Format("{0}, {1} ", "channel", "Must specify a channel to play."));

            Channel = channel;

            Uri url = channel.CurrentTrack.TrackUrl;

            //Template method
            GetPlayerKey();
            ParseStreamUri(channel.CurrentTrack.TrackUrl);
            Trace.WriteLine(string.Format("{0} received request: {1}", PlayerType.ToString(), url),
                            TraceCategory.StreamParsing.ToString());
            Trace.WriteLine(string.Format("{0} will attempt to stream {1}", PlayerType.ToString(), url),
                            TraceCategory.StreamParsing.ToString());
            Play(channel);
        }

        /// <summary>
        /// 
        /// </summary>
        public abstract PlayerType PlayerType { get; }

        /// <summary>
        /// 
        /// </summary>
        public abstract Icon PlayerIcon { get; }

        /// <summary>
        /// 
        /// </summary>
        public abstract bool IsInstalled { get; }

        /// <summary>
        /// 
        /// </summary>
        public virtual IChannel Channel { get; set; }

        #endregion

        #region IPlayerFactory Members

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual IChannel GetPlayerKey()
        {
            return PlayerLoader.Channel;
        }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="channel"></param>
        protected abstract void Play(IChannel channel);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="streamUri"></param>
        /// <returns></returns>
        protected abstract Uri ParseStreamUri(Uri streamUri);
    }
}