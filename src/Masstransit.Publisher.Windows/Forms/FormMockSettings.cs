using Masstransit.Publisher.Domain.Classes;
using Masstransit.Publisher.Domain.Interfaces;
using Masstransit.Publisher.Windows.Forms.UserControls;

namespace Masstransit.Publisher.Windows.Forms
{
    public partial class FormMockSettings : Form
    {
        private readonly IMockInterfaceService _mockService;

        public LocalConfiguration LocalConfiguration { get; set; }

        public FormMockSettings(IMockInterfaceService mockService, LocalConfiguration localConfiguration)
        {
            InitializeComponent();

            LocalConfiguration = localConfiguration ?? throw new ArgumentNullException(nameof(localConfiguration));

            if (localConfiguration.MockSettings == null)
                throw new InvalidOperationException("The mock settings could not be null.");

            _mockService = mockService;

            numericUpDownMaxArrayLength.Value = localConfiguration.MockSettings.MaxArrayLength;
            numericUpDownMinArrayLength.Value = localConfiguration.MockSettings.MinArrayLength;

            foreach (var mockSetting in LocalConfiguration.MockSettings.CustomProperties)
            {
                var userControlMockSettings = new UserControlMockSettings(mockSetting, () =>
                {
                    LocalConfiguration.MockSettings.CustomProperties.Remove(mockSetting);
                });

                flowLayoutPanel.Controls.Add(userControlMockSettings);
            }
        }

        private void linkLabelNew_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            NewCustomPropertySetting();
        }

        private void NewCustomPropertySetting()
        {
            var mockSetting = new CustomPropertyMockSettings();

            var userControlMockSettings = new UserControlMockSettings(mockSetting, () =>
            {
                LocalConfiguration.MockSettings.CustomProperties.Remove(mockSetting);
            });

            flowLayoutPanel.Controls.Add(userControlMockSettings);
        }

        private void buttonNewCustomSettings_Click(object sender, EventArgs e)
        {
            NewCustomPropertySetting();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            var newMockSettings = new MockSettings()
            {
                MaxArrayLength = (int)numericUpDownMaxArrayLength.Value,
                MinArrayLength = (int)numericUpDownMinArrayLength.Value,
                CustomProperties = new List<CustomPropertyMockSettings>()
            };

            foreach (UserControlMockSettings userControlMockSettings in flowLayoutPanel.Controls)
            {
                newMockSettings.CustomProperties.Add(userControlMockSettings.CustomPropertyMockSettings);
            }

            if (newMockSettings.CustomProperties.Exists(n => n.Invalid))
            {
                var messages = newMockSettings.CustomProperties
                    .Where(n => n.Invalid)
                    .Select(n => n.InvalidMessage)
                    .ToList();

                MessageBox.Show(string.Join(Environment.NewLine, messages), "Invalid custom properties", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            LocalConfiguration.MockSettings = newMockSettings;

            Close();
        }
    }
}
