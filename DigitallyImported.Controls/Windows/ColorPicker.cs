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
            get => __CheckBox;
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
            get => base.BackColor;
            set => base.BackColor = value;
        }

        /// <summary>
        /// 
        /// </summary>
        [DefaultValue(typeof (Color), "Black"), Description("The currently selected color."), Category("Appearance")]
        public Color Color
        {
            get => _CheckBox.BackColor;
            set
            {
                SetColor(value);
                EventHandler colorChangedEvent = ColorChanged;
                colorChangedEvent?.Invoke(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public override Color ForeColor
        {
            get => base.ForeColor;
            set => base.ForeColor = value;
        }

        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public override string Text
        {
            get => base.Text;
            set => base.Text = value;
        }

        [Category("Appearance"),
         Description("True meanse the control displays the currently selected color's name, False otherwise."),
         DefaultValue(true)]
        public bool TextDisplayed
        {
            get => _TextDisplayed;
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
            return ((c.R + c.G) + c.B) > 0x17e ? Color.Black : Color.White;
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
                var objectValue = RuntimeHelpers.GetObjectValue(editor.EditValue(_EditorService, color));
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
            private bool _closeDropDownCalled;

            public DropDownForm()
            {
                FormBorderStyle = FormBorderStyle.None;
                ShowInTaskbar = false;
                KeyPreview = true;
                StartPosition = FormStartPosition.Manual;
                var panel = new Panel {BorderStyle = BorderStyle.FixedSingle, Dock = DockStyle.Fill};
                Controls.Add(panel);
            }

            public bool Canceled { get; private set; }

            public void CloseDropDown()
            {
                _closeDropDownCalled = true;
                Hide();
            }

            protected override void OnDeactivate(EventArgs e)
            {
                Owner = null;
                base.OnDeactivate(e);
                if (!_closeDropDownCalled)
                {
                    Canceled = true;
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
            private readonly ColorPicker _picker;
            private bool _canceled;
            private DropDownForm _dropDownHolder;

            public EditorService(ColorPicker owner)
            {
                _picker = owner;
            }

            public bool Canceled => _canceled;

            #region IServiceProvider Members

            public object GetService(Type serviceType)
            {
                var obj2 = new object();
                return serviceType == typeof (IWindowsFormsEditorService) ? this : obj2;
            }

            #endregion

            #region IWindowsFormsEditorService Members

            public void CloseDropDown()
            {
                _dropDownHolder?.CloseDropDown();
            }

            public void DropDownControl(Control control)
            {
                _canceled = false;
                _dropDownHolder = new DropDownForm {Bounds = control.Bounds};
                _dropDownHolder.SetControl(control);
                Control parentForm = GetParentForm(_picker);
                if (parentForm is Form form)
                {
                    _dropDownHolder.Owner = form;
                }
                PositionDropDownHolder();
                _dropDownHolder.Show();
                DoModalLoop();
                _canceled = _dropDownHolder.Canceled;
                _dropDownHolder.Dispose();
                _dropDownHolder = null;
            }

            public DialogResult ShowDialog(Form dialog)
            {
                throw new NotSupportedException();
            }

            #endregion

            private void DoModalLoop()
            {
                while (_dropDownHolder.Visible)
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
                Point point = _picker.Parent.PointToScreen(_picker.Location);
                Rectangle workingArea = Screen.PrimaryScreen.WorkingArea;
                if (point.X < workingArea.X)
                {
                    point.X = workingArea.X;
                }
                else if ((point.X + _dropDownHolder.Width) > workingArea.Right)
                {
                    point.X = workingArea.Right - _dropDownHolder.Width;
                }
                if (((point.Y + _picker.Height) + _dropDownHolder.Height) > workingArea.Bottom)
                {
                    point.Offset(0, 0 - _dropDownHolder.Height);
                }
                else
                {
                    point.Offset(0, _picker.Height);
                }
                _dropDownHolder.Location = point;
            }
        }

        #endregion
    }
}