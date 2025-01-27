namespace Music_store
{
    partial class ClientsForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            clientsDataGridView = new System.Windows.Forms.DataGridView();
            AddClient = new System.Windows.Forms.Button();
            EditClient = new System.Windows.Forms.Button();
            DeleteClient = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)clientsDataGridView).BeginInit();
            SuspendLayout();
            // 
            // clientsDataGridView
            // 
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(192, 255, 255);
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            clientsDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            clientsDataGridView.BackgroundColor = System.Drawing.Color.LightBlue;
            clientsDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            clientsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            clientsDataGridView.GridColor = System.Drawing.SystemColors.InfoText;
            clientsDataGridView.Location = new System.Drawing.Point(12, 39);
            clientsDataGridView.Name = "clientsDataGridView";
            clientsDataGridView.ReadOnly = true;
            clientsDataGridView.RowHeadersWidth = 51;
            clientsDataGridView.Size = new System.Drawing.Size(776, 278);
            clientsDataGridView.TabIndex = 7;
            // 
            // AddClient
            // 
            AddClient.BackColor = System.Drawing.SystemColors.ActiveCaption;
            AddClient.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            AddClient.Location = new System.Drawing.Point(23, 373);
            AddClient.Name = "AddClient";
            AddClient.Size = new System.Drawing.Size(149, 38);
            AddClient.TabIndex = 6;
            AddClient.Text = "Добавить";
            AddClient.UseVisualStyleBackColor = false;
            AddClient.Click += AddClient_Click;
            // 
            // EditClient
            // 
            EditClient.BackColor = System.Drawing.SystemColors.ActiveCaption;
            EditClient.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            EditClient.Location = new System.Drawing.Point(178, 373);
            EditClient.Name = "EditClient";
            EditClient.Size = new System.Drawing.Size(149, 38);
            EditClient.TabIndex = 5;
            EditClient.Text = "Редактировать";
            EditClient.UseVisualStyleBackColor = false;
            EditClient.Click += EditClient_Click;
            // 
            // DeleteClient
            // 
            DeleteClient.BackColor = System.Drawing.SystemColors.ActiveCaption;
            DeleteClient.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            DeleteClient.Location = new System.Drawing.Point(333, 373);
            DeleteClient.Name = "DeleteClient";
            DeleteClient.Size = new System.Drawing.Size(149, 38);
            DeleteClient.TabIndex = 4;
            DeleteClient.Text = "Удалить";
            DeleteClient.UseVisualStyleBackColor = false;
            DeleteClient.Click += DeleteClient_Click;
            // 
            // ClientsForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(800, 450);
            Controls.Add(clientsDataGridView);
            Controls.Add(AddClient);
            Controls.Add(EditClient);
            Controls.Add(DeleteClient);
            Name = "ClientsForm";
            Text = "Клиенты";
            Load += ClientsForm_Load;
            ((System.ComponentModel.ISupportInitialize)clientsDataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.DataGridView clientsDataGridView;
        private System.Windows.Forms.Button AddClient;
        private System.Windows.Forms.Button EditClient;
        private System.Windows.Forms.Button DeleteClient;
    }
}