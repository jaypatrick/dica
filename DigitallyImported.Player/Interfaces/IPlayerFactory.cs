#region using declarations

using DigitallyImported.Components;

#endregion

namespace DigitallyImported.Player
{
    /// <summary>
    /// </summary>
    public interface IPlayerFactory
    {
        /// <summary>
        /// </summary>
        /// <returns> </returns>
        IChannel GetPlayerKey();
    }
}