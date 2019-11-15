#region using declarations

using System;
using System.Windows.Forms;
using DigitallyImported.Components;

#endregion

namespace DigitallyImported.Controls.Windows
{
    /// <summary>
    /// </summary>
    public partial class Event : UserControl, IEvent
    {
        private DateTime _endTime;
        private DateTime _eventDate;
        private DateTime _startTime;
        private string _title;

        /// <summary>
        /// </summary>
        public Event()
        {
            InitializeComponent();
        }

        /// <summary>
        /// </summary>
        public virtual TimeZone PlaylistTimeZone
        {
            get
            {
                var tz = TimeZone.CurrentTimeZone;
                return tz;
            }
        }

        #region IEvent Members

        /// <summary>
        /// </summary>
        public virtual DateTime EventDate
        {
            get => _eventDate;
            set => _eventDate = value;
        }

        /// <summary>
        /// </summary>
        public virtual DayOfWeek Day { get; set; }

        /// <summary>
        /// </summary>
        public virtual string Title
        {
            get => _title;
            set
            {
                _title = value;
                Name = value.Replace(" ", "").ToLower();
            }
        }

        /// <summary>
        /// </summary>
        public virtual string Subtitle { get; set; }


        /// <summary>
        /// </summary>
        public virtual DateTime StartTime
        {
            get => _startTime;
            set
            {
                _startTime = PlaylistTimeZone.IsDaylightSavingTime(value)
                                 ? value.AddHours(4).ToLocalTime()
                                 : value.AddHours(5).ToLocalTime();

                _startTime = value;
            }
        }

        /// <summary>
        /// </summary>
        public virtual DateTime EndTime
        {
            get => _endTime;
            set =>
                _endTime = PlaylistTimeZone.IsDaylightSavingTime(value)
                    ? value.AddHours(4).ToLocalTime()
                    : value.AddHours(5).ToLocalTime();
        }

        /// <summary>
        /// </summary>
        public virtual string Channel { get; set; }

        /// <summary>
        /// </summary>
        public virtual Uri EventUrl { get; set; }

        /// <summary>
        /// </summary>
        public virtual StationType PlaylistType { get; set; }

        /// <summary>
        /// </summary>
        public virtual SubscriptionLevel SubscriptionLevel { get; set; }

        /// <summary>
        /// </summary>
        public virtual bool IsSelected { get; set; }

        /// <summary>
        /// </summary>
        /// <param name="other"> </param>
        /// <returns> </returns>
        public bool Equals(IContent other)
        {
            return Name.Equals(other.Name, StringComparison.CurrentCultureIgnoreCase);
        }

        #endregion

        /// <summary>
        /// </summary>
        /// <returns> </returns>
        public override string ToString()
        {
            return Name;
        }

        /// <summary>
        /// </summary>
        /// <returns> </returns>
        public string GetEventDetails()
        {
            return string.Format("{0} :: {1}-{2}{4}{3}{4}{5}{4}{6}"
                                 , _eventDate.ToShortDateString()
                                 , _startTime.ToShortTimeString()
                                 , _endTime.ToShortTimeString()
                                 , Components.Utilities.CapitalizeFirstLetters(Channel)
                                 , Environment.NewLine
                                 , Components.Utilities.CapitalizeFirstLetters(Title)
                                 , Components.Utilities.CapitalizeFirstLetters(Subtitle));
        }
    }
}