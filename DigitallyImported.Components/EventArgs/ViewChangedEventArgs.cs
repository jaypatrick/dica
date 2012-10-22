using System;

namespace DigitallyImported.Components
{
    [Serializable]
    public class ViewChangedEventArgs<T> : EventArgs
        where T : IContentCollection<IChannel>
    {
        private readonly T _changedContent;

        public ViewChangedEventArgs()
            : this(default(T))
        {
        }

        public ViewChangedEventArgs(T changedContent)
        {
            _changedContent = changedContent;
        }

        public virtual T ChangedContent
        {
            get { return _changedContent; }
        }
    }
}