namespace Publicador
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
            this.textBoxContract = new System.Windows.Forms.TextBox();
            this.richTextBoxJson = new System.Windows.Forms.RichTextBox();
            this.labelContrato = new System.Windows.Forms.Label();
            this.labelJson = new System.Windows.Forms.Label();
            this.labelFila = new System.Windows.Forms.Label();
            this.textBoxQueue = new System.Windows.Forms.TextBox();
            this.richTextBoxConnectionString = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonEnviar = new System.Windows.Forms.Button();
            this.buttonPublicar = new System.Windows.Forms.Button();
            this.buttonGerarJson = new System.Windows.Forms.Button();
            this.dataGridViewAutoComplete = new System.Windows.Forms.DataGridView();
            this.linkLabelSelectDll = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAutoComplete)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxContract
            // 
            this.textBoxContract.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxContract.Font = new System.Drawing.Font("Ubuntu", 15F);
            this.textBoxContract.Location = new System.Drawing.Point(15, 96);
            this.textBoxContract.Name = "textBoxContract";
            this.textBoxContract.Size = new System.Drawing.Size(874, 30);
            this.textBoxContract.TabIndex = 3;
            this.textBoxContract.TextChanged += new System.EventHandler(this.textBoxContrato_TextChanged);
            this.textBoxContract.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxContrato_KeyDown);
            // 
            // richTextBoxJson
            // 
            this.richTextBoxJson.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxJson.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxJson.Location = new System.Drawing.Point(15, 150);
            this.richTextBoxJson.Name = "richTextBoxJson";
            this.richTextBoxJson.Size = new System.Drawing.Size(874, 323);
            this.richTextBoxJson.TabIndex = 5;
            this.richTextBoxJson.Text = "";
            // 
            // labelContrato
            // 
            this.labelContrato.AutoSize = true;
            this.labelContrato.Font = new System.Drawing.Font("Ubuntu", 10F);
            this.labelContrato.Location = new System.Drawing.Point(12, 75);
            this.labelContrato.Name = "labelContrato";
            this.labelContrato.Size = new System.Drawing.Size(65, 18);
            this.labelContrato.TabIndex = 2;
            this.labelContrato.Text = "Contract";
            // 
            // labelJson
            // 
            this.labelJson.AutoSize = true;
            this.labelJson.Font = new System.Drawing.Font("Ubuntu", 10F);
            this.labelJson.Location = new System.Drawing.Point(12, 129);
            this.labelJson.Name = "labelJson";
            this.labelJson.Size = new System.Drawing.Size(43, 18);
            this.labelJson.TabIndex = 4;
            this.labelJson.Text = "JSON";
            // 
            // labelFila
            // 
            this.labelFila.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelFila.AutoSize = true;
            this.labelFila.Font = new System.Drawing.Font("Ubuntu", 10F);
            this.labelFila.Location = new System.Drawing.Point(12, 476);
            this.labelFila.Name = "labelFila";
            this.labelFila.Size = new System.Drawing.Size(51, 18);
            this.labelFila.TabIndex = 6;
            this.labelFila.Text = "Queue";
            // 
            // textBoxQueue
            // 
            this.textBoxQueue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxQueue.Font = new System.Drawing.Font("Ubuntu", 15F);
            this.textBoxQueue.Location = new System.Drawing.Point(15, 497);
            this.textBoxQueue.Name = "textBoxQueue";
            this.textBoxQueue.Size = new System.Drawing.Size(874, 30);
            this.textBoxQueue.TabIndex = 7;
            // 
            // richTextBoxConnectionString
            // 
            this.richTextBoxConnectionString.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxConnectionString.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxConnectionString.Location = new System.Drawing.Point(15, 31);
            this.richTextBoxConnectionString.Name = "richTextBoxConnectionString";
            this.richTextBoxConnectionString.Size = new System.Drawing.Size(874, 41);
            this.richTextBoxConnectionString.TabIndex = 1;
            this.richTextBoxConnectionString.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Ubuntu", 10F);
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Connection String";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(512, 1024);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // buttonEnviar
            // 
            this.buttonEnviar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonEnviar.Font = new System.Drawing.Font("Ubuntu", 10F);
            this.buttonEnviar.Location = new System.Drawing.Point(768, 533);
            this.buttonEnviar.Name = "buttonEnviar";
            this.buttonEnviar.Size = new System.Drawing.Size(121, 45);
            this.buttonEnviar.TabIndex = 8;
            this.buttonEnviar.Text = "Send";
            this.buttonEnviar.UseVisualStyleBackColor = true;
            this.buttonEnviar.Click += new System.EventHandler(this.buttonEnviar_Click);
            // 
            // buttonPublicar
            // 
            this.buttonPublicar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonPublicar.Font = new System.Drawing.Font("Ubuntu", 10F);
            this.buttonPublicar.Location = new System.Drawing.Point(641, 533);
            this.buttonPublicar.Name = "buttonPublicar";
            this.buttonPublicar.Size = new System.Drawing.Size(121, 45);
            this.buttonPublicar.TabIndex = 10;
            this.buttonPublicar.Text = "Publish";
            this.buttonPublicar.UseVisualStyleBackColor = true;
            this.buttonPublicar.Click += new System.EventHandler(this.buttonPublicar_Click);
            // 
            // buttonGerarJson
            // 
            this.buttonGerarJson.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonGerarJson.Font = new System.Drawing.Font("Ubuntu", 10F);
            this.buttonGerarJson.Location = new System.Drawing.Point(15, 533);
            this.buttonGerarJson.Name = "buttonGerarJson";
            this.buttonGerarJson.Size = new System.Drawing.Size(121, 45);
            this.buttonGerarJson.TabIndex = 11;
            this.buttonGerarJson.Text = "Generate";
            this.buttonGerarJson.UseVisualStyleBackColor = true;
            this.buttonGerarJson.Click += new System.EventHandler(this.buttonGerarJson_Click);
            // 
            // dataGridViewAutoComplete
            // 
            this.dataGridViewAutoComplete.AllowUserToAddRows = false;
            this.dataGridViewAutoComplete.AllowUserToDeleteRows = false;
            this.dataGridViewAutoComplete.AllowUserToResizeColumns = false;
            this.dataGridViewAutoComplete.AllowUserToResizeRows = false;
            this.dataGridViewAutoComplete.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewAutoComplete.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewAutoComplete.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAutoComplete.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridViewAutoComplete.Location = new System.Drawing.Point(15, 132);
            this.dataGridViewAutoComplete.Name = "dataGridViewAutoComplete";
            this.dataGridViewAutoComplete.RowHeadersVisible = false;
            this.dataGridViewAutoComplete.RowTemplate.Height = 30;
            this.dataGridViewAutoComplete.Size = new System.Drawing.Size(874, 341);
            this.dataGridViewAutoComplete.TabIndex = 12;
            this.dataGridViewAutoComplete.Visible = false;
            this.dataGridViewAutoComplete.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewAutoComplete_CellDoubleClick);
            this.dataGridViewAutoComplete.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridViewAutoComplete_KeyDown);
            // 
            // linkLabelSelectDll
            // 
            this.linkLabelSelectDll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabelSelectDll.Location = new System.Drawing.Point(437, 77);
            this.linkLabelSelectDll.Name = "linkLabelSelectDll";
            this.linkLabelSelectDll.Size = new System.Drawing.Size(452, 16);
            this.linkLabelSelectDll.TabIndex = 13;
            this.linkLabelSelectDll.TabStop = true;
            this.linkLabelSelectDll.Text = "Select .dll";
            this.linkLabelSelectDll.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.linkLabelSelectDll.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelSelectDll_LinkClicked);
            // 
            // FormPublisher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(898, 590);
            this.Controls.Add(this.linkLabelSelectDll);
            this.Controls.Add(this.dataGridViewAutoComplete);
            this.Controls.Add(this.buttonGerarJson);
            this.Controls.Add(this.buttonPublicar);
            this.Controls.Add(this.buttonEnviar);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.richTextBoxConnectionString);
            this.Controls.Add(this.labelFila);
            this.Controls.Add(this.textBoxQueue);
            this.Controls.Add(this.labelJson);
            this.Controls.Add(this.labelContrato);
            this.Controls.Add(this.richTextBoxJson);
            this.Controls.Add(this.textBoxContract);
            this.Font = new System.Drawing.Font("Ubuntu", 8.25F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormPublisher";
            this.Text = "Masstransit - Publisher";
            this.Load += new System.EventHandler(this.FormPublicador_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAutoComplete)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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

