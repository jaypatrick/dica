using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using DigitallyImported.Components;
using DigitallyImported.Configuration.Properties;
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
            : this(PlayerTypes.Default)
        { 

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="playerType"></param>
        protected Player(PlayerTypes playerType)
        {
            if (!IsInstalled) throw new PlayerNotInstalledException
                (string.Format("{0} {1}", playerType.ToString(), "is not installed."));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="channel"></param>
        protected abstract void Play(DigitallyImported.Components.IChannel channel);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="channel"></param>
        public void OpenPlayer(IChannel channel)
        {
            if (channel == null) throw new ArgumentNullException(string.Format("{0}, {1} ", "channel", "Must specify a channel to play."));

            Channel = channel;

            var url = channel.CurrentTrack.TrackUrl;

            //Template method
            GetPlayerKey();
            ParseStreamUri(channel.CurrentTrack.TrackUrl);
            Trace.WriteLine(string.Format("{0} received request: {1}", this.PlayerType.ToString(), url), TraceCategories.StreamParsing.ToString());
            Trace.WriteLine(string.Format("{0} will attempt to stream {1}", this.PlayerType.ToString(), url), TraceCategories.StreamParsing.ToString());
            Play(channel);
            
        }

        /// <summary>
        /// 
        /// </summary>
        public abstract PlayerTypes PlayerType { get; }

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
        /// <returns></returns>
        public virtual IChannel GetPlayerKey()
        {
            return PlayerLoader.Channel;
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual IChannel Channel { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="streamUri"></param>
        /// <returns></returns>
        protected abstract Uri ParseStreamUri(Uri streamUri);
    }
}
