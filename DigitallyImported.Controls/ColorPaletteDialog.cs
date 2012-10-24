#region using declarations

using System;
using System.Drawing;
using System.Windows.Forms;

#endregion

namespace DigitallyImported.Controls
{
    /// <summary>
    /// </summary>
    public partial class ColorPaletteDialog : Form
    {
        private readonly Panel[] _panel = new Panel[40];
        private readonly Button cancelButton = new Button();

        private readonly Color[] color = new Color[40]
            {
                //row 1
                Color.FromArgb(0, 0, 0), Color.FromArgb(153, 51, 0),
                Color.FromArgb(51, 51, 0), Color.FromArgb(0, 51, 0),
                Color.FromArgb(0, 51, 102), Color.FromArgb(0, 0, 128),
                Color.FromArgb(51, 51, 153), Color.FromArgb(51, 51, 51),

                //row 2
                Color.FromArgb(128, 0, 0), Color.FromArgb(255, 102, 0),
                Color.FromArgb(128, 128, 0), Color.FromArgb(0, 128, 0),
                Color.FromArgb(0, 128, 128), Color.FromArgb(0, 0, 255),
                Color.FromArgb(102, 102, 153), Color.FromArgb(128, 128, 128),

                //row 3
                Color.FromArgb(255, 0, 0), Color.FromArgb(255, 153, 0),
                Color.FromArgb(153, 204, 0), Color.FromArgb(51, 153, 102),
                Color.FromArgb(51, 204, 204), Color.FromArgb(51, 102, 255),
                Color.FromArgb(128, 0, 128), Color.FromArgb(153, 153, 153),

                //row 4
                Color.FromArgb(255, 0, 255), Color.FromArgb(255, 204, 0),
                Color.FromArgb(255, 255, 0), Color.FromArgb(0, 255, 0),
                Color.FromArgb(0, 255, 255), Color.FromArgb(0, 204, 255),
                Color.FromArgb(153, 51, 102), Color.FromArgb(192, 192, 192),

                //row 5
                Color.FromArgb(255, 153, 204), Color.FromArgb(255, 204, 153),
                Color.FromArgb(255, 255, 153), Color.FromArgb(204, 255, 204),
                Color.FromArgb(204, 255, 255), Color.FromArgb(153, 204, 255),
                Color.FromArgb(204, 153, 255), Color.FromArgb(255, 255, 255)
            };

        private readonly string[] colorName = new string[40]
            {
                "Black", "Brown", "Olive Green", "Dark Green", "Dark Teal",
                "Dark Blue", "Indigo", "Gray-80%",
                "Dark Red", "Orange", "Dark Yellow", "Green", "Teal", "Blue",
                "Blue-Gray", "Gray-50%",
                "Red", "Light Orange", "Lime", "Sea Green", "Aqua", "Light Blue",
                "Violet", "Gray-40%",
                "Pink", "Gold", "Yellow", "Bright Green", "Turquoise", "Sky Blue",
                "Plum", "Gray-25%",
                "Rose", "Tan", "Light Yellow", "Light Green", "Light Turquoise",
                "Pale Blue", "Lavender", "White"
            };

        private readonly Button moreColorsButton = new Button();
        private byte max = 40;
        private Color selectedColor;

        /// <summary>
        /// </summary>
        /// <param name="x"> </param>
        /// <param name="y"> </param>
        public ColorPaletteDialog(int x, int y)
        {
            Size = new Size(158, 132);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MinimizeBox = MaximizeBox = ControlBox = false;
            ShowInTaskbar = false;
            CenterToScreen();
            Location = new Point(x, y);

            BuildPalette();

            moreColorsButton.Text = "More colors ...";
            moreColorsButton.Size = new Size(142, 22);
            moreColorsButton.Location = new Point(5, 99);
            moreColorsButton.Click += moreColorsButton_Click;
            moreColorsButton.FlatStyle = FlatStyle.Popup;
            Controls.Add(moreColorsButton);

            //"invisible" button to cancel at Escape
            cancelButton.Size = new Size(5, 5);
            cancelButton.Location = new Point(-10, -10);
            cancelButton.Click += cancelButton_Click;
            Controls.Add(cancelButton);
            cancelButton.TabIndex = 0;
            CancelButton = cancelButton;
        }

        /// <summary>
        /// </summary>
        public Color Color
        {
            get { return selectedColor; }
        }

        private void BuildPalette()
        {
            byte pwidth = 16;
            byte pheight = 16;
            byte pdistance = 2;
            byte border = 5;
            int x = border, y = border;
            var toolTip = new ToolTip();

            for (var i = 0; i < max; i++)
            {
                _panel[i] = new Panel {Height = pwidth, Width = pheight, Location = new Point(x, y)};
                toolTip.SetToolTip(_panel[i], colorName[i]);

                Controls.Add(_panel[i]);

                if (x < (7*(pwidth + pdistance)))
                    x += pwidth + pdistance;
                else
                {
                    x = border;
                    y += pheight + pdistance;
                }

                _panel[i].BackColor = color[i];
                _panel[i].MouseEnter += OnMouseEnterPanel;
                _panel[i].MouseLeave += OnMouseLeavePanel;
                _panel[i].MouseDown += OnMouseDownPanel;
                _panel[i].MouseUp += OnMouseUpPanel;
                _panel[i].Paint += OnPanelPaint;
            }
        }

        private void moreColorsButton_Click(object sender, EventArgs e)
        {
            var colDialog = new ColorDialog {FullOpen = true};
            colDialog.ShowDialog();
            selectedColor = colDialog.Color;
            colDialog.Dispose();

            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void OnMouseEnterPanel(object sender, EventArgs e)
        {
            DrawPanel(sender, 1);
        }

        private void OnMouseLeavePanel(object sender, EventArgs e)
        {
            DrawPanel(sender, 0);
        }

        private void OnMouseDownPanel(object sender, MouseEventArgs e)
        {
            DrawPanel(sender, 2);
        }

        private void OnMouseUpPanel(object sender, MouseEventArgs e)
        {
            using (var panel = (Panel) sender)
            {
                selectedColor = panel.BackColor;
            }
            Close();
        }

        private void DrawPanel(object sender, byte state)
        {
            var panel = (Panel) sender;

            var g = panel.CreateGraphics();

            Pen pen1, pen2;

            switch (state)
            {
                case 1:
                    pen1 = new Pen(SystemColors.ControlLightLight);
                    pen2 = new Pen(SystemColors.ControlDarkDark);
                    break;
                case 2:
                    pen1 = new Pen(SystemColors.ControlDarkDark);
                    pen2 = new Pen(SystemColors.ControlLightLight);
                    break;
                default:
                    pen1 = new Pen(SystemColors.ControlDark);
                    pen2 = new Pen(SystemColors.ControlDark);
                    break;
            }

            var r = panel.ClientRectangle;
            var p1 = new Point(r.Left, r.Top); //top left
            var p2 = new Point(r.Right - 1, r.Top); //top right
            var p3 = new Point(r.Left, r.Bottom - 1); //bottom left
            var p4 = new Point(r.Right - 1, r.Bottom - 1); //bottom right

            g.DrawLine(pen1, p1, p2);
            g.DrawLine(pen1, p1, p3);
            g.DrawLine(pen2, p2, p4);
            g.DrawLine(pen2, p3, p4);
        }

        private void OnPanelPaint(Object sender, PaintEventArgs e)
        {
            DrawPanel(sender, 0);
        }
    }
}