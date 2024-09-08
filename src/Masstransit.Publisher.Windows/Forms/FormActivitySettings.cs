using Masstransit.Publisher.Domain.Classes;
using Newtonsoft.Json;

namespace Masstransit.Publisher.Windows.Forms
{
    public partial class FormActivitySettings : Form
    {
        public ActivitySettings ActivitySettings { get; private set; }

        public FormActivitySettings(ActivitySettings activitySettings)
        {
            InitializeComponent();

            ActivitySettings = activitySettings;

            if (ActivitySettings.Activities.Count == 0)
            {
                ActivitySettings.Activities = new()
                {
                    new()
                    {
                        Name = "Activity1",
                        Queue = "queue_activity1"
                    }
                };

            }

            richTextBoxActivitySettings.Text = JsonConvert.SerializeObject(activitySettings, Formatting.Indented);
        }

        private void FormActivitySettings_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                var activitySettings = JsonConvert.DeserializeObject<ActivitySettings>(richTextBoxActivitySettings.Text);

                ActivitySettings = activitySettings ?? throw new InvalidOperationException("Activity settings is required");

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
