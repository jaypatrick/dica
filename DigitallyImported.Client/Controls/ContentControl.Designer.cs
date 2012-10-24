using System.Windows.Forms;
using DigitallyImported.Components;
using DigitallyImported.Controls.Windows;

namespace DigitallyImported.Client.Controls
{
    partial class ContentControl<TChannel, TTrack>
        where TChannel : UserControl, IChannel, new()
        where TTrack : UserControl, ITrack, new()
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ContentControl<,>));
            this.MainToolStripContainer = new System.Windows.Forms.ToolStripContainer();
            this.BottomStatusStrip = new System.Windows.Forms.StatusStrip();
            this.ConnectionStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.PlaylistRefreshProgress = new System.Windows.Forms.ToolStripProgressBar();
            this.ExceptionStatusMessage = new System.Windows.Forms.ToolStripStatusLabel();
            this.MemoryStatus = new System.Windows.Forms.Label();
            this.RefreshCounterLabel = new System.Windows.Forms.Label();
            this.PlaylistPanel = new ChannelPanel<TChannel>();
            this.MainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printPreviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.indexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TopToolStrip = new System.Windows.Forms.ToolStrip();
            this.RefreshPlaylistButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.ViewChannelSplitButton = new System.Windows.Forms.ToolStripSplitButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.ViewEventsSplitButton = new System.Windows.Forms.ToolStripSplitButton();
            this.FeedbackButton = new System.Windows.Forms.ToolStripButton();
            this.TopOptionsToolStrip = new System.Windows.Forms.ToolStrip();
            this.ViewPlaylistsSplitButton = new System.Windows.Forms.ToolStripSplitButton();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.SortPlaylistSplitButton = new System.Windows.Forms.ToolStripSplitButton();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.PlayerTypeSplitButton = new System.Windows.Forms.ToolStripSplitButton();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.OptionsButton = new System.Windows.Forms.ToolStripButton();
            this.MainContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.RefreshPlaylistWorker = new System.ComponentModel.BackgroundWorker();
            this.MainNotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.RefreshEventlistWorker = new System.ComponentModel.BackgroundWorker();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.PlaylistsContextMenu = new PlaylistsContextMenu(this.components);
            this.SortContextMenu = new SortContextMenu(this.components);
            this.ChannelsContextMenu = new ChannelsContextMenu<TChannel>(this.components);
            this.EventsContextMenu = new EventsContextMenu(this.components);
            this.PlayersContextMenu = new PlayersContextMenu(this.components);
            this.MainToolStripContainer.BottomToolStripPanel.SuspendLayout();
            this.MainToolStripContainer.ContentPanel.SuspendLayout();
            this.MainToolStripContainer.TopToolStripPanel.SuspendLayout();
            this.MainToolStripContainer.SuspendLayout();
            this.BottomStatusStrip.SuspendLayout();
            this.MainMenuStrip.SuspendLayout();
            this.TopToolStrip.SuspendLayout();
            this.TopOptionsToolStrip.SuspendLayout();
            this.MainContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainToolStripContainer
            // 
            // 
            // MainToolStripContainer.BottomToolStripPanel
            // 
            this.MainToolStripContainer.BottomToolStripPanel.Controls.Add(this.BottomStatusStrip);
            // 
            // MainToolStripContainer.ContentPanel
            // 
            this.MainToolStripContainer.ContentPanel.AllowDrop = true;
            this.MainToolStripContainer.ContentPanel.Controls.Add(this.MemoryStatus);
            this.MainToolStripContainer.ContentPanel.Controls.Add(this.RefreshCounterLabel);
            this.MainToolStripContainer.ContentPanel.Controls.Add(this.PlaylistPanel);
            this.MainToolStripContainer.ContentPanel.Size = new System.Drawing.Size(470, 524);
            this.MainToolStripContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainToolStripContainer.LeftToolStripPanelVisible = false;
            this.MainToolStripContainer.Location = new System.Drawing.Point(0, 0);
            this.MainToolStripContainer.Name = "MainToolStripContainer";
            this.MainToolStripContainer.RightToolStripPanelVisible = false;
            this.MainToolStripContainer.Size = new System.Drawing.Size(470, 620);
            this.MainToolStripContainer.TabIndex = 0;
            // 
            // MainToolStripContainer.TopToolStripPanel
            // 
            this.MainToolStripContainer.TopToolStripPanel.Controls.Add(this.MainMenuStrip);
            this.MainToolStripContainer.TopToolStripPanel.Controls.Add(this.TopToolStrip);
            this.MainToolStripContainer.TopToolStripPanel.Controls.Add(this.TopOptionsToolStrip);
            // 
            // BottomStatusStrip
            // 
            this.BottomStatusStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.BottomStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ConnectionStatusLabel,
            this.PlaylistRefreshProgress,
            this.ExceptionStatusMessage});
            this.BottomStatusStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.BottomStatusStrip.Location = new System.Drawing.Point(0, 0);
            this.BottomStatusStrip.Name = "BottomStatusStrip";
            this.BottomStatusStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.BottomStatusStrip.ShowItemToolTips = true;
            this.BottomStatusStrip.Size = new System.Drawing.Size(470, 22);
            this.BottomStatusStrip.TabIndex = 0;
            // 
            // ConnectionStatusLabel
            // 
            this.ConnectionStatusLabel.Name = "ConnectionStatusLabel";
            this.ConnectionStatusLabel.Size = new System.Drawing.Size(26, 13);
            this.ConnectionStatusLabel.Text = "LAN";
            // 
            // PlaylistRefreshProgress
            // 
            this.PlaylistRefreshProgress.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.PlaylistRefreshProgress.Name = "PlaylistRefreshProgress";
            this.PlaylistRefreshProgress.Size = new System.Drawing.Size(100, 16);
            // 
            // ExceptionStatusMessage
            // 
            this.ExceptionStatusMessage.ForeColor = System.Drawing.Color.Red;
            this.ExceptionStatusMessage.Name = "ExceptionStatusMessage";
            this.ExceptionStatusMessage.Size = new System.Drawing.Size(101, 13);
            this.ExceptionStatusMessage.Text = "Exception Occurred";
            this.ExceptionStatusMessage.Visible = false;
            // 
            // MemoryStatus
            // 
            this.MemoryStatus.AutoSize = true;
            this.MemoryStatus.Location = new System.Drawing.Point(391, 10);
            this.MemoryStatus.Name = "MemoryStatus";
            this.MemoryStatus.Size = new System.Drawing.Size(21, 13);
            this.MemoryStatus.TabIndex = 7;
            this.MemoryStatus.Text = string.Empty;
            // 
            // RefreshCounterLabel
            // 
            this.RefreshCounterLabel.AutoSize = true;
            this.RefreshCounterLabel.Location = new System.Drawing.Point(13, 10);
            this.RefreshCounterLabel.Name = "RefreshCounterLabel";
            this.RefreshCounterLabel.Size = new System.Drawing.Size(13, 13);
            this.RefreshCounterLabel.TabIndex = 5;
            this.RefreshCounterLabel.Text = "0";
            // 
            // PlaylistPanel
            // 
            this.PlaylistPanel.AutoScroll = true;
            this.PlaylistPanel.CausesValidation = false;
            this.PlaylistPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.PlaylistPanel.Location = new System.Drawing.Point(4, 26);
            this.PlaylistPanel.Name = "PlaylistPanel";
            this.PlaylistPanel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.PlaylistPanel.Size = new System.Drawing.Size(452, 520);
            this.PlaylistPanel.TabIndex = 4;
            this.PlaylistPanel.WrapContents = false;
            // 
            // MainMenuStrip
            // 
            this.MainMenuStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.MainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.MainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MainMenuStrip.Name = "MainMenuStrip";
            this.MainMenuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.MainMenuStrip.Size = new System.Drawing.Size(470, 24);
            this.MainMenuStrip.TabIndex = 0;
            this.MainMenuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.toolStripSeparator,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripSeparator1,
            this.printToolStripMenuItem,
            this.printPreviewToolStripMenuItem,
            this.toolStripSeparator2,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // newToolStripMenuItem
            // 
            //this.newToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripMenuItem.Image")));
            this.newToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.newToolStripMenuItem.Text = "&New";
            // 
            // openToolStripMenuItem
            // 
            //this.openToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripMenuItem.Image")));
            this.openToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.openToolStripMenuItem.Text = "&Open";
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(148, 6);
            // 
            // saveToolStripMenuItem
            // 
            //this.saveToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripMenuItem.Image")));
            this.saveToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.saveToolStripMenuItem.Text = "&Save";
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.saveAsToolStripMenuItem.Text = "Save &As";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(148, 6);
            // 
            // printToolStripMenuItem
            // 
            //this.printToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("printToolStripMenuItem.Image")));
            this.printToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.printToolStripMenuItem.Name = "printToolStripMenuItem";
            this.printToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.printToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.printToolStripMenuItem.Text = "&Print";
            // 
            // printPreviewToolStripMenuItem
            // 
            //this.printPreviewToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("printPreviewToolStripMenuItem.Image")));
            this.printPreviewToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.printPreviewToolStripMenuItem.Name = "printPreviewToolStripMenuItem";
            this.printPreviewToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.printPreviewToolStripMenuItem.Text = "Print Pre&view";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(148, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitApplication);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoToolStripMenuItem,
            this.redoToolStripMenuItem,
            this.toolStripSeparator3,
            this.cutToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.toolStripSeparator4,
            this.selectAllToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.editToolStripMenuItem.Text = "&Edit";
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.undoToolStripMenuItem.Text = "&Undo";
            // 
            // redoToolStripMenuItem
            // 
            this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            this.redoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.redoToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.redoToolStripMenuItem.Text = "&Redo";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(147, 6);
            // 
            // cutToolStripMenuItem
            // 
            //this.cutToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("cutToolStripMenuItem.Image")));
            this.cutToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.cutToolStripMenuItem.Text = "Cu&t";
            // 
            // copyToolStripMenuItem
            // 
            //this.copyToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("copyToolStripMenuItem.Image")));
            this.copyToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.copyToolStripMenuItem.Text = "&Copy";
            // 
            // pasteToolStripMenuItem
            // 
            //this.pasteToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("pasteToolStripMenuItem.Image")));
            this.pasteToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.pasteToolStripMenuItem.Text = "&Paste";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(147, 6);
            // 
            // selectAllToolStripMenuItem
            // 
            this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.selectAllToolStripMenuItem.Text = "Select &All";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.customizeToolStripMenuItem,
            this.optionsToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.toolsToolStripMenuItem.Text = "&Tools";
            // 
            // customizeToolStripMenuItem
            // 
            this.customizeToolStripMenuItem.Name = "customizeToolStripMenuItem";
            this.customizeToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.customizeToolStripMenuItem.Text = "&Customize...";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.optionsToolStripMenuItem.Text = "&Options...";
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.OptionsToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contentsToolStripMenuItem,
            this.indexToolStripMenuItem,
            this.searchToolStripMenuItem,
            this.toolStripSeparator5,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // contentsToolStripMenuItem
            // 
            this.contentsToolStripMenuItem.Name = "contentsToolStripMenuItem";
            this.contentsToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.contentsToolStripMenuItem.Text = "&Contents";
            // 
            // indexToolStripMenuItem
            // 
            this.indexToolStripMenuItem.Name = "indexToolStripMenuItem";
            this.indexToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.indexToolStripMenuItem.Text = "&Index";
            // 
            // searchToolStripMenuItem
            // 
            this.searchToolStripMenuItem.Name = "searchToolStripMenuItem";
            this.searchToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.searchToolStripMenuItem.Text = "&Search";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(126, 6);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.aboutToolStripMenuItem.Text = "&About...";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
            // 
            // TopToolStrip
            // 
            this.TopToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.TopToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RefreshPlaylistButton,
            this.toolStripSeparator6,
            this.ViewChannelSplitButton,
            this.toolStripSeparator7,
            this.ViewEventsSplitButton,
            this.FeedbackButton});
            this.TopToolStrip.Location = new System.Drawing.Point(3, 24);
            this.TopToolStrip.Name = "TopToolStrip";
            this.TopToolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.TopToolStrip.Size = new System.Drawing.Size(413, 25);
            this.TopToolStrip.TabIndex = 1;
            // 
            // RefreshPlaylistButton
            // 
            //this.RefreshPlaylistButton.Image = ((System.Drawing.Image)(resources.GetObject("RefreshPlaylistButton.Image")));
            this.RefreshPlaylistButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.RefreshPlaylistButton.Name = "RefreshPlaylistButton";
            this.RefreshPlaylistButton.Size = new System.Drawing.Size(101, 22);
            this.RefreshPlaylistButton.Text = "Refresh Playlist";
            this.RefreshPlaylistButton.Click += new System.EventHandler(this.RefreshPlaylist);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // ViewChannelSplitButton
            // 
            this.ViewChannelSplitButton.Enabled = false;
            //this.ViewChannelSplitButton.Image = ((System.Drawing.Image)(resources.GetObject("ViewChannelSplitButton.Image")));
            this.ViewChannelSplitButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ViewChannelSplitButton.Name = "ViewChannelSplitButton";
            this.ViewChannelSplitButton.Size = new System.Drawing.Size(103, 22);
            this.ViewChannelSplitButton.Text = "View Channel";
            this.ViewChannelSplitButton.ToolTipText = "View Channel";
            this.ViewChannelSplitButton.ButtonClick += new System.EventHandler(this.ViewChannelSplitButton_ButtonClick);
            this.ViewChannelSplitButton.TextChanged += new System.EventHandler(this.ViewChannelSplitButton_TextChanged);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 25);
            // 
            // ViewEventsSplitButton
            // 
            this.ViewEventsSplitButton.Enabled = false;
            //this.ViewEventsSplitButton.Image = ((System.Drawing.Image)(resources.GetObject("ViewEventsSplitButton.Image")));
            this.ViewEventsSplitButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ViewEventsSplitButton.Name = "ViewEventsSplitButton";
            this.ViewEventsSplitButton.Size = new System.Drawing.Size(97, 22);
            this.ViewEventsSplitButton.Text = "View Events";
            this.ViewEventsSplitButton.ButtonClick += new System.EventHandler(this.ViewEventsSplitButton_ButtonClick);
            // 
            // FeedbackButton
            // 
            this.FeedbackButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            //this.FeedbackButton.Image = ((System.Drawing.Image)(resources.GetObject("FeedbackButton.Image")));
            this.FeedbackButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.FeedbackButton.Name = "FeedbackButton";
            this.FeedbackButton.Size = new System.Drawing.Size(57, 22);
            this.FeedbackButton.Text = "Feedback";
            this.FeedbackButton.Click += new System.EventHandler(this.FeedbackButton_Click);
            // 
            // TopOptionsToolStrip
            // 
            this.TopOptionsToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.TopOptionsToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ViewPlaylistsSplitButton,
            this.toolStripSeparator8,
            this.SortPlaylistSplitButton,
            this.toolStripSeparator9,
            this.PlayerTypeSplitButton,
            this.toolStripSeparator10,
            this.OptionsButton});
            this.TopOptionsToolStrip.Location = new System.Drawing.Point(3, 49);
            this.TopOptionsToolStrip.Name = "TopOptionsToolStrip";
            this.TopOptionsToolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.TopOptionsToolStrip.Size = new System.Drawing.Size(362, 25);
            this.TopOptionsToolStrip.TabIndex = 2;
            // 
            // ViewPlaylistsSplitButton
            // 
            this.ViewPlaylistsSplitButton.Enabled = false;
            //this.ViewPlaylistsSplitButton.Image = ((System.Drawing.Image)(resources.GetObject("ViewPlaylistsSplitButton.Image")));
            this.ViewPlaylistsSplitButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ViewPlaylistsSplitButton.Name = "ViewPlaylistsSplitButton";
            this.ViewPlaylistsSplitButton.Size = new System.Drawing.Size(77, 22);
            this.ViewPlaylistsSplitButton.Text = "Playlists";
            this.ViewPlaylistsSplitButton.ButtonClick += new System.EventHandler(this.ViewSitesSplitButton_ButtonClick);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 25);
            // 
            // SortPlaylistSplitButton
            // 
            this.SortPlaylistSplitButton.Enabled = false;
            //this.SortPlaylistSplitButton.Image = ((System.Drawing.Image)(resources.GetObject("SortPlaylistSplitButton.Image")));
            this.SortPlaylistSplitButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SortPlaylistSplitButton.Name = "SortPlaylistSplitButton";
            this.SortPlaylistSplitButton.Size = new System.Drawing.Size(95, 22);
            this.SortPlaylistSplitButton.Text = "Sort Playlist";
            this.SortPlaylistSplitButton.ButtonClick += new System.EventHandler(this.SortPlaylist_ButtonClick);
            this.SortPlaylistSplitButton.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.SortPlaylist_ItemClicked);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(6, 25);
            // 
            // PlayerTypeSplitButton
            // 
            this.PlayerTypeSplitButton.Enabled = false;
            //this.PlayerTypeSplitButton.Image = ((System.Drawing.Image)(resources.GetObject("PlayerTypeSplitButton.Image")));
            this.PlayerTypeSplitButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.PlayerTypeSplitButton.Name = "PlayerTypeSplitButton";
            this.PlayerTypeSplitButton.Size = new System.Drawing.Size(96, 22);
            this.PlayerTypeSplitButton.Text = "Player Type";
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(6, 25);
            // 
            // OptionsButton
            // 
            //this.OptionsButton.Image = ((System.Drawing.Image)(resources.GetObject("OptionsButton.Image")));
            this.OptionsButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.OptionsButton.Name = "OptionsButton";
            this.OptionsButton.Size = new System.Drawing.Size(64, 22);
            this.OptionsButton.Text = "Options";
            this.OptionsButton.Click += new System.EventHandler(this.OptionsToolStripMenuItem_Click);
            // 
            // MainContextMenuStrip
            // 
            this.MainContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem1});
            this.MainContextMenuStrip.Name = "MainContextMenuStrip";
            this.MainContextMenuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.MainContextMenuStrip.Size = new System.Drawing.Size(104, 32);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(100, 6);
            // 
            // exitToolStripMenuItem1
            // 
            this.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
            this.exitToolStripMenuItem1.Size = new System.Drawing.Size(103, 22);
            this.exitToolStripMenuItem1.Text = "E&xit";
            this.exitToolStripMenuItem1.Click += new System.EventHandler(this.ExitApplication);
            // 
            // RefreshPlaylistWorker
            // 
            this.RefreshPlaylistWorker.WorkerReportsProgress = true;
            this.RefreshPlaylistWorker.WorkerSupportsCancellation = true;
            this.RefreshPlaylistWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.RefreshPlaylistWorker_DoWork);
            this.RefreshPlaylistWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.RefreshPlaylistWorker_RunWorkerCompleted);
            this.RefreshPlaylistWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.RefreshPlaylistWorker_ProgressChanged);
            // 
            // MainNotifyIcon
            // 
            this.MainNotifyIcon.Text = "notifyIcon1";
            this.MainNotifyIcon.Visible = true;
            // 
            // RefreshEventlistWorker
            // 
            this.RefreshEventlistWorker.WorkerReportsProgress = true;
            this.RefreshEventlistWorker.WorkerSupportsCancellation = true;
            this.RefreshEventlistWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.RefreshEventlistWorker_DoWork);
            this.RefreshEventlistWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.RefreshEventlistWorker_RunWorkerCompleted);
            this.RefreshEventlistWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.RefreshEventlistWorker_ProgressChanged);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 23);
            // 
            // PlaylistsContextMenu
            // 
            this.PlaylistsContextMenu.Name = "SitesContextMenu";
            this.PlaylistsContextMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.PlaylistsContextMenu.Size = new System.Drawing.Size(151, 98);
            this.PlaylistsContextMenu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.PlaylistsMenu_ItemClicked);
            // 
            // SortContextMenu
            // 
            this.SortContextMenu.Name = "SortContextMenu";
            this.SortContextMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.SortContextMenu.Size = new System.Drawing.Size(151, 98);
            this.SortContextMenu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.SortPlaylist_ItemClicked);
            // 
            // ChannelsContextMenu
            // 
            this.ChannelsContextMenu.Channels = null;
            this.ChannelsContextMenu.Name = "ChannelsContextMenu";
            this.ChannelsContextMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.ChannelsContextMenu.Size = new System.Drawing.Size(61, 4);
            this.ChannelsContextMenu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.ViewChannel_ItemClicked);
            // 
            // EventsContextMenu
            // 
            this.EventsContextMenu.Events = null;
            this.EventsContextMenu.Name = "EventsContextMenu";
            this.EventsContextMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.EventsContextMenu.Size = new System.Drawing.Size(151, 98);
            // 
            // PlayersContextMenu
            // 
            this.PlayersContextMenu.Name = "PlayersContextMenu";
            this.PlayersContextMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.PlayersContextMenu.ShowCheckMargin = true;
            this.PlayersContextMenu.ShowImageMargin = false;
            this.PlayersContextMenu.Size = new System.Drawing.Size(151, 98);
            this.PlayersContextMenu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.PlayerType_ItemClicked);
            // 
            // ContentControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.MainToolStripContainer);
            this.Name = "ContentControl";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Size = new System.Drawing.Size(470, 620);
            this.Load += new System.EventHandler(this.ContentControl_Load);
            this.MainToolStripContainer.BottomToolStripPanel.ResumeLayout(false);
            this.MainToolStripContainer.BottomToolStripPanel.PerformLayout();
            this.MainToolStripContainer.ContentPanel.ResumeLayout(false);
            this.MainToolStripContainer.ContentPanel.PerformLayout();
            this.MainToolStripContainer.TopToolStripPanel.ResumeLayout(false);
            this.MainToolStripContainer.TopToolStripPanel.PerformLayout();
            this.MainToolStripContainer.ResumeLayout(false);
            this.MainToolStripContainer.PerformLayout();
            this.BottomStatusStrip.ResumeLayout(false);
            this.BottomStatusStrip.PerformLayout();
            this.MainMenuStrip.ResumeLayout(false);
            this.MainMenuStrip.PerformLayout();
            this.TopToolStrip.ResumeLayout(false);
            this.TopToolStrip.PerformLayout();
            this.TopOptionsToolStrip.ResumeLayout(false);
            this.TopOptionsToolStrip.PerformLayout();
            this.MainContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer MainToolStripContainer;
        private System.Windows.Forms.MenuStrip MainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printPreviewToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem customizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem indexToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStrip TopToolStrip;
        private System.Windows.Forms.StatusStrip BottomStatusStrip;
        private System.Windows.Forms.ToolStripButton RefreshPlaylistButton;
        private System.Windows.Forms.ToolStripSplitButton ViewChannelSplitButton;
        private System.Windows.Forms.ContextMenuStrip MainContextMenuStrip;
        private System.ComponentModel.BackgroundWorker RefreshPlaylistWorker;
        private System.Windows.Forms.ToolStripProgressBar PlaylistRefreshProgress;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.NotifyIcon MainNotifyIcon;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.ComponentModel.BackgroundWorker RefreshEventlistWorker;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem1;
        private System.Windows.Forms.ToolStripButton FeedbackButton;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStrip TopOptionsToolStrip;
        private System.Windows.Forms.ToolStripSplitButton ViewPlaylistsSplitButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripStatusLabel ConnectionStatusLabel;
        private System.Windows.Forms.ToolStripSplitButton SortPlaylistSplitButton;
        private PlaylistsContextMenu PlaylistsContextMenu;
        private SortContextMenu SortContextMenu;
        private ChannelsContextMenu<TChannel> ChannelsContextMenu;
        private EventsContextMenu EventsContextMenu;
        private ChannelPanel<TChannel> PlaylistPanel;
        private System.Windows.Forms.ToolStripSplitButton PlayerTypeSplitButton;
        private PlayersContextMenu PlayersContextMenu;
        private System.Windows.Forms.ToolStripSplitButton ViewEventsSplitButton;
        private System.Windows.Forms.ToolStripButton OptionsButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ToolStripStatusLabel ExceptionStatusMessage;
        private System.Windows.Forms.Label RefreshCounterLabel;
        private System.Windows.Forms.Label MemoryStatus;
    }
}
