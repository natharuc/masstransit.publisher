namespace Masstransit.Publisher.Windows.Forms
{
    partial class FormActivitySettings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormActivitySettings));
            panelBotoes = new Panel();
            buttonSave = new Button();
            panelMain = new Panel();
            groupBoxActivities = new GroupBox();
            dataGridViewActivities = new DataGridView();
            ColumnName = new DataGridViewTextBoxColumn();
            ColumnQueue = new DataGridViewTextBoxColumn();
            ColumnDelete = new DataGridViewButtonColumn();
            panelActivitiesButtons = new Panel();
            buttonAddActivity = new Button();
            groupBoxContracts = new GroupBox();
            comboBoxFaultMessageProperty = new ComboBox();
            labelFaultMessageProperty = new Label();
            comboBoxFaultContract = new ComboBox();
            labelFaultContract = new Label();
            comboBoxSuccessMessageProperty = new ComboBox();
            labelSuccessMessageProperty = new Label();
            comboBoxSuccessContract = new ComboBox();
            labelSuccessContract = new Label();
            groupBoxGeneral = new GroupBox();
            checkBoxListenToFaultQueue = new CheckBox();
            textBoxFaultQueue = new TextBox();
            labelFaultQueue = new Label();
            textBoxSuccessQueue = new TextBox();
            labelSuccessQueue = new Label();
            textBoxTrackingNumberProperty = new TextBox();
            labelTrackingNumberProperty = new Label();
            panelBotoes.SuspendLayout();
            panelMain.SuspendLayout();
            groupBoxActivities.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewActivities).BeginInit();
            panelActivitiesButtons.SuspendLayout();
            groupBoxContracts.SuspendLayout();
            groupBoxGeneral.SuspendLayout();
            SuspendLayout();
            // 
            // panelBotoes
            // 
            panelBotoes.Controls.Add(buttonSave);
            panelBotoes.Dock = DockStyle.Bottom;
            panelBotoes.Location = new Point(10, 685);
            panelBotoes.Name = "panelBotoes";
            panelBotoes.Padding = new Padding(5);
            panelBotoes.Size = new Size(580, 65);
            panelBotoes.TabIndex = 2;
            // 
            // buttonSave
            // 
            buttonSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonSave.FlatStyle = FlatStyle.Flat;
            buttonSave.Location = new Point(428, 5);
            buttonSave.Margin = new Padding(2);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(145, 55);
            buttonSave.TabIndex = 5;
            buttonSave.Text = "Save";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // panelMain
            // 
            panelMain.AutoScroll = true;
            panelMain.Controls.Add(groupBoxActivities);
            panelMain.Controls.Add(groupBoxContracts);
            panelMain.Controls.Add(groupBoxGeneral);
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(10, 10);
            panelMain.Name = "panelMain";
            panelMain.Padding = new Padding(0, 0, 0, 10);
            panelMain.Size = new Size(580, 675);
            panelMain.TabIndex = 3;
            // 
            // groupBoxActivities
            // 
            groupBoxActivities.Controls.Add(dataGridViewActivities);
            groupBoxActivities.Controls.Add(panelActivitiesButtons);
            groupBoxActivities.Dock = DockStyle.Fill;
            groupBoxActivities.Location = new Point(0, 448);
            groupBoxActivities.Name = "groupBoxActivities";
            groupBoxActivities.Padding = new Padding(10);
            groupBoxActivities.Size = new Size(580, 217);
            groupBoxActivities.TabIndex = 2;
            groupBoxActivities.TabStop = false;
            groupBoxActivities.Text = "Activities";
            // 
            // dataGridViewActivities
            // 
            dataGridViewActivities.AllowUserToAddRows = false;
            dataGridViewActivities.AllowUserToDeleteRows = false;
            dataGridViewActivities.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewActivities.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewActivities.Columns.AddRange(new DataGridViewColumn[] { ColumnName, ColumnQueue, ColumnDelete });
            dataGridViewActivities.Dock = DockStyle.Fill;
            dataGridViewActivities.Location = new Point(10, 26);
            dataGridViewActivities.Name = "dataGridViewActivities";
            dataGridViewActivities.RowHeadersVisible = false;
            dataGridViewActivities.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewActivities.Size = new Size(560, 121);
            dataGridViewActivities.TabIndex = 3;
            dataGridViewActivities.CellContentClick += dataGridViewActivities_CellContentClick;
            // 
            // ColumnName
            // 
            ColumnName.HeaderText = "Name";
            ColumnName.Name = "ColumnName";
            // 
            // ColumnQueue
            // 
            ColumnQueue.HeaderText = "Queue";
            ColumnQueue.Name = "ColumnQueue";
            // 
            // ColumnDelete
            // 
            ColumnDelete.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            ColumnDelete.FillWeight = 50F;
            ColumnDelete.HeaderText = "";
            ColumnDelete.Name = "ColumnDelete";
            ColumnDelete.ReadOnly = true;
            ColumnDelete.Text = "X";
            ColumnDelete.UseColumnTextForButtonValue = true;
            ColumnDelete.Width = 40;
            // 
            // panelActivitiesButtons
            // 
            panelActivitiesButtons.Controls.Add(buttonAddActivity);
            panelActivitiesButtons.Dock = DockStyle.Bottom;
            panelActivitiesButtons.Location = new Point(10, 147);
            panelActivitiesButtons.Name = "panelActivitiesButtons";
            panelActivitiesButtons.Padding = new Padding(0, 5, 0, 0);
            panelActivitiesButtons.Size = new Size(560, 60);
            panelActivitiesButtons.TabIndex = 2;
            // 
            // buttonAddActivity
            // 
            buttonAddActivity.FlatStyle = FlatStyle.Flat;
            buttonAddActivity.Location = new Point(5, 8);
            buttonAddActivity.Name = "buttonAddActivity";
            buttonAddActivity.Size = new Size(552, 40);
            buttonAddActivity.TabIndex = 3;
            buttonAddActivity.Text = "Add Activity";
            buttonAddActivity.UseVisualStyleBackColor = true;
            buttonAddActivity.Click += buttonAddActivity_Click;
            // 
            // groupBoxContracts
            // 
            groupBoxContracts.Controls.Add(comboBoxFaultMessageProperty);
            groupBoxContracts.Controls.Add(labelFaultMessageProperty);
            groupBoxContracts.Controls.Add(comboBoxFaultContract);
            groupBoxContracts.Controls.Add(labelFaultContract);
            groupBoxContracts.Controls.Add(comboBoxSuccessMessageProperty);
            groupBoxContracts.Controls.Add(labelSuccessMessageProperty);
            groupBoxContracts.Controls.Add(comboBoxSuccessContract);
            groupBoxContracts.Controls.Add(labelSuccessContract);
            groupBoxContracts.Dock = DockStyle.Top;
            groupBoxContracts.Location = new Point(0, 190);
            groupBoxContracts.Name = "groupBoxContracts";
            groupBoxContracts.Padding = new Padding(10);
            groupBoxContracts.Size = new Size(580, 258);
            groupBoxContracts.TabIndex = 1;
            groupBoxContracts.TabStop = false;
            groupBoxContracts.Text = "Custom Contracts (Optional)";
            // 
            // comboBoxFaultMessageProperty
            // 
            comboBoxFaultMessageProperty.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            comboBoxFaultMessageProperty.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxFaultMessageProperty.Enabled = false;
            comboBoxFaultMessageProperty.FormattingEnabled = true;
            comboBoxFaultMessageProperty.Location = new Point(13, 215);
            comboBoxFaultMessageProperty.Name = "comboBoxFaultMessageProperty";
            comboBoxFaultMessageProperty.Size = new Size(554, 23);
            comboBoxFaultMessageProperty.TabIndex = 7;
            // 
            // labelFaultMessageProperty
            // 
            labelFaultMessageProperty.AutoSize = true;
            labelFaultMessageProperty.Location = new Point(13, 197);
            labelFaultMessageProperty.Name = "labelFaultMessageProperty";
            labelFaultMessageProperty.Size = new Size(133, 15);
            labelFaultMessageProperty.TabIndex = 6;
            labelFaultMessageProperty.Text = "Fault Message Property:";
            // 
            // comboBoxFaultContract
            // 
            comboBoxFaultContract.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            comboBoxFaultContract.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxFaultContract.FormattingEnabled = true;
            comboBoxFaultContract.Location = new Point(13, 165);
            comboBoxFaultContract.Name = "comboBoxFaultContract";
            comboBoxFaultContract.Size = new Size(554, 23);
            comboBoxFaultContract.TabIndex = 5;
            comboBoxFaultContract.SelectedIndexChanged += comboBoxFaultContract_SelectedIndexChanged;
            // 
            // labelFaultContract
            // 
            labelFaultContract.AutoSize = true;
            labelFaultContract.Location = new Point(13, 147);
            labelFaultContract.Name = "labelFaultContract";
            labelFaultContract.Size = new Size(85, 15);
            labelFaultContract.TabIndex = 4;
            labelFaultContract.Text = "Fault Contract:";
            // 
            // comboBoxSuccessMessageProperty
            // 
            comboBoxSuccessMessageProperty.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            comboBoxSuccessMessageProperty.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxSuccessMessageProperty.Enabled = false;
            comboBoxSuccessMessageProperty.FormattingEnabled = true;
            comboBoxSuccessMessageProperty.Location = new Point(13, 104);
            comboBoxSuccessMessageProperty.Name = "comboBoxSuccessMessageProperty";
            comboBoxSuccessMessageProperty.Size = new Size(554, 23);
            comboBoxSuccessMessageProperty.TabIndex = 3;
            // 
            // labelSuccessMessageProperty
            // 
            labelSuccessMessageProperty.AutoSize = true;
            labelSuccessMessageProperty.Location = new Point(13, 86);
            labelSuccessMessageProperty.Name = "labelSuccessMessageProperty";
            labelSuccessMessageProperty.Size = new Size(148, 15);
            labelSuccessMessageProperty.TabIndex = 2;
            labelSuccessMessageProperty.Text = "Success Message Property:";
            // 
            // comboBoxSuccessContract
            // 
            comboBoxSuccessContract.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            comboBoxSuccessContract.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxSuccessContract.FormattingEnabled = true;
            comboBoxSuccessContract.Location = new Point(13, 47);
            comboBoxSuccessContract.Name = "comboBoxSuccessContract";
            comboBoxSuccessContract.Size = new Size(554, 23);
            comboBoxSuccessContract.TabIndex = 1;
            comboBoxSuccessContract.SelectedIndexChanged += comboBoxSuccessContract_SelectedIndexChanged;
            // 
            // labelSuccessContract
            // 
            labelSuccessContract.AutoSize = true;
            labelSuccessContract.Location = new Point(13, 29);
            labelSuccessContract.Name = "labelSuccessContract";
            labelSuccessContract.Size = new Size(100, 15);
            labelSuccessContract.TabIndex = 0;
            labelSuccessContract.Text = "Success Contract:";
            // 
            // groupBoxGeneral
            // 
            groupBoxGeneral.Controls.Add(checkBoxListenToFaultQueue);
            groupBoxGeneral.Controls.Add(textBoxFaultQueue);
            groupBoxGeneral.Controls.Add(labelFaultQueue);
            groupBoxGeneral.Controls.Add(textBoxSuccessQueue);
            groupBoxGeneral.Controls.Add(labelSuccessQueue);
            groupBoxGeneral.Controls.Add(textBoxTrackingNumberProperty);
            groupBoxGeneral.Controls.Add(labelTrackingNumberProperty);
            groupBoxGeneral.Dock = DockStyle.Top;
            groupBoxGeneral.Location = new Point(0, 0);
            groupBoxGeneral.Name = "groupBoxGeneral";
            groupBoxGeneral.Padding = new Padding(10);
            groupBoxGeneral.Size = new Size(580, 190);
            groupBoxGeneral.TabIndex = 0;
            groupBoxGeneral.TabStop = false;
            groupBoxGeneral.Text = "General Settings";
            // 
            // checkBoxListenToFaultQueue
            // 
            checkBoxListenToFaultQueue.AutoSize = true;
            checkBoxListenToFaultQueue.Location = new Point(13, 147);
            checkBoxListenToFaultQueue.Name = "checkBoxListenToFaultQueue";
            checkBoxListenToFaultQueue.Size = new Size(321, 19);
            checkBoxListenToFaultQueue.TabIndex = 6;
            checkBoxListenToFaultQueue.Text = "Listen to Fault Queue (Azure Service Bus messages only)";
            checkBoxListenToFaultQueue.UseVisualStyleBackColor = true;
            // 
            // textBoxFaultQueue
            // 
            textBoxFaultQueue.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxFaultQueue.Location = new Point(13, 118);
            textBoxFaultQueue.Name = "textBoxFaultQueue";
            textBoxFaultQueue.Size = new Size(554, 23);
            textBoxFaultQueue.TabIndex = 2;
            // 
            // labelFaultQueue
            // 
            labelFaultQueue.AutoSize = true;
            labelFaultQueue.Location = new Point(13, 100);
            labelFaultQueue.Name = "labelFaultQueue";
            labelFaultQueue.Size = new Size(74, 15);
            labelFaultQueue.TabIndex = 4;
            labelFaultQueue.Text = "Fault Queue:";
            // 
            // textBoxSuccessQueue
            // 
            textBoxSuccessQueue.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxSuccessQueue.Location = new Point(13, 74);
            textBoxSuccessQueue.Name = "textBoxSuccessQueue";
            textBoxSuccessQueue.Size = new Size(554, 23);
            textBoxSuccessQueue.TabIndex = 1;
            // 
            // labelSuccessQueue
            // 
            labelSuccessQueue.AutoSize = true;
            labelSuccessQueue.Location = new Point(13, 56);
            labelSuccessQueue.Name = "labelSuccessQueue";
            labelSuccessQueue.Size = new Size(89, 15);
            labelSuccessQueue.TabIndex = 2;
            labelSuccessQueue.Text = "Success Queue:";
            // 
            // textBoxTrackingNumberProperty
            // 
            textBoxTrackingNumberProperty.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxTrackingNumberProperty.Location = new Point(13, 30);
            textBoxTrackingNumberProperty.Name = "textBoxTrackingNumberProperty";
            textBoxTrackingNumberProperty.Size = new Size(554, 23);
            textBoxTrackingNumberProperty.TabIndex = 0;
            // 
            // labelTrackingNumberProperty
            // 
            labelTrackingNumberProperty.AutoSize = true;
            labelTrackingNumberProperty.Location = new Point(13, 12);
            labelTrackingNumberProperty.Name = "labelTrackingNumberProperty";
            labelTrackingNumberProperty.Size = new Size(150, 15);
            labelTrackingNumberProperty.TabIndex = 0;
            labelTrackingNumberProperty.Text = "Tracking Number Property:";
            // 
            // FormActivitySettings
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(600, 760);
            Controls.Add(panelMain);
            Controls.Add(panelBotoes);
            Icon = (Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormActivitySettings";
            Padding = new Padding(10);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Activity Settings";
            Load += FormActivitySettings_Load;
            KeyDown += FormActivitySettings_KeyDown;
            panelBotoes.ResumeLayout(false);
            panelMain.ResumeLayout(false);
            groupBoxActivities.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewActivities).EndInit();
            panelActivitiesButtons.ResumeLayout(false);
            groupBoxContracts.ResumeLayout(false);
            groupBoxContracts.PerformLayout();
            groupBoxGeneral.ResumeLayout(false);
            groupBoxGeneral.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelBotoes;
        private Button buttonSave;
        private Panel panelMain;
        private GroupBox groupBoxGeneral;
        private TextBox textBoxTrackingNumberProperty;
        private Label labelTrackingNumberProperty;
        private TextBox textBoxSuccessQueue;
        private Label labelSuccessQueue;
        private TextBox textBoxFaultQueue;
        private Label labelFaultQueue;
        private CheckBox checkBoxListenToFaultQueue;
        private GroupBox groupBoxActivities;
        private DataGridView dataGridViewActivities;
        private Panel panelActivitiesButtons;
        private Button buttonAddActivity;
        private DataGridViewTextBoxColumn ColumnName;
        private DataGridViewTextBoxColumn ColumnQueue;
        private DataGridViewButtonColumn ColumnDelete;
        private GroupBox groupBoxContracts;
        private ComboBox comboBoxSuccessContract;
        private Label labelSuccessContract;
        private ComboBox comboBoxSuccessMessageProperty;
        private Label labelSuccessMessageProperty;
        private ComboBox comboBoxFaultContract;
        private Label labelFaultContract;
        private ComboBox comboBoxFaultMessageProperty;
        private Label labelFaultMessageProperty;
    }
}