#region using declarations

using DigitallyImported.Components;

#endregion

namespace DigitallyImported.Player
{
    /// <summary>
    /// </summary>
    public sealed class PlayerController
    {
        /// <summary>
        /// </summary>
        public PlayerController()
        {
        }

        /// <summary>
        /// </summary>
        /// <param name="channel"> </param>
        public PlayerController(IChannel channel)
        {
            Channel = channel;
        }

        /// <summary>
        /// </summary>
        internal IChannel Channel { get; set; }

        /// <summary>
        /// </summary>
        /// <param name="channel"> </param>
        /// <param name="playerType"> </param>
        internal void Play(IChannel channel, PlayerType playerType)
        {
            // http://www.codeproject.com/gen/design/CSharpClassFactory.asp

            Channel = channel;
            // PlayerFactory<IPlayer> pf = PlayerFactory<IPlayer>.Instance;
            IPlayer player = null;

            switch (playerType)
            {
                case PlayerType.WMP:
                    {
                        //player = pf.CreateMediaPlayer(channel);
                        player = PlayerFactory<IPlayer, WMediaPlayer>.Instance.CreatePlayer(channel);
                        break;
                    }

                case PlayerType.iTunes:
                    {
                        //player = pf.CreateITunes(channel);
                        player = PlayerFactory<IPlayer, ITunes>.Instance.CreatePlayer(channel);
                        break;
                    }

                    //case PlayerTypes.Quicktime:
                    //    {
                    //        //player = pf.CreateQuicktime(channel);
                    //        //player = PlayerFactory<IPlayer, Quicktime>.Instance.CreatePlayer(channel);
                    //        break;
                    //    }
                case PlayerType.Winamp:
                    {
                        //player = pf.CreateWinamp(channel);
                        player = PlayerFactory<IPlayer, Winamp>.Instance.CreatePlayer(channel);
                        break;
                    }
                case PlayerType.Zune:
                    {
                        player = PlayerFactory<IPlayer, Zune>.Instance.CreatePlayer(channel);
                        break;
                    }

                case PlayerType.Default:
                    {
                        //player = pf.CreateDefault(channel);
                        player = PlayerFactory<IPlayer, WebPlayer>.Instance.CreatePlayer(channel);
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
            if (player != null)
            {
                // calls base template method
                player.OpenPlayer(channel);
            }
        }
    }
}