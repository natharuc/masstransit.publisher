namespace Masstransit.Publisher.Windows.Forms
{
    partial class FormLogDetails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogDetails));
            panelTop = new Panel();
            labelTitle = new Label();
            panelMain = new Panel();
            groupBoxBody = new GroupBox();
            richTextBoxBody = new RichTextBox();
            panelBodyButtons = new Panel();
            buttonFormatJson = new Button();
            buttonCopyBody = new Button();
            groupBoxMessage = new GroupBox();
            labelMessageValue = new Label();
            panelMessageButtons = new Panel();
            buttonCopyMessage = new Button();
            panelBottom = new Panel();
            buttonClose = new Button();
            panelTop.SuspendLayout();
            panelMain.SuspendLayout();
            groupBoxBody.SuspendLayout();
            panelBodyButtons.SuspendLayout();
            groupBoxMessage.SuspendLayout();
            panelMessageButtons.SuspendLayout();
            panelBottom.SuspendLayout();
            SuspendLayout();
            // 
            // panelTop
            // 
            panelTop.BackColor = Color.FromArgb(45, 45, 48);
            panelTop.Controls.Add(labelTitle);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Name = "panelTop";
            panelTop.Padding = new Padding(15, 10, 15, 10);
            panelTop.Size = new Size(784, 60);
            panelTop.TabIndex = 0;
            // 
            // labelTitle
            // 
            labelTitle.Dock = DockStyle.Fill;
            labelTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            labelTitle.ForeColor = Color.White;
            labelTitle.Location = new Point(15, 10);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(754, 40);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "Log Details";
            labelTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panelMain
            // 
            panelMain.Controls.Add(groupBoxBody);
            panelMain.Controls.Add(groupBoxMessage);
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(0, 60);
            panelMain.Name = "panelMain";
            panelMain.Padding = new Padding(15);
            panelMain.Size = new Size(784, 491);
            panelMain.TabIndex = 1;
            // 
            // groupBoxBody
            // 
            groupBoxBody.Controls.Add(richTextBoxBody);
            groupBoxBody.Controls.Add(panelBodyButtons);
            groupBoxBody.Dock = DockStyle.Fill;
            groupBoxBody.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            groupBoxBody.Location = new Point(15, 135);
            groupBoxBody.Name = "groupBoxBody";
            groupBoxBody.Padding = new Padding(10);
            groupBoxBody.Size = new Size(754, 341);
            groupBoxBody.TabIndex = 1;
            groupBoxBody.TabStop = false;
            groupBoxBody.Text = "Body Content";
            // 
            // richTextBoxBody
            // 
            richTextBoxBody.BackColor = Color.FromArgb(30, 30, 30);
            richTextBoxBody.BorderStyle = BorderStyle.None;
            richTextBoxBody.Dock = DockStyle.Fill;
            richTextBoxBody.Font = new Font("Consolas", 10F);
            richTextBoxBody.ForeColor = Color.FromArgb(220, 220, 220);
            richTextBoxBody.Location = new Point(10, 28);
            richTextBoxBody.Name = "richTextBoxBody";
            richTextBoxBody.ReadOnly = true;
            richTextBoxBody.Size = new Size(734, 253);
            richTextBoxBody.TabIndex = 0;
            richTextBoxBody.Text = "";
            richTextBoxBody.WordWrap = false;
            // 
            // panelBodyButtons
            // 
            panelBodyButtons.Controls.Add(buttonFormatJson);
            panelBodyButtons.Controls.Add(buttonCopyBody);
            panelBodyButtons.Dock = DockStyle.Bottom;
            panelBodyButtons.Location = new Point(10, 281);
            panelBodyButtons.Name = "panelBodyButtons";
            panelBodyButtons.Padding = new Padding(0, 10, 0, 0);
            panelBodyButtons.Size = new Size(734, 50);
            panelBodyButtons.TabIndex = 1;
            // 
            // buttonFormatJson
            // 
            buttonFormatJson.FlatStyle = FlatStyle.Flat;
            buttonFormatJson.Font = new Font("Segoe UI", 9F);
            buttonFormatJson.Location = new Point(120, 10);
            buttonFormatJson.Name = "buttonFormatJson";
            buttonFormatJson.Size = new Size(110, 35);
            buttonFormatJson.TabIndex = 1;
            buttonFormatJson.Text = "Format JSON";
            buttonFormatJson.UseVisualStyleBackColor = true;
            buttonFormatJson.Click += buttonFormatJson_Click;
            // 
            // buttonCopyBody
            // 
            buttonCopyBody.FlatStyle = FlatStyle.Flat;
            buttonCopyBody.Font = new Font("Segoe UI", 9F);
            buttonCopyBody.Location = new Point(5, 10);
            buttonCopyBody.Name = "buttonCopyBody";
            buttonCopyBody.Size = new Size(110, 35);
            buttonCopyBody.TabIndex = 0;
            buttonCopyBody.Text = "Copy Body";
            buttonCopyBody.UseVisualStyleBackColor = true;
            buttonCopyBody.Click += buttonCopyBody_Click;
            // 
            // groupBoxMessage
            // 
            groupBoxMessage.Controls.Add(labelMessageValue);
            groupBoxMessage.Controls.Add(panelMessageButtons);
            groupBoxMessage.Dock = DockStyle.Top;
            groupBoxMessage.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            groupBoxMessage.Location = new Point(15, 15);
            groupBoxMessage.Name = "groupBoxMessage";
            groupBoxMessage.Padding = new Padding(10);
            groupBoxMessage.Size = new Size(754, 120);
            groupBoxMessage.TabIndex = 0;
            groupBoxMessage.TabStop = false;
            groupBoxMessage.Text = "Log Message";
            // 
            // labelMessageValue
            // 
            labelMessageValue.Dock = DockStyle.Fill;
            labelMessageValue.Font = new Font("Segoe UI", 10F);
            labelMessageValue.Location = new Point(10, 28);
            labelMessageValue.Name = "labelMessageValue";
            labelMessageValue.Padding = new Padding(5);
            labelMessageValue.Size = new Size(734, 32);
            labelMessageValue.TabIndex = 0;
            labelMessageValue.Text = "Message content here...";
            // 
            // panelMessageButtons
            // 
            panelMessageButtons.Controls.Add(buttonCopyMessage);
            panelMessageButtons.Dock = DockStyle.Bottom;
            panelMessageButtons.Location = new Point(10, 60);
            panelMessageButtons.Name = "panelMessageButtons";
            panelMessageButtons.Padding = new Padding(0, 10, 0, 0);
            panelMessageButtons.Size = new Size(734, 50);
            panelMessageButtons.TabIndex = 1;
            // 
            // buttonCopyMessage
            // 
            buttonCopyMessage.FlatStyle = FlatStyle.Flat;
            buttonCopyMessage.Font = new Font("Segoe UI", 9F);
            buttonCopyMessage.Location = new Point(5, 10);
            buttonCopyMessage.Name = "buttonCopyMessage";
            buttonCopyMessage.Size = new Size(130, 35);
            buttonCopyMessage.TabIndex = 0;
            buttonCopyMessage.Text = "Copy Message";
            buttonCopyMessage.UseVisualStyleBackColor = true;
            buttonCopyMessage.Click += buttonCopyMessage_Click;
            // 
            // panelBottom
            // 
            panelBottom.Controls.Add(buttonClose);
            panelBottom.Dock = DockStyle.Bottom;
            panelBottom.Location = new Point(0, 551);
            panelBottom.Name = "panelBottom";
            panelBottom.Padding = new Padding(15, 5, 15, 10);
            panelBottom.Size = new Size(784, 60);
            panelBottom.TabIndex = 2;
            // 
            // buttonClose
            // 
            buttonClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonClose.FlatStyle = FlatStyle.Flat;
            buttonClose.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            buttonClose.Location = new Point(656, 10);
            buttonClose.Name = "buttonClose";
            buttonClose.Size = new Size(110, 40);
            buttonClose.TabIndex = 0;
            buttonClose.Text = "Close";
            buttonClose.UseVisualStyleBackColor = true;
            buttonClose.Click += buttonClose_Click;
            // 
            // FormLogDetails
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 611);
            Controls.Add(panelMain);
            Controls.Add(panelBottom);
            Controls.Add(panelTop);
            Icon = (Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormLogDetails";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Log Details";
            KeyDown += FormLogDetails_KeyDown;
            panelTop.ResumeLayout(false);
            panelMain.ResumeLayout(false);
            groupBoxBody.ResumeLayout(false);
            panelBodyButtons.ResumeLayout(false);
            groupBoxMessage.ResumeLayout(false);
            panelMessageButtons.ResumeLayout(false);
            panelBottom.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panelTop;
        private Label labelTitle;
        private Panel panelMain;
        private GroupBox groupBoxMessage;
        private Label labelMessageValue;
        private Panel panelMessageButtons;
        private Button buttonCopyMessage;
        private GroupBox groupBoxBody;
        private RichTextBox richTextBoxBody;
        private Panel panelBodyButtons;
        private Button buttonCopyBody;
        private Button buttonFormatJson;
        private Panel panelBottom;
        private Button buttonClose;
    }
}
