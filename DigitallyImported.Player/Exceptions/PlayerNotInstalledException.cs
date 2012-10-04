using System;
using System.Runtime.Serialization;

namespace DigitallyImported.Player
{
    public class PlayerNotInstalledException : System.Exception, ISerializable
    {
        private IPlayer _player;

        /// <summary>
        /// 
        /// </summary>
        public PlayerNotInstalledException()
        {
            // Add implementation.
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public PlayerNotInstalledException(string message)
            : this(message, null)
        {
            // Add implementation.
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="inner"></param>
        public PlayerNotInstalledException(string message, Exception inner)
            : this(message, inner, null)
        {
            // Add implementation.
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="inner"></param>
        /// <param name="player"></param>
        public PlayerNotInstalledException(string message, Exception inner, IPlayer player)
        {
            this._player = player;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        protected PlayerNotInstalledException(SerializationInfo info, StreamingContext context)
        {
            // Add implementation.
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual IPlayer Player
        {
            get { return this._player; }
        }
    }
}
