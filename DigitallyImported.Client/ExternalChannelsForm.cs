using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using DigitallyImported.Client.Controls;
using DigitallyImported.Components;
using C = DigitallyImported.Configuration.Properties;
using P = DigitallyImported.Resources.Properties;
using System.Threading.Tasks;

namespace DigitallyImported.Client
{
    public partial class ExternalChannelsForm : BaseForm
    {
        private ExternalChannelPickerControl[] _pickerControls;

        private string _channelsFileName = string.Format("{0}/{1}", Environment.CurrentDirectory, C.Settings.Default.ExternalPlaylistXml);

        ExternalChannelEntryCollection<ExternalChannelEntry<string, Uri>> _externalEntries;

        public ExternalChannelsForm()
            //: this(new ExternalChannelEntryCollection<ExternalChannelEntry<string, Uri>>())
        {
            InitializeComponent();
        }

        public ExternalChannelsForm(ExternalChannelEntryCollection<ExternalChannelEntry<string, Uri>> externalEntries)
        {
            InitializeComponent();

            _externalEntries = externalEntries;
        }

        public ExternalChannelEntryCollection<ExternalChannelEntry<string, Uri>> ExternalEntries
        {
            get { return _externalEntries; }
        }

        protected internal void RemoveChannel(string name)
        {
            if (_externalEntries.ContainsKey(name))
                _externalEntries.Remove(name);
        }

        protected internal void AddChannel(string channelName, Uri channelUri)
        {
            if (!_externalEntries.ContainsKey(channelName))
                _externalEntries.Add(channelName, channelUri);
        }

        protected internal void Save()
        {
            FileStream fileStream = new FileStream(_channelsFileName, FileMode.Create);

            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.NewLineHandling = NewLineHandling.Entitize;

            XmlWriter writer = XmlTextWriter.Create(fileStream, settings);

            _externalEntries.WriteXml(writer);
            writer.Flush();
        }

        private void ChannelPicker_ChannelAdded(object sender, EventArgs e)
        {
            // add new instance of the control and assign event handler recursively

            ExternalChannelPickerControl newPicker = new ExternalChannelPickerControl();
            WirePickerEvents(newPicker);

            this.ExternalChannelPickerPanel.Controls.Add(newPicker);
        }

        private void ChannelPicker_ChannelRemoved(object sender, EventArgs e)
        {
            ExternalChannelPickerControl control = ((Button)sender).Parent as ExternalChannelPickerControl;

            if (control != null)
            {
                this.ExternalChannelPickerPanel.Controls.RemoveByKey(control.Name);

                RemoveChannel(control.Name);
            }
        }

        private void ExternalChannelsForm_Load(object sender, EventArgs e)
        {
            _externalEntries = new ExternalChannelEntryCollection<ExternalChannelEntry<string, Uri>>();         
            XmlReader reader;

            // read in settings
            if (File.Exists(_channelsFileName))
            {
                reader = XmlReader.Create(_channelsFileName);

                _externalEntries.ReadXml(reader);
                this.ChannelCountLabel.Text = string.Format(P.Resources.ChannelsAvailableNumber, _externalEntries.Count.ToString());

                _pickerControls = new ExternalChannelPickerControl[_externalEntries.Count];

                Parallel.ForEach(_externalEntries, entry => 

                // foreach (KeyValuePair<string, Uri> entry in _externalEntries)
                {
                    ExternalChannelPickerControl control = new ExternalChannelPickerControl(entry.Key, entry.Value);

                    control.Name = entry.Key;
                    WirePickerEvents(control);

                    this.ExternalChannelPickerPanel.Controls.Add(control);
                });
            }

            ExternalChannelPickerControl picker = new ExternalChannelPickerControl();
            WirePickerEvents(picker);

            this.ExternalChannelPickerPanel.Controls.Add(picker);
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            // loop through, add all entries to dictionary, and save
            foreach (Control control in this.ExternalChannelPickerPanel.Controls)
            {
                ExternalChannelPickerControl channelPicker = control as ExternalChannelPickerControl;

                if (channelPicker != null)
                {
                    if (!string.IsNullOrEmpty(channelPicker.ChannelName) && !_externalEntries.ContainsKey(channelPicker.ChannelName))
                    {
                        _externalEntries.Add(channelPicker.ChannelName, channelPicker.ChannelUri);
                    }
                    else
                    {
                        // alert user
                    }
                }
            }

            Save();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            // ?
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            this.ExternalChannelPickerPanel.Controls.Clear();
            this.ExternalChannelPickerPanel.Controls.Add(new ExternalChannelPickerControl());
            this.OnLoad(e); // reload gui
        }

        private void WirePickerEvents(ExternalChannelPickerControl control)
        {
            control.ChannelSaved += new EventHandler<EventArgs>(ChannelPicker_ChannelAdded);
            control.ChannelRemoved += new EventHandler<EventArgs>(ChannelPicker_ChannelRemoved);
        }
    }
}