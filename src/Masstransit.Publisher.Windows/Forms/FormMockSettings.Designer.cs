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
            panelTittle = new Panel();
            linkLabelNew = new LinkLabel();
            panelTittle.SuspendLayout();
            SuspendLayout();
            // 
            // flowLayoutPanel
            // 
            flowLayoutPanel.Dock = DockStyle.Fill;
            flowLayoutPanel.Location = new Point(0, 25);
            flowLayoutPanel.Name = "flowLayoutPanel";
            flowLayoutPanel.Padding = new Padding(5);
            flowLayoutPanel.Size = new Size(574, 527);
            flowLayoutPanel.TabIndex = 0;
            // 
            // panelTittle
            // 
            panelTittle.Controls.Add(linkLabelNew);
            panelTittle.Dock = DockStyle.Top;
            panelTittle.Location = new Point(0, 0);
            panelTittle.Name = "panelTittle";
            panelTittle.Size = new Size(574, 25);
            panelTittle.TabIndex = 0;
            // 
            // linkLabelNew
            // 
            linkLabelNew.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            linkLabelNew.AutoSize = true;
            linkLabelNew.LinkColor = Color.Black;
            linkLabelNew.Location = new Point(6, 5);
            linkLabelNew.Margin = new Padding(2, 0, 2, 0);
            linkLabelNew.Name = "linkLabelNew";
            linkLabelNew.Size = new Size(31, 15);
            linkLabelNew.TabIndex = 15;
            linkLabelNew.TabStop = true;
            linkLabelNew.Text = "New";
            linkLabelNew.TextAlign = ContentAlignment.MiddleRight;
            linkLabelNew.LinkClicked += linkLabelNew_LinkClicked;
            // 
            // FormMockSettings
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(574, 552);
            Controls.Add(flowLayoutPanel);
            Controls.Add(panelTittle);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimizeBox = false;
            Name = "FormMockSettings";
            Text = "Mock Settings";
            FormClosing += FormMockSettings_FormClosing;
            panelTittle.ResumeLayout(false);
            panelTittle.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel flowLayoutPanel;
        private Panel panelTittle;
        private LinkLabel linkLabelNew;
    }
}