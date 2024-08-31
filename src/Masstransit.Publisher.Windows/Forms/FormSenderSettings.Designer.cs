namespace Masstransit.Publisher.Windows.Forms
{
    partial class FormSenderSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSenderSettings));
            textBoxQueue = new TextBox();
            labelQueue = new Label();
            numericUpDownMessageCount = new NumericUpDown();
            labelMessageCount = new Label();
            buttonSave = new Button();
            panelBotoes = new Panel();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)numericUpDownMessageCount).BeginInit();
            panelBotoes.SuspendLayout();
            SuspendLayout();
            // 
            // textBoxQueue
            // 
            textBoxQueue.Location = new Point(8, 22);
            textBoxQueue.Name = "textBoxQueue";
            textBoxQueue.Size = new Size(480, 23);
            textBoxQueue.TabIndex = 0;
            // 
            // labelQueue
            // 
            labelQueue.AutoSize = true;
            labelQueue.Location = new Point(8, 5);
            labelQueue.Name = "labelQueue";
            labelQueue.Size = new Size(42, 15);
            labelQueue.TabIndex = 1;
            labelQueue.Text = "Queue";
            // 
            // numericUpDownMessageCount
            // 
            numericUpDownMessageCount.Location = new Point(8, 73);
            numericUpDownMessageCount.Maximum = new decimal(new int[] { 999999999, 0, 0, 0 });
            numericUpDownMessageCount.Name = "numericUpDownMessageCount";
            numericUpDownMessageCount.Size = new Size(137, 23);
            numericUpDownMessageCount.TabIndex = 2;
            // 
            // labelMessageCount
            // 
            labelMessageCount.AutoSize = true;
            labelMessageCount.Location = new Point(8, 51);
            labelMessageCount.Name = "labelMessageCount";
            labelMessageCount.Size = new Size(89, 15);
            labelMessageCount.TabIndex = 3;
            labelMessageCount.Text = "Message Count";
            // 
            // buttonSave
            // 
            buttonSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonSave.FlatStyle = FlatStyle.Flat;
            buttonSave.Location = new Point(699, -25);
            buttonSave.Margin = new Padding(2);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(145, 55);
            buttonSave.TabIndex = 17;
            buttonSave.Text = "Save";
            buttonSave.UseVisualStyleBackColor = true;
            // 
            // panelBotoes
            // 
            panelBotoes.Controls.Add(button1);
            panelBotoes.Controls.Add(buttonSave);
            panelBotoes.Dock = DockStyle.Bottom;
            panelBotoes.Location = new Point(5, 115);
            panelBotoes.Name = "panelBotoes";
            panelBotoes.Padding = new Padding(5);
            panelBotoes.Size = new Size(486, 73);
            panelBotoes.TabIndex = 4;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Location = new Point(334, 7);
            button1.Margin = new Padding(2);
            button1.Name = "button1";
            button1.Size = new Size(145, 55);
            button1.TabIndex = 18;
            button1.Text = "Save";
            button1.UseVisualStyleBackColor = true;
            button1.Click += buttonSave_Click;
            // 
            // FormSenderSettings
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(496, 193);
            Controls.Add(panelBotoes);
            Controls.Add(labelMessageCount);
            Controls.Add(numericUpDownMessageCount);
            Controls.Add(labelQueue);
            Controls.Add(textBoxQueue);
            Icon = (Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormSenderSettings";
            Padding = new Padding(5);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sender Settings";
            KeyDown += FormActivitySettings_KeyDown;
            ((System.ComponentModel.ISupportInitialize)numericUpDownMessageCount).EndInit();
            panelBotoes.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxQueue;
        private Label labelQueue;
        private NumericUpDown numericUpDownMessageCount;
        private Label labelMessageCount;
        private Button buttonSave;
        private Panel panelBotoes;
        private Button button1;
    }
}