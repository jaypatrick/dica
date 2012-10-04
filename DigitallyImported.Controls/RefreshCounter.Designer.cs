namespace DigitallyImported.Controls
{
    partial class RefreshCounter
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
            this.countdownTimer = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // countdownTimer
            // 
            this.countdownTimer.CustomFormat = "mm:ss";
            this.countdownTimer.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.countdownTimer.Location = new System.Drawing.Point(0, 0);
            this.countdownTimer.Margin = new System.Windows.Forms.Padding(2);
            this.countdownTimer.Name = "countdownTimer";
            this.countdownTimer.ShowUpDown = true;
            this.countdownTimer.Size = new System.Drawing.Size(58, 20);
            this.countdownTimer.TabIndex = 0;
            // 
            // RefreshCounter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.countdownTimer);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "RefreshCounter";
            this.Size = new System.Drawing.Size(57, 18);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker countdownTimer;
    }
}
