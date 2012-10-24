#region using declarations

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Design;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Windows.Forms.Design;

#endregion

namespace DigitallyImported.Controls.Windows
{
    // using Microsoft.VisualBasic.CompilerServices;

    [DefaultProperty("Color"), DefaultEvent("ColorChanged")]
    public partial class ColorPicker : Control
    {
        private const string DefaultColorName = "Black";
        private readonly EditorService _EditorService;
        private bool _TextDisplayed;
        [AccessedThroughProperty("_CheckBox")] private CheckBox __CheckBox;

        public ColorPicker()
            : this(Color.FromName("Black"))
        {
        }

        public ColorPicker(Color c)
        {
            _TextDisplayed = true;
            _CheckBox = new CheckBox
                {Appearance = Appearance.Button, Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleCenter};
            SetColor(c);
            Controls.Add(_CheckBox);
            _EditorService = new EditorService(this);
        }

        private CheckBox _CheckBox
        {
            get { return __CheckBox; }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (__CheckBox != null)
                {
                    __CheckBox.CheckStateChanged -= OnCheckStateChanged;
                }
                __CheckBox = value;
                if (__CheckBox != null)
                {
                    __CheckBox.CheckStateChanged += OnCheckStateChanged;
                }
            }
        }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public override Color BackColor
        {
            get { return base.BackColor; }
            set { base.BackColor = value; }
        }

        [DefaultValue(typeof (Color), "Black"), Description("The currently selected color."), Category("Appearance")]
        public Color Color
        {
            get { return _CheckBox.BackColor; }
            set
            {
                SetColor(value);
                EventHandler colorChangedEvent = ColorChanged;
                if (colorChangedEvent != null)
                {
                    colorChangedEvent(this, EventArgs.Empty);
                }
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public override Color ForeColor
        {
            get { return base.ForeColor; }
            set { base.ForeColor = value; }
        }

        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public override string Text
        {
            get { return base.Text; }
            set { base.Text = value; }
        }

        [Category("Appearance"),
         Description("True meanse the control displays the currently selected color's name, False otherwise."),
         DefaultValue(true)]
        public bool TextDisplayed
        {
            get { return _TextDisplayed; }
            set
            {
                _TextDisplayed = value;
                SetColor(Color);
            }
        }

        public event EventHandler ColorChanged;

        private void CloseDropDown()
        {
            _EditorService.CloseDropDown();
        }

        private Color GetInvertedColor(Color c)
        {
            if (((c.R + c.G) + c.B) > 0x17e)
            {
                return Color.Black;
            }
            return Color.White;
        }

        private void OnCheckStateChanged(object sender, EventArgs e)
        {
            if (_CheckBox.CheckState == CheckState.Checked)
            {
                ShowDropDown();
            }
            else
            {
                CloseDropDown();
            }
        }

        private void SetColor(Color c)
        {
            _CheckBox.BackColor = c;
            _CheckBox.ForeColor = GetInvertedColor(c);
            _CheckBox.Text = _TextDisplayed ? c.Name : string.Empty;
        }

        private void ShowDropDown()
        {
            try
            {
                var editor = new ColorEditor();
                Color color = Color;
                object objectValue = RuntimeHelpers.GetObjectValue(editor.EditValue(_EditorService, color));
                if ((objectValue != null) && !_EditorService.Canceled)
                {
                    Color = (Color) objectValue;
                }
                _CheckBox.CheckState = CheckState.Unchecked;
            }
            catch (Exception exception1)
            {
                // ProjectData.SetProjectError(exception1);
                Trace.WriteLine(exception1.ToString());
                // ProjectData.ClearProjectError();
            }
        }

        #region Nested type: DropDownForm

        private class DropDownForm : Form
        {
            private bool _Canceled;
            private bool _CloseDropDownCalled;

            public DropDownForm()
            {
                FormBorderStyle = FormBorderStyle.None;
                ShowInTaskbar = false;
                KeyPreview = true;
                StartPosition = FormStartPosition.Manual;
                var panel = new Panel {BorderStyle = BorderStyle.FixedSingle, Dock = DockStyle.Fill};
                Controls.Add(panel);
            }

            public bool Canceled
            {
                get { return _Canceled; }
            }

            public void CloseDropDown()
            {
                _CloseDropDownCalled = true;
                Hide();
            }

            protected override void OnDeactivate(EventArgs e)
            {
                Owner = null;
                base.OnDeactivate(e);
                if (!_CloseDropDownCalled)
                {
                    _Canceled = true;
                }
                Hide();
            }

            protected override void OnKeyDown(KeyEventArgs e)
            {
                base.OnKeyDown(e);
                if ((e.Modifiers == Keys.None) && (e.KeyCode == Keys.Escape))
                {
                    Hide();
                }
            }

            public void SetControl(Control ctl)
            {
                (Controls[0]).Controls.Add(ctl);
            }
        }

        #endregion

        #region Nested type: EditorService

        private class EditorService : IWindowsFormsEditorService, IServiceProvider
        {
            private readonly ColorPicker _Picker;
            private bool _Canceled;
            private DropDownForm _DropDownHolder;

            public EditorService(ColorPicker owner)
            {
                _Picker = owner;
            }

            public bool Canceled
            {
                get { return _Canceled; }
            }

            #region IServiceProvider Members

            public object GetService(Type serviceType)
            {
                var obj2 = new object();
                if (serviceType.Equals(typeof (IWindowsFormsEditorService)))
                {
                    return this;
                }
                return obj2;
            }

            #endregion

            #region IWindowsFormsEditorService Members

            public void CloseDropDown()
            {
                if (_DropDownHolder != null)
                {
                    _DropDownHolder.CloseDropDown();
                }
            }

            public void DropDownControl(Control control)
            {
                _Canceled = false;
                _DropDownHolder = new DropDownForm {Bounds = control.Bounds};
                _DropDownHolder.SetControl(control);
                Control parentForm = GetParentForm(_Picker);
                if (parentForm != null && (parentForm is Form))
                {
                    _DropDownHolder.Owner = (Form) parentForm;
                }
                PositionDropDownHolder();
                _DropDownHolder.Show();
                DoModalLoop();
                _Canceled = _DropDownHolder.Canceled;
                _DropDownHolder.Dispose();
                _DropDownHolder = null;
            }

            public DialogResult ShowDialog(Form dialog)
            {
                throw new NotSupportedException();
            }

            #endregion

            private void DoModalLoop()
            {
                while (_DropDownHolder.Visible)
                {
                    Application.DoEvents();
                    MsgWaitForMultipleObjects(1, IntPtr.Zero, 1, 5, 0xff);
                }
            }

            private Control GetParentForm(Control ctl)
            {
                while (ctl.Parent != null)
                {
                    ctl = ctl.Parent;
                }
                return ctl;
            }

            [DllImport("User32", SetLastError = true)]
            private static extern int MsgWaitForMultipleObjects(int nCount, IntPtr pHandles, short bWaitAll,
                                                                int dwMilliseconds, int dwWakeMask);

            private void PositionDropDownHolder()
            {
                Point point = _Picker.Parent.PointToScreen(_Picker.Location);
                Rectangle workingArea = Screen.PrimaryScreen.WorkingArea;
                if (point.X < workingArea.X)
                {
                    point.X = workingArea.X;
                }
                else if ((point.X + _DropDownHolder.Width) > workingArea.Right)
                {
                    point.X = workingArea.Right - _DropDownHolder.Width;
                }
                if (((point.Y + _Picker.Height) + _DropDownHolder.Height) > workingArea.Bottom)
                {
                    point.Offset(0, 0 - _DropDownHolder.Height);
                }
                else
                {
                    point.Offset(0, _Picker.Height);
                }
                _DropDownHolder.Location = point;
            }
        }

        #endregion
    }
}