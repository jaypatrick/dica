#region using declarations

using System;

#endregion

namespace DigitallyImported.Components
{
    /// <summary>
    /// </summary>
    [Serializable]
    public class CommentCountChangedEventArgs<T>
        : ContentChangedEventArgs<T> where T : ITrack
    {
        /// <summary>
        /// </summary>
        /// <param name="track"> </param>
        /// <param name="newValue"> </param>
        public CommentCountChangedEventArgs(T track, int newValue)
        {
            RefreshedContent = track;
            CommentCount = newValue;
        }

        /// <summary>
        /// </summary>
        public int CommentCount { get; set; }

        /// <summary>
        /// </summary>
        public int NewComments
        {
            get { return CommentCount - RefreshedContent.CommentCount; }
        }

        /// <summary>
        /// </summary>
        public override T RefreshedContent { get; set; }
    }
}