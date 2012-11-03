#region using declarations

using System;
using System.Runtime.Serialization;

#endregion

namespace DigitallyImported.Player
{
    /// <summary>
    /// </summary>
    [Serializable]
    public class PlayerNotInstalledException : ApplicationException
    {
        /// <summary>
        /// </summary>
        public PlayerNotInstalledException()
        {
            // Add implementation.
        }

        /// <summary>
        /// </summary>
        /// <param name="message"> </param>
        public PlayerNotInstalledException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// </summary>
        /// <param name="message"> </param>
        /// <param name="inner"> </param>
        public PlayerNotInstalledException(string message, Exception inner = null)
            : base(message, inner)
        {
            // Add implementation.
        }

        /// <summary>
        /// </summary>
        /// <param name="message"> </param>
        /// <param name="inner"> </param>
        /// <param name="player"> </param>
        public PlayerNotInstalledException(string message, Exception inner, IPlayer player)
            : base(message, inner)
        {
            Player = player;
        }

        /// <summary>
        /// </summary>
        /// <param name="info"> </param>
        /// <param name="context"> </param>
        protected PlayerNotInstalledException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            // Add implementation.
        }

        /// <summary>
        /// </summary>
        protected virtual IPlayer Player { get; set; }
    }
}