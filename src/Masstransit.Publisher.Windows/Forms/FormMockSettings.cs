using Masstransit.Publisher.Domain.Classes;
using Masstransit.Publisher.Domain.Interfaces;
using Masstransit.Publisher.Windows.Forms.UserControls;

namespace Masstransit.Publisher.Windows.Forms
{
    public partial class FormMockSettings : Form
    {
        private readonly IMockInterfaceService _mockService;

        public LocalConfiguration LocalConfiguration { get;  set; }

        public FormMockSettings(IMockInterfaceService mockService, LocalConfiguration localConfiguration)
        {
            InitializeComponent();

            LocalConfiguration = localConfiguration ?? throw new ArgumentNullException(nameof(localConfiguration));
            
            if (localConfiguration.MockSettings == null)
                throw new InvalidOperationException("The mock settings could not be null.");

            _mockService = mockService;

            foreach (var mockSetting in LocalConfiguration.MockSettings)
            {
                var userControlMockSettings = new UserControlMockSettings(_mockService, mockSetting, () =>
                {
                    LocalConfiguration.MockSettings.Remove(mockSetting);
                });

                flowLayoutPanel.Controls.Add(userControlMockSettings);
            }
        }

        private void FormMockSettings_FormClosing(object sender, FormClosingEventArgs e)
        {
            linkLabelNew.Focus();

            LocalConfiguration.MockSettings = new List<MockSettings>();

            foreach (UserControlMockSettings userControlMockSettings in flowLayoutPanel.Controls)
            {
                LocalConfiguration.MockSettings.Add(userControlMockSettings.MockSettings);
            }
        }

        private void linkLabelNew_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var mockSetting = new MockSettings();

            var userControlMockSettings = new UserControlMockSettings(_mockService, mockSetting, () =>
            {
                LocalConfiguration.MockSettings.Remove(mockSetting);
            });

            flowLayoutPanel.Controls.Add(userControlMockSettings);
        }
    }
}
