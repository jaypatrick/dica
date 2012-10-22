using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using DigitallyImported.Client.Controls;
using DigitallyImported.Components;
using C = DigitallyImported.Configuration.Properties;
using P = DigitallyImported.Resources.Properties;

namespace DigitallyImported.Client
{
    public partial class ExternalChannelsForm : BaseForm
    {
        private readonly string _channelsFileName = string.Format("{0}/{1}", Environment.CurrentDirectory,
                                                                  C.Settings.Default.ExternalPlaylistXml);

        private ExternalChannelEntryCollection<ExternalChannelEntry<string, Uri>> _externalEntries;

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
            var fileStream = new FileStream(_channelsFileName, FileMode.Create);

            var settings = new XmlWriterSettings {Indent = true, NewLineHandling = NewLineHandling.Entitize};

            XmlWriter writer = XmlWriter.Create(fileStream, settings);

            _externalEntries.WriteXml(writer);
            writer.Flush();
        }

        private void ChannelPicker_ChannelAdded(object sender, EventArgs e)
        {
            // add new instance of the control and assign event handler recursively

            var newPicker = new ExternalChannelPickerControl();
            WirePickerEvents(newPicker);

            ExternalChannelPickerPanel.Controls.Add(newPicker);
        }

        private void ChannelPicker_ChannelRemoved(object sender, EventArgs e)
        {
            var control = ((Button) sender).Parent as ExternalChannelPickerControl;

            if (control != null)
            {
                ExternalChannelPickerPanel.Controls.RemoveByKey(control.Name);

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
                ChannelCountLabel.Text = string.Format(P.Resources.ChannelsAvailableNumber,
                                                       _externalEntries.Count.ToString());

                Parallel.ForEach(_externalEntries, entry =>
                                                   // foreach (KeyValuePair<string, Uri> entry in _externalEntries)
                    {
                        var control = new ExternalChannelPickerControl(entry.Key, entry.Value) {Name = entry.Key};

                        WirePickerEvents(control);

                        ExternalChannelPickerPanel.Controls.Add(control);
                    });
            }

            var picker = new ExternalChannelPickerControl();
            WirePickerEvents(picker);

            ExternalChannelPickerPanel.Controls.Add(picker);
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            // loop through, add all entries to dictionary, and save
            foreach (Control control in ExternalChannelPickerPanel.Controls)
            {
                var channelPicker = control as ExternalChannelPickerControl;

                if (channelPicker != null)
                {
                    if (!string.IsNullOrEmpty(channelPicker.ChannelName) &&
                        !_externalEntries.ContainsKey(channelPicker.ChannelName))
                    {
                        _externalEntries.Add(channelPicker.ChannelName, channelPicker.ChannelUri);
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
            ExternalChannelPickerPanel.Controls.Clear();
            ExternalChannelPickerPanel.Controls.Add(new ExternalChannelPickerControl());
            OnLoad(e); // reload gui
        }

        private void WirePickerEvents(ExternalChannelPickerControl control)
        {
            control.ChannelSaved += ChannelPicker_ChannelAdded;
            control.ChannelRemoved += ChannelPicker_ChannelRemoved;
        }
    }
}