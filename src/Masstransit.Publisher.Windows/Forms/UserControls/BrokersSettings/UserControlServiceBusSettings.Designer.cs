namespace Masstransit.Publisher.Windows.Forms.UserControls.BrokersSettings
{
    partial class UserControlServiceBusSettings
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            labelConnectionString = new Label();
            richTextBoxConnectionString = new RichTextBox();
            SuspendLayout();
            // 
            // labelConnectionString
            // 
            labelConnectionString.Dock = DockStyle.Top;
            labelConnectionString.Location = new Point(0, 0);
            labelConnectionString.Margin = new Padding(2, 0, 2, 0);
            labelConnectionString.Name = "labelConnectionString";
            labelConnectionString.Size = new Size(609, 23);
            labelConnectionString.TabIndex = 2;
            labelConnectionString.Text = "Connection String";
            labelConnectionString.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // richTextBoxConnectionString
            // 
            richTextBoxConnectionString.BorderStyle = BorderStyle.None;
            richTextBoxConnectionString.Dock = DockStyle.Fill;
            richTextBoxConnectionString.Location = new Point(0, 23);
            richTextBoxConnectionString.Margin = new Padding(2);
            richTextBoxConnectionString.Name = "richTextBoxConnectionString";
            richTextBoxConnectionString.Size = new Size(609, 210);
            richTextBoxConnectionString.TabIndex = 3;
            richTextBoxConnectionString.Text = "";
            // 
            // UserControlServiceBusSettings
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(richTextBoxConnectionString);
            Controls.Add(labelConnectionString);
            Name = "UserControlServiceBusSettings";
            Size = new Size(609, 233);
            ResumeLayout(false);
        }

        #endregion

        private Label labelConnectionString;
        private RichTextBox richTextBoxConnectionString;
    }
}
