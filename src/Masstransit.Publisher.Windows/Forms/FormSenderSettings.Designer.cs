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
            ((System.ComponentModel.ISupportInitialize)numericUpDownMessageCount).BeginInit();
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
            // FormSenderSettings
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(496, 112);
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
            FormClosing += FormSenderSettings_FormClosing;
            KeyDown += FormActivitySettings_KeyDown;
            ((System.ComponentModel.ISupportInitialize)numericUpDownMessageCount).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxQueue;
        private Label labelQueue;
        private NumericUpDown numericUpDownMessageCount;
        private Label labelMessageCount;
    }
}