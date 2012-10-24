#region using declarations

using System.Drawing;
using DigitallyImported.Components;

#endregion

namespace DigitallyImported.Player
{
    // BASE INTERFACE FOR ALL PLAYERS
    /// <summary>
    /// </summary>
    public interface IPlayer
    {
        // void Play(IChannel channel);
        /// <summary>
        /// </summary>
        IChannel Channel { get; set; }

        /// <summary>
        /// </summary>
        PlayerType PlayerType { get; }

        /// <summary>
        /// </summary>
        Icon PlayerIcon { get; }

        /// <summary>
        /// </summary>
        bool IsInstalled { get; }

        /// <summary>
        /// </summary>
        /// <param name="channel"> </param>
        void OpenPlayer(IChannel channel);
    }
}