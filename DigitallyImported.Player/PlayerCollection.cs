#region using declarations

using System.Collections.Generic;
using DigitallyImported.Components;

#endregion

namespace DigitallyImported.Player
{
    /// <summary>
    /// </summary>
    /// <typeparam name="TChannel"> </typeparam>
    /// <typeparam name="TPlayer"> </typeparam>
    public class PlayerCollection<TChannel, TPlayer> : Dictionary<TChannel, TPlayer>
        where TChannel : IChannel
        where TPlayer : IPlayer
    {
    }
}