#region using declarations

using System.ComponentModel;
using DigitallyImported.Components;

#endregion

namespace DigitallyImported.Controls.Windows
{
    /// <summary>
    /// </summary>
    public partial class EventsContextMenu : BaseContextMenu
    {
        /// <summary>
        /// </summary>
        public EventsContextMenu()
        {
            InitializeComponent();
        }

        /// <summary>
        /// </summary>
        /// <param name="container"> </param>
        public EventsContextMenu(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        /// <summary>
        /// </summary>
        public new EventCollection<Event> Events { get; set; }

        private void EventsContextMenu_Opening(object sender, CancelEventArgs e)
        {
            Items.Clear();

            if (Events != null)
            {
                Events.ForEach(item =>
                    {
                        int i = 0;
                        Items.Add(item.GetEventDetails()
                                  , Resources.Properties.Resources.DIIconNew.ToBitmap()
                                  , (o, ea) => Components.Utilities.StartProcess(
                                      item.EventUrl.AbsoluteUri));

                        Items[i].Name = item.Name;
                        ++i;
                    });
            }
        }
    }
}