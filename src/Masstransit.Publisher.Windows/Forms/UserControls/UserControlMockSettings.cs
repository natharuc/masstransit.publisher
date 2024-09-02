using Masstransit.Publisher.Domain.Classes;

namespace Masstransit.Publisher.Windows.Forms.UserControls
{
    public partial class UserControlMockSettings : UserControl
    {
        public CustomPropertyMockSettings CustomPropertyMockSettings
        {
            get
            {
                return new CustomPropertyMockSettings
                {
                    Name = textBoxName.Text,
                    Type = comboBoxType.SelectedItem.ToString(),
                    Value = textBoxValue.Text,
                    Ignore = checkBoxIgnore.Checked,
                    RegenerateBeforeSending = checkBoxRegenerateBeforeSending.Checked
                };
            }
        }

        private Action _remover;

        public UserControlMockSettings(CustomPropertyMockSettings propertySettings, Action remover)
        {
            InitializeComponent();

            _remover = remover;

            comboBoxType.DataSource = GetPrimitiveTypes();

            textBoxName.Text = propertySettings.Name;
            comboBoxType.SelectedItem = propertySettings.Type;
            textBoxValue.Text = propertySettings.Value;
            checkBoxIgnore.Checked = propertySettings.Ignore;
            checkBoxRegenerateBeforeSending.Checked = propertySettings.RegenerateBeforeSending;
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

            checkBoxRegenerateBeforeSending.Enabled = !checkBoxIgnore.Checked;

            if (checkBoxRegenerateBeforeSending.Checked)
                checkBoxRegenerateBeforeSending.Checked = !checkBoxIgnore.Checked;
        }

        private void textBoxValue_TextChanged(object sender, EventArgs e)
        {
            checkBoxRegenerateBeforeSending.Enabled = string.IsNullOrEmpty(textBoxValue.Text);

            if (checkBoxRegenerateBeforeSending.Checked)
                checkBoxRegenerateBeforeSending.Checked = string.IsNullOrEmpty(textBoxValue.Text);
        }

        private void checkBoxAwaysChange_CheckedChanged(object sender, EventArgs e)
        {
            textBoxValue.Enabled = !checkBoxRegenerateBeforeSending.Checked;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
