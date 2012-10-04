namespace DigitallyImported.Player
{
    using DigitallyImported.Components;

    /// <summary>
    /// 
    /// </summary>
    public class PlayerController
    {
        /// <summary>
        /// 
        /// </summary>
        public PlayerController()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="channel"></param>
        public PlayerController(IChannel channel)
        {
            this.Channel = channel;
        }

        /// <summary>
        /// 
        /// </summary>
        protected internal virtual IChannel Channel { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="channel"></param>
        /// <param name="playerType"></param>
        protected internal virtual void Play(IChannel channel, PlayerTypes playerType)
        {
            // http://www.codeproject.com/gen/design/CSharpClassFactory.asp

            Channel = channel;
            // PlayerFactory<IPlayer> pf = PlayerFactory<IPlayer>.Instance;
            IPlayer player = null;

            try
            {
                switch (playerType)
                {
                    case PlayerTypes.WMP:
                        {
                            //player = pf.CreateMediaPlayer(channel);
                            player = PlayerFactory<IPlayer, WMediaPlayer>.Instance.CreatePlayer(channel);
                            break;
                        }

                    case PlayerTypes.iTunes:
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
                    case PlayerTypes.Winamp:
                        {
                            //player = pf.CreateWinamp(channel);
                            player = PlayerFactory<IPlayer, Winamp>.Instance.CreatePlayer(channel);
                            break;
                        }
                    case PlayerTypes.Zune:
                        {
                            player = PlayerFactory<IPlayer, Zune>.Instance.CreatePlayer(channel);
                            break;
                        }

                    case PlayerTypes.Default:
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
                    player.OpenPlayer(channel);
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
