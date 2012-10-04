using System.Windows.Forms;
using DigitallyImported.Components;
namespace DigitallyImported.Client
{
    partial class FavoritesForm<TChannel, TTrack>
        where TChannel : UserControl, IChannel, new()
        where TTrack: UserControl, ITrack, new()
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FavoritesForm<,>));
            this.ChannelsGroupBox = new System.Windows.Forms.GroupBox();
            this.PlaylistLabel3 = new System.Windows.Forms.Label();
            this.RemoveExternalButton = new System.Windows.Forms.Button();
            this.AddExternalButton = new System.Windows.Forms.Button();
            this.ExternalPlaylistCheckBox = new System.Windows.Forms.CheckedListBox();
            this.PlaylistLabel2 = new System.Windows.Forms.Label();
            this.PlaylistLabel1 = new System.Windows.Forms.Label();
            this.DIPlaylistCheckedList = new System.Windows.Forms.CheckedListBox();
            this.SkyPlaylistCheckedList = new System.Windows.Forms.CheckedListBox();
            this.ClearButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.FavoritesPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.FavoritesStatusStrip = new System.Windows.Forms.StatusStrip();
            this.ChannelCountLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.ChannelsGroupBox.SuspendLayout();
            this.FavoritesPanel.SuspendLayout();
            this.FavoritesStatusStrip.SuspendLayout();
            this.toolStripContainer1.BottomToolStripPanel.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ChannelsGroupBox
            // 
            this.ChannelsGroupBox.Controls.Add(this.PlaylistLabel3);
            this.ChannelsGroupBox.Controls.Add(this.RemoveExternalButton);
            this.ChannelsGroupBox.Controls.Add(this.AddExternalButton);
            this.ChannelsGroupBox.Controls.Add(this.ExternalPlaylistCheckBox);
            this.ChannelsGroupBox.Controls.Add(this.PlaylistLabel2);
            this.ChannelsGroupBox.Controls.Add(this.PlaylistLabel1);
            this.ChannelsGroupBox.Controls.Add(this.DIPlaylistCheckedList);
            this.ChannelsGroupBox.Controls.Add(this.SkyPlaylistCheckedList);
            this.ChannelsGroupBox.Location = new System.Drawing.Point(3, 3);
            this.ChannelsGroupBox.Name = "ChannelsGroupBox";
            this.ChannelsGroupBox.Size = new System.Drawing.Size(390, 293);
            this.ChannelsGroupBox.TabIndex = 5;
            this.ChannelsGroupBox.TabStop = false;
            this.ChannelsGroupBox.Text = "Available Channels";
            // 
            // PlaylistLabel3
            // 
            this.PlaylistLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlaylistLabel3.Location = new System.Drawing.Point(258, 16);
            this.PlaylistLabel3.Name = "PlaylistLabel3";
            this.PlaylistLabel3.Size = new System.Drawing.Size(84, 23);
            this.PlaylistLabel3.TabIndex = 10;
            this.PlaylistLabel3.Text = "0";
            this.PlaylistLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // RemoveExternalButton
            // 
            this.RemoveExternalButton.Location = new System.Drawing.Point(361, 262);
            this.RemoveExternalButton.Name = "RemoveExternalButton";
            this.RemoveExternalButton.Size = new System.Drawing.Size(20, 20);
            this.RemoveExternalButton.TabIndex = 9;
            this.RemoveExternalButton.Text = "-";
            this.RemoveExternalButton.UseVisualStyleBackColor = true;
            this.RemoveExternalButton.Click += new System.EventHandler(this.RemoveExternalButton_Click);
            // 
            // AddExternalButton
            // 
            this.AddExternalButton.Location = new System.Drawing.Point(335, 262);
            this.AddExternalButton.Name = "AddExternalButton";
            this.AddExternalButton.Size = new System.Drawing.Size(20, 20);
            this.AddExternalButton.TabIndex = 8;
            this.AddExternalButton.Text = "+";
            this.AddExternalButton.UseVisualStyleBackColor = true;
            this.AddExternalButton.Click += new System.EventHandler(this.AddExternalButton_Click);
            // 
            // ExternalPlaylistCheckBox
            // 
            this.ExternalPlaylistCheckBox.CheckOnClick = true;
            this.ExternalPlaylistCheckBox.FormattingEnabled = true;
            this.ExternalPlaylistCheckBox.Location = new System.Drawing.Point(261, 42);
            this.ExternalPlaylistCheckBox.Name = "ExternalPlaylistCheckBox";
            this.ExternalPlaylistCheckBox.Size = new System.Drawing.Size(120, 214);
            this.ExternalPlaylistCheckBox.TabIndex = 7;
            this.ExternalPlaylistCheckBox.ThreeDCheckBoxes = true;
            // 
            // PlaylistLabel2
            // 
            this.PlaylistLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlaylistLabel2.Location = new System.Drawing.Point(132, 16);
            this.PlaylistLabel2.Name = "PlaylistLabel2";
            this.PlaylistLabel2.Size = new System.Drawing.Size(84, 23);
            this.PlaylistLabel2.TabIndex = 6;
            this.PlaylistLabel2.Text = "0";
            this.PlaylistLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PlaylistLabel1
            // 
            this.PlaylistLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlaylistLabel1.Location = new System.Drawing.Point(9, 16);
            this.PlaylistLabel1.Name = "PlaylistLabel1";
            this.PlaylistLabel1.Size = new System.Drawing.Size(84, 23);
            this.PlaylistLabel1.TabIndex = 5;
            this.PlaylistLabel1.Text = "0";
            this.PlaylistLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DIPlaylistCheckedList
            // 
            this.DIPlaylistCheckedList.CheckOnClick = true;
            this.DIPlaylistCheckedList.FormattingEnabled = true;
            this.DIPlaylistCheckedList.Location = new System.Drawing.Point(9, 42);
            this.DIPlaylistCheckedList.Name = "DIPlaylistCheckedList";
            this.DIPlaylistCheckedList.Size = new System.Drawing.Size(120, 214);
            this.DIPlaylistCheckedList.TabIndex = 0;
            this.DIPlaylistCheckedList.ThreeDCheckBoxes = true;
            // 
            // SkyPlaylistCheckedList
            // 
            this.SkyPlaylistCheckedList.CheckOnClick = true;
            this.SkyPlaylistCheckedList.FormattingEnabled = true;
            this.SkyPlaylistCheckedList.Location = new System.Drawing.Point(135, 42);
            this.SkyPlaylistCheckedList.Name = "SkyPlaylistCheckedList";
            this.SkyPlaylistCheckedList.Size = new System.Drawing.Size(120, 214);
            this.SkyPlaylistCheckedList.TabIndex = 1;
            this.SkyPlaylistCheckedList.ThreeDCheckBoxes = true;
            // 
            // ClearButton
            // 
            this.ClearButton.Location = new System.Drawing.Point(165, 302);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(75, 23);
            this.ClearButton.TabIndex = 4;
            this.ClearButton.Text = "Clear";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ResetButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelButton.Location = new System.Drawing.Point(84, 302);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 3;
            this.CancelButton.Text = "&Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            // 
            // SaveButton
            // 
            this.SaveButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.SaveButton.Location = new System.Drawing.Point(3, 302);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 2;
            this.SaveButton.Text = "&Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // FavoritesPanel
            // 
            this.FavoritesPanel.AutoScroll = true;
            this.FavoritesPanel.Controls.Add(this.ChannelsGroupBox);
            this.FavoritesPanel.Controls.Add(this.SaveButton);
            this.FavoritesPanel.Controls.Add(this.CancelButton);
            this.FavoritesPanel.Controls.Add(this.ClearButton);
            this.FavoritesPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FavoritesPanel.Location = new System.Drawing.Point(0, 0);
            this.FavoritesPanel.Name = "FavoritesPanel";
            this.FavoritesPanel.Size = new System.Drawing.Size(397, 330);
            this.FavoritesPanel.TabIndex = 5;
            // 
            // FavoritesStatusStrip
            // 
            this.FavoritesStatusStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.FavoritesStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ChannelCountLabel});
            this.FavoritesStatusStrip.Location = new System.Drawing.Point(0, 0);
            this.FavoritesStatusStrip.Name = "FavoritesStatusStrip";
            this.FavoritesStatusStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.FavoritesStatusStrip.Size = new System.Drawing.Size(397, 22);
            this.FavoritesStatusStrip.TabIndex = 6;
            this.FavoritesStatusStrip.Text = "statusStrip1";
            // 
            // ChannelCountLabel
            // 
            this.ChannelCountLabel.Name = "ChannelCountLabel";
            this.ChannelCountLabel.Size = new System.Drawing.Size(13, 17);
            this.ChannelCountLabel.Text = "0";
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.BottomToolStripPanel
            // 
            this.toolStripContainer1.BottomToolStripPanel.Controls.Add(this.FavoritesStatusStrip);
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.AutoScroll = true;
            this.toolStripContainer1.ContentPanel.Controls.Add(this.FavoritesPanel);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(397, 330);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.LeftToolStripPanelVisible = false;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.RightToolStripPanelVisible = false;
            this.toolStripContainer1.Size = new System.Drawing.Size(397, 352);
            this.toolStripContainer1.TabIndex = 6;
            this.toolStripContainer1.Text = "toolStripContainer1";
            this.toolStripContainer1.TopToolStripPanelVisible = false;
            // 
            // FavoritesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(397, 352);
            this.Controls.Add(this.toolStripContainer1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            //this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FavoritesForm";
            this.ShowInTaskbar = false;
            this.Text = "Favorites List";
            this.Load += new System.EventHandler(this.FavoritesForm_Load);
            this.ChannelsGroupBox.ResumeLayout(false);
            this.FavoritesPanel.ResumeLayout(false);
            this.FavoritesStatusStrip.ResumeLayout(false);
            this.FavoritesStatusStrip.PerformLayout();
            this.toolStripContainer1.BottomToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.BottomToolStripPanel.PerformLayout();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox ChannelsGroupBox;
        private System.Windows.Forms.CheckedListBox DIPlaylistCheckedList;
        private System.Windows.Forms.CheckedListBox SkyPlaylistCheckedList;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.FlowLayoutPanel FavoritesPanel;
        private System.Windows.Forms.StatusStrip FavoritesStatusStrip;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ToolStripStatusLabel ChannelCountLabel;
        private System.Windows.Forms.Label PlaylistLabel2;
        private System.Windows.Forms.Label PlaylistLabel1;
        private Label PlaylistLabel3;
        private Button RemoveExternalButton;
        private Button AddExternalButton;
        private CheckedListBox ExternalPlaylistCheckBox;

    }
}