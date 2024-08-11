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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPublisher));
            textBoxContract = new TextBox();
            richTextBoxJson = new RichTextBox();
            labelContrato = new Label();
            labelJson = new Label();
            labelFila = new Label();
            textBoxQueue = new TextBox();
            richTextBoxConnectionString = new RichTextBox();
            label1 = new Label();
            button1 = new Button();
            buttonEnviar = new Button();
            buttonPublicar = new Button();
            buttonMockJson = new Button();
            dataGridViewAutoComplete = new DataGridView();
            linkLabelSelectDll = new LinkLabel();
            labelSelectedContract = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewAutoComplete).BeginInit();
            SuspendLayout();
            // 
            // textBoxContract
            // 
            textBoxContract.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxContract.Font = new Font("Ubuntu", 15F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxContract.Location = new Point(15, 96);
            textBoxContract.Name = "textBoxContract";
            textBoxContract.Size = new Size(874, 30);
            textBoxContract.TabIndex = 3;
            textBoxContract.TextChanged += textBoxContract_TextChanged;
            textBoxContract.KeyDown += textBoxContract_KeyDown;
            // 
            // richTextBoxJson
            // 
            richTextBoxJson.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            richTextBoxJson.BorderStyle = BorderStyle.None;
            richTextBoxJson.Location = new Point(15, 171);
            richTextBoxJson.Name = "richTextBoxJson";
            richTextBoxJson.Size = new Size(874, 302);
            richTextBoxJson.TabIndex = 5;
            richTextBoxJson.Text = "";
            // 
            // labelContrato
            // 
            labelContrato.AutoSize = true;
            labelContrato.Font = new Font("Ubuntu", 10F, FontStyle.Regular, GraphicsUnit.Point);
            labelContrato.Location = new Point(12, 75);
            labelContrato.Name = "labelContrato";
            labelContrato.Size = new Size(107, 18);
            labelContrato.TabIndex = 2;
            labelContrato.Text = "Search contract";
            // 
            // labelJson
            // 
            labelJson.AutoSize = true;
            labelJson.Font = new Font("Ubuntu", 10F, FontStyle.Regular, GraphicsUnit.Point);
            labelJson.Location = new Point(12, 150);
            labelJson.Name = "labelJson";
            labelJson.Size = new Size(43, 18);
            labelJson.TabIndex = 4;
            labelJson.Text = "JSON";
            // 
            // labelFila
            // 
            labelFila.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            labelFila.AutoSize = true;
            labelFila.Font = new Font("Ubuntu", 10F, FontStyle.Regular, GraphicsUnit.Point);
            labelFila.Location = new Point(12, 476);
            labelFila.Name = "labelFila";
            labelFila.Size = new Size(51, 18);
            labelFila.TabIndex = 6;
            labelFila.Text = "Queue";
            // 
            // textBoxQueue
            // 
            textBoxQueue.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBoxQueue.Font = new Font("Ubuntu", 15F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxQueue.Location = new Point(15, 497);
            textBoxQueue.Name = "textBoxQueue";
            textBoxQueue.Size = new Size(874, 30);
            textBoxQueue.TabIndex = 7;
            // 
            // richTextBoxConnectionString
            // 
            richTextBoxConnectionString.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            richTextBoxConnectionString.BorderStyle = BorderStyle.None;
            richTextBoxConnectionString.Location = new Point(15, 31);
            richTextBoxConnectionString.Name = "richTextBoxConnectionString";
            richTextBoxConnectionString.Size = new Size(874, 41);
            richTextBoxConnectionString.TabIndex = 1;
            richTextBoxConnectionString.Text = "";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Ubuntu", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(122, 18);
            label1.TabIndex = 0;
            label1.Text = "Connection String";
            // 
            // button1
            // 
            button1.Location = new Point(512, 1024);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 8;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            // 
            // buttonEnviar
            // 
            buttonEnviar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonEnviar.Font = new Font("Ubuntu", 10F, FontStyle.Regular, GraphicsUnit.Point);
            buttonEnviar.Location = new Point(768, 533);
            buttonEnviar.Name = "buttonEnviar";
            buttonEnviar.Size = new Size(121, 45);
            buttonEnviar.TabIndex = 8;
            buttonEnviar.Text = "Send";
            buttonEnviar.UseVisualStyleBackColor = true;
            buttonEnviar.Click += buttonSend_Click;
            // 
            // buttonPublicar
            // 
            buttonPublicar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonPublicar.Font = new Font("Ubuntu", 10F, FontStyle.Regular, GraphicsUnit.Point);
            buttonPublicar.Location = new Point(641, 533);
            buttonPublicar.Name = "buttonPublicar";
            buttonPublicar.Size = new Size(121, 45);
            buttonPublicar.TabIndex = 10;
            buttonPublicar.Text = "Publish";
            buttonPublicar.UseVisualStyleBackColor = true;
            buttonPublicar.Click += buttonPublish_Click;
            // 
            // buttonMockJson
            // 
            buttonMockJson.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonMockJson.Font = new Font("Ubuntu", 10F, FontStyle.Regular, GraphicsUnit.Point);
            buttonMockJson.Location = new Point(15, 533);
            buttonMockJson.Name = "buttonMockJson";
            buttonMockJson.Size = new Size(121, 45);
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
            dataGridViewAutoComplete.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewAutoComplete.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewAutoComplete.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewAutoComplete.EditMode = DataGridViewEditMode.EditProgrammatically;
            dataGridViewAutoComplete.Location = new Point(15, 171);
            dataGridViewAutoComplete.Name = "dataGridViewAutoComplete";
            dataGridViewAutoComplete.RowHeadersVisible = false;
            dataGridViewAutoComplete.RowTemplate.Height = 30;
            dataGridViewAutoComplete.Size = new Size(874, 302);
            dataGridViewAutoComplete.TabIndex = 12;
            dataGridViewAutoComplete.Visible = false;
            dataGridViewAutoComplete.CellDoubleClick += dataGridViewAutoComplete_CellDoubleClick;
            dataGridViewAutoComplete.KeyDown += dataGridViewAutoComplete_KeyDown;
            // 
            // linkLabelSelectDll
            // 
            linkLabelSelectDll.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            linkLabelSelectDll.Location = new Point(437, 77);
            linkLabelSelectDll.Name = "linkLabelSelectDll";
            linkLabelSelectDll.Size = new Size(452, 16);
            linkLabelSelectDll.TabIndex = 13;
            linkLabelSelectDll.TabStop = true;
            linkLabelSelectDll.Text = "Select .dll";
            linkLabelSelectDll.TextAlign = ContentAlignment.MiddleRight;
            linkLabelSelectDll.LinkClicked += linkLabelSelectDll_LinkClicked;
            // 
            // labelSelectedContract
            // 
            labelSelectedContract.Font = new Font("Ubuntu", 9F, FontStyle.Italic, GraphicsUnit.Point);
            labelSelectedContract.Location = new Point(15, 129);
            labelSelectedContract.Name = "labelSelectedContract";
            labelSelectedContract.Size = new Size(874, 18);
            labelSelectedContract.TabIndex = 14;
            labelSelectedContract.Text = "...";
            // 
            // FormPublisher
            // 
            AutoScaleDimensions = new SizeF(6F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(898, 590);
            Controls.Add(labelSelectedContract);
            Controls.Add(linkLabelSelectDll);
            Controls.Add(dataGridViewAutoComplete);
            Controls.Add(buttonMockJson);
            Controls.Add(buttonPublicar);
            Controls.Add(buttonEnviar);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(richTextBoxConnectionString);
            Controls.Add(labelFila);
            Controls.Add(textBoxQueue);
            Controls.Add(labelJson);
            Controls.Add(labelContrato);
            Controls.Add(richTextBoxJson);
            Controls.Add(textBoxContract);
            Font = new Font("Ubuntu", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormPublisher";
            Text = "Masstransit - Publisher";
            Load += FormPublicador_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewAutoComplete).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox textBoxContract;
        private System.Windows.Forms.RichTextBox richTextBoxJson;
        private System.Windows.Forms.Label labelContrato;
        private System.Windows.Forms.Label labelJson;
        private System.Windows.Forms.Label labelFila;
        private System.Windows.Forms.TextBox textBoxQueue;
        private System.Windows.Forms.RichTextBox richTextBoxConnectionString;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button buttonEnviar;
        private System.Windows.Forms.Button buttonPublicar;
        private System.Windows.Forms.Button buttonMockJson;
        private System.Windows.Forms.DataGridView dataGridViewAutoComplete;
        private System.Windows.Forms.LinkLabel linkLabelSelectDll;
        private Label labelSelectedContract;
    }
}

