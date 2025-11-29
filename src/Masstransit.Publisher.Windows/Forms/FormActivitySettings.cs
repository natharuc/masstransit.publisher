using Masstransit.Publisher.Domain.Classes;

namespace Masstransit.Publisher.Windows.Forms
{
    public partial class FormActivitySettings : Form
    {
        public ActivitySettings ActivitySettings { get; private set; }
        private List<Contract> _contracts;

        public FormActivitySettings(ActivitySettings activitySettings, List<Contract> contracts)
        {
            InitializeComponent();

            _contracts = contracts ?? new List<Contract>();
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

            checkBoxListenToFaultQueue.Checked = ActivitySettings.ListenToFaultQueue;

            LoadContracts();
            LoadActivities();
        }

        private void LoadContracts()
        {
            // Populate Success Contract ComboBox
            comboBoxSuccessContract.Items.Clear();
            comboBoxSuccessContract.Items.Add("(Default: ActivityCompleted)");

            foreach (var contract in _contracts.Where(c => c.RequiresGeneric))
            {
                comboBoxSuccessContract.Items.Add(contract);
            }

            // Populate Fault Contract ComboBox
            comboBoxFaultContract.Items.Clear();
            comboBoxFaultContract.Items.Add("(Default: ActivityFaulted)");

            foreach (var contract in _contracts.Where(c => c.RequiresGeneric))
            {
                comboBoxFaultContract.Items.Add(contract);
            }

            // Select saved contracts or default
            if (ActivitySettings.SuccessContract != null)
            {
                var savedSuccessContract = _contracts.FirstOrDefault(c => c.Name == ActivitySettings.SuccessContract.Name);
                if (savedSuccessContract != null)
                {
                    comboBoxSuccessContract.SelectedItem = savedSuccessContract;
                }
            }
            else
            {
                comboBoxSuccessContract.SelectedIndex = 0;
            }

            if (ActivitySettings.FaultContract != null)
            {
                var savedFaultContract = _contracts.FirstOrDefault(c => c.Name == ActivitySettings.FaultContract.Name);
                if (savedFaultContract != null)
                {
                    comboBoxFaultContract.SelectedItem = savedFaultContract;
                }
            }
            else
            {
                comboBoxFaultContract.SelectedIndex = 0;
            }
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
                // Validate basic settings
                if (string.IsNullOrWhiteSpace(textBoxSuccessQueue.Text))
                {
                    MessageBox.Show("Success Queue is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBoxSuccessQueue.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(textBoxFaultQueue.Text))
                {
                    MessageBox.Show("Fault Queue is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBoxFaultQueue.Focus();
                    return;
                }

                ActivitySettings.TrackingNumberProperty = textBoxTrackingNumberProperty.Text.Trim();
                ActivitySettings.SuccessQueue = textBoxSuccessQueue.Text.Trim();
                ActivitySettings.FaultQueue = textBoxFaultQueue.Text.Trim();

                // Save Success Contract settings
                if (comboBoxSuccessContract.SelectedIndex > 0 && comboBoxSuccessContract.SelectedItem is Contract successContract)
                {
                    if (comboBoxSuccessMessageProperty.SelectedItem == null)
                    {
                        MessageBox.Show("Success Message Property is required when a custom Success Contract is selected.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        comboBoxSuccessMessageProperty.Focus();
                        return;
                    }

                    ActivitySettings.SuccessContract = successContract;
                    ActivitySettings.SuccessMessageProperty = comboBoxSuccessMessageProperty.SelectedItem?.ToString();
                }
                else
                {
                    ActivitySettings.SuccessContract = null;
                    ActivitySettings.SuccessMessageProperty = null;
                }

                // Save Fault Contract settings
                if (comboBoxFaultContract.SelectedIndex > 0 && comboBoxFaultContract.SelectedItem is Contract faultContract)
                {
                    if (comboBoxFaultMessageProperty.SelectedItem == null)
                    {
                        MessageBox.Show("Fault Message Property is required when a custom Fault Contract is selected.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        comboBoxFaultMessageProperty.Focus();
                        return;
                    }

                    ActivitySettings.FaultContract = faultContract;
                    ActivitySettings.FaultMessageProperty = comboBoxFaultMessageProperty.SelectedItem?.ToString();
                }
                else
                {
                    ActivitySettings.FaultContract = null;
                    ActivitySettings.FaultMessageProperty = null;
                }

                // Save Activities
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

                ActivitySettings.ListenToFaultQueue = checkBoxListenToFaultQueue.Checked;

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

        private void comboBoxSuccessContract_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxSuccessMessageProperty.Items.Clear();
            comboBoxSuccessMessageProperty.Enabled = false;

            if (comboBoxSuccessContract.SelectedIndex > 0 && comboBoxSuccessContract.SelectedItem is Contract contract)
            {
                LoadPropertiesForContract(contract, comboBoxSuccessMessageProperty);
                comboBoxSuccessMessageProperty.Enabled = true;

                // Select saved property if available
                if (!string.IsNullOrEmpty(ActivitySettings.SuccessMessageProperty))
                {
                    var savedProperty = comboBoxSuccessMessageProperty.Items
                        .Cast<string>()
                        .FirstOrDefault(p => string.Equals(p, ActivitySettings.SuccessMessageProperty, StringComparison.OrdinalIgnoreCase));

                    if (savedProperty != null)
                    {
                        comboBoxSuccessMessageProperty.SelectedItem = savedProperty;
                    }
                }
            }
        }

        private void comboBoxFaultContract_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxFaultMessageProperty.Items.Clear();
            comboBoxFaultMessageProperty.Enabled = false;

            if (comboBoxFaultContract.SelectedIndex > 0 && comboBoxFaultContract.SelectedItem is Contract contract)
            {
                LoadPropertiesForContract(contract, comboBoxFaultMessageProperty);
                comboBoxFaultMessageProperty.Enabled = true;

                // Select saved property if available
                if (!string.IsNullOrEmpty(ActivitySettings.FaultMessageProperty))
                {
                    var savedProperty = comboBoxFaultMessageProperty.Items
                        .Cast<string>()
                        .FirstOrDefault(p => string.Equals(p, ActivitySettings.FaultMessageProperty, StringComparison.OrdinalIgnoreCase));

                    if (savedProperty != null)
                    {
                        comboBoxFaultMessageProperty.SelectedItem = savedProperty;
                    }
                }
            }
        }

        private void LoadPropertiesForContract(Contract contract, ComboBox targetComboBox)
        {
            try
            {
                var type = contract.GetFullType();

                // Get all writable properties (excluding TrackingNumber since it's set automatically)
                // The generic type will be resolved at runtime with the actual message type
                var properties = type.GetProperties()
                    .Where(p => !string.Equals(p.Name, "TrackingNumber", StringComparison.OrdinalIgnoreCase))
                    .Select(p => p.Name)
                    .ToList();

                foreach (var property in properties)
                {
                    targetComboBox.Items.Add(property);
                }

                if (targetComboBox.Items.Count == 0)
                {
                    targetComboBox.Items.Add("(No writable properties found)");
                    targetComboBox.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading properties: {ex.Message}\n\nContract: {contract.Name}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormActivitySettings_Load(object sender, EventArgs e)
        {

        }
    }
}
