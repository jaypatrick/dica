namespace DigitallyImported.Controls.Windows
{
    partial class Channel
    {

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
        protected internal virtual void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblChannelName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblRecordLabel = new System.Windows.Forms.Label();
            this.toolTipLinks = new System.Windows.Forms.ToolTip(this.components);
            this.lnkChannelInfo = new System.Windows.Forms.LinkLabel();
            this.picSiteIcon = new System.Windows.Forms.PictureBox();
            this.StartTimeLabel = new System.Windows.Forms.Label();
            this.pic24k = new System.Windows.Forms.PictureBox();
            this.EditContextMenu = new BaseContextMenu(this.components);
            this.lnkTrackTitle = new System.Windows.Forms.LinkLabel();
            this.lnkPlaylistHistory = new System.Windows.Forms.LinkLabel();
            this.lnkPostComments = new System.Windows.Forms.LinkLabel();
            this.picWmp = new System.Windows.Forms.PictureBox();
            this.picMp3 = new System.Windows.Forms.PictureBox();
            this.pic32k = new System.Windows.Forms.PictureBox();
            this.picAacPlus = new System.Windows.Forms.PictureBox();
            this.pic96k = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picSiteIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic24k)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWmp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMp3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic32k)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAacPlus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic96k)).BeginInit();
            this.SuspendLayout();
            // 
            // lblChannelName
            // 
            this.lblChannelName.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lblChannelName.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblChannelName.Location = new System.Drawing.Point(0, 6);
            this.lblChannelName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblChannelName.Name = "lblChannelName";
            this.lblChannelName.Size = new System.Drawing.Size(100, 66);
            this.lblChannelName.TabIndex = 0;
            this.lblChannelName.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(328, 6);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "Choose Format";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(107, 6);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "Currently Playing:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblRecordLabel
            // 
            this.lblRecordLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.8F);
            this.lblRecordLabel.Location = new System.Drawing.Point(104, 53);
            this.lblRecordLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRecordLabel.Name = "lblRecordLabel";
            this.lblRecordLabel.Size = new System.Drawing.Size(135, 10);
            this.lblRecordLabel.TabIndex = 17;
            // 
            // toolTipLinks
            // 
            this.toolTipLinks.AutomaticDelay = 100;
            this.toolTipLinks.AutoPopDelay = 30000;
            this.toolTipLinks.InitialDelay = 100;
            this.toolTipLinks.ReshowDelay = 20;
            // 
            // lnkChannelInfo
            // 
            this.lnkChannelInfo.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkChannelInfo.LinkBehavior = System.Windows.Forms.LinkBehavior.AlwaysUnderline;
            this.lnkChannelInfo.LinkColor = System.Drawing.Color.RoyalBlue;
            this.lnkChannelInfo.Location = new System.Drawing.Point(11, 80);
            this.lnkChannelInfo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lnkChannelInfo.Name = "lnkChannelInfo";
            this.lnkChannelInfo.Size = new System.Drawing.Size(90, 13);
            this.lnkChannelInfo.TabIndex = 19;
            this.lnkChannelInfo.TabStop = true;
            this.lnkChannelInfo.Text = "Channel Info";
            this.lnkChannelInfo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lnkChannelInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabel_LinkClicked);
            // 
            // picSiteIcon
            // 
            this.picSiteIcon.Location = new System.Drawing.Point(4, 80);
            this.picSiteIcon.Margin = new System.Windows.Forms.Padding(2);
            this.picSiteIcon.Name = "picSiteIcon";
            this.picSiteIcon.Size = new System.Drawing.Size(16, 16);
            this.picSiteIcon.TabIndex = 21;
            this.picSiteIcon.TabStop = false;
            // 
            // StartTimeLabel
            // 
            this.StartTimeLabel.AutoSize = true;
            this.StartTimeLabel.Font = new System.Drawing.Font("Tahoma", 8F);
            this.StartTimeLabel.ForeColor = System.Drawing.Color.Gray;
            this.StartTimeLabel.Location = new System.Drawing.Point(327, 83);
            this.StartTimeLabel.Name = "StartTimeLabel";
            this.StartTimeLabel.Size = new System.Drawing.Size(85, 13);
            this.StartTimeLabel.TabIndex = 22;
            this.StartTimeLabel.Text = "Track Start Time";
            // 
            // pic24k
            // 
            this.pic24k.ContextMenuStrip = this.EditContextMenu;
            this.pic24k.Location = new System.Drawing.Point(350, 60);
            this.pic24k.Margin = new System.Windows.Forms.Padding(2);
            this.pic24k.Name = "pic24k";
            this.pic24k.Size = new System.Drawing.Size(30, 15);
            this.pic24k.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pic24k.TabIndex = 20;
            this.pic24k.TabStop = false;
            this.pic24k.MouseLeave += new System.EventHandler(this.PictureBox_MouseLeave);
            this.pic24k.MouseClick += new System.Windows.Forms.MouseEventHandler(this.StreamType_MouseClick);
            this.pic24k.MouseEnter += new System.EventHandler(this.PictureBox_MouseEnter);
            // 
            // EditContextMenu
            // 
            this.EditContextMenu.Name = "EditContextMenu";
            this.EditContextMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.EditContextMenu.Size = new System.Drawing.Size(151, 98);
            // 
            // lnkTrackTitle
            // 
            this.lnkTrackTitle.ContextMenuStrip = this.EditContextMenu;
            this.lnkTrackTitle.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.lnkTrackTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkTrackTitle.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.lnkTrackTitle.LinkColor = System.Drawing.Color.Black;
            this.lnkTrackTitle.Location = new System.Drawing.Point(106, 19);
            this.lnkTrackTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lnkTrackTitle.Name = "lnkTrackTitle";
            this.lnkTrackTitle.Size = new System.Drawing.Size(206, 34);
            this.lnkTrackTitle.TabIndex = 16;
            this.lnkTrackTitle.TabStop = true;
            this.lnkTrackTitle.Text = "The Track Title Goes Here";
            this.lnkTrackTitle.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabel_LinkClicked);
            // 
            // lnkPlaylistHistory
            // 
            this.lnkPlaylistHistory.AutoSize = true;
            this.lnkPlaylistHistory.ContextMenuStrip = this.EditContextMenu;
            this.lnkPlaylistHistory.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkPlaylistHistory.LinkColor = System.Drawing.Color.RoyalBlue;
            this.lnkPlaylistHistory.Location = new System.Drawing.Point(104, 80);
            this.lnkPlaylistHistory.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lnkPlaylistHistory.Name = "lnkPlaylistHistory";
            this.lnkPlaylistHistory.Size = new System.Drawing.Size(135, 13);
            this.lnkPlaylistHistory.TabIndex = 13;
            this.lnkPlaylistHistory.TabStop = true;
            this.lnkPlaylistHistory.Text = "Recent Playlist History";
            this.lnkPlaylistHistory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabel_LinkClicked);
            // 
            // lnkPostComments
            // 
            this.lnkPostComments.AutoSize = true;
            this.lnkPostComments.ContextMenuStrip = this.EditContextMenu;
            this.lnkPostComments.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkPostComments.LinkBehavior = System.Windows.Forms.LinkBehavior.AlwaysUnderline;
            this.lnkPostComments.LinkColor = System.Drawing.Color.Red;
            this.lnkPostComments.Location = new System.Drawing.Point(105, 63);
            this.lnkPostComments.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lnkPostComments.Name = "lnkPostComments";
            this.lnkPostComments.Size = new System.Drawing.Size(119, 12);
            this.lnkPostComments.TabIndex = 12;
            this.lnkPostComments.TabStop = true;
            this.lnkPostComments.Text = "Read and Post Comments";
            this.lnkPostComments.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabel_LinkClicked);
            // 
            // picWmp
            // 
            this.picWmp.ContextMenuStrip = this.EditContextMenu;
            this.picWmp.Location = new System.Drawing.Point(384, 32);
            this.picWmp.Margin = new System.Windows.Forms.Padding(2);
            this.picWmp.Name = "picWmp";
            this.picWmp.Size = new System.Drawing.Size(30, 21);
            this.picWmp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picWmp.TabIndex = 6;
            this.picWmp.TabStop = false;
            this.picWmp.MouseLeave += new System.EventHandler(this.PictureBox_MouseLeave);
            this.picWmp.MouseClick += new System.Windows.Forms.MouseEventHandler(this.StreamType_MouseClick);
            this.picWmp.MouseEnter += new System.EventHandler(this.PictureBox_MouseEnter);
            // 
            // picMp3
            // 
            this.picMp3.ContextMenuStrip = this.EditContextMenu;
            this.picMp3.Location = new System.Drawing.Point(316, 32);
            this.picMp3.Margin = new System.Windows.Forms.Padding(2);
            this.picMp3.Name = "picMp3";
            this.picMp3.Size = new System.Drawing.Size(30, 21);
            this.picMp3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picMp3.TabIndex = 5;
            this.picMp3.TabStop = false;
            this.picMp3.MouseLeave += new System.EventHandler(this.PictureBox_MouseLeave);
            this.picMp3.MouseClick += new System.Windows.Forms.MouseEventHandler(this.StreamType_MouseClick);
            this.picMp3.MouseEnter += new System.EventHandler(this.PictureBox_MouseEnter);
            // 
            // pic32k
            // 
            this.pic32k.ContextMenuStrip = this.EditContextMenu;
            this.pic32k.Location = new System.Drawing.Point(384, 60);
            this.pic32k.Margin = new System.Windows.Forms.Padding(2);
            this.pic32k.Name = "pic32k";
            this.pic32k.Size = new System.Drawing.Size(30, 15);
            this.pic32k.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pic32k.TabIndex = 3;
            this.pic32k.TabStop = false;
            this.pic32k.MouseLeave += new System.EventHandler(this.PictureBox_MouseLeave);
            this.pic32k.MouseClick += new System.Windows.Forms.MouseEventHandler(this.StreamType_MouseClick);
            this.pic32k.MouseEnter += new System.EventHandler(this.PictureBox_MouseEnter);
            // 
            // picAacPlus
            // 
            this.picAacPlus.ContextMenuStrip = this.EditContextMenu;
            this.picAacPlus.Location = new System.Drawing.Point(350, 32);
            this.picAacPlus.Margin = new System.Windows.Forms.Padding(2);
            this.picAacPlus.Name = "picAacPlus";
            this.picAacPlus.Size = new System.Drawing.Size(30, 21);
            this.picAacPlus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picAacPlus.TabIndex = 2;
            this.picAacPlus.TabStop = false;
            this.picAacPlus.MouseLeave += new System.EventHandler(this.PictureBox_MouseLeave);
            this.picAacPlus.MouseClick += new System.Windows.Forms.MouseEventHandler(this.StreamType_MouseClick);
            this.picAacPlus.MouseEnter += new System.EventHandler(this.PictureBox_MouseEnter);
            // 
            // pic96k
            // 
            this.pic96k.ContextMenuStrip = this.EditContextMenu;
            this.pic96k.Location = new System.Drawing.Point(316, 60);
            this.pic96k.Margin = new System.Windows.Forms.Padding(2);
            this.pic96k.Name = "pic96k";
            this.pic96k.Size = new System.Drawing.Size(30, 15);
            this.pic96k.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pic96k.TabIndex = 1;
            this.pic96k.TabStop = false;
            this.pic96k.MouseLeave += new System.EventHandler(this.PictureBox_MouseLeave);
            this.pic96k.MouseClick += new System.Windows.Forms.MouseEventHandler(this.StreamType_MouseClick);
            this.pic96k.MouseEnter += new System.EventHandler(this.PictureBox_MouseEnter);
            // 
            // Channel
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.picSiteIcon);
            this.Controls.Add(this.StartTimeLabel);
            this.Controls.Add(this.pic24k);
            this.Controls.Add(this.lnkChannelInfo);
            this.Controls.Add(this.lnkTrackTitle);
            this.Controls.Add(this.lblRecordLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lnkPlaylistHistory);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lnkPostComments);
            this.Controls.Add(this.picWmp);
            this.Controls.Add(this.picMp3);
            this.Controls.Add(this.pic32k);
            this.Controls.Add(this.picAacPlus);
            this.Controls.Add(this.pic96k);
            this.Controls.Add(this.lblChannelName);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Channel";
            this.Size = new System.Drawing.Size(430, 120);
            ((System.ComponentModel.ISupportInitialize)(this.picSiteIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic24k)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWmp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMp3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic32k)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAacPlus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic96k)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected internal System.Windows.Forms.PictureBox pic96k;
        protected internal System.Windows.Forms.PictureBox picAacPlus;
        protected internal System.Windows.Forms.PictureBox pic32k;
        protected internal System.Windows.Forms.PictureBox picMp3;
        protected internal System.Windows.Forms.PictureBox picWmp;
        protected internal System.Windows.Forms.PictureBox pic24k;
        protected internal System.Windows.Forms.PictureBox picSiteIcon;
        protected internal System.Windows.Forms.Label label1;
        protected internal System.Windows.Forms.Label label2;
        protected internal System.Windows.Forms.Label lblChannelName;
        protected internal System.Windows.Forms.LinkLabel lnkTrackTitle;
        protected internal System.Windows.Forms.LinkLabel lnkPostComments;
        protected internal System.Windows.Forms.Label lblRecordLabel;
        protected internal System.Windows.Forms.ToolTip toolTipLinks;
        protected internal System.Windows.Forms.LinkLabel lnkPlaylistHistory;
        protected internal System.Windows.Forms.LinkLabel lnkChannelInfo;
        protected internal System.Windows.Forms.Label StartTimeLabel;
        protected internal BaseContextMenu EditContextMenu;
        private System.ComponentModel.IContainer components;
    }
}
