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
            richTextBoxActivitySettings = new RichTextBox();
            panelInfo = new Panel();
            labelInfo = new Label();
            panelBotoes = new Panel();
            buttonSalvar = new Button();
            buttonSave = new Button();
            panelInfo.SuspendLayout();
            panelBotoes.SuspendLayout();
            SuspendLayout();
            // 
            // richTextBoxActivitySettings
            // 
            richTextBoxActivitySettings.BorderStyle = BorderStyle.None;
            richTextBoxActivitySettings.Dock = DockStyle.Fill;
            richTextBoxActivitySettings.Font = new Font("Lucida Console", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            richTextBoxActivitySettings.Location = new Point(5, 5);
            richTextBoxActivitySettings.Name = "richTextBoxActivitySettings";
            richTextBoxActivitySettings.Size = new Size(486, 256);
            richTextBoxActivitySettings.TabIndex = 0;
            richTextBoxActivitySettings.Text = resources.GetString("richTextBoxActivitySettings.Text");
            // 
            // panelInfo
            // 
            panelInfo.Controls.Add(labelInfo);
            panelInfo.Dock = DockStyle.Bottom;
            panelInfo.Location = new Point(5, 261);
            panelInfo.Name = "panelInfo";
            panelInfo.Size = new Size(486, 115);
            panelInfo.TabIndex = 1;
            // 
            // labelInfo
            // 
            labelInfo.Dock = DockStyle.Fill;
            labelInfo.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point);
            labelInfo.Location = new Point(0, 0);
            labelInfo.Name = "labelInfo";
            labelInfo.Size = new Size(486, 115);
            labelInfo.TabIndex = 0;
            labelInfo.Text = resources.GetString("labelInfo.Text");
            // 
            // panelBotoes
            // 
            panelBotoes.Controls.Add(buttonSalvar);
            panelBotoes.Controls.Add(buttonSave);
            panelBotoes.Dock = DockStyle.Bottom;
            panelBotoes.Location = new Point(5, 376);
            panelBotoes.Name = "panelBotoes";
            panelBotoes.Padding = new Padding(5);
            panelBotoes.Size = new Size(486, 73);
            panelBotoes.TabIndex = 2;
            // 
            // buttonSalvar
            // 
            buttonSalvar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonSalvar.FlatStyle = FlatStyle.Flat;
            buttonSalvar.Location = new Point(334, 7);
            buttonSalvar.Margin = new Padding(2);
            buttonSalvar.Name = "buttonSalvar";
            buttonSalvar.Size = new Size(145, 55);
            buttonSalvar.TabIndex = 18;
            buttonSalvar.Text = "Save";
            buttonSalvar.UseVisualStyleBackColor = true;
            buttonSalvar.Click += buttonSave_Click;
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
            // FormActivitySettings
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(496, 454);
            Controls.Add(richTextBoxActivitySettings);
            Controls.Add(panelInfo);
            Controls.Add(panelBotoes);
            Icon = (Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormActivitySettings";
            Padding = new Padding(5);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Activity Settings";
            KeyDown += FormActivitySettings_KeyDown;
            panelInfo.ResumeLayout(false);
            panelBotoes.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private RichTextBox richTextBoxActivitySettings;
        private Panel panelInfo;
        private Label labelInfo;
        private Panel panelBotoes;
        private Button buttonSave;
        private Button buttonSalvar;
    }
}