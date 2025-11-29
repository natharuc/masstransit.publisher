using Masstransit.Publisher.Domain.Interfaces;

namespace Masstransit.Publisher.Windows.Forms
{
    public partial class FormLogDetails : Form
    {
        private readonly LogMessage _logMessage;

        public FormLogDetails(LogMessage logMessage)
        {
            InitializeComponent();
            _logMessage = logMessage;
            LoadLogDetails();
        }

        private void LoadLogDetails()
        {
            labelMessageValue.Text = _logMessage.Message;

            if (!string.IsNullOrEmpty(_logMessage.Body))
            {
                richTextBoxBody.Text = _logMessage.Body;
                TryFormatJson();
            }
            else
            {
                richTextBoxBody.Text = "(No body content)";
                richTextBoxBody.ForeColor = Color.Gray;
                buttonCopyBody.Enabled = false;
                buttonFormatJson.Enabled = false;
            }
        }

        private void TryFormatJson()
        {
            if (string.IsNullOrWhiteSpace(_logMessage.Body))
                return;

            try
            {
                var jsonObject = Newtonsoft.Json.Linq.JToken.Parse(_logMessage.Body);
                richTextBoxBody.Text = jsonObject.ToString(Newtonsoft.Json.Formatting.Indented);
                buttonFormatJson.Enabled = false;
            }
            catch
            {
                // Not JSON, keep original text
                buttonFormatJson.Enabled = false;
            }
        }

        private void buttonCopyMessage_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(_logMessage.Message))
            {
                Clipboard.SetText(_logMessage.Message);
                ShowCopiedFeedback(buttonCopyMessage);
            }
        }

        private void buttonCopyBody_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(_logMessage.Body))
            {
                Clipboard.SetText(_logMessage.Body);
                ShowCopiedFeedback(buttonCopyBody);
            }
        }

        private void buttonFormatJson_Click(object sender, EventArgs e)
        {
            TryFormatJson();
        }

        private void ShowCopiedFeedback(Button button)
        {
            var originalText = button.Text;
            button.Text = "? Copied!";
            button.Enabled = false;

            var timer = new System.Windows.Forms.Timer
            {
                Interval = 1500
            };

            timer.Tick += (s, e) =>
            {
                button.Text = originalText;
                button.Enabled = true;
                timer.Stop();
                timer.Dispose();
            };

            timer.Start();
        }

        private void FormLogDetails_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
