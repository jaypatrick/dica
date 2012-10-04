namespace DigitallyImported.Utilities
{
    using System;

    /// <summary>
    /// 
    /// </summary>
    internal class PlaylistTimer : System.Windows.Forms.Timer
    {
        /// <summary>
        /// 
        /// </summary>
        protected internal event EventHandler<EventArgs> TimerTick
        {
            add
            {
                _timerTick += value;
            }
            remove
            {
                _timerTick -= value;
            }
        }
        private EventHandler<EventArgs> _timerTick;
        private readonly object _timerTickLock = new object();

        /// <summary>
        /// 
        /// </summary>
        protected internal PlaylistTimer() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tickInterval"></param>
        protected internal PlaylistTimer(TimeSpan tickInterval)
        {
            // if (tickInterval == null) throw new ArgumentNullException("tickInterval");

            TickInterval = tickInterval;

            this.Tick += new EventHandler(PlaylistTimer_Tick);
        }

        private void PlaylistTimer_Tick(object sender, EventArgs e)
        {
            if (_timerTick != null)
                _timerTick(sender, e);
        }

        /// <summary>
        /// 
        /// </summary>
        protected internal void Reset()
        {
            this.Stop();
            this.Start();
        }

        /// <summary>
        /// 
        /// </summary>
        protected internal TimeSpan TickInterval
        {
            get { return this._tickInterval; }
            set
            {
                this._tickInterval = value;
                this.Interval = (int)value.TotalMilliseconds;
            }
        }
        private TimeSpan _tickInterval;
    }
}
