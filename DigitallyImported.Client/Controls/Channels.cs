using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


using DigitallyImported.Configuration.Properties;
using DigitallyImported.Components;
using DigitallyImported.Resources.Properties;

namespace DigitallyImported.Client.Controls
{
    /// <summary>
    /// 
    /// </summary>
    public partial class Channels : DigitallyImported.Controls.ChannelList
    {
        /// <summary>
        /// 
        /// </summary>
        public Channels()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        public override bool IsSelected
        {
            get
            {
                return this.isSelected;
            }
            set
            {
                this.isSelected = value;
                if (value == true)
                {
                    this.BackColor = Settings.Default.SelectedChannelBackground;
                    this.Focus();
                }
                else
                {
                    if (this.isAlternating)
                        this.BackColor = Settings.Default.AlternatingChannelBackground;
                    else
                        this.BackColor = Color.Transparent;
                }
            }
        }
        private bool isSelected = false;

        /// <summary>
        /// 
        /// </summary>
        public override bool IsAlternating
        {
            get
            {
                return this.isAlternating;
            }
            set
            {
                this.isAlternating = value;
                if (value == true)
                    this.BackColor = Settings.Default.AlternatingChannelBackground;
                else
                    this.BackColor = Color.Transparent;
            }
        }
        private bool isAlternating;
    }
}

