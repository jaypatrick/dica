namespace DigitallyImported.Controls.Windows
{
    partial class PremiumChannel
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
        protected internal override void InitializeComponent()
        {
            base.InitializeComponent();

            this.picAac = new System.Windows.Forms.PictureBox();
            this.pic256k = new System.Windows.Forms.PictureBox();
            this.pic128kAac = new System.Windows.Forms.PictureBox();
            this.pic128kWmp = new System.Windows.Forms.PictureBox();
            this.pic64k = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pic96k)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAacPlus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic32k)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMp3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWmp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic24k)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSiteIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAac)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic256k)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic128kAac)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic128kWmp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic64k)).BeginInit();
            this.SuspendLayout();
            // 
            // pic96k
            // 
            this.pic96k.Location = new System.Drawing.Point(374, 80);
            this.pic96k.Visible = false;
            // 
            // picAacPlus
            // 
            this.picAacPlus.Location = new System.Drawing.Point(362, 51);
            // 
            // pic32k
            // 
            this.pic32k.Location = new System.Drawing.Point(397, 80);
            this.pic32k.Visible = false;
            // 
            // picMp3
            // 
            this.picMp3.Location = new System.Drawing.Point(291, 24);
            // 
            // picWmp
            // 
            this.picWmp.Location = new System.Drawing.Point(361, 26);
            // 
            // pic24k
            // 
            this.pic24k.Location = new System.Drawing.Point(384, 79);
            this.pic24k.Visible = false;
            // 
            // lnkTrackTitle
            // 
            this.lnkTrackTitle.Size = new System.Drawing.Size(180, 32);
            // 
            // lblRecordLabel
            // 
            this.lblRecordLabel.Size = new System.Drawing.Size(180, 10);
            // 
            // StartTimeLabel
            // 
            this.StartTimeLabel.Location = new System.Drawing.Point(323, 79);
            // 
            // picAac
            // 
            this.picAac.Location = new System.Drawing.Point(291, 51);
            this.picAac.Name = "picAac";
            this.picAac.Size = new System.Drawing.Size(30, 21);
            this.picAac.TabIndex = 24;
            this.picAac.TabStop = false;
            // 
            // pic256k
            // 
            this.pic256k.Location = new System.Drawing.Point(326, 30);
            this.pic256k.Name = "pic256k";
            this.pic256k.Size = new System.Drawing.Size(30, 15);
            this.pic256k.TabIndex = 25;
            this.pic256k.TabStop = false;
            this.pic256k.MouseClick += new System.Windows.Forms.MouseEventHandler(this.StreamType_MouseClick);
            this.pic256k.MouseEnter += new System.EventHandler(this.PictureBox_MouseEnter);
            // 
            // pic128kAac
            // 
            this.pic128kAac.Location = new System.Drawing.Point(326, 57);
            this.pic128kAac.Name = "pic128kAac";
            this.pic128kAac.Size = new System.Drawing.Size(30, 15);
            this.pic128kAac.TabIndex = 26;
            this.pic128kAac.TabStop = false;
            this.pic128kAac.MouseClick += new System.Windows.Forms.MouseEventHandler(this.StreamType_MouseClick);
            this.pic128kAac.MouseEnter += new System.EventHandler(this.PictureBox_MouseEnter);
            // 
            // pic128kWmp
            // 
            this.pic128kWmp.Location = new System.Drawing.Point(397, 30);
            this.pic128kWmp.Name = "pic128kWmp";
            this.pic128kWmp.Size = new System.Drawing.Size(30, 15);
            this.pic128kWmp.TabIndex = 27;
            this.pic128kWmp.TabStop = false;
            this.pic128kWmp.MouseClick += new System.Windows.Forms.MouseEventHandler(this.StreamType_MouseClick);
            this.pic128kWmp.MouseEnter += new System.EventHandler(this.PictureBox_MouseEnter);
            // 
            // pic64k
            // 
            this.pic64k.Location = new System.Drawing.Point(397, 57);
            this.pic64k.Name = "pic64k";
            this.pic64k.Size = new System.Drawing.Size(30, 15);
            this.pic64k.TabIndex = 28;
            this.pic64k.TabStop = false;
            this.pic64k.MouseClick += new System.Windows.Forms.MouseEventHandler(this.StreamType_MouseClick);
            this.pic64k.MouseEnter += new System.EventHandler(this.PictureBox_MouseEnter);
            // 
            // PremiumChannel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.pic64k);
            this.Controls.Add(this.pic128kWmp);
            this.Controls.Add(this.pic128kAac);
            this.Controls.Add(this.picAac);
            this.Controls.Add(this.pic256k);
            this.Name = "PremiumChannel";
            this.Controls.SetChildIndex(this.pic256k, 0);
            this.Controls.SetChildIndex(this.pic96k, 0);
            this.Controls.SetChildIndex(this.picWmp, 0);
            this.Controls.SetChildIndex(this.picAacPlus, 0);
            this.Controls.SetChildIndex(this.pic32k, 0);
            this.Controls.SetChildIndex(this.pic24k, 0);
            this.Controls.SetChildIndex(this.picAac, 0);
            this.Controls.SetChildIndex(this.picMp3, 0);
            this.Controls.SetChildIndex(this.lblChannelName, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.lnkPostComments, 0);
            this.Controls.SetChildIndex(this.lnkPlaylistHistory, 0);
            this.Controls.SetChildIndex(this.lnkTrackTitle, 0);
            this.Controls.SetChildIndex(this.lblRecordLabel, 0);
            this.Controls.SetChildIndex(this.lnkChannelInfo, 0);
            this.Controls.SetChildIndex(this.picSiteIcon, 0);
            this.Controls.SetChildIndex(this.StartTimeLabel, 0);
            this.Controls.SetChildIndex(this.pic128kAac, 0);
            this.Controls.SetChildIndex(this.pic128kWmp, 0);
            this.Controls.SetChildIndex(this.pic64k, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pic96k)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAacPlus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic32k)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMp3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWmp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic24k)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSiteIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAac)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic256k)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic128kAac)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic128kWmp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic64k)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picAac;
        private System.Windows.Forms.PictureBox pic256k;
        private System.Windows.Forms.PictureBox pic128kAac;
        private System.Windows.Forms.PictureBox pic128kWmp;
        private System.Windows.Forms.PictureBox pic64k;
    }
}
