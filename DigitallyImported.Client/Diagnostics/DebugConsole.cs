#define TRACE

#region using declarations

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows.Forms;

#endregion

namespace DigitallyImported.Client.Diagnostics
{
    /// <summary>
    ///   Summary description for DebugConsole.
    /// </summary>
    public class DebugConsoleWrapper : Form
    {
        /// <summary>
        ///   Required designer variable.
        /// </summary>
        private readonly Container _components = null;

        public StringBuilder Buffer = new StringBuilder();

        private Button _btnClear;
        private Button _btnSave;
        private CheckBox _checkScroll;
        private CheckBox _checkTop;
        private ColumnHeader _col1;
        private ColumnHeader _col2;
        private ColumnHeader _col3;
        private ListViewItem.ListViewSubItem _currentMsgItem;
        private int _eventCounter;
        private ListView _outputView;
        private Panel _panel2;
        private SaveFileDialog _saveFileDlg;
        private DefaultTraceListener _tracer = new DefaultTraceListener();

        /// <summary>
        /// </summary>
        public DebugConsoleWrapper()
        {
            InitializeComponent();
        }

        /// <summary>
        ///   Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_components != null)
                {
                    _components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// </summary>
        public void CreateEventRow()
        {
            DateTime d = DateTime.Now;

            // create a ListView item/subitems : [event nb] - [time] - [empty string]
            string msg1 = (++_eventCounter).ToString(CultureInfo.InvariantCulture);
            string msg2 = d.ToLongTimeString();
            var elem = new ListViewItem(msg1);
            elem.SubItems.Add(msg2);
            elem.SubItems.Add("");
            // this.OutputView.Items.Add(elem);

            if (_outputView.InvokeRequired)
                _outputView.Invoke((Action) (() => _outputView.Items.Add(elem)));
            else
                _outputView.Items.Add(elem);

            // we save the message item for incoming text updates
            _currentMsgItem = elem.SubItems[2];
        }


        /// <summary>
        /// </summary>
        public void UpdateCurrentRow( /*bool CreateRowNextTime*/)
        {
            if (_currentMsgItem == null) CreateEventRow();
            if (_currentMsgItem != null)
            {
                _currentMsgItem.Text = Buffer.ToString();

                // if null, a new row will be created next time this function is called
                if (true) _currentMsgItem = null;
            }

            // this is the autoscroll, move to the last element available in the ListView
            if (_checkScroll.CheckState == CheckState.Checked)
            {
                _outputView.EnsureVisible(_outputView.Items.Count - 1);
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            _saveFileDlg.Filter = "Text file (*.txt)|*.txt|All files (*.*)|*.*";
            _saveFileDlg.FileName = "log.txt";
            _saveFileDlg.ShowDialog();

            var fileInfo = new FileInfo(_saveFileDlg.FileName);

            // create a new textfile and export all lines
            StreamWriter s = fileInfo.CreateText();
            for (int i = 0; i < _outputView.Items.Count; i++)
            {
                var sb = new StringBuilder();
                sb.Append(_outputView.Items[i].SubItems[0].Text);
                sb.Append("\t");
                sb.Append(_outputView.Items[i].SubItems[1].Text);
                sb.Append("\t");
                sb.Append(_outputView.Items[i].SubItems[2].Text);
                s.WriteLine(sb.ToString());
            }

            s.Close();
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            _eventCounter = 0;
            _outputView.Items.Clear();
            _currentMsgItem = null;
            Buffer = new StringBuilder();
        }

        private void CheckTop_CheckedChanged(object sender, EventArgs e)
        {
            TopMost = _checkTop.CheckState == CheckState.Checked;
        }

        private void CheckScroll_CheckedChanged(object sender, EventArgs e)
        {
            if (_checkScroll.CheckState == CheckState.Checked)
                _outputView.EnsureVisible(_outputView.Items.Count - 1);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///   Required method for Designer support - do not modify
        ///   the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this._btnSave = new System.Windows.Forms.Button();
            this._btnClear = new System.Windows.Forms.Button();
            this._saveFileDlg = new System.Windows.Forms.SaveFileDialog();
            this._checkScroll = new System.Windows.Forms.CheckBox();
            this._outputView = new System.Windows.Forms.ListView();
            this._col1 = new System.Windows.Forms.ColumnHeader();
            this._col2 = new System.Windows.Forms.ColumnHeader();
            this._col3 = new System.Windows.Forms.ColumnHeader();
            this._checkTop = new System.Windows.Forms.CheckBox();
            this._panel2 = new System.Windows.Forms.Panel();
            this._panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnSave
            // 
            this._btnSave.Location = new System.Drawing.Point(8, 16);
            this._btnSave.Name = "_btnSave";
            this._btnSave.Size = new System.Drawing.Size(64, 24);
            this._btnSave.TabIndex = 8;
            this._btnSave.Text = "Save";
            this._btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // BtnClear
            // 
            this._btnClear.Location = new System.Drawing.Point(80, 16);
            this._btnClear.Name = "_btnClear";
            this._btnClear.Size = new System.Drawing.Size(64, 24);
            this._btnClear.TabIndex = 8;
            this._btnClear.Text = "Clear";
            this._btnClear.Click += new System.EventHandler(this.BtnClear_Click);
            // 
            // CheckScroll
            // 
            this._checkScroll.Checked = true;
            this._checkScroll.CheckState = System.Windows.Forms.CheckState.Checked;
            this._checkScroll.Location = new System.Drawing.Point(152, 16);
            this._checkScroll.Name = "_checkScroll";
            this._checkScroll.Size = new System.Drawing.Size(80, 16);
            this._checkScroll.TabIndex = 8;
            this._checkScroll.Text = "autoscroll";
            this._checkScroll.CheckedChanged += new System.EventHandler(this.CheckScroll_CheckedChanged);
            // 
            // OutputView
            // 
            this._outputView.AutoArrange = false;
            this._outputView.BackColor = System.Drawing.Color.RoyalBlue;
            this._outputView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[]
                {
                    this._col1,
                    this._col2,
                    this._col3
                });
            this._outputView.Dock = System.Windows.Forms.DockStyle.Fill;
            this._outputView.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular,
                                                            System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this._outputView.ForeColor = System.Drawing.Color.Yellow;
            this._outputView.Location = new System.Drawing.Point(0, 0);
            this._outputView.Name = "_outputView";
            this._outputView.Size = new System.Drawing.Size(760, 286);
            this._outputView.TabIndex = 7;
            this._outputView.UseCompatibleStateImageBehavior = false;
            this._outputView.View = System.Windows.Forms.View.Details;
            // 
            // Col1
            // 
            this._col1.Text = "#";
            this._col1.Width = 30;
            // 
            // Col2
            // 
            this._col2.Text = "Time";
            this._col2.Width = 101;
            // 
            // Col3
            // 
            this._col3.Text = "Message";
            this._col3.Width = 619;
            // 
            // CheckTop
            // 
            this._checkTop.Location = new System.Drawing.Point(240, 16);
            this._checkTop.Name = "_checkTop";
            this._checkTop.Size = new System.Drawing.Size(96, 16);
            this._checkTop.TabIndex = 8;
            this._checkTop.Text = "always on top";
            this._checkTop.CheckedChanged += new System.EventHandler(this.CheckTop_CheckedChanged);
            // 
            // panel2
            // 
            this._panel2.Controls.Add(this._btnSave);
            this._panel2.Controls.Add(this._btnClear);
            this._panel2.Controls.Add(this._checkScroll);
            this._panel2.Controls.Add(this._checkTop);
            this._panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._panel2.Location = new System.Drawing.Point(0, 286);
            this._panel2.Name = "_panel2";
            this._panel2.Size = new System.Drawing.Size(760, 48);
            this._panel2.TabIndex = 8;
            // 
            // DebugConsoleWrapper
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(760, 334);
            this.Controls.Add(this._outputView);
            this.Controls.Add(this._panel2);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MinimumSize = new System.Drawing.Size(390, 160);
            this.Name = "DebugConsoleWrapper";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Debug Console";
            this._panel2.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion
    }

    // DebugConsole Singleton
    internal sealed class DebugConsole : TraceListener
    {
        public static readonly DebugConsole Instance =
            new DebugConsole();

        private readonly DebugConsoleWrapper _debugForm = new DebugConsoleWrapper();

        // if this parameter is set to true, a call to WriteLine will always create a new row
        // (if false, it may be appended to the current buffer created with some Write calls)
        private bool _useCrWl = true;

        private DebugConsole()
        {
            _debugForm.Show();
        }

        public void Init(bool useDebugOutput, bool useCrForWriteLine)
        {
            var dtl = new DefaultTraceListener();

            if (useDebugOutput)
            {
                Debug.Listeners.Add(this);
                Debug.Listeners.Add(dtl);
            }
            else
            {
                Trace.Listeners.Add(this);
                Trace.Listeners.Add(dtl);
            }

            _useCrWl = useCrForWriteLine;
        }

        public override void Write(string message)
        {
            _debugForm.Buffer.Append(message);

            if (_debugForm.InvokeRequired && !_debugForm.Disposing)
                _debugForm.Invoke((Action) (() => _debugForm.UpdateCurrentRow()));

            else
                _debugForm.UpdateCurrentRow();

            // DebugForm.BeginInvoke(Action(delegate() { Console.WriteLine("Simple Anonymous Method Called"); }));
        }

        public override void WriteLine(string message)
        {
            if (_useCrWl)
            {
                _debugForm.CreateEventRow();
                _debugForm.Buffer = new StringBuilder();
            }

            _debugForm.Buffer.Append(message);

            if (_debugForm.InvokeRequired && !_debugForm.Disposing)
                _debugForm.Invoke((Action) (() => _debugForm.UpdateCurrentRow()));
            else
                _debugForm.UpdateCurrentRow();

            _debugForm.Buffer = new StringBuilder();
        }
    }
}