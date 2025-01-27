namespace Music_store
{
    partial class MusiciansForm
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
            deleteMusician = new System.Windows.Forms.Button();
            EditMusician = new System.Windows.Forms.Button();
            AddMusician = new System.Windows.Forms.Button();
            musiciansDataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)musiciansDataGridView).BeginInit();
            SuspendLayout();
            // 
            // deleteMusician
            // 
            deleteMusician.BackColor = System.Drawing.SystemColors.ActiveCaption;
            deleteMusician.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            deleteMusician.Location = new System.Drawing.Point(322, 355);
            deleteMusician.Name = "deleteMusician";
            deleteMusician.Size = new System.Drawing.Size(149, 38);
            deleteMusician.TabIndex = 0;
            deleteMusician.Text = "Удалить";
            deleteMusician.UseVisualStyleBackColor = false;
            deleteMusician.Click += deleteMusicianButton_Click;
            // 
            // EditMusician
            // 
            EditMusician.BackColor = System.Drawing.SystemColors.ActiveCaption;
            EditMusician.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            EditMusician.Location = new System.Drawing.Point(167, 355);
            EditMusician.Name = "EditMusician";
            EditMusician.Size = new System.Drawing.Size(149, 38);
            EditMusician.TabIndex = 1;
            EditMusician.Text = "Редактировать";
            EditMusician.UseVisualStyleBackColor = false;
            EditMusician.Click += EditMusician_Click;
            // 
            // AddMusician
            // 
            AddMusician.BackColor = System.Drawing.SystemColors.ActiveCaption;
            AddMusician.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            AddMusician.Location = new System.Drawing.Point(12, 355);
            AddMusician.Name = "AddMusician";
            AddMusician.Size = new System.Drawing.Size(149, 38);
            AddMusician.TabIndex = 2;
            AddMusician.Text = "добавить";
            AddMusician.UseVisualStyleBackColor = false;
            AddMusician.Click += AddMusician_Click;
            // 
            // musiciansDataGridView
            // 
            musiciansDataGridView.AllowUserToOrderColumns = true;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(192, 255, 255);
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            musiciansDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            musiciansDataGridView.BackgroundColor = System.Drawing.Color.LightBlue;
            musiciansDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            musiciansDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            musiciansDataGridView.GridColor = System.Drawing.SystemColors.InfoText;
            musiciansDataGridView.Location = new System.Drawing.Point(12, 12);
            musiciansDataGridView.Name = "musiciansDataGridView";
            musiciansDataGridView.ReadOnly = true;
            musiciansDataGridView.RowHeadersWidth = 51;
            musiciansDataGridView.Size = new System.Drawing.Size(776, 301);
            musiciansDataGridView.TabIndex = 3;
            // 
            // MusiciansForm
            // 
            AccessibleRole = System.Windows.Forms.AccessibleRole.MenuPopup;
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(800, 450);
            Controls.Add(musiciansDataGridView);
            Controls.Add(AddMusician);
            Controls.Add(EditMusician);
            Controls.Add(deleteMusician);
            Name = "MusiciansForm";
            Text = "Музыканты";
            Load += MusiciansForm_Load;
            ((System.ComponentModel.ISupportInitialize)musiciansDataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button deleteMusician;
        private System.Windows.Forms.Button EditMusician;
        private System.Windows.Forms.Button AddMusician;
        private System.Windows.Forms.DataGridView musiciansDataGridView;
    }
}