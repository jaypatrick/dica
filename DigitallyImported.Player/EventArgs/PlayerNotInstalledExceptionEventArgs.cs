#region using declarations

using System;

#endregion

namespace DigitallyImported.Player
{
    /// <summary>
    /// </summary>
    /// <typeparam name="T"> </typeparam>
    [Serializable]
    public class PlayerNotInstalledExceptionEventArgs<T> : EventArgs where T : IPlayer
    {
        /// <summary>
        /// </summary>
        /// <param name="player"> </param>
        public PlayerNotInstalledExceptionEventArgs(Exception e)
        {
            // _player = player;
            Exception = e;
        }

        /// <summary>
        /// </summary>
        public virtual T Player { get; set; }

        /// <summary>
        /// </summary>
        public virtual Exception Exception { get; set; }
    }
}