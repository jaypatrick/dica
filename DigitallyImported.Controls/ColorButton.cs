using System;
using System.Drawing;
using System.Windows.Forms;

namespace DigitallyImported.Utilities
{
    public partial class ColorButton : UserControl
    {
        /// <summary>
        /// 
        /// </summary>
        public ColorButton()
        {
            MouseEnter += OnMouseEnter;
            MouseLeave += OnMouseLeave;
            MouseUp += OnMouseUp;
            Paint += ButtonPaint;
        }

        /// <summary>
        /// 
        /// </summary>
        public Color CenterColor { get; set; }

        private void OnMouseEnter(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void OnMouseLeave(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void OnMouseUp(object sender, MouseEventArgs e)
        {
            Invalidate();
        }

        private void ButtonPaint(Object sender, PaintEventArgs e)
        {
            var g = e.Graphics;

            var r = ClientRectangle;

            byte border = 4;
            byte right_border = 15;

            var rc = new Rectangle(r.Left + border, r.Top + border,
                                   r.Width - border - right_border - 1, r.Height - border*2 - 1);

            var centerColorBrush = new SolidBrush(CenterColor);
            g.FillRectangle(centerColorBrush, rc);

            var pen = new Pen(Color.Black);
            g.DrawRectangle(pen, rc);

            //draw the arrow
            var p1 = new Point(r.Width - 9, r.Height/2 - 1);
            var p2 = new Point(r.Width - 5, r.Height/2 - 1);
            g.DrawLine(pen, p1, p2);

            p1 = new Point(r.Width - 8, r.Height/2);
            p2 = new Point(r.Width - 6, r.Height/2);
            g.DrawLine(pen, p1, p2);

            p1 = new Point(r.Width - 7, r.Height/2);
            p2 = new Point(r.Width - 7, r.Height/2 + 1);
            g.DrawLine(pen, p1, p2);

            //draw the divider line
            pen = new Pen(SystemColors.ControlDark);
            p1 = new Point(r.Width - 12, 4);
            p2 = new Point(r.Width - 12, r.Height - 5);
            g.DrawLine(pen, p1, p2);

            pen = new Pen(SystemColors.ControlLightLight);
            p1 = new Point(r.Width - 11, 4);
            p2 = new Point(r.Width - 11, r.Height - 5);
            g.DrawLine(pen, p1, p2);
        }
    }
}