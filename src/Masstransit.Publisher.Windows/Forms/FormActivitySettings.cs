using Masstransit.Publisher.Domain.Classes;

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

            LoadSettings();
        }

        private void LoadSettings()
        {
            textBoxTrackingNumberProperty.Text = ActivitySettings.TrackingNumberProperty ?? string.Empty;
            textBoxSuccessQueue.Text = ActivitySettings.SuccessQueue ?? string.Empty;
            textBoxFaultQueue.Text = ActivitySettings.FaultQueue ?? string.Empty;

            LoadActivities();
        }

        private void LoadActivities()
        {
            dataGridViewActivities.Rows.Clear();

            foreach (var activity in ActivitySettings.Activities)
            {
                dataGridViewActivities.Rows.Add(activity.Name, activity.Queue);
            }
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
                ActivitySettings.TrackingNumberProperty = textBoxTrackingNumberProperty.Text.Trim();
                ActivitySettings.SuccessQueue = textBoxSuccessQueue.Text.Trim();
                ActivitySettings.FaultQueue = textBoxFaultQueue.Text.Trim();

                ActivitySettings.Activities.Clear();

                foreach (DataGridViewRow row in dataGridViewActivities.Rows)
                {
                    if (row.IsNewRow) continue;

                    var name = row.Cells[0].Value?.ToString();
                    var queue = row.Cells[1].Value?.ToString();

                    if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(queue))
                    {
                        MessageBox.Show("All activities must have a Name and Queue.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    ActivitySettings.Activities.Add(new Activity
                    {
                        Name = name,
                        Queue = queue
                    });
                }

                if (ActivitySettings.Activities.Count == 0)
                {
                    MessageBox.Show("At least one activity is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonAddActivity_Click(object sender, EventArgs e)
        {
            var activityNumber = dataGridViewActivities.Rows.Count + 1;
            dataGridViewActivities.Rows.Add($"Activity{activityNumber}", $"queue_activity{activityNumber}");
        }

        private void buttonRemoveActivity_Click(object sender, EventArgs e)
        {
            if (dataGridViewActivities.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select an activity to remove.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            foreach (DataGridViewRow row in dataGridViewActivities.SelectedRows)
            {
                if (!row.IsNewRow)
                {
                    dataGridViewActivities.Rows.Remove(row);
                }
            }
        }

        private void dataGridViewActivities_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if the clicked cell is in the delete button column
            if (e.ColumnIndex == dataGridViewActivities.Columns["ColumnDelete"].Index && e.RowIndex >= 0)
            {
                var row = dataGridViewActivities.Rows[e.RowIndex];
                
                if (!row.IsNewRow)
                {
                    var activityName = row.Cells["ColumnName"].Value?.ToString() ?? "this activity";
                    
                    var result = MessageBox.Show(
                        $"Remove {activityName}?", 
                        "Confirm Deletion", 
                        MessageBoxButtons.YesNo, 
                        MessageBoxIcon.Question);
                    
                    if (result == DialogResult.Yes)
                    {
                        dataGridViewActivities.Rows.RemoveAt(e.RowIndex);
                    }
                }
            }
        }
    }
}
