#region using declarations

using System;
using System.ComponentModel;
using System.Configuration;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using DigitallyImported.Components;
using DigitallyImported.Configuration.Properties;
using DigitallyImported.Controls;
using DigitallyImported.Controls.Windows;
using P = DigitallyImported.Resources.Properties;
using SortOrder = DigitallyImported.Components.SortOrder;

#endregion

// using DigitallyImported.Player;

namespace DigitallyImported.Client
{
    /// <summary>
    ///   Summary description for DIAdmin.
    /// </summary>
    public class AdminForm : BaseForm
    {
        private ErrorProvider AdminErrorProvider;
        private LinkLabel ListenKeyLinkLabel;
        private TextBox ListenKeyTextbox;
        private TextBox PasswordTextbox;
        private TextBox UsernameTextbox;
        private Color _color = Color.Black;
        private TimeSpan _refreshInterval;
        private ToolStrip adminFormToolStrip;
        private ColorPicker alternatingChannelColorPicker;
        private DomainUpDown calendarFormatValue;
        private ColorPicker channelColorPicker;
        private ColorButton colorButton;
        private IContainer components;
        private Label label1;
        private Label label10;
        private Label label11;
        private Label label12;
        private Label label13;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;

        // PLAYERTYPE RADIO BUTTONS
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label lable12;
        private RadioButton[] playerTypes;
        private GroupBox premiumInfoGroupBox;
        private Panel previousChannelPanel;
        private RefreshCounter refreshCounter1;
        private RadioButton rememberNoRadio;
        private RadioButton rememberYesRadio;
        private ColorPicker selectedChannelColorPicker;
        private CheckedListBox serviceLevelValues;
        private Panel showToastPanel;
        private DomainUpDown sortByValue;
        private DomainUpDown sortOrderValue;
        private RadioButton toastNoRadio;
        private RadioButton toastYesRadio;
        private ToolStripButton toolStripLoadDefaults;
        private ToolStripButton toolStripSave;
        private ToolStripLabel toolStripStatusLabel;
        private Label trackBarValue;
        private TrackBar transparencyTrackBar;

        /// <summary>
        /// </summary>
        public AdminForm()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();

            Icon = P.Resources.DIIconNew;
            CenterToScreen();
        }

        /// <summary>
        ///   Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            bool serviceLevelChanged = false;

            if (!ValidateChildren()) return;
            Settings.Default.PlaylistRefreshInterval = refreshCounter1.CountdownTimer.Value.TimeOfDay;


            Settings.Default.SelectedChannelBackground = selectedChannelColorPicker.Color;
            Settings.Default.AlternatingChannelBackground = alternatingChannelColorPicker.Color;
            Settings.Default.ChannelBackground = channelColorPicker.Color;
            Settings.Default.ShowUserToast = toastYesRadio.Checked;
            Settings.Default.RememberPreviousChannel = rememberYesRadio.Checked;
            Settings.Default.ChannelSortOrder = sortOrderValue.Text;
            Settings.Default.ChannelSortBy = sortByValue.Text;
            Settings.Default.CalendarFormat = calendarFormatValue.Text;
            Settings.Default.FormOpacityValue = ((double) transparencyTrackBar.Value/100);

            foreach (object item in serviceLevelValues.CheckedItems)
            {
                if (
                    !Settings.Default.SubscriptionType.Equals(item.ToString(),
                                                              StringComparison.CurrentCultureIgnoreCase))
                    serviceLevelChanged = true;

                Settings.Default.SubscriptionType = item.ToString();
                break; // only get the first one selected.
            }


            Settings.Default.Username = UsernameTextbox.Text;
            Settings.Default.Password = PasswordTextbox.Text;
            Settings.Default.ListenKey = ListenKeyTextbox.Text;

            Settings.Default.Save();

            if (serviceLevelChanged)
            {
                switch (
                    MessageBox.Show(this,
                                    string.Format(P.Resources.ServiceLevelChangedMessage, Environment.NewLine,
                                                  P.Resources.RestartApplicationMessage)
                                    , P.Resources.RestartApplicationMessage
                                    , MessageBoxButtons.YesNo
                                    , MessageBoxIcon.Question
                                    , MessageBoxDefaultButton.Button1))
                {
                    case DialogResult.Yes:
                        Application.Restart();
                        break;
                    case DialogResult.No:
                        DialogResult = DialogResult.OK;
                        break;
                }
            }

            DialogResult = DialogResult.OK;
        }

        private void DIAdmin_Load(object sender, EventArgs e)
        {
            refreshCounter1.Stop();
            bindEnums();
            bindControls();

            trackBarValue.Text = transparencyTrackBar.Value.ToString(CultureInfo.InvariantCulture);

            Settings.Default.SettingChanging += Default_SettingChanging;
            Settings.Default.SettingsSaving += Default_SettingsSaving;

            //int[] colorInts = new int[colors.Length];


            //        for (int i = 0; i < colors.Length; i++)
            //        {
            //            colorInts[i] = Math.Abs(colors[i].ToArgb());
            //        }

            //        this.channelColorPicker.Color = Settings.Default.ChannelBackground;
            //        this.alternatingChannelColorPicker.Color = Settings.Default.AlternatingChannelBackground;
            //        this.selectedChannelColorPicker.Color = Settings.Default.SelectedChannelBackground;
        }

        private void colorButton_Click(object sender, EventArgs e)
        {
            var callingButton = (ColorButton) sender;
            var p = new Point(callingButton.Left, callingButton.Top + callingButton.Height);
            p = PointToScreen(p);

            var clDlg = new ColorPaletteDialog(p.X, p.Y);

            clDlg.ShowDialog();

            if (clDlg.DialogResult == DialogResult.OK)
                _color = clDlg.Color;

            callingButton.CenterColor = _color;

            Invalidate();

            clDlg.Dispose();
        }

        private void Default_SettingChanging(object sender, SettingChangingEventArgs e)
        {
            // this.txtPlaylistRefresh.Text = e.SettingName + (int)e.NewValue;
        }

        private void Default_SettingsSaving(object sender, CancelEventArgs e)
        {
            // PERFORM VALIDATION HERE!
        }

        private void ChannelButton_Click(object sender, EventArgs e)
        {
        }

        private void selectedChannelButton_Click(object sender, EventArgs e)
        {
            // this.selectedChannelColor.ShowDialog();
        }

        private void alternatingChannelButton_Click(object sender, EventArgs e)
        {
            // this.alternatingChannelColor.ShowDialog();
        }

        private void reloadDefaultsButton_Click(object sender, EventArgs e)
        {
            Settings.Default.Reset();
            bindControls();
        }

        private void bindControls()
        {
            refreshCounter1.CountdownTimer.Value = new DateTime(2000, 1, 1).Add(Settings.Default.PlaylistRefreshInterval);
            selectedChannelColorPicker.Color = Settings.Default.SelectedChannelBackground;
            alternatingChannelColorPicker.Color = Settings.Default.AlternatingChannelBackground;
            channelColorPicker.Color = Settings.Default.ChannelBackground;

            // set selected values
            sortOrderValue.Text = Settings.Default.ChannelSortOrder;
            sortByValue.Text = Settings.Default.ChannelSortBy;
            transparencyTrackBar.Value = ((int) (Settings.Default.FormOpacityValue*100));
            calendarFormatValue.Text = Settings.Default.CalendarFormat;

            serviceLevelValues.ClearSelected();
            serviceLevelValues.SetItemChecked(serviceLevelValues.FindStringExact(Settings.Default.SubscriptionType),
                                              true);

            UsernameTextbox.Text = Settings.Default.Username;
            PasswordTextbox.Text = Settings.Default.Password;
            ListenKeyTextbox.Text = Settings.Default.ListenKey;

            // set the Listen Key link here
            //LinkLabel.Link link = new LinkLabel.Link();
            //link.LinkData = P.Resources.ListenKeyLinkData;
            ListenKeyLinkLabel.Links[0].LinkData = P.Resources.ListenKeyLinkData;

            // radio buttons
            if (!Settings.Default.RememberPreviousChannel) rememberNoRadio.PerformClick();

            if (!Settings.Default.ShowUserToast) toastNoRadio.PerformClick();

            togglePremiumTextboxes(serviceLevelValues.SelectedIndex);
        }

        private void bindEnums()
        {
            // bind to enums
            sortOrderValue.Items.AddRange(Enum.GetNames(typeof (SortOrder)));
            sortByValue.Items.AddRange(Enum.GetNames(typeof (SortBy)));
            serviceLevelValues.Items.AddRange(Enum.GetNames(typeof (SubscriptionLevel)));
            calendarFormatValue.Items.AddRange(Enum.GetNames(typeof (CalendarFormat)));
        }

        private void txtPlaylistRefresh_Validated(object sender, EventArgs e)
        {
            AdminErrorProvider.SetError((Control) sender, string.Empty);
            toolStripSave.Enabled = true;
        }

        private void txtPlaylistRefresh_Validating(object sender, CancelEventArgs e)
        {
            string errorMessage;

            //if (!ValidRefreshInterval(refreshCounter1, out errorMessage))
            //{
            //    e.Cancel = true;
            //}
        }

        private void transparencyTrackBar_Scroll(object sender, EventArgs e)
        {
            trackBarValue.Text = (transparencyTrackBar.Value).ToString(CultureInfo.InvariantCulture);
        }

        private void ListenKeyLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ListenKeyLinkLabel.Links[ListenKeyLinkLabel.Links.IndexOf(e.Link)].Visited = true;
            var target = e.Link.LinkData as string;

            if (!string.IsNullOrEmpty(target))
            {
                Components.Utilities.StartProcess(e.Link.LinkData as string);
            }
        }

        private void serviceLevelValues_SelectedIndexChanged(object sender, EventArgs e)
        {
            {
                //{
                //    if (selected == 0)
                //    {
                //        this.UsernameTextbox.Enabled = false;
                //        this.PasswordTextbox.Enabled = false;
                //        this.ListenKeyTextbox.Enabled = false;
                //    }
                //    else
                //    {
                //        this.UsernameTextbox.Enabled = true;
                //        this.PasswordTextbox.Enabled = true;
                //        this.ListenKeyTextbox.Enabled = true;
                //    }
                //}

                // togglePremiumTextboxes(serviceLevelValues.SelectedIndex;);
            }
        }

        private void togglePremiumTextboxes(int selected)
        {
            if (selected >= 0)
            {
                foreach (Control c in premiumInfoGroupBox.Controls)
                {
                    if (c is TextBox)
                    {
                        c.Enabled = Convert.ToBoolean(selected);
                    }
                }
            }
        }

        private void serviceLevelValues_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            togglePremiumTextboxes(e.Index);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///   Required method for Designer support - do not modify
        ///   the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            var resources = new System.ComponentModel.ComponentResourceManager(typeof (AdminForm));
            this.showToastPanel = new System.Windows.Forms.Panel();
            this.toastNoRadio = new System.Windows.Forms.RadioButton();
            this.toastYesRadio = new System.Windows.Forms.RadioButton();
            this.label11 = new System.Windows.Forms.Label();
            this.premiumInfoGroupBox = new System.Windows.Forms.GroupBox();
            this.ListenKeyLinkLabel = new System.Windows.Forms.LinkLabel();
            this.ListenKeyTextbox = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.serviceLevelValues = new System.Windows.Forms.CheckedListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.PasswordTextbox = new System.Windows.Forms.TextBox();
            this.UsernameTextbox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.lable12 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.trackBarValue = new System.Windows.Forms.Label();
            this.transparencyTrackBar = new System.Windows.Forms.TrackBar();
            this.label4 = new System.Windows.Forms.Label();
            this.sortByValue = new System.Windows.Forms.DomainUpDown();
            this.adminFormToolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripLoadDefaults = new System.Windows.Forms.ToolStripButton();
            this.label3 = new System.Windows.Forms.Label();
            this.sortOrderValue = new System.Windows.Forms.DomainUpDown();
            this.previousChannelPanel = new System.Windows.Forms.Panel();
            this.rememberNoRadio = new System.Windows.Forms.RadioButton();
            this.rememberYesRadio = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.AdminErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.refreshCounter1 = new RefreshCounter();
            this.channelColorPicker = new ColorPicker();
            this.alternatingChannelColorPicker = new ColorPicker();
            this.selectedChannelColorPicker = new ColorPicker();
            this.label13 = new System.Windows.Forms.Label();
            this.calendarFormatValue = new System.Windows.Forms.DomainUpDown();
            this.showToastPanel.SuspendLayout();
            this.premiumInfoGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.transparencyTrackBar)).BeginInit();
            this.adminFormToolStrip.SuspendLayout();
            this.previousChannelPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.AdminErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // showToastPanel
            // 
            this.showToastPanel.Controls.Add(this.toastNoRadio);
            this.showToastPanel.Controls.Add(this.toastYesRadio);
            this.showToastPanel.Controls.Add(this.label11);
            this.showToastPanel.Location = new System.Drawing.Point(8, 189);
            this.showToastPanel.Name = "showToastPanel";
            this.showToastPanel.Size = new System.Drawing.Size(218, 23);
            this.showToastPanel.TabIndex = 28;
            // 
            // toastNoRadio
            // 
            this.toastNoRadio.AutoSize = true;
            this.toastNoRadio.Location = new System.Drawing.Point(173, 1);
            this.toastNoRadio.Name = "toastNoRadio";
            this.toastNoRadio.Size = new System.Drawing.Size(39, 17);
            this.toastNoRadio.TabIndex = 2;
            this.toastNoRadio.Text = "No";
            this.toastNoRadio.UseVisualStyleBackColor = true;
            // 
            // toastYesRadio
            // 
            this.toastYesRadio.AutoSize = true;
            this.toastYesRadio.Checked = true;
            this.toastYesRadio.Location = new System.Drawing.Point(126, 1);
            this.toastYesRadio.Name = "toastYesRadio";
            this.toastYesRadio.Size = new System.Drawing.Size(43, 17);
            this.toastYesRadio.TabIndex = 1;
            this.toastYesRadio.TabStop = true;
            this.toastYesRadio.Text = "Yes";
            this.toastYesRadio.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(-3, 1);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(91, 13);
            this.label11.TabIndex = 0;
            this.label11.Text = "Show Info Toast?";
            // 
            // premiumInfoGroupBox
            // 
            this.premiumInfoGroupBox.Controls.Add(this.ListenKeyLinkLabel);
            this.premiumInfoGroupBox.Controls.Add(this.ListenKeyTextbox);
            this.premiumInfoGroupBox.Controls.Add(this.label12);
            this.premiumInfoGroupBox.Controls.Add(this.serviceLevelValues);
            this.premiumInfoGroupBox.Controls.Add(this.label5);
            this.premiumInfoGroupBox.Controls.Add(this.label10);
            this.premiumInfoGroupBox.Controls.Add(this.PasswordTextbox);
            this.premiumInfoGroupBox.Controls.Add(this.UsernameTextbox);
            this.premiumInfoGroupBox.Controls.Add(this.label9);
            this.premiumInfoGroupBox.Controls.Add(this.lable12);
            this.premiumInfoGroupBox.Location = new System.Drawing.Point(8, 302);
            this.premiumInfoGroupBox.Name = "premiumInfoGroupBox";
            this.premiumInfoGroupBox.Size = new System.Drawing.Size(218, 173);
            this.premiumInfoGroupBox.TabIndex = 25;
            this.premiumInfoGroupBox.TabStop = false;
            this.premiumInfoGroupBox.Text = "Premium Info";
            // 
            // ListenKeyLinkLabel
            // 
            this.ListenKeyLinkLabel.AutoSize = true;
            this.ListenKeyLinkLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ListenKeyLinkLabel.DisabledLinkColor = System.Drawing.Color.Red;
            this.ListenKeyLinkLabel.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.ListenKeyLinkLabel.LinkColor = System.Drawing.Color.Navy;
            this.ListenKeyLinkLabel.Location = new System.Drawing.Point(67, 131);
            this.ListenKeyLinkLabel.Name = "ListenKeyLinkLabel";
            this.ListenKeyLinkLabel.Size = new System.Drawing.Size(112, 13);
            this.ListenKeyLinkLabel.TabIndex = 30;
            this.ListenKeyLinkLabel.TabStop = true;
            this.ListenKeyLinkLabel.Text = "What is my listen key?";
            this.ListenKeyLinkLabel.VisitedLinkColor = System.Drawing.Color.Blue;
            this.ListenKeyLinkLabel.LinkClicked +=
                new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ListenKeyLinkLabel_LinkClicked);
            // 
            // ListenKeyTextbox
            // 
            this.ListenKeyTextbox.Enabled = false;
            this.ListenKeyTextbox.Location = new System.Drawing.Point(70, 108);
            this.ListenKeyTextbox.Name = "ListenKeyTextbox";
            this.ListenKeyTextbox.Size = new System.Drawing.Size(142, 20);
            this.ListenKeyTextbox.TabIndex = 29;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 110);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(59, 13);
            this.label12.TabIndex = 28;
            this.label12.Text = "Listen Key:";
            // 
            // serviceLevelValues
            // 
            this.serviceLevelValues.CheckOnClick = true;
            this.serviceLevelValues.FormattingEnabled = true;
            this.serviceLevelValues.Location = new System.Drawing.Point(90, 16);
            this.serviceLevelValues.Name = "serviceLevelValues";
            this.serviceLevelValues.Size = new System.Drawing.Size(122, 34);
            this.serviceLevelValues.TabIndex = 6;
            this.serviceLevelValues.ThreeDCheckBoxes = true;
            this.serviceLevelValues.ItemCheck +=
                new System.Windows.Forms.ItemCheckEventHandler(this.serviceLevelValues_ItemCheck);
            this.serviceLevelValues.SelectedIndexChanged +=
                new System.EventHandler(this.serviceLevelValues_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 147);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 13);
            this.label5.TabIndex = 27;
            this.label5.Text = "Form Transparency";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 16);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(75, 13);
            this.label10.TabIndex = 5;
            this.label10.Text = "Service Level:";
            // 
            // PasswordTextbox
            // 
            this.PasswordTextbox.Enabled = false;
            this.PasswordTextbox.Location = new System.Drawing.Point(70, 82);
            this.PasswordTextbox.Name = "PasswordTextbox";
            this.PasswordTextbox.Size = new System.Drawing.Size(142, 20);
            this.PasswordTextbox.TabIndex = 4;
            this.PasswordTextbox.UseSystemPasswordChar = true;
            // 
            // UsernameTextbox
            // 
            this.UsernameTextbox.Enabled = false;
            this.UsernameTextbox.Location = new System.Drawing.Point(70, 56);
            this.UsernameTextbox.Name = "UsernameTextbox";
            this.UsernameTextbox.Size = new System.Drawing.Size(142, 20);
            this.UsernameTextbox.TabIndex = 3;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 85);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 13);
            this.label9.TabIndex = 2;
            this.label9.Text = "Password:";
            // 
            // lable12
            // 
            this.lable12.AutoSize = true;
            this.lable12.Location = new System.Drawing.Point(6, 59);
            this.lable12.Name = "lable12";
            this.lable12.Size = new System.Drawing.Size(58, 13);
            this.lable12.TabIndex = 1;
            this.lable12.Text = "Username:";
            this.lable12.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(59, 119);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(118, 13);
            this.label8.TabIndex = 24;
            this.label8.Text = "Selected Channel Color";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(59, 77);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(126, 13);
            this.label7.TabIndex = 23;
            this.label7.Text = "Alternating Channel Color";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(81, 35);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 13);
            this.label6.TabIndex = 22;
            this.label6.Text = "Channel Color";
            // 
            // trackBarValue
            // 
            this.trackBarValue.AutoSize = true;
            this.trackBarValue.Location = new System.Drawing.Point(127, 385);
            this.trackBarValue.Name = "trackBarValue";
            this.trackBarValue.Size = new System.Drawing.Size(98, 13);
            this.trackBarValue.TabIndex = 17;
            this.trackBarValue.Text = "Form Transparency";
            // 
            // transparencyTrackBar
            // 
            this.transparencyTrackBar.Location = new System.Drawing.Point(8, 481);
            this.transparencyTrackBar.Maximum = 100;
            this.transparencyTrackBar.Name = "transparencyTrackBar";
            this.transparencyTrackBar.Size = new System.Drawing.Size(219, 45);
            this.transparencyTrackBar.SmallChange = 5;
            this.transparencyTrackBar.TabIndex = 16;
            this.transparencyTrackBar.TickFrequency = 10;
            this.transparencyTrackBar.Scroll += new System.EventHandler(this.transparencyTrackBar_Scroll);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 242);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Channel Sort By: ";
            // 
            // sortByValue
            // 
            this.sortByValue.Location = new System.Drawing.Point(119, 240);
            this.sortByValue.Margin = new System.Windows.Forms.Padding(2);
            this.sortByValue.Name = "sortByValue";
            this.sortByValue.Size = new System.Drawing.Size(105, 20);
            this.sortByValue.Sorted = true;
            this.sortByValue.TabIndex = 11;
            this.sortByValue.Wrap = true;
            // 
            // adminFormToolStrip
            // 
            this.adminFormToolStrip.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.adminFormToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[]
                {
                    this.toolStripStatusLabel,
                    this.toolStripSave,
                    this.toolStripLoadDefaults
                });
            this.adminFormToolStrip.Location = new System.Drawing.Point(0, 521);
            this.adminFormToolStrip.Name = "adminFormToolStrip";
            this.adminFormToolStrip.Size = new System.Drawing.Size(234, 25);
            this.adminFormToolStrip.TabIndex = 9;
            this.adminFormToolStrip.Text = "toolStrip1";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(39, 22);
            this.toolStripStatusLabel.Text = "Ready";
            // 
            // toolStripSave
            // 
            this.toolStripSave.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripSave.Image = ((System.Drawing.Image) (resources.GetObject("toolStripSave.Image")));
            this.toolStripSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSave.Name = "toolStripSave";
            this.toolStripSave.Size = new System.Drawing.Size(35, 22);
            this.toolStripSave.Text = "S&ave";
            this.toolStripSave.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // toolStripLoadDefaults
            // 
            this.toolStripLoadDefaults.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLoadDefaults.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripLoadDefaults.Image =
                ((System.Drawing.Image) (resources.GetObject("toolStripLoadDefaults.Image")));
            this.toolStripLoadDefaults.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripLoadDefaults.Name = "toolStripLoadDefaults";
            this.toolStripLoadDefaults.Size = new System.Drawing.Size(83, 22);
            this.toolStripLoadDefaults.Text = "Load &Defaults";
            this.toolStripLoadDefaults.Click += new System.EventHandler(this.reloadDefaultsButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 219);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Channel Sort Order: ";
            // 
            // sortOrderValue
            // 
            this.sortOrderValue.Location = new System.Drawing.Point(119, 217);
            this.sortOrderValue.Margin = new System.Windows.Forms.Padding(2);
            this.sortOrderValue.Name = "sortOrderValue";
            this.sortOrderValue.Size = new System.Drawing.Size(105, 20);
            this.sortOrderValue.Sorted = true;
            this.sortOrderValue.TabIndex = 4;
            this.sortOrderValue.Wrap = true;
            // 
            // previousChannelPanel
            // 
            this.previousChannelPanel.Controls.Add(this.rememberNoRadio);
            this.previousChannelPanel.Controls.Add(this.rememberYesRadio);
            this.previousChannelPanel.Controls.Add(this.label2);
            this.previousChannelPanel.Location = new System.Drawing.Point(8, 163);
            this.previousChannelPanel.Margin = new System.Windows.Forms.Padding(2);
            this.previousChannelPanel.Name = "previousChannelPanel";
            this.previousChannelPanel.Size = new System.Drawing.Size(217, 21);
            this.previousChannelPanel.TabIndex = 3;
            // 
            // rememberNoRadio
            // 
            this.rememberNoRadio.AutoSize = true;
            this.rememberNoRadio.Location = new System.Drawing.Point(173, 2);
            this.rememberNoRadio.Margin = new System.Windows.Forms.Padding(2);
            this.rememberNoRadio.Name = "rememberNoRadio";
            this.rememberNoRadio.Size = new System.Drawing.Size(39, 17);
            this.rememberNoRadio.TabIndex = 2;
            this.rememberNoRadio.Text = "&No";
            this.rememberNoRadio.UseVisualStyleBackColor = true;
            // 
            // rememberYesRadio
            // 
            this.rememberYesRadio.AutoSize = true;
            this.rememberYesRadio.Checked = true;
            this.rememberYesRadio.Location = new System.Drawing.Point(126, 2);
            this.rememberYesRadio.Margin = new System.Windows.Forms.Padding(2);
            this.rememberYesRadio.Name = "rememberYesRadio";
            this.rememberYesRadio.Size = new System.Drawing.Size(43, 17);
            this.rememberYesRadio.TabIndex = 1;
            this.rememberYesRadio.TabStop = true;
            this.rememberYesRadio.Text = "&Yes";
            this.rememberYesRadio.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(-3, 2);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Play Previous Channel?";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 10);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Playlist Refresh Interval";
            // 
            // AdminErrorProvider
            // 
            this.AdminErrorProvider.ContainerControl = this;
            // 
            // refreshCounter1
            // 
            this.refreshCounter1.Location = new System.Drawing.Point(164, 5);
            this.refreshCounter1.Margin = new System.Windows.Forms.Padding(2);
            this.refreshCounter1.Name = "refreshCounter1";
            this.refreshCounter1.Size = new System.Drawing.Size(56, 18);
            this.refreshCounter1.TabIndex = 26;
            this.refreshCounter1.Value = "02:11";
            // 
            // channelColorPicker
            // 
            this.channelColorPicker.Color = System.Drawing.Color.Gainsboro;
            this.channelColorPicker.Location = new System.Drawing.Point(8, 51);
            this.channelColorPicker.Name = "channelColorPicker";
            this.channelColorPicker.Size = new System.Drawing.Size(218, 23);
            this.channelColorPicker.TabIndex = 21;
            // 
            // alternatingChannelColorPicker
            // 
            this.alternatingChannelColorPicker.Color = System.Drawing.Color.WhiteSmoke;
            this.alternatingChannelColorPicker.Location = new System.Drawing.Point(8, 93);
            this.alternatingChannelColorPicker.Name = "alternatingChannelColorPicker";
            this.alternatingChannelColorPicker.Size = new System.Drawing.Size(218, 23);
            this.alternatingChannelColorPicker.TabIndex = 20;
            // 
            // selectedChannelColorPicker
            // 
            this.selectedChannelColorPicker.Color = System.Drawing.Color.Beige;
            this.selectedChannelColorPicker.Location = new System.Drawing.Point(8, 135);
            this.selectedChannelColorPicker.Name = "selectedChannelColorPicker";
            this.selectedChannelColorPicker.Size = new System.Drawing.Size(218, 23);
            this.selectedChannelColorPicker.TabIndex = 19;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(4, 267);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(87, 13);
            this.label13.TabIndex = 29;
            this.label13.Text = "Calendar Format:";
            // 
            // calendarFormatValue
            // 
            this.calendarFormatValue.Location = new System.Drawing.Point(119, 265);
            this.calendarFormatValue.Name = "calendarFormatValue";
            this.calendarFormatValue.Size = new System.Drawing.Size(105, 20);
            this.calendarFormatValue.TabIndex = 30;
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(234, 546);
            this.Controls.Add(this.calendarFormatValue);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.showToastPanel);
            this.Controls.Add(this.refreshCounter1);
            this.Controls.Add(this.premiumInfoGroupBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.channelColorPicker);
            this.Controls.Add(this.alternatingChannelColorPicker);
            this.Controls.Add(this.selectedChannelColorPicker);
            this.Controls.Add(this.trackBarValue);
            this.Controls.Add(this.transparencyTrackBar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.sortByValue);
            this.Controls.Add(this.adminFormToolStrip);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.sortOrderValue);
            this.Controls.Add(this.previousChannelPanel);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon) (resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "AdminForm";
            this.ShowInTaskbar = false;
            this.Text = "Digitally Imported Radio :: Options";
            this.Load += new System.EventHandler(this.DIAdmin_Load);
            this.showToastPanel.ResumeLayout(false);
            this.showToastPanel.PerformLayout();
            this.premiumInfoGroupBox.ResumeLayout(false);
            this.premiumInfoGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize) (this.transparencyTrackBar)).EndInit();
            this.adminFormToolStrip.ResumeLayout(false);
            this.adminFormToolStrip.PerformLayout();
            this.previousChannelPanel.ResumeLayout(false);
            this.previousChannelPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize) (this.AdminErrorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}