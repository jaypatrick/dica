namespace DigitallyImported.Controls
{
    partial class ChannelSection
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
            components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;

            this.components = new System.ComponentModel.Container();
            this.lblChannelName = new System.Windows.Forms.Label();
            this.pic96k = new System.Windows.Forms.PictureBox();
            this.picAac = new System.Windows.Forms.PictureBox();
            this.pic32k = new System.Windows.Forms.PictureBox();
            this.picMp3 = new System.Windows.Forms.PictureBox();
            this.picWmp = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lnkPostComments = new System.Windows.Forms.LinkLabel();
            this.lnkPlaylistHistory = new System.Windows.Forms.LinkLabel();
            this.lnkTrackTitle = new System.Windows.Forms.LinkLabel();
            this.lblRecordLabel = new System.Windows.Forms.Label();
            this.lnkRefreshPlaylist = new System.Windows.Forms.LinkLabel();
            this.toolTipLinks = new System.Windows.Forms.ToolTip(this.components);
            this.lnkChannelInfo = new System.Windows.Forms.LinkLabel();
            this.pic24k = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pic96k)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAac)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic32k)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMp3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWmp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic24k)).BeginInit();
            this.SuspendLayout();
            // 
            // lblChannelName
            // 
            this.lblChannelName.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.lblChannelName.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblChannelName.Location = new System.Drawing.Point(16, 8);
            this.lblChannelName.Name = "lblChannelName";
            this.lblChannelName.Size = new System.Drawing.Size(128, 64);
            this.lblChannelName.TabIndex = 0;
            this.lblChannelName.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pic96k
            // 
            this.pic96k.Location = new System.Drawing.Point(451, 73);
            this.pic96k.Name = "pic96k";
            this.pic96k.Size = new System.Drawing.Size(30, 15);
            this.pic96k.TabIndex = 1;
            this.pic96k.TabStop = false;
            this.pic96k.MouseLeave += new System.EventHandler(this.pictureBox_MouseLeave);
            this.pic96k.Click += new System.EventHandler(this.streamType_Click);
            this.pic96k.MouseEnter += new System.EventHandler(this.pictureBox_MouseEnter);
            // 
            // picAac
            // 
            this.picAac.Location = new System.Drawing.Point(489, 39);
            this.picAac.Name = "picAac";
            this.picAac.Size = new System.Drawing.Size(29, 24);
            this.picAac.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picAac.TabIndex = 2;
            this.picAac.TabStop = false;
            this.picAac.MouseLeave += new System.EventHandler(this.pictureBox_MouseLeave);
            this.picAac.Click += new System.EventHandler(this.streamType_Click);
            this.picAac.MouseEnter += new System.EventHandler(this.pictureBox_MouseEnter);
            // 
            // pic32k
            // 
            this.pic32k.Location = new System.Drawing.Point(524, 73);
            this.pic32k.Name = "pic32k";
            this.pic32k.Size = new System.Drawing.Size(30, 15);
            this.pic32k.TabIndex = 3;
            this.pic32k.TabStop = false;
            this.pic32k.MouseLeave += new System.EventHandler(this.pictureBox_MouseLeave);
            this.pic32k.Click += new System.EventHandler(this.streamType_Click);
            this.pic32k.MouseEnter += new System.EventHandler(this.pictureBox_MouseEnter);
            // 
            // picMp3
            // 
            this.picMp3.Location = new System.Drawing.Point(451, 39);
            this.picMp3.Name = "picMp3";
            this.picMp3.Size = new System.Drawing.Size(30, 24);
            this.picMp3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picMp3.TabIndex = 5;
            this.picMp3.TabStop = false;
            this.picMp3.MouseLeave += new System.EventHandler(this.pictureBox_MouseLeave);
            this.picMp3.Click += new System.EventHandler(this.streamType_Click);
            this.picMp3.MouseEnter += new System.EventHandler(this.pictureBox_MouseEnter);
            // 
            // picWmp
            // 
            this.picWmp.Location = new System.Drawing.Point(524, 39);
            this.picWmp.Name = "picWmp";
            this.picWmp.Size = new System.Drawing.Size(30, 24);
            this.picWmp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picWmp.TabIndex = 6;
            this.picWmp.TabStop = false;
            this.picWmp.MouseLeave += new System.EventHandler(this.pictureBox_MouseLeave);
            this.picWmp.Click += new System.EventHandler(this.streamType_Click);
            this.picWmp.MouseEnter += new System.EventHandler(this.pictureBox_MouseEnter);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(448, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "Listen Now!";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(152, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(186, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "Currently Playing:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lnkPostComments
            // 
            this.lnkPostComments.Font = new System.Drawing.Font("Tahoma", 6.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkPostComments.LinkBehavior = System.Windows.Forms.LinkBehavior.AlwaysUnderline;
            this.lnkPostComments.LinkColor = System.Drawing.Color.Red;
            this.lnkPostComments.Location = new System.Drawing.Point(152, 72);
            this.lnkPostComments.Name = "lnkPostComments";
            this.lnkPostComments.Size = new System.Drawing.Size(288, 16);
            this.lnkPostComments.TabIndex = 12;
            this.lnkPostComments.TabStop = true;
            this.lnkPostComments.Text = "Read and Post Comments";
            this.lnkPostComments.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkPostComments_LinkClicked);
            // 
            // lnkPlaylistHistory
            // 
            this.lnkPlaylistHistory.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkPlaylistHistory.LinkColor = System.Drawing.Color.RoyalBlue;
            this.lnkPlaylistHistory.Location = new System.Drawing.Point(152, 96);
            this.lnkPlaylistHistory.Name = "lnkPlaylistHistory";
            this.lnkPlaylistHistory.Size = new System.Drawing.Size(168, 16);
            this.lnkPlaylistHistory.TabIndex = 13;
            this.lnkPlaylistHistory.TabStop = true;
            this.lnkPlaylistHistory.Text = "Recent Playlist History";
            this.lnkPlaylistHistory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkPlaylistHistory_LinkClicked);
            // 
            // lnkTrackTitle
            // 
            this.lnkTrackTitle.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.lnkTrackTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkTrackTitle.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.lnkTrackTitle.LinkColor = System.Drawing.Color.Black;
            this.lnkTrackTitle.Location = new System.Drawing.Point(152, 24);
            this.lnkTrackTitle.Name = "lnkTrackTitle";
            this.lnkTrackTitle.Size = new System.Drawing.Size(288, 32);
            this.lnkTrackTitle.TabIndex = 16;
            this.lnkTrackTitle.TabStop = true;
            this.lnkTrackTitle.Text = "The Track Title Goes Here";
            this.lnkTrackTitle.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkTrackTitle_LinkClicked);
            // 
            // lblRecordLabel
            // 
            this.lblRecordLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.8F);
            this.lblRecordLabel.Location = new System.Drawing.Point(152, 56);
            this.lblRecordLabel.Name = "lblRecordLabel";
            this.lblRecordLabel.Size = new System.Drawing.Size(288, 16);
            this.lblRecordLabel.TabIndex = 17;
            // 
            // lnkRefreshPlaylist
            // 
            this.lnkRefreshPlaylist.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.lnkRefreshPlaylist.LinkBehavior = System.Windows.Forms.LinkBehavior.AlwaysUnderline;
            this.lnkRefreshPlaylist.LinkColor = System.Drawing.Color.RoyalBlue;
            this.lnkRefreshPlaylist.Location = new System.Drawing.Point(448, 96);
            this.lnkRefreshPlaylist.Name = "lnkRefreshPlaylist";
            this.lnkRefreshPlaylist.Size = new System.Drawing.Size(112, 16);
            this.lnkRefreshPlaylist.TabIndex = 18;
            this.lnkRefreshPlaylist.TabStop = true;
            this.lnkRefreshPlaylist.Text = "Refresh Playlist";
            this.lnkRefreshPlaylist.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lnkRefreshPlaylist.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkRefreshPlaylist_LinkClicked);
            // 
            // toolTipLinks
            // 
            this.toolTipLinks.AutomaticDelay = 100;
            this.toolTipLinks.AutoPopDelay = 30000;
            this.toolTipLinks.InitialDelay = 100;
            this.toolTipLinks.ReshowDelay = 20;
            this.toolTipLinks.Popup += new System.Windows.Forms.PopupEventHandler(this.toolTipLinks_Popup);
            // 
            // lnkChannelInfo
            // 
            this.lnkChannelInfo.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkChannelInfo.LinkBehavior = System.Windows.Forms.LinkBehavior.AlwaysUnderline;
            this.lnkChannelInfo.LinkColor = System.Drawing.Color.RoyalBlue;
            this.lnkChannelInfo.Location = new System.Drawing.Point(16, 96);
            this.lnkChannelInfo.Name = "lnkChannelInfo";
            this.lnkChannelInfo.Size = new System.Drawing.Size(128, 16);
            this.lnkChannelInfo.TabIndex = 19;
            this.lnkChannelInfo.TabStop = true;
            this.lnkChannelInfo.Text = "Channel Info";
            this.lnkChannelInfo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lnkChannelInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkChannelInfo_LinkClicked);
            // 
            // pic24k
            // 
            this.pic24k.Location = new System.Drawing.Point(488, 73);
            this.pic24k.Name = "pic24k";
            this.pic24k.Size = new System.Drawing.Size(30, 15);
            this.pic24k.TabIndex = 20;
            this.pic24k.TabStop = false;
            this.pic24k.MouseLeave += new System.EventHandler(this.pictureBox_MouseLeave);
            this.pic24k.Click += new System.EventHandler(this.streamType_Click);
            this.pic24k.MouseEnter += new System.EventHandler(this.pictureBox_MouseEnter);
            // 
            // ChannelSection
            // 
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.pic24k);
            this.Controls.Add(this.lnkChannelInfo);
            this.Controls.Add(this.lnkRefreshPlaylist);
            this.Controls.Add(this.lblRecordLabel);
            this.Controls.Add(this.lnkTrackTitle);
            this.Controls.Add(this.lnkPlaylistHistory);
            this.Controls.Add(this.lnkPostComments);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.picWmp);
            this.Controls.Add(this.picMp3);
            this.Controls.Add(this.pic32k);
            this.Controls.Add(this.picAac);
            this.Controls.Add(this.pic96k);
            this.Controls.Add(this.lblChannelName);
            this.DoubleBuffered = true;
            this.Name = "ChannelSection";
            this.Size = new System.Drawing.Size(563, 112);
            ((System.ComponentModel.ISupportInitialize)(this.pic96k)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAac)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic32k)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMp3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWmp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic24k)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion
    }
}
