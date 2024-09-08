namespace Masstransit.Publisher.Windows.Forms.UserControls.BrokersSettings
{
    partial class UserControlRabbitMqSettings
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
            groupBoxUser = new GroupBox();
            textBoxUser = new TextBox();
            groupBox1 = new GroupBox();
            textBoxPassword = new TextBox();
            groupBoxVirtualHost = new GroupBox();
            textBoxVirtualHost = new TextBox();
            groupBoxHost.SuspendLayout();
            groupBoxUser.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBoxVirtualHost.SuspendLayout();
            SuspendLayout();
            // 
            // groupBoxHost
            // 
            groupBoxHost.Controls.Add(textBoxHost);
            groupBoxHost.Dock = DockStyle.Fill;
            groupBoxHost.Location = new Point(0, 0);
            groupBoxHost.Name = "groupBoxHost";
            groupBoxHost.Padding = new Padding(10, 5, 10, 5);
            groupBoxHost.Size = new Size(207, 55);
            groupBoxHost.TabIndex = 0;
            groupBoxHost.TabStop = false;
            groupBoxHost.Text = "Host";
            // 
            // textBoxHost
            // 
            textBoxHost.Dock = DockStyle.Fill;
            textBoxHost.Location = new Point(10, 21);
            textBoxHost.Name = "textBoxHost";
            textBoxHost.Size = new Size(187, 23);
            textBoxHost.TabIndex = 0;
            // 
            // groupBoxUser
            // 
            groupBoxUser.Controls.Add(textBoxUser);
            groupBoxUser.Dock = DockStyle.Right;
            groupBoxUser.Location = new Point(407, 0);
            groupBoxUser.Name = "groupBoxUser";
            groupBoxUser.Padding = new Padding(10, 5, 10, 5);
            groupBoxUser.Size = new Size(200, 55);
            groupBoxUser.TabIndex = 1;
            groupBoxUser.TabStop = false;
            groupBoxUser.Text = "User";
            // 
            // textBoxUser
            // 
            textBoxUser.Dock = DockStyle.Fill;
            textBoxUser.Location = new Point(10, 21);
            textBoxUser.Name = "textBoxUser";
            textBoxUser.Size = new Size(180, 23);
            textBoxUser.TabIndex = 0;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(textBoxPassword);
            groupBox1.Dock = DockStyle.Right;
            groupBox1.Location = new Point(607, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(10, 5, 10, 5);
            groupBox1.Size = new Size(200, 55);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Password";
            // 
            // textBoxPassword
            // 
            textBoxPassword.Dock = DockStyle.Fill;
            textBoxPassword.Location = new Point(10, 21);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.Size = new Size(180, 23);
            textBoxPassword.TabIndex = 0;
            textBoxPassword.UseSystemPasswordChar = true;
            // 
            // groupBoxVirtualHost
            // 
            groupBoxVirtualHost.Controls.Add(textBoxVirtualHost);
            groupBoxVirtualHost.Dock = DockStyle.Right;
            groupBoxVirtualHost.Location = new Point(207, 0);
            groupBoxVirtualHost.Name = "groupBoxVirtualHost";
            groupBoxVirtualHost.Padding = new Padding(10, 5, 10, 5);
            groupBoxVirtualHost.Size = new Size(200, 55);
            groupBoxVirtualHost.TabIndex = 3;
            groupBoxVirtualHost.TabStop = false;
            groupBoxVirtualHost.Text = "Virtual Host";
            // 
            // textBoxVirtualHost
            // 
            textBoxVirtualHost.Dock = DockStyle.Fill;
            textBoxVirtualHost.Location = new Point(10, 21);
            textBoxVirtualHost.Name = "textBoxVirtualHost";
            textBoxVirtualHost.Size = new Size(180, 23);
            textBoxVirtualHost.TabIndex = 0;
            // 
            // UserControlRabbitMqSettings
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(groupBoxHost);
            Controls.Add(groupBoxVirtualHost);
            Controls.Add(groupBoxUser);
            Controls.Add(groupBox1);
            Name = "UserControlRabbitMqSettings";
            Size = new Size(807, 55);
            groupBoxHost.ResumeLayout(false);
            groupBoxHost.PerformLayout();
            groupBoxUser.ResumeLayout(false);
            groupBoxUser.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBoxVirtualHost.ResumeLayout(false);
            groupBoxVirtualHost.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBoxHost;
        private TextBox textBoxHost;
        private GroupBox groupBoxUser;
        private TextBox textBoxUser;
        private GroupBox groupBox1;
        private TextBox textBoxPassword;
        private GroupBox groupBoxVirtualHost;
        private TextBox textBoxVirtualHost;
    }
}
