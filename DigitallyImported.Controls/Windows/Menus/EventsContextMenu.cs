using System;
using System.ComponentModel;

using DigitallyImported.Components;

namespace DigitallyImported.Utilities
{
    public partial class EventsContextMenu : BaseContextMenu
    {
        public EventsContextMenu()
        {
            InitializeComponent();
        }

        public EventsContextMenu(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        private void EventsContextMenu_Opening(object sender, CancelEventArgs e)
        {
            Items.Clear();

            if (_events != null)
            {
                _events.ForEach(item =>
                {
                    int i = 0;
                    Items.Add(item.GetEventDetails()
                            , Resources.Properties.Resources.DIIconNew.ToBitmap()
                            , (o, ea) =>
                            {
                                DigitallyImported.Components.Utilities.StartProcess(
                                    item.EventUrl.AbsoluteUri);
                            });

                    Items[i].Name = item.Name;
                    ++i;
                });
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public EventCollection<Event> Events
        {
            get { return this._events; }
            set { this._events = value; }
        }

        private EventCollection<Event> _events = null;

    }
}
