using System.Drawing;
using DigitallyImported.Components;

namespace DigitallyImported.Player
{
    // BASE INTERFACE FOR ALL PLAYERS
    public interface IPlayer
    {
        void OpenPlayer(IChannel channel);
        // void Play(IChannel channel);
        IChannel Channel { get; set; }
        PlayerTypes PlayerType { get; }
        Icon PlayerIcon { get; }
        bool IsInstalled { get; }
    }
}
