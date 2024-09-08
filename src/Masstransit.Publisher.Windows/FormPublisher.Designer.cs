namespace Masstransit.Publisher.Windows
{
    partial class FormPublisher
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPublisher));
            textBoxContract = new TextBox();
            richTextBoxJson = new RichTextBox();
            labelContrato = new Label();
            labelJson = new Label();
            buttonEnviar = new Button();
            buttonPublicar = new Button();
            buttonMockJson = new Button();
            dataGridViewAutoComplete = new DataGridView();
            linkLabelSelectDll = new LinkLabel();
            labelSelectedContract = new Label();
            buttonConfigMock = new Button();
            toolTip = new ToolTip(components);
            buttonExecuteActivity = new Button();
            buttonActivitySettings = new Button();
            buttonSenderSettings = new Button();
            tabControl = new TabControl();
            tabPageSender = new TabPage();
            panelBrokerSettings = new Panel();
            panelBrokers = new FlowLayoutPanel();
            tabPageLog = new TabPage();
            listBoxLog = new ListBox();
            ((System.ComponentModel.ISupportInitialize)dataGridViewAutoComplete).BeginInit();
            tabControl.SuspendLayout();
            tabPageSender.SuspendLayout();
            tabPageLog.SuspendLayout();
            SuspendLayout();
            // 
            // textBoxContract
            // 
            textBoxContract.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxContract.Location = new Point(6, 150);
            textBoxContract.Margin = new Padding(2);
            textBoxContract.Name = "textBoxContract";
            textBoxContract.Size = new Size(709, 22);
            textBoxContract.TabIndex = 3;
            textBoxContract.TextChanged += textBoxContract_TextChanged;
            textBoxContract.KeyDown += textBoxContract_KeyDown;
            // 
            // richTextBoxJson
            // 
            richTextBoxJson.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            richTextBoxJson.BorderStyle = BorderStyle.None;
            richTextBoxJson.Location = new Point(6, 210);
            richTextBoxJson.Margin = new Padding(2);
            richTextBoxJson.Name = "richTextBoxJson";
            richTextBoxJson.Size = new Size(708, 423);
            richTextBoxJson.TabIndex = 5;
            richTextBoxJson.Text = "";
            // 
            // labelContrato
            // 
            labelContrato.AutoSize = true;
            labelContrato.Location = new Point(7, 135);
            labelContrato.Margin = new Padding(2, 0, 2, 0);
            labelContrato.Name = "labelContrato";
            labelContrato.Size = new Size(86, 13);
            labelContrato.TabIndex = 2;
            labelContrato.Text = "Search contract";
            // 
            // labelJson
            // 
            labelJson.AutoSize = true;
            labelJson.Location = new Point(5, 195);
            labelJson.Margin = new Padding(2, 0, 2, 0);
            labelJson.Name = "labelJson";
            labelJson.Size = new Size(52, 13);
            labelJson.TabIndex = 4;
            labelJson.Text = "Message";
            // 
            // buttonEnviar
            // 
            buttonEnviar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonEnviar.FlatStyle = FlatStyle.Flat;
            buttonEnviar.Location = new Point(594, 645);
            buttonEnviar.Margin = new Padding(2);
            buttonEnviar.Name = "buttonEnviar";
            buttonEnviar.Size = new Size(120, 37);
            buttonEnviar.TabIndex = 8;
            buttonEnviar.Text = "Send";
            buttonEnviar.UseVisualStyleBackColor = true;
            buttonEnviar.Click += buttonSend_Click;
            // 
            // buttonPublicar
            // 
            buttonPublicar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonPublicar.FlatStyle = FlatStyle.Flat;
            buttonPublicar.Location = new Point(474, 645);
            buttonPublicar.Margin = new Padding(2);
            buttonPublicar.Name = "buttonPublicar";
            buttonPublicar.Size = new Size(121, 37);
            buttonPublicar.TabIndex = 10;
            buttonPublicar.Text = "Publish";
            buttonPublicar.UseVisualStyleBackColor = true;
            buttonPublicar.Click += buttonPublish_Click;
            // 
            // buttonMockJson
            // 
            buttonMockJson.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonMockJson.FlatStyle = FlatStyle.Flat;
            buttonMockJson.Location = new Point(6, 645);
            buttonMockJson.Margin = new Padding(2);
            buttonMockJson.Name = "buttonMockJson";
            buttonMockJson.Size = new Size(121, 37);
            buttonMockJson.TabIndex = 11;
            buttonMockJson.Text = "Mock";
            buttonMockJson.UseVisualStyleBackColor = true;
            buttonMockJson.Click += buttonMockJson_Click;
            // 
            // dataGridViewAutoComplete
            // 
            dataGridViewAutoComplete.AllowUserToAddRows = false;
            dataGridViewAutoComplete.AllowUserToDeleteRows = false;
            dataGridViewAutoComplete.AllowUserToResizeColumns = false;
            dataGridViewAutoComplete.AllowUserToResizeRows = false;
            dataGridViewAutoComplete.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewAutoComplete.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewAutoComplete.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewAutoComplete.EditMode = DataGridViewEditMode.EditProgrammatically;
            dataGridViewAutoComplete.Location = new Point(6, 210);
            dataGridViewAutoComplete.Margin = new Padding(2);
            dataGridViewAutoComplete.Name = "dataGridViewAutoComplete";
            dataGridViewAutoComplete.RowHeadersVisible = false;
            dataGridViewAutoComplete.RowTemplate.Height = 30;
            dataGridViewAutoComplete.Size = new Size(708, 423);
            dataGridViewAutoComplete.TabIndex = 12;
            dataGridViewAutoComplete.Visible = false;
            dataGridViewAutoComplete.CellDoubleClick += dataGridViewAutoComplete_CellDoubleClick;
            dataGridViewAutoComplete.KeyDown += dataGridViewAutoComplete_KeyDown;
            // 
            // linkLabelSelectDll
            // 
            linkLabelSelectDll.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            linkLabelSelectDll.Location = new Point(263, 135);
            linkLabelSelectDll.Margin = new Padding(2, 0, 2, 0);
            linkLabelSelectDll.Name = "linkLabelSelectDll";
            linkLabelSelectDll.Size = new Size(452, 13);
            linkLabelSelectDll.TabIndex = 13;
            linkLabelSelectDll.TabStop = true;
            linkLabelSelectDll.Text = "Select .dll";
            linkLabelSelectDll.TextAlign = ContentAlignment.MiddleRight;
            linkLabelSelectDll.LinkClicked += linkLabelSelectDll_LinkClicked;
            // 
            // labelSelectedContract
            // 
            labelSelectedContract.Location = new Point(5, 174);
            labelSelectedContract.Margin = new Padding(2, 0, 2, 0);
            labelSelectedContract.Name = "labelSelectedContract";
            labelSelectedContract.Size = new Size(708, 15);
            labelSelectedContract.TabIndex = 14;
            labelSelectedContract.Text = "...";
            // 
            // buttonConfigMock
            // 
            buttonConfigMock.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonConfigMock.BackColor = SystemColors.Control;
            buttonConfigMock.BackgroundImageLayout = ImageLayout.Zoom;
            buttonConfigMock.FlatStyle = FlatStyle.Flat;
            buttonConfigMock.Image = Properties.Resources.iconSettings;
            buttonConfigMock.Location = new Point(126, 645);
            buttonConfigMock.Margin = new Padding(2);
            buttonConfigMock.Name = "buttonConfigMock";
            buttonConfigMock.Size = new Size(35, 37);
            buttonConfigMock.TabIndex = 15;
            toolTip.SetToolTip(buttonConfigMock, "Mock Settings");
            buttonConfigMock.UseVisualStyleBackColor = false;
            buttonConfigMock.Click += buttonConfigMock_Click;
            // 
            // buttonExecuteActivity
            // 
            buttonExecuteActivity.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonExecuteActivity.FlatStyle = FlatStyle.Flat;
            buttonExecuteActivity.Location = new Point(315, 645);
            buttonExecuteActivity.Margin = new Padding(2);
            buttonExecuteActivity.Name = "buttonExecuteActivity";
            buttonExecuteActivity.Size = new Size(121, 37);
            buttonExecuteActivity.TabIndex = 16;
            buttonExecuteActivity.Text = "Execute";
            toolTip.SetToolTip(buttonExecuteActivity, "Execute Activity");
            buttonExecuteActivity.UseVisualStyleBackColor = true;
            buttonExecuteActivity.Click += buttonExecuteActivity_Click;
            // 
            // buttonActivitySettings
            // 
            buttonActivitySettings.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonActivitySettings.BackColor = SystemColors.Control;
            buttonActivitySettings.BackgroundImageLayout = ImageLayout.Zoom;
            buttonActivitySettings.FlatStyle = FlatStyle.Flat;
            buttonActivitySettings.Image = Properties.Resources.iconSettings;
            buttonActivitySettings.Location = new Point(281, 645);
            buttonActivitySettings.Margin = new Padding(2);
            buttonActivitySettings.Name = "buttonActivitySettings";
            buttonActivitySettings.Size = new Size(35, 37);
            buttonActivitySettings.TabIndex = 17;
            toolTip.SetToolTip(buttonActivitySettings, "Execute Activity Settings");
            buttonActivitySettings.UseVisualStyleBackColor = false;
            buttonActivitySettings.Click += buttonActivitySettings_Click;
            // 
            // buttonSenderSettings
            // 
            buttonSenderSettings.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonSenderSettings.BackColor = SystemColors.Control;
            buttonSenderSettings.BackgroundImageLayout = ImageLayout.Zoom;
            buttonSenderSettings.FlatStyle = FlatStyle.Flat;
            buttonSenderSettings.Image = Properties.Resources.iconSettings;
            buttonSenderSettings.Location = new Point(440, 645);
            buttonSenderSettings.Margin = new Padding(2);
            buttonSenderSettings.Name = "buttonSenderSettings";
            buttonSenderSettings.Size = new Size(35, 37);
            buttonSenderSettings.TabIndex = 18;
            toolTip.SetToolTip(buttonSenderSettings, "Sender Settings");
            buttonSenderSettings.UseVisualStyleBackColor = false;
            buttonSenderSettings.Click += buttonSenderSettings_Click;
            // 
            // tabControl
            // 
            tabControl.Controls.Add(tabPageSender);
            tabControl.Controls.Add(tabPageLog);
            tabControl.Dock = DockStyle.Fill;
            tabControl.Location = new Point(0, 0);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(731, 721);
            tabControl.TabIndex = 20;
            // 
            // tabPageSender
            // 
            tabPageSender.Controls.Add(buttonSenderSettings);
            tabPageSender.Controls.Add(buttonActivitySettings);
            tabPageSender.Controls.Add(richTextBoxJson);
            tabPageSender.Controls.Add(buttonExecuteActivity);
            tabPageSender.Controls.Add(dataGridViewAutoComplete);
            tabPageSender.Controls.Add(buttonConfigMock);
            tabPageSender.Controls.Add(textBoxContract);
            tabPageSender.Controls.Add(labelSelectedContract);
            tabPageSender.Controls.Add(labelContrato);
            tabPageSender.Controls.Add(linkLabelSelectDll);
            tabPageSender.Controls.Add(labelJson);
            tabPageSender.Controls.Add(buttonMockJson);
            tabPageSender.Controls.Add(buttonPublicar);
            tabPageSender.Controls.Add(buttonEnviar);
            tabPageSender.Controls.Add(panelBrokerSettings);
            tabPageSender.Controls.Add(panelBrokers);
            tabPageSender.Location = new Point(4, 22);
            tabPageSender.Name = "tabPageSender";
            tabPageSender.Padding = new Padding(3);
            tabPageSender.Size = new Size(723, 695);
            tabPageSender.TabIndex = 0;
            tabPageSender.Text = "Home";
            tabPageSender.UseVisualStyleBackColor = true;
            // 
            // panelBrokerSettings
            // 
            panelBrokerSettings.Dock = DockStyle.Top;
            panelBrokerSettings.Location = new Point(3, 57);
            panelBrokerSettings.Name = "panelBrokerSettings";
            panelBrokerSettings.Size = new Size(717, 61);
            panelBrokerSettings.TabIndex = 19;
            // 
            // panelBrokers
            // 
            panelBrokers.Dock = DockStyle.Top;
            panelBrokers.Location = new Point(3, 3);
            panelBrokers.Name = "panelBrokers";
            panelBrokers.Size = new Size(717, 54);
            panelBrokers.TabIndex = 0;
            // 
            // tabPageLog
            // 
            tabPageLog.Controls.Add(listBoxLog);
            tabPageLog.Location = new Point(4, 24);
            tabPageLog.Name = "tabPageLog";
            tabPageLog.Padding = new Padding(3);
            tabPageLog.Size = new Size(723, 693);
            tabPageLog.TabIndex = 1;
            tabPageLog.Text = "Log";
            tabPageLog.UseVisualStyleBackColor = true;
            // 
            // listBoxLog
            // 
            listBoxLog.Dock = DockStyle.Fill;
            listBoxLog.FormattingEnabled = true;
            listBoxLog.Location = new Point(3, 3);
            listBoxLog.Name = "listBoxLog";
            listBoxLog.Size = new Size(717, 687);
            listBoxLog.TabIndex = 0;
            // 
            // FormPublisher
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(731, 721);
            Controls.Add(tabControl);
            Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(2, 4, 2, 4);
            Name = "FormPublisher";
            Text = "Masstransit - Publisher";
            Load += FormPublicador_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewAutoComplete).EndInit();
            tabControl.ResumeLayout(false);
            tabPageSender.ResumeLayout(false);
            tabPageSender.PerformLayout();
            tabPageLog.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TextBox textBoxContract;
        private System.Windows.Forms.RichTextBox richTextBoxJson;
        private System.Windows.Forms.Label labelContrato;
        private System.Windows.Forms.Label labelJson;
        private System.Windows.Forms.Button buttonEnviar;
        private System.Windows.Forms.Button buttonPublicar;
        private System.Windows.Forms.Button buttonMockJson;
        private System.Windows.Forms.DataGridView dataGridViewAutoComplete;
        private System.Windows.Forms.LinkLabel linkLabelSelectDll;
        private Label labelSelectedContract;
        private Button buttonConfigMock;
        private ToolTip toolTip;
        private Button buttonExecuteActivity;
        private Button buttonActivitySettings;
        private Button buttonSenderSettings;
        private TabControl tabControl;
        private TabPage tabPageSender;
        private TabPage tabPageLog;
        private ListBox listBoxLog;
        private Panel panelBrokerSettings;
        private FlowLayoutPanel panelBrokers;
    }
}

