namespace DigitallyImported.Client
{
    partial class ExternalChannelsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExternalChannelsForm));
            this.ChannelsGroupBox = new System.Windows.Forms.GroupBox();
            this.ExternalChannelPickerPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.ChannelPicker = new DigitallyImported.Client.Controls.ExternalChannelPickerControl();
            this.FavoritesStatusStrip = new System.Windows.Forms.StatusStrip();
            this.ChannelCountLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.ClearButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.ChannelsGroupBox.SuspendLayout();
            this.ExternalChannelPickerPanel.SuspendLayout();
            this.FavoritesStatusStrip.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ChannelsGroupBox
            // 
            this.ChannelsGroupBox.Controls.Add(this.ExternalChannelPickerPanel);
            this.ChannelsGroupBox.Location = new System.Drawing.Point(3, 3);
            this.ChannelsGroupBox.Name = "ChannelsGroupBox";
            this.ChannelsGroupBox.Size = new System.Drawing.Size(587, 247);
            this.ChannelsGroupBox.TabIndex = 0;
            this.ChannelsGroupBox.TabStop = false;
            this.ChannelsGroupBox.Text = "External Channels";
            // 
            // ExternalChannelPickerPanel
            // 
            this.ExternalChannelPickerPanel.AutoScroll = true;
            //this.ExternalChannelPickerPanel.Controls.Add(this.ChannelPicker);
            this.ExternalChannelPickerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ExternalChannelPickerPanel.Location = new System.Drawing.Point(3, 16);
            this.ExternalChannelPickerPanel.Name = "ExternalChannelPickerPanel";
            this.ExternalChannelPickerPanel.Size = new System.Drawing.Size(581, 228);
            this.ExternalChannelPickerPanel.TabIndex = 0;
            // 
            // ChannelPicker
            // 
            this.ChannelPicker.Location = new System.Drawing.Point(3, 3);
            this.ChannelPicker.Name = "ChannelPicker";
            this.ChannelPicker.Size = new System.Drawing.Size(575, 29);
            this.ChannelPicker.TabIndex = 0;
            this.ChannelPicker.ChannelRemoved += new System.EventHandler<System.EventArgs>(this.ChannelPicker_ChannelRemoved);
            this.ChannelPicker.ChannelSaved += new System.EventHandler<System.EventArgs>(this.ChannelPicker_ChannelAdded);
            // 
            // FavoritesStatusStrip
            // 
            this.FavoritesStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ChannelCountLabel});
            this.FavoritesStatusStrip.Location = new System.Drawing.Point(0, 286);
            this.FavoritesStatusStrip.Name = "FavoritesStatusStrip";
            this.FavoritesStatusStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.FavoritesStatusStrip.Size = new System.Drawing.Size(593, 22);
            this.FavoritesStatusStrip.TabIndex = 1;
            this.FavoritesStatusStrip.Text = "statusStrip1";
            // 
            // ChannelCountLabel
            // 
            this.ChannelCountLabel.Name = "ChannelCountLabel";
            this.ChannelCountLabel.Size = new System.Drawing.Size(13, 17);
            this.ChannelCountLabel.Text = "0";
            // 
            // ClearButton
            // 
            this.ClearButton.Location = new System.Drawing.Point(165, 256);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(75, 23);
            this.ClearButton.TabIndex = 7;
            this.ClearButton.Text = "Clear";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelButton.Location = new System.Drawing.Point(84, 256);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 6;
            this.CancelButton.Text = "&Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.SaveButton.Location = new System.Drawing.Point(3, 256);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 5;
            this.SaveButton.Text = "&Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ChannelsGroupBox);
            this.panel1.Controls.Add(this.SaveButton);
            this.panel1.Controls.Add(this.CancelButton);
            this.panel1.Controls.Add(this.ClearButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(593, 286);
            this.panel1.TabIndex = 8;
            // 
            // ExternalChannelsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 308);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.FavoritesStatusStrip);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ExternalChannelsForm";
            this.ShowInTaskbar = false;
            this.Text = "External Channel List";
            this.Load += new System.EventHandler(this.ExternalChannelsForm_Load);
            this.ChannelsGroupBox.ResumeLayout(false);
            this.ExternalChannelPickerPanel.ResumeLayout(false);
            this.FavoritesStatusStrip.ResumeLayout(false);
            this.FavoritesStatusStrip.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox ChannelsGroupBox;
        private System.Windows.Forms.StatusStrip FavoritesStatusStrip;
        private System.Windows.Forms.FlowLayoutPanel ExternalChannelPickerPanel;
        private System.Windows.Forms.ToolStripStatusLabel ChannelCountLabel;
        private DigitallyImported.Client.Controls.ExternalChannelPickerControl ChannelPicker;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.FlowLayoutPanel panel1;
    }
}