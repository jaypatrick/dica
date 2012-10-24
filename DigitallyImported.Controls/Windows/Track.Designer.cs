namespace DigitallyImported.Controls.Windows
{
    partial class Track
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
            this.toolTipLinks = new System.Windows.Forms.ToolTip(this.components);
            this.lnkTrackTitle = new System.Windows.Forms.LinkLabel();
            this.lblRecordLabel = new System.Windows.Forms.Label();
            this.lnkCounter = new System.Windows.Forms.LinkLabel();
            this.lnkPostComments = new System.Windows.Forms.LinkLabel();
            this.EditContextMenu = new BaseContextMenu(this.components);
            this.SuspendLayout();
            // 
            // lnkTrackTitle
            // 
            this.lnkTrackTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkTrackTitle.ForeColor = System.Drawing.Color.Gray;
            this.lnkTrackTitle.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.lnkTrackTitle.LinkColor = System.Drawing.Color.Black;
            this.lnkTrackTitle.Location = new System.Drawing.Point(24, 0);
            this.lnkTrackTitle.Name = "lnkTrackTitle";
            this.lnkTrackTitle.Size = new System.Drawing.Size(276, 37);
            this.lnkTrackTitle.TabIndex = 1;
            this.lnkTrackTitle.TabStop = true;
            this.lnkTrackTitle.Text = "Track Title";
            // 
            // lblRecordLabel
            // 
            this.lblRecordLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.8F);
            this.lblRecordLabel.Location = new System.Drawing.Point(24, 49);
            this.lblRecordLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRecordLabel.Name = "lblRecordLabel";
            this.lblRecordLabel.Size = new System.Drawing.Size(120, 16);
            this.lblRecordLabel.TabIndex = 18;
            this.lblRecordLabel.Text = "Record Label";
            // 
            // lnkCounter
            // 
            this.lnkCounter.AutoSize = true;
            this.lnkCounter.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkCounter.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.lnkCounter.LinkColor = System.Drawing.Color.Black;
            this.lnkCounter.Location = new System.Drawing.Point(1, 0);
            this.lnkCounter.Name = "lnkCounter";
            this.lnkCounter.Size = new System.Drawing.Size(17, 17);
            this.lnkCounter.TabIndex = 19;
            this.lnkCounter.TabStop = true;
            this.lnkCounter.Text = "0";
            // 
            // lnkPostComments
            // 
            this.lnkPostComments.AutoSize = true;
            this.lnkPostComments.ContextMenuStrip = this.EditContextMenu;
            this.lnkPostComments.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkPostComments.LinkBehavior = System.Windows.Forms.LinkBehavior.AlwaysUnderline;
            this.lnkPostComments.LinkColor = System.Drawing.Color.Red;
            this.lnkPostComments.Location = new System.Drawing.Point(25, 37);
            this.lnkPostComments.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lnkPostComments.Name = "lnkPostComments";
            this.lnkPostComments.Size = new System.Drawing.Size(119, 12);
            this.lnkPostComments.TabIndex = 13;
            this.lnkPostComments.TabStop = true;
            this.lnkPostComments.Text = "Read and Post Comments";
            this.lnkPostComments.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabel_LinkClicked);
            // 
            // EditContextMenu
            // 
            this.EditContextMenu.Name = "EditContextMenu";
            this.EditContextMenu.Size = new System.Drawing.Size(151, 98);
            // 
            // Track
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.lnkCounter);
            this.Controls.Add(this.lblRecordLabel);
            this.Controls.Add(this.lnkPostComments);
            this.Controls.Add(this.lnkTrackTitle);
            this.DoubleBuffered = true;
            this.Name = "Track";
            this.Size = new System.Drawing.Size(300, 65);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private BaseContextMenu EditContextMenu;
        private System.Windows.Forms.ToolTip toolTipLinks;
        private System.Windows.Forms.LinkLabel lnkTrackTitle;
        protected internal System.Windows.Forms.LinkLabel lnkPostComments;
        protected internal System.Windows.Forms.Label lblRecordLabel;
        private System.Windows.Forms.LinkLabel lnkCounter;
    }
}
