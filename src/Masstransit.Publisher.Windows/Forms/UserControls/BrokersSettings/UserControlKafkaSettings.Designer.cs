namespace Masstransit.Publisher.Windows.Forms.UserControls.BrokersSettings
{
    partial class UserControlKafkaSettings
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
            groupBoxHost = new GroupBox();
            textBoxHost = new TextBox();
            groupBoxPort = new GroupBox();
            numericUpDownPort = new NumericUpDown();
            groupBoxHost.SuspendLayout();
            groupBoxPort.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownPort).BeginInit();
            SuspendLayout();
            // 
            // groupBoxHost
            // 
            groupBoxHost.Controls.Add(textBoxHost);
            groupBoxHost.Dock = DockStyle.Fill;
            groupBoxHost.Location = new Point(0, 0);
            groupBoxHost.Name = "groupBoxHost";
            groupBoxHost.Padding = new Padding(10, 5, 10, 5);
            groupBoxHost.Size = new Size(607, 55);
            groupBoxHost.TabIndex = 0;
            groupBoxHost.TabStop = false;
            groupBoxHost.Text = "Host";
            // 
            // textBoxHost
            // 
            textBoxHost.Dock = DockStyle.Fill;
            textBoxHost.Location = new Point(10, 21);
            textBoxHost.Name = "textBoxHost";
            textBoxHost.Size = new Size(587, 23);
            textBoxHost.TabIndex = 0;
            // 
            // groupBoxPort
            // 
            groupBoxPort.Controls.Add(numericUpDownPort);
            groupBoxPort.Dock = DockStyle.Right;
            groupBoxPort.Location = new Point(607, 0);
            groupBoxPort.Name = "groupBoxPort";
            groupBoxPort.Padding = new Padding(10, 5, 10, 5);
            groupBoxPort.Size = new Size(200, 55);
            groupBoxPort.TabIndex = 2;
            groupBoxPort.TabStop = false;
            groupBoxPort.Text = "Port";
            // 
            // numericUpDownPort
            // 
            numericUpDownPort.Dock = DockStyle.Fill;
            numericUpDownPort.Location = new Point(10, 21);
            numericUpDownPort.Maximum = new decimal(new int[] { 99999999, 0, 0, 0 });
            numericUpDownPort.Name = "numericUpDownPort";
            numericUpDownPort.Size = new Size(180, 23);
            numericUpDownPort.TabIndex = 0;
            // 
            // UserControlKafkaSettings
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(groupBoxHost);
            Controls.Add(groupBoxPort);
            Name = "UserControlKafkaSettings";
            Size = new Size(807, 55);
            groupBoxHost.ResumeLayout(false);
            groupBoxHost.PerformLayout();
            groupBoxPort.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)numericUpDownPort).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBoxHost;
        private TextBox textBoxHost;
        private GroupBox groupBoxUser;
        private TextBox textBoxUser;
        private GroupBox groupBoxPort;
        private NumericUpDown numericUpDownPort;
        private TextBox textBoxPassword;
    }
}
