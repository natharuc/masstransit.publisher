using Masstransit.Publisher.Domain.Classes;
using Masstransit.Publisher.Domain.Interfaces;

namespace Masstransit.Publisher.Windows.Forms.UserControls
{
    public partial class UserControlMockSettings : UserControl
    {
        public MockSettings MockSettings { get; set; }

        private IMockInterfaceService _mockInterfaceService;

        private Action _remover;

        public UserControlMockSettings(IMockInterfaceService mockInterfaceService, MockSettings mockSettings, Action remover)
        {
            InitializeComponent();

            _remover = remover;

            MockSettings = mockSettings;

            _mockInterfaceService = mockInterfaceService;

            comboBoxType.DataSource = _mockInterfaceService.GetMockTypes();

            textBoxName.DataBindings.Add("Text", MockSettings, "Name", true, DataSourceUpdateMode.OnPropertyChanged);
            textBoxValue.DataBindings.Add("Text", MockSettings, "Value", true, DataSourceUpdateMode.OnPropertyChanged);
            comboBoxType.DataBindings.Add("SelectedItem", MockSettings, "Type", true, DataSourceUpdateMode.OnPropertyChanged);
            checkBoxIgnore.DataBindings.Add("Checked", MockSettings, "Ignore", true, DataSourceUpdateMode.OnPropertyChanged);
            
        }

        private void linkLabelRemover_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _remover();

            this.Dispose();
        }

        private void checkBoxIgnore_CheckedChanged(object sender, EventArgs e)
        {
            textBoxValue.Enabled = !checkBoxIgnore.Checked;
        }
    }
}
