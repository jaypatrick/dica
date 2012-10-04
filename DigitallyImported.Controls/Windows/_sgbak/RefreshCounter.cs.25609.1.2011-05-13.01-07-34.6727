namespace DigitallyImported.Utilities
{
    using System;
    using System.ComponentModel;
    using System.Globalization;
    using System.Windows.Forms;

    using DigitallyImported.Configuration.Properties;

    /// <summary>
    /// 
    /// </summary>
    public partial class RefreshCounter : UserControl
    {
        internal static TimeSpan _counterInterval = TimeSpan.FromMilliseconds(1000); // constant?
        internal static TimeSpan _refreshInterval = Settings.Default.PlaylistRefreshInterval;

        DateTimeFormatInfo _timeFormat = new CultureInfo("en-US", false).DateTimeFormat;

        // controls counter ticks, i.e. countdown in 1 second intervals
        PlaylistTimer _counterIntervalTimer = new PlaylistTimer(_counterInterval);
        
        // controls refresh ticks, i.e. refresh every 5 minutes
        PlaylistTimer _refreshIntervalTimer = new PlaylistTimer(_refreshInterval);

        DateTimeFormatInfo info = CultureInfo.CurrentCulture.DateTimeFormat;

        /// <summary>
        /// 
        /// </summary>
        public RefreshCounter()
            : this(_refreshInterval)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="refreshInterval"></param>
        public RefreshCounter(TimeSpan refreshInterval)
        {
            if (refreshInterval <= _minInterval || refreshInterval >= _maxInterval) 
                throw new ArgumentOutOfRangeException("refreshInterval", 
                    string.Format("{0} {1} and {2}", "Refresh interval must be between", _minInterval.ToString(), _maxInterval.ToString()));

            InitializeComponent();

            _counterIntervalTimer.TimerTick += new EventHandler<EventArgs>(CounterInterval_TimerTick);
            _refreshIntervalTimer.TimerTick += new EventHandler<EventArgs>(RefreshInterval_TimerTick);
            Settings.Default.SettingChanging += new System.Configuration.SettingChangingEventHandler(RefreshInterval_SettingChanging);

            _refreshIntervalTimer.TickInterval = refreshInterval;
            _refreshInterval = refreshInterval;

            // _value = refreshInterval.ToString("mm:ss");

            Start();
        }

        /// <summary>
        /// 
        /// </summary>
        public static event EventHandler<EventArgs> CounterRefreshed
        {
            add
            {
                _counterRefreshed += value;
            }
            remove
            {
                _counterRefreshed -= value;
            }
        }
        private static EventHandler<EventArgs> _counterRefreshed;
        private static readonly object _counterRefreshedLock = new object();

        public event EventHandler<EventArgs> CounterTick
        {
            add
            {
                _counterTick += value;
            }
            remove
            {
                _counterTick -= value;
            }
        }
        private EventHandler<EventArgs> _counterTick;
        private readonly object _counterTickLock = new object();

        private void CounterInterval_TimerTick(object sender, EventArgs e)
        {
            this.CountdownTimer.Value = CountdownTimer.Value.Subtract(_counterIntervalTimer.TickInterval);
            this._value = CountdownTimer.Value.Subtract(_counterIntervalTimer.TickInterval).ToString("mm:ss");


            if (_counterTick != null)
                _counterTick(sender, e);
        }

        private void RefreshInterval_TimerTick(object sender, EventArgs e)
        {
            if (_counterRefreshed != null)
                _counterRefreshed(sender, e);
            
            this.Reset();
        }

        private void RefreshInterval_SettingChanging(object sender, System.Configuration.SettingChangingEventArgs e)
        {
            if (e.SettingName == "PlaylistRefreshInterval")
            {
                TimeSpan refreshInterval = (TimeSpan)e.NewValue;

                _refreshInterval = refreshInterval;

                this._refreshIntervalTimer.TickInterval = refreshInterval;
                this.Reset();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void Reset()
        {
            this.CountdownTimer.Value = new DateTime(2000, 1, 1);
            this.CountdownTimer.Value = (CountdownTimer.Value.Add(_refreshInterval));

            this._refreshIntervalTimer.Reset();
        }

        /// <summary>
        /// 
        /// </summary>
        public void Stop()
        {
            this._refreshIntervalTimer.Stop();
            this._counterIntervalTimer.Stop();
        }

        /// <summary>
        /// 
        /// </summary>
        public void Start()
        {
            this.CountdownTimer.Value = new DateTime(2000, 1, 1);
            this.CountdownTimer.Value = (CountdownTimer.Value.Add(_refreshInterval));

            this._refreshIntervalTimer.Start();
            this._counterIntervalTimer.Start();
        }

        /// <summary>
        /// 
        /// </summary>
        /// 
        public static TimeSpan MaxInterval
        {
            get { return _maxInterval; }
        }
        private static TimeSpan _maxInterval = TimeSpan.MaxValue;

        /// <summary>
        /// 
        /// </summary>
        public static TimeSpan MinInterval
        {
            get { return _minInterval; }
        }
        private static TimeSpan _minInterval = TimeSpan.MinValue;

        /// <summary>
        /// The number of seconds that will elapse before the counter refreshes.
        /// </summary>
        /// 
        [DefaultValue("00:05:00")]
        public static TimeSpan RefreshInterval
        {
            get { return _refreshInterval; }
        }


        /// <summary>
        /// 
        /// </summary>
        public string Value
        {
            get { return _value; }
            set { _value = value; }
        }
        private string _value;

        public override string ToString()
        {
            return _value;
        }
    }
}
