namespace DigitallyImported.Utilities.Windows
{
    // using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Drawing;
    using System.Drawing.Design;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    using System.Windows.Forms.Design;

    [DefaultProperty("Color"), DefaultEvent("ColorChanged")]
    public partial class ColorPicker : Control
    {
        [AccessedThroughProperty("_CheckBox")]
        private CheckBox __CheckBox;
        private EditorService _EditorService;
        private bool _TextDisplayed;
        private const string DefaultColorName = "Black";

        public event EventHandler ColorChanged;

        public ColorPicker()
            : this(System.Drawing.Color.FromName("Black"))
        {
        }

        public ColorPicker(System.Drawing.Color c)
        {
            this._TextDisplayed = true;
            this._CheckBox = new CheckBox();
            this._CheckBox.Appearance = Appearance.Button;
            this._CheckBox.Dock = DockStyle.Fill;
            this._CheckBox.TextAlign = ContentAlignment.MiddleCenter;
            this.SetColor(c);
            this.Controls.Add(this._CheckBox);
            this._EditorService = new EditorService(this);
        }

        private void CloseDropDown()
        {
            this._EditorService.CloseDropDown();
        }

        private System.Drawing.Color GetInvertedColor(System.Drawing.Color c)
        {
            if (((c.R + c.G) + c.B) > 0x17e)
            {
                return System.Drawing.Color.Black;
            }
            return System.Drawing.Color.White;
        }

        private void OnCheckStateChanged(object sender, EventArgs e)
        {
            if (this._CheckBox.CheckState == CheckState.Checked)
            {
                this.ShowDropDown();
            }
            else
            {
                this.CloseDropDown();
            }
        }

        private void SetColor(System.Drawing.Color c)
        {
            this._CheckBox.BackColor = c;
            this._CheckBox.ForeColor = this.GetInvertedColor(c);
            if (this._TextDisplayed)
            {
                this._CheckBox.Text = c.Name;
            }
            else
            {
                this._CheckBox.Text = string.Empty;
            }
        }

        private void ShowDropDown()
        {
            try
            {
                ColorEditor editor = new ColorEditor();
                System.Drawing.Color color = this.Color;
                object objectValue = RuntimeHelpers.GetObjectValue(editor.EditValue(this._EditorService, color));
                if ((objectValue != null) && !this._EditorService.Canceled)
                {
                    this.Color = (System.Drawing.Color)objectValue;
                }
                this._CheckBox.CheckState = CheckState.Unchecked;
            }
            catch (Exception exception1)
            {
                // ProjectData.SetProjectError(exception1);
                Trace.WriteLine(exception1.ToString());
                // ProjectData.ClearProjectError();
            }
        }

        private CheckBox _CheckBox
        {
            get
            {
                return this.__CheckBox;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this.__CheckBox != null)
                {
                    this.__CheckBox.CheckStateChanged -= new EventHandler(this.OnCheckStateChanged);
                }
                this.__CheckBox = value;
                if (this.__CheckBox != null)
                {
                    this.__CheckBox.CheckStateChanged += new EventHandler(this.OnCheckStateChanged);
                }
            }
        }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public override System.Drawing.Color BackColor
        {
            get
            {
                return base.BackColor;
            }
            set
            {
                base.BackColor = value;
            }
        }

        [DefaultValue(typeof(System.Drawing.Color), "Black"), Description("The currently selected color."), Category("Appearance")]
        public System.Drawing.Color Color
        {
            get
            {
                return this._CheckBox.BackColor;
            }
            set
            {
                this.SetColor(value);
                EventHandler colorChangedEvent = this.ColorChanged;
                if (colorChangedEvent != null)
                {
                    colorChangedEvent(this, EventArgs.Empty);
                }
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public override System.Drawing.Color ForeColor
        {
            get
            {
                return base.ForeColor;
            }
            set
            {
                base.ForeColor = value;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                base.Text = value;
            }
        }

        [Category("Appearance"), Description("True meanse the control displays the currently selected color's name, False otherwise."), DefaultValue(true)]
        public bool TextDisplayed
        {
            get
            {
                return this._TextDisplayed;
            }
            set
            {
                this._TextDisplayed = value;
                this.SetColor(this.Color);
            }
        }

        private class DropDownForm : Form
        {
            private bool _Canceled;
            private bool _CloseDropDownCalled;

            public DropDownForm()
            {
                this.FormBorderStyle = FormBorderStyle.None;
                this.ShowInTaskbar = false;
                this.KeyPreview = true;
                this.StartPosition = FormStartPosition.Manual;
                Panel panel = new Panel();
                panel.BorderStyle = BorderStyle.FixedSingle;
                panel.Dock = DockStyle.Fill;
                this.Controls.Add(panel);
            }

            public void CloseDropDown()
            {
                this._CloseDropDownCalled = true;
                this.Hide();
            }

            protected override void OnDeactivate(EventArgs e)
            {
                this.Owner = null;
                base.OnDeactivate(e);
                if (!this._CloseDropDownCalled)
                {
                    this._Canceled = true;
                }
                this.Hide();
            }

            protected override void OnKeyDown(KeyEventArgs e)
            {
                base.OnKeyDown(e);
                if ((e.Modifiers == Keys.None) && (e.KeyCode == Keys.Escape))
                {
                    this.Hide();
                }
            }

            public void SetControl(Control ctl)
            {
                ((Panel)this.Controls[0]).Controls.Add(ctl);
            }

            public bool Canceled
            {
                get
                {
                    return this._Canceled;
                }
            }
        }

        private class EditorService : IWindowsFormsEditorService, IServiceProvider
        {
            private bool _Canceled;
            private ColorPicker.DropDownForm _DropDownHolder;
            private ColorPicker _Picker;

            public EditorService(ColorPicker owner)
            {
                this._Picker = owner;
            }

            public void CloseDropDown()
            {
                if (this._DropDownHolder != null)
                {
                    this._DropDownHolder.CloseDropDown();
                }
            }

            private void DoModalLoop()
            {
                while (this._DropDownHolder.Visible)
                {
                    Application.DoEvents();
                    MsgWaitForMultipleObjects(1, IntPtr.Zero, 1, 5, 0xff);
                }
            }

            public void DropDownControl(Control control)
            {
                this._Canceled = false;
                this._DropDownHolder = new ColorPicker.DropDownForm();
                this._DropDownHolder.Bounds = control.Bounds;
                this._DropDownHolder.SetControl(control);
                Control parentForm = this.GetParentForm(this._Picker);
                if ((parentForm != null) && (parentForm is Form))
                {
                    this._DropDownHolder.Owner = (Form)parentForm;
                }
                this.PositionDropDownHolder();
                this._DropDownHolder.Show();
                this.DoModalLoop();
                this._Canceled = this._DropDownHolder.Canceled;
                this._DropDownHolder.Dispose();
                this._DropDownHolder = null;
            }

            private Control GetParentForm(Control ctl)
            {
                while (ctl.Parent != null)
                {
                    ctl = ctl.Parent;
                }
                return ctl;
            }

            public object GetService(System.Type serviceType)
            {
                object obj2 = new object();
                if (serviceType.Equals(typeof(IWindowsFormsEditorService)))
                {
                    return this;
                }
                return obj2;
            }

            [DllImport("User32", SetLastError = true)]
            private static extern int MsgWaitForMultipleObjects(int nCount, IntPtr pHandles, short bWaitAll, int dwMilliseconds, int dwWakeMask);
            private void PositionDropDownHolder()
            {
                Point point = this._Picker.Parent.PointToScreen(this._Picker.Location);
                Rectangle workingArea = Screen.PrimaryScreen.WorkingArea;
                if (point.X < workingArea.X)
                {
                    point.X = workingArea.X;
                }
                else if ((point.X + this._DropDownHolder.Width) > workingArea.Right)
                {
                    point.X = workingArea.Right - this._DropDownHolder.Width;
                }
                if (((point.Y + this._Picker.Height) + this._DropDownHolder.Height) > workingArea.Bottom)
                {
                    point.Offset(0, 0 - this._DropDownHolder.Height);
                }
                else
                {
                    point.Offset(0, this._Picker.Height);
                }
                this._DropDownHolder.Location = point;
            }

            public DialogResult ShowDialog(Form dialog)
            {
                throw new NotSupportedException();
            }

            public bool Canceled
            {
                get
                {
                    return this._Canceled;
                }
            }
        }
    }
}

