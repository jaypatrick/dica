using System;
using System.Windows.Forms;
using DigitallyImported.Components;

namespace DigitallyImported.Utilities
{
    /// <summary>
    /// 
    /// </summary>
    public partial class Event : UserControl, IEvent
    {
        public Event()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime EventDate
        {
            get
            {
                return _eventDate;
            }
            set
            {
                _eventDate = value;
            }
        }
        private DateTime _eventDate;
        /// <summary>
        /// 
        /// </summary>
        public virtual DayOfWeek Day
        {
            get
            {
                return _day;
            }
            set
            {
                _day = value; 
            }
        }
        private DayOfWeek _day;

        /// <summary>
        /// 
        /// </summary>
        public virtual string Title
        {
            get
            {
                return _title;
            }
            set
            {
                _title = value;
                this.Name = value.Replace(" ", "").ToLower();
            }
        }
        private string _title;

        /// <summary>
        /// 
        /// </summary>
        public virtual string Subtitle
        {
            get
            {
                return _subtitle;
            }
            set
            {
                _subtitle = value;
            }
        }
        private string _subtitle;


        /// <summary>
        /// 
        /// </summary>
        public virtual TimeZone PlaylistTimeZone
        {
            get
            {
                TimeZone tz = TimeZone.CurrentTimeZone;
                return tz;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime StartTime
        {
            get
            {
                return _startTime;
            }
            set
            {
                if (PlaylistTimeZone.IsDaylightSavingTime(value))
                {
                    _startTime = value.AddHours(4).ToLocalTime();
                }
                else
                {
                    _startTime = value.AddHours(5).ToLocalTime();
                }

                _startTime = value;
            }
        }
        private DateTime _startTime;

        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime EndTime
        {
            get
            {
                return _endTime;
            }
            set
            {
                if (PlaylistTimeZone.IsDaylightSavingTime(value))
                {
                    _endTime = value.AddHours(4).ToLocalTime();
                }
                else
                {
                    _endTime = value.AddHours(5).ToLocalTime();
                }
            }
        }
        private DateTime _endTime;

        /// <summary>
        /// 
        /// </summary>
        public virtual string Channel
        {
            get
            {
                return _channel;
            }
            set
            {
                _channel = value;
            }
        }
        private string _channel;

        /// <summary>
        /// 
        /// </summary>
        public virtual Uri EventUrl
        {
            get
            {
                return _eventUri;
            }
            set
            {
                _eventUri = value;
            }
        }
        private Uri _eventUri;

        /// <summary>
        /// 
        /// </summary>
        public virtual PlaylistTypes PlaylistType
        {
            get { return this._PlaylistType; }
            set { this._PlaylistType = value; }
        }
        private PlaylistTypes _PlaylistType;

        /// <summary>
        /// 
        /// </summary>
        public virtual SubscriptionLevel SubscriptionLevel
        {
            get { return this._subscriptionLevel; }
            set { this._subscriptionLevel = value; }
        }
        private SubscriptionLevel _subscriptionLevel;

        /// <summary>
        /// 
        /// </summary>
        public virtual bool IsSelected
        {
            get { return this._isSelected; }
            set { this._isSelected = value; }
        }
        private bool _isSelected;

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.Name;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string GetEventDetails()
        {
            return string.Format("{0} :: {1}-{2}{4}{3}{4}{5}{4}{6}"
                        , _eventDate.ToShortDateString()
                        , _startTime.ToShortTimeString()
                        , _endTime.ToShortTimeString()
                        , DigitallyImported.Components.Utilities.CapitalizeFirstLetters(Channel)
                        , Environment.NewLine
                        , DigitallyImported.Components.Utilities.CapitalizeFirstLetters(Title)
                        , DigitallyImported.Components.Utilities.CapitalizeFirstLetters(Subtitle));
        }

        #region IEquatable<IContent> Members

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(IContent other)
        {
            return this.Name.Equals(other.Name, StringComparison.CurrentCultureIgnoreCase);
        }

        #endregion
    }
}
