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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            clientsDataGridView = new System.Windows.Forms.DataGridView();
            AddClient = new System.Windows.Forms.Button();
            EditClient = new System.Windows.Forms.Button();
            DeleteClient = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)clientsDataGridView).BeginInit();
            SuspendLayout();
            // 
            // clientsDataGridView
            // 
            clientsDataGridView.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(192, 255, 255);
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            clientsDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            clientsDataGridView.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            clientsDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            clientsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            clientsDataGridView.GridColor = System.Drawing.SystemColors.InfoText;
            clientsDataGridView.Location = new System.Drawing.Point(12, 39);
            clientsDataGridView.Name = "clientsDataGridView";
            clientsDataGridView.RowHeadersWidth = 51;
            clientsDataGridView.Size = new System.Drawing.Size(776, 278);
            clientsDataGridView.TabIndex = 7;
            // 
            // AddClient
            // 
            AddClient.BackColor = System.Drawing.SystemColors.AppWorkspace;
            AddClient.Location = new System.Drawing.Point(178, 382);
            AddClient.Name = "AddClient";
            AddClient.Size = new System.Drawing.Size(94, 29);
            AddClient.TabIndex = 6;
            AddClient.Text = "добавить";
            AddClient.UseVisualStyleBackColor = false;
            AddClient.Click += AddClient_Click;
            // 
            // EditClient
            // 
            EditClient.BackColor = System.Drawing.SystemColors.AppWorkspace;
            EditClient.Location = new System.Drawing.Point(23, 373);
            EditClient.Name = "EditClient";
            EditClient.Size = new System.Drawing.Size(149, 38);
            EditClient.TabIndex = 5;
            EditClient.Text = "Редактировать";
            EditClient.UseVisualStyleBackColor = false;
            EditClient.Click += EditClient_Click;
            // 
            // DeleteClient
            // 
            DeleteClient.BackColor = System.Drawing.SystemColors.AppWorkspace;
            DeleteClient.Location = new System.Drawing.Point(278, 382);
            DeleteClient.Name = "DeleteClient";
            DeleteClient.Size = new System.Drawing.Size(94, 29);
            DeleteClient.TabIndex = 4;
            DeleteClient.Text = "Удалить музыканта";
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