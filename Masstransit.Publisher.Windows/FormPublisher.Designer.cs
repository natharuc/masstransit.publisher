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
            buttonGerarJson = new Button();
            dataGridViewAutoComplete = new DataGridView();
            linkLabelSelectDll = new LinkLabel();
            ((System.ComponentModel.ISupportInitialize)dataGridViewAutoComplete).BeginInit();
            SuspendLayout();
            // 
            // textBoxContract
            // 
            textBoxContract.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxContract.Font = new Font("Ubuntu", 15F);
            textBoxContract.Location = new Point(15, 96);
            textBoxContract.Name = "textBoxContract";
            textBoxContract.Size = new Size(874, 30);
            textBoxContract.TabIndex = 3;
            textBoxContract.TextChanged += textBoxContrato_TextChanged;
            textBoxContract.KeyDown += textBoxContrato_KeyDown;
            // 
            // richTextBoxJson
            // 
            richTextBoxJson.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            richTextBoxJson.BorderStyle = BorderStyle.None;
            richTextBoxJson.Location = new Point(15, 150);
            richTextBoxJson.Name = "richTextBoxJson";
            richTextBoxJson.Size = new Size(874, 323);
            richTextBoxJson.TabIndex = 5;
            richTextBoxJson.Text = "";
            // 
            // labelContrato
            // 
            labelContrato.AutoSize = true;
            labelContrato.Font = new Font("Ubuntu", 10F);
            labelContrato.Location = new Point(12, 75);
            labelContrato.Name = "labelContrato";
            labelContrato.Size = new Size(65, 18);
            labelContrato.TabIndex = 2;
            labelContrato.Text = "Contract";
            // 
            // labelJson
            // 
            labelJson.AutoSize = true;
            labelJson.Font = new Font("Ubuntu", 10F);
            labelJson.Location = new Point(12, 129);
            labelJson.Name = "labelJson";
            labelJson.Size = new Size(43, 18);
            labelJson.TabIndex = 4;
            labelJson.Text = "JSON";
            // 
            // labelFila
            // 
            labelFila.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            labelFila.AutoSize = true;
            labelFila.Font = new Font("Ubuntu", 10F);
            labelFila.Location = new Point(12, 476);
            labelFila.Name = "labelFila";
            labelFila.Size = new Size(51, 18);
            labelFila.TabIndex = 6;
            labelFila.Text = "Queue";
            // 
            // textBoxQueue
            // 
            textBoxQueue.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBoxQueue.Font = new Font("Ubuntu", 15F);
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
            label1.Font = new Font("Ubuntu", 10F);
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
            buttonEnviar.Font = new Font("Ubuntu", 10F);
            buttonEnviar.Location = new Point(768, 533);
            buttonEnviar.Name = "buttonEnviar";
            buttonEnviar.Size = new Size(121, 45);
            buttonEnviar.TabIndex = 8;
            buttonEnviar.Text = "Send";
            buttonEnviar.UseVisualStyleBackColor = true;
            buttonEnviar.Click += buttonEnviar_Click;
            // 
            // buttonPublicar
            // 
            buttonPublicar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonPublicar.Font = new Font("Ubuntu", 10F);
            buttonPublicar.Location = new Point(641, 533);
            buttonPublicar.Name = "buttonPublicar";
            buttonPublicar.Size = new Size(121, 45);
            buttonPublicar.TabIndex = 10;
            buttonPublicar.Text = "Publish";
            buttonPublicar.UseVisualStyleBackColor = true;
            buttonPublicar.Click += buttonPublicar_Click;
            // 
            // buttonGerarJson
            // 
            buttonGerarJson.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonGerarJson.Font = new Font("Ubuntu", 10F);
            buttonGerarJson.Location = new Point(15, 533);
            buttonGerarJson.Name = "buttonGerarJson";
            buttonGerarJson.Size = new Size(121, 45);
            buttonGerarJson.TabIndex = 11;
            buttonGerarJson.Text = "Generate";
            buttonGerarJson.UseVisualStyleBackColor = true;
            buttonGerarJson.Click += buttonGerarJson_Click;
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
            dataGridViewAutoComplete.Location = new Point(15, 132);
            dataGridViewAutoComplete.Name = "dataGridViewAutoComplete";
            dataGridViewAutoComplete.RowHeadersVisible = false;
            dataGridViewAutoComplete.RowTemplate.Height = 30;
            dataGridViewAutoComplete.Size = new Size(874, 341);
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
            // FormPublisher
            // 
            AutoScaleDimensions = new SizeF(6F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(898, 590);
            Controls.Add(linkLabelSelectDll);
            Controls.Add(dataGridViewAutoComplete);
            Controls.Add(buttonGerarJson);
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
            Font = new Font("Ubuntu", 8.25F);
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
        private System.Windows.Forms.Button buttonGerarJson;
        private System.Windows.Forms.DataGridView dataGridViewAutoComplete;
        private System.Windows.Forms.LinkLabel linkLabelSelectDll;
    }
}

