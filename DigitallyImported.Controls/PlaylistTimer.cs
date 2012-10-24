#region using declarations

using System;
using System.Windows.Forms;

#endregion

namespace DigitallyImported.Controls
{
    /// <summary>
    /// </summary>
    internal class PlaylistTimer : Timer
    {
        private TimeSpan _tickInterval;
        private EventHandler<EventArgs> _timerTick;

        /// <summary>
        /// </summary>
        protected internal PlaylistTimer()
        {
        }

        /// <summary>
        /// </summary>
        /// <param name="tickInterval"> </param>
        protected internal PlaylistTimer(TimeSpan tickInterval)
        {
            // if (tickInterval == null) throw new ArgumentNullException("tickInterval");

            TickInterval = tickInterval;

            Tick += PlaylistTimer_Tick;
        }

        /// <summary>
        /// </summary>
        protected internal TimeSpan TickInterval
        {
            get { return _tickInterval; }
            set
            {
                _tickInterval = value;
                Interval = (int) value.TotalMilliseconds;
            }
        }

        /// <summary>
        /// </summary>
        protected internal event EventHandler<EventArgs> TimerTick
        {
            add { _timerTick += value; }
            remove { _timerTick -= value; }
        }

        private void PlaylistTimer_Tick(object sender, EventArgs e)
        {
            if (_timerTick != null)
                _timerTick(sender, e);
        }

        /// <summary>
        /// </summary>
        protected internal void Reset()
        {
            Stop();
            Start();
        }
    }
}