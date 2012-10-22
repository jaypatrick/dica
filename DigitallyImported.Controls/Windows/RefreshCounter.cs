using System;
using System.ComponentModel;
using System.Configuration;
using System.Globalization;
using System.Windows.Forms;
using DigitallyImported.Configuration.Properties;

namespace DigitallyImported.Utilities
{
    /// <summary>
    /// 
    /// </summary>
    public partial class RefreshCounter : UserControl
    {
        internal static TimeSpan _counterInterval = TimeSpan.FromMilliseconds(1000); // constant?
        internal static TimeSpan _refreshInterval = Settings.Default.PlaylistRefreshInterval;
        private static EventHandler<EventArgs> _counterRefreshed;
        private static readonly object _counterRefreshedLock = new object();
        private static TimeSpan _maxInterval = TimeSpan.MaxValue;
        private static TimeSpan _minInterval = TimeSpan.MinValue;

        // controls counter ticks, i.e. countdown in 1 second intervals
        private readonly PlaylistTimer _counterIntervalTimer = new PlaylistTimer(_counterInterval);
        private readonly object _counterTickLock = new object();

        // controls refresh ticks, i.e. refresh every 5 minutes
        private readonly PlaylistTimer _refreshIntervalTimer = new PlaylistTimer(_refreshInterval);
        private EventHandler<EventArgs> _counterTick;
        private DateTimeFormatInfo _timeFormat = new CultureInfo("en-US", false).DateTimeFormat;
        private string _value;

        private DateTimeFormatInfo info = CultureInfo.CurrentCulture.DateTimeFormat;

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
                                                      string.Format("{0} {1} and {2}",
                                                                    "Refresh interval must be between",
                                                                    _minInterval.ToString(), _maxInterval.ToString()));

            InitializeComponent();

            _counterIntervalTimer.TimerTick += CounterInterval_TimerTick;
            _refreshIntervalTimer.TimerTick += RefreshInterval_TimerTick;
            Settings.Default.SettingChanging += RefreshInterval_SettingChanging;

            _refreshIntervalTimer.TickInterval = refreshInterval;
            _refreshInterval = refreshInterval;

            // _value = refreshInterval.ToString("mm:ss");

            Start();
        }

        /// <summary>
        /// 
        /// </summary>
        /// 
        public static TimeSpan MaxInterval
        {
            get { return _maxInterval; }
        }

        /// <summary>
        /// 
        /// </summary>
        public static TimeSpan MinInterval
        {
            get { return _minInterval; }
        }

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

        /// <summary>
        /// 
        /// </summary>
        public static event EventHandler<EventArgs> CounterRefreshed
        {
            add { _counterRefreshed += value; }
            remove { _counterRefreshed -= value; }
        }

        public event EventHandler<EventArgs> CounterTick
        {
            add { _counterTick += value; }
            remove { _counterTick -= value; }
        }

        private void CounterInterval_TimerTick(object sender, EventArgs e)
        {
            CountdownTimer.Value = CountdownTimer.Value.Subtract(_counterIntervalTimer.TickInterval);
            _value = CountdownTimer.Value.Subtract(_counterIntervalTimer.TickInterval).ToString("mm:ss");


            if (_counterTick != null)
                _counterTick(sender, e);
        }

        private void RefreshInterval_TimerTick(object sender, EventArgs e)
        {
            if (_counterRefreshed != null)
                _counterRefreshed(sender, e);

            Reset();
        }

        private void RefreshInterval_SettingChanging(object sender, SettingChangingEventArgs e)
        {
            if (e.SettingName == "PlaylistRefreshInterval")
            {
                var refreshInterval = (TimeSpan) e.NewValue;

                _refreshInterval = refreshInterval;

                _refreshIntervalTimer.TickInterval = refreshInterval;
                Reset();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void Reset()
        {
            CountdownTimer.Value = new DateTime(2000, 1, 1);
            CountdownTimer.Value = (CountdownTimer.Value.Add(_refreshInterval));

            _refreshIntervalTimer.Reset();
        }

        /// <summary>
        /// 
        /// </summary>
        public void Stop()
        {
            _refreshIntervalTimer.Stop();
            _counterIntervalTimer.Stop();
        }

        /// <summary>
        /// 
        /// </summary>
        public void Start()
        {
            CountdownTimer.Value = new DateTime(2000, 1, 1);
            CountdownTimer.Value = (CountdownTimer.Value.Add(_refreshInterval));

            _refreshIntervalTimer.Start();
            _counterIntervalTimer.Start();
        }

        public override string ToString()
        {
            return _value;
        }
    }
}