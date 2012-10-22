using System;

namespace DigitallyImported.Components
{
    /// <summary>
    /// 
    /// </summary>
    /// 
    [Serializable]
    public class eeEventArgs<T>
        : ContentChangedEventArgs<T> where T : ITrack
    {
        private int _commentCount;
        private T _track;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="track"></param>
        /// <param name="newValue"></param>
        public eeEventArgs(T track, int newValue)
        {
            _track = track;
            _commentCount = newValue;
        }

        /// <summary>
        /// 
        /// </summary>
        public int CommentCount
        {
            get { return _commentCount; }
            set { _commentCount = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public int NewComments
        {
            get { return _commentCount - _track.CommentCount; }
        }

        /// <summary>
        /// 
        /// </summary>
        public override T RefreshedContent
        {
            get { return _track; }
            set { _track = value; }
        }
    }
}