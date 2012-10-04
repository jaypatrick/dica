using System;

namespace DigitallyImported.Player
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// 

    [Serializable]
    public class PlayerNotInstalledExceptionEventArgs<T> : EventArgs where T: IPlayer
    {
        private T _player = default(T);
        private Exception _exception;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="player"></param>
        public PlayerNotInstalledExceptionEventArgs(Exception e)
        {
            // _player = player;
            _exception = e;
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual T Player
        {
            get { return _player; }
            set { _player = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual Exception Exception
        {
            get { return _exception; }
            set { _exception = value; }
        }
    }
}
