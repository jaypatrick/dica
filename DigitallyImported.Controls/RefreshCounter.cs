namespace DigitallyImported.Controls
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Data;
    using System.Globalization;
    using System.Text;
    using System.Windows.Forms;

    using DigitallyImported.Configuration.Properties;

    /// <summary>
    /// 
    /// </summary>
    public partial class RefreshCounter : UserControl
    {
        internal static int counterInterval = 1000; // constant?
        internal static int refreshInterval = 300000;
        private string _countFrom = string.Empty;

        DateTimeFormatInfo _timeFormat = new CultureInfo("en-US", false).DateTimeFormat;

        // controls counter ticks, i.e. countdown in 1 second intervals
        PlaylistTimer _counterIntervalTimer = new PlaylistTimer(counterInterval); // get tick from settings
        
        // controls refresh ticks, i.e. refresh every 5 minutes
        PlaylistTimer _refreshIntervalTimer = new PlaylistTimer(refreshInterval); // get tick from settings

        /// <summary>
        /// 
        /// </summary>
        public RefreshCounter()
            : this(refreshInterval)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="refreshInterval"></param>
        public RefreshCounter(int refreshInterval)
        {
            if (refreshInterval <= 0) throw new ArgumentOutOfRangeException("refreshInterval",
                                            "Refresh interval must be greater than 0");

            InitializeComponent();

            _counterIntervalTimer.TimerTick += new EventHandler<EventArgs>(CounterInterval_TimerTick);
            _refreshIntervalTimer.TimerTick += new EventHandler<EventArgs>(RefreshInterval_TimerTick);
            Settings.Default.SettingChanging += new System.Configuration.SettingChangingEventHandler(RefreshInterval_SettingChanging);

            _refreshIntervalTimer.TickInterval = refreshInterval;
            _countFrom = TimeSpan.FromMilliseconds((double)refreshInterval).ToString();

            Start();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="refreshInterval"></param>
        public RefreshCounter(TimeSpan refreshInterval)
        {

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

        private void CounterInterval_TimerTick(object sender, EventArgs e)
        {
            this.countdownTimer.Value = this.countdownTimer.Value.AddMilliseconds(-(double)_counterIntervalTimer.TickInterval);
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
                this._countFrom = TimeSpan.FromMilliseconds(double.Parse(e.NewValue.ToString())).ToString();
                this._refreshIntervalTimer.TickInterval = (int)e.NewValue;
                this.Reset();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void Reset()
        {
            this.countdownTimer.Value = DateTime.Parse(string.Format(_timeFormat, "{0}", _countFrom));
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
            this.countdownTimer.Value = DateTime.Parse(string.Format(_timeFormat, "{0}", _countFrom));

            this._refreshIntervalTimer.Start();
            this._counterIntervalTimer.Start();
        }
    }
}
