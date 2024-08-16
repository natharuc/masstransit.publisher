using Masstransit.Publisher.Domain.Classes;

namespace Masstransit.Publisher.Windows.Forms.UserControls
{
    public partial class UserControlMockSettings : UserControl
    {
        public CustomPropertyMockSettings MockSettings { get; set; }

        private Action _remover;

        public UserControlMockSettings(CustomPropertyMockSettings mockSettings, Action remover)
        {
            InitializeComponent();

            _remover = remover;

            MockSettings = mockSettings;

            comboBoxType.DataSource = GetPrimitiveTypes();

            textBoxName.DataBindings.Add("Text", MockSettings, "Name", true, DataSourceUpdateMode.OnPropertyChanged);
            textBoxValue.DataBindings.Add("Text", MockSettings, "Value", true, DataSourceUpdateMode.OnPropertyChanged);
            comboBoxType.DataBindings.Add("SelectedItem", MockSettings, "Type", true, DataSourceUpdateMode.OnPropertyChanged);
            checkBoxIgnore.DataBindings.Add("Checked", MockSettings, "Ignore", true, DataSourceUpdateMode.OnPropertyChanged);
            checkBoxAwaysChange.DataBindings.Add("Checked", MockSettings, "RegenerateBeforeSending", true, DataSourceUpdateMode.OnPropertyChanged);

        }

        static List<string> GetPrimitiveTypes()
        {
            return new List<string>
            {
                "Any", 
                typeof(bool).Name,
                typeof(byte).Name,
                typeof(sbyte).Name,
                typeof(char).Name,
                typeof(decimal).Name,
                typeof(double).Name,
                typeof(float).Name,
                typeof(int).Name,
                typeof(uint).Name,
                typeof(long).Name,
                typeof(ulong).Name,
                typeof(short).Name,
                typeof(ushort).Name,
                typeof(string).Name,
                typeof(object).Name,
                typeof(Guid).Name,
                typeof(DateTime).Name
            };
        }

        private void linkLabelRemover_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _remover();

            this.Dispose();
        }

        private void checkBoxIgnore_CheckedChanged(object sender, EventArgs e)
        {
            textBoxValue.Enabled = !checkBoxIgnore.Checked;

            checkBoxAwaysChange.Enabled = !checkBoxIgnore.Checked;

            if (checkBoxAwaysChange.Checked)
                checkBoxAwaysChange.Checked = !checkBoxIgnore.Checked;
        }

        private void textBoxValue_TextChanged(object sender, EventArgs e)
        {
            checkBoxAwaysChange.Enabled = string.IsNullOrEmpty(textBoxValue.Text);

            if (checkBoxAwaysChange.Checked)
                checkBoxAwaysChange.Checked = string.IsNullOrEmpty(textBoxValue.Text);
        }

        private void checkBoxAwaysChange_CheckedChanged(object sender, EventArgs e)
        {
            textBoxValue.Enabled = !checkBoxAwaysChange.Checked;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
