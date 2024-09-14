using Masstransit.Publisher.Domain.Classes;

namespace Masstransit.Publisher.Windows.Forms
{
    public partial class FormSenderSettings : Form
    {
        public SenderSettings SenderSettings { get; private set; }

        public FormSenderSettings(SenderSettings senderSettings)
        {
            InitializeComponent();

            SenderSettings = senderSettings;

            textBoxQueue.DataBindings.Add("Text", SenderSettings, "Queue", false, DataSourceUpdateMode.OnPropertyChanged);

            numericUpDownMessageCount.DataBindings.Add("Value", SenderSettings, "MessageCount", false, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void FormActivitySettings_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            SenderSettings = new SenderSettings
            {
                Queue = textBoxQueue.Text,
                MessageCount = (int)numericUpDownMessageCount.Value
            };

            Close();
        }

        private void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}
