namespace Masstransit.Publisher.Windows.Forms
{
    partial class FormMockSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMockSettings));
            flowLayoutPanel = new FlowLayoutPanel();
            panelBotoes = new Panel();
            buttonSave = new Button();
            panelTittle = new Panel();
            buttonNewCustomSettings = new Button();
            groupBoxArraySettings = new GroupBox();
            labelMaxElementsOnArrays = new Label();
            labelMinElementsOnArrays = new Label();
            numericUpDownMaxArrayLength = new NumericUpDown();
            numericUpDownMinArrayLength = new NumericUpDown();
            panelBotoes.SuspendLayout();
            panelTittle.SuspendLayout();
            groupBoxArraySettings.SuspendLayout();
            KeyDown += Form_KeyDown;
            ((System.ComponentModel.ISupportInitialize)numericUpDownMaxArrayLength).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownMinArrayLength).BeginInit();
            SuspendLayout();
            // 
            // flowLayoutPanel
            // 
            flowLayoutPanel.Dock = DockStyle.Fill;
            flowLayoutPanel.Location = new Point(0, 88);
            flowLayoutPanel.Name = "flowLayoutPanel";
            flowLayoutPanel.Padding = new Padding(5);
            flowLayoutPanel.Size = new Size(574, 464);
            flowLayoutPanel.TabIndex = 0;
            // 
            // panelBotoes
            // 
            panelBotoes.Controls.Add(buttonSave);
            panelBotoes.Dock = DockStyle.Bottom;
            panelBotoes.Location = new Point(0, 479);
            panelBotoes.Name = "panelBotoes";
            panelBotoes.Padding = new Padding(5);
            panelBotoes.Size = new Size(574, 73);
            panelBotoes.TabIndex = 1;
            // 
            // buttonSave
            // 
            buttonSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonSave.FlatStyle = FlatStyle.Flat;
            buttonSave.Location = new Point(418, 7);
            buttonSave.Margin = new Padding(2);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(145, 55);
            buttonSave.TabIndex = 17;
            buttonSave.Text = "Save";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // panelTittle
            // 
            panelTittle.Controls.Add(buttonNewCustomSettings);
            panelTittle.Controls.Add(groupBoxArraySettings);
            panelTittle.Dock = DockStyle.Top;
            panelTittle.Location = new Point(0, 0);
            panelTittle.Name = "panelTittle";
            panelTittle.Padding = new Padding(5);
            panelTittle.Size = new Size(574, 88);
            panelTittle.TabIndex = 0;
            // 
            // buttonNewCustomSettings
            // 
            buttonNewCustomSettings.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonNewCustomSettings.FlatStyle = FlatStyle.Flat;
            buttonNewCustomSettings.Location = new Point(7, 48);
            buttonNewCustomSettings.Margin = new Padding(2);
            buttonNewCustomSettings.Name = "buttonNewCustomSettings";
            buttonNewCustomSettings.Size = new Size(235, 33);
            buttonNewCustomSettings.TabIndex = 17;
            buttonNewCustomSettings.Text = "New custom property settings";
            buttonNewCustomSettings.UseVisualStyleBackColor = true;
            buttonNewCustomSettings.Click += buttonNewCustomSettings_Click;
            // 
            // groupBoxArraySettings
            // 
            groupBoxArraySettings.Controls.Add(labelMaxElementsOnArrays);
            groupBoxArraySettings.Controls.Add(labelMinElementsOnArrays);
            groupBoxArraySettings.Controls.Add(numericUpDownMaxArrayLength);
            groupBoxArraySettings.Controls.Add(numericUpDownMinArrayLength);
            groupBoxArraySettings.Dock = DockStyle.Right;
            groupBoxArraySettings.Location = new Point(359, 5);
            groupBoxArraySettings.Name = "groupBoxArraySettings";
            groupBoxArraySettings.Size = new Size(210, 78);
            groupBoxArraySettings.TabIndex = 16;
            groupBoxArraySettings.TabStop = false;
            groupBoxArraySettings.Text = "Number of Elements on Arrays";
            // 
            // labelMaxElementsOnArrays
            // 
            labelMaxElementsOnArrays.AutoSize = true;
            labelMaxElementsOnArrays.Location = new Point(110, 25);
            labelMaxElementsOnArrays.Name = "labelMaxElementsOnArrays";
            labelMaxElementsOnArrays.Size = new Size(30, 15);
            labelMaxElementsOnArrays.TabIndex = 3;
            labelMaxElementsOnArrays.Text = "Max";
            // 
            // labelMinElementsOnArrays
            // 
            labelMinElementsOnArrays.AutoSize = true;
            labelMinElementsOnArrays.Location = new Point(17, 25);
            labelMinElementsOnArrays.Name = "labelMinElementsOnArrays";
            labelMinElementsOnArrays.Size = new Size(28, 15);
            labelMinElementsOnArrays.TabIndex = 2;
            labelMinElementsOnArrays.Text = "Min";
            // 
            // numericUpDownMaxArrayLength
            // 
            numericUpDownMaxArrayLength.Location = new Point(110, 43);
            numericUpDownMaxArrayLength.Maximum = new decimal(new int[] { 999999999, 0, 0, 0 });
            numericUpDownMaxArrayLength.Name = "numericUpDownMaxArrayLength";
            numericUpDownMaxArrayLength.Size = new Size(88, 23);
            numericUpDownMaxArrayLength.TabIndex = 1;
            // 
            // numericUpDownMinArrayLength
            // 
            numericUpDownMinArrayLength.Location = new Point(17, 43);
            numericUpDownMinArrayLength.Maximum = new decimal(new int[] { 999999999, 0, 0, 0 });
            numericUpDownMinArrayLength.Name = "numericUpDownMinArrayLength";
            numericUpDownMinArrayLength.Size = new Size(87, 23);
            numericUpDownMinArrayLength.TabIndex = 0;
            // 
            // FormMockSettings
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(574, 552);
            Controls.Add(panelBotoes);
            Controls.Add(flowLayoutPanel);
            Controls.Add(panelTittle);
            Icon = (Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            MinimizeBox = false;
            Name = "FormMockSettings";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Mock Settings";
            panelBotoes.ResumeLayout(false);
            panelTittle.ResumeLayout(false);
            groupBoxArraySettings.ResumeLayout(false);
            groupBoxArraySettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownMaxArrayLength).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownMinArrayLength).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel flowLayoutPanel;
        private Panel panelTittle;
        private GroupBox groupBoxArraySettings;
        private NumericUpDown numericUpDownMinArrayLength;
        private NumericUpDown numericUpDownMaxArrayLength;
        private Label labelMinElementsOnArrays;
        private Label labelMaxElementsOnArrays;
        private Button buttonNewCustomSettings;
        private Panel panelBotoes;
        private Button buttonSave;
    }
}