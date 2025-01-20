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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            deleteMusician = new System.Windows.Forms.Button();
            EditMusician = new System.Windows.Forms.Button();
            AddMusician = new System.Windows.Forms.Button();
            musiciansDataGridView = new System.Windows.Forms.DataGridView();
            EnsemblesButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)musiciansDataGridView).BeginInit();
            SuspendLayout();
            // 
            // deleteMusician
            // 
            deleteMusician.Location = new System.Drawing.Point(278, 355);
            deleteMusician.Name = "deleteMusician";
            deleteMusician.Size = new System.Drawing.Size(94, 29);
            deleteMusician.TabIndex = 0;
            deleteMusician.Text = "Удалить музыканта";
            deleteMusician.UseVisualStyleBackColor = true;
            deleteMusician.Click += deleteMusicianButton_Click;
            // 
            // EditMusician
            // 
            EditMusician.Location = new System.Drawing.Point(23, 346);
            EditMusician.Name = "EditMusician";
            EditMusician.Size = new System.Drawing.Size(149, 38);
            EditMusician.TabIndex = 1;
            EditMusician.Text = "Редактировать";
            EditMusician.UseVisualStyleBackColor = true;
            EditMusician.Click += EditMusician_Click;
            // 
            // AddMusician
            // 
            AddMusician.Location = new System.Drawing.Point(178, 355);
            AddMusician.Name = "AddMusician";
            AddMusician.Size = new System.Drawing.Size(94, 29);
            AddMusician.TabIndex = 2;
            AddMusician.Text = "добавить";
            AddMusician.UseVisualStyleBackColor = true;
            AddMusician.Click += AddMusician_Click;
            // 
            // musiciansDataGridView
            // 
            musiciansDataGridView.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(192, 255, 255);
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            musiciansDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
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
            // EnsemblesButton
            // 
            EnsemblesButton.Location = new System.Drawing.Point(417, 355);
            EnsemblesButton.Name = "EnsemblesButton";
            EnsemblesButton.Size = new System.Drawing.Size(94, 29);
            EnsemblesButton.TabIndex = 4;
            EnsemblesButton.Text = "Ансамбли";
            EnsemblesButton.UseVisualStyleBackColor = true;
            // 
            // MusiciansForm
            // 
            AccessibleRole = System.Windows.Forms.AccessibleRole.MenuPopup;
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(800, 450);
            Controls.Add(EnsemblesButton);
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
        private System.Windows.Forms.Button EnsemblesButton;
    }
}