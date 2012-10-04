using System.Windows.Forms;
using DigitallyImported.Components;
namespace DigitallyImported.Client
{
    partial class PlaylistForm<TChannel, TTrack>
        where TChannel: UserControl, IChannel, new()
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlaylistForm<,>));
            this.SuspendLayout();
            // 
            // PlaylistContainer
            // 
            this.PlaylistContainer.AutoSize = true;
            this.PlaylistContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PlaylistContainer.Location = new System.Drawing.Point(0, 0);
            this.PlaylistContainer.Name = "PlaylistContainer";
            this.PlaylistContainer.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.PlaylistContainer.Size = new System.Drawing.Size(460, 626);
            this.PlaylistContainer.TabIndex = 0;
            // 
            // PlaylistForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(460, 626);
            this.Controls.Add(this.PlaylistContainer);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            //this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "PlaylistForm";
            this.Text = "PlaylistForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}