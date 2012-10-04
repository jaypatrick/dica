using System.Collections.Generic;

using DigitallyImported.Components;

namespace DigitallyImported.Player
{
    public class PlayerCollection<Channel, Player> : Dictionary<Channel, Player>
        where Channel: IChannel
        where Player: IPlayer
    {
        public PlayerCollection()
            : base()
        {

        }
    }
}
