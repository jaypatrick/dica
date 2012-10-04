namespace DigitallyImported.Client
{
    partial class HistoryForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HistoryForm));
            this.lnkTitle = new System.Windows.Forms.LinkLabel();
            this.HistoryPanel = new DigitallyImported.Utilities.ChannelPanel<DigitallyImported.Utilities.PremiumChannel>();
            this.SuspendLayout();
            // 
            // lnkTitle
            // 
            this.lnkTitle.AutoSize = true;
            this.lnkTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkTitle.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lnkTitle.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.lnkTitle.LinkColor = System.Drawing.Color.Black;
            this.lnkTitle.Location = new System.Drawing.Point(12, 0);
            this.lnkTitle.Name = "lnkTitle";
            this.lnkTitle.Size = new System.Drawing.Size(43, 20);
            this.lnkTitle.TabIndex = 0;
            this.lnkTitle.TabStop = true;
            this.lnkTitle.Text = "Title";
            // 
            // HistoryPanel
            // 
            this.HistoryPanel.BackColor = System.Drawing.Color.Transparent;
            this.HistoryPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.HistoryPanel.Location = new System.Drawing.Point(0, 23);
            this.HistoryPanel.Name = "HistoryPanel";
            this.HistoryPanel.Size = new System.Drawing.Size(305, 341);
            this.HistoryPanel.TabIndex = 1;
            this.HistoryPanel.WrapContents = false;
            // 
            // HistoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(309, 376);
            this.Controls.Add(this.lnkTitle);
            this.Controls.Add(this.HistoryPanel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HistoryForm";
            this.Opacity = 0.8;
            this.ShowInTaskbar = false;
            this.Text = "HistoryForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel lnkTitle;
        private DigitallyImported.Utilities.ChannelPanel<DigitallyImported.Utilities.PremiumChannel> HistoryPanel;

    }
}