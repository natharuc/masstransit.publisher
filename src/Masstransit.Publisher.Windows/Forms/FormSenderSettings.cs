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

        private void FormSenderSettings_FormClosing(object sender, FormClosingEventArgs e)
        {
            labelQueue.Focus();
        }
    }
}
