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
            editMusician = new System.Windows.Forms.Button();
            addMusician = new System.Windows.Forms.Button();
            musiciansDataGridView = new System.Windows.Forms.DataGridView();
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
            // editMusician
            // 
            editMusician.Location = new System.Drawing.Point(23, 346);
            editMusician.Name = "editMusician";
            editMusician.Size = new System.Drawing.Size(149, 38);
            editMusician.TabIndex = 1;
            editMusician.Text = "Редактировать";
            editMusician.UseVisualStyleBackColor = true;
            editMusician.Click += editMusician_Click;
            // 
            // addMusician
            // 
            addMusician.Location = new System.Drawing.Point(178, 355);
            addMusician.Name = "addMusician";
            addMusician.Size = new System.Drawing.Size(94, 29);
            addMusician.TabIndex = 2;
            addMusician.Text = "добавить";
            addMusician.UseVisualStyleBackColor = true;
            addMusician.Click += addMusicianButton_Click;
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
            musiciansDataGridView.RowHeadersWidth = 51;
            musiciansDataGridView.Size = new System.Drawing.Size(776, 278);
            musiciansDataGridView.TabIndex = 3;
            musiciansDataGridView.CellContentClick += dataGridView1_CellContentClick;
            // 
            // MusiciansForm
            // 
            AccessibleRole = System.Windows.Forms.AccessibleRole.MenuPopup;
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(800, 450);
            Controls.Add(musiciansDataGridView);
            Controls.Add(addMusician);
            Controls.Add(editMusician);
            Controls.Add(deleteMusician);
            Name = "MusiciansForm";
            Text = "Музыканты";
            Load += MusiciansForm_Load;
            ((System.ComponentModel.ISupportInitialize)musiciansDataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button deleteMusician;
        private System.Windows.Forms.Button editMusician;
        private System.Windows.Forms.Button addMusician;
        private System.Windows.Forms.DataGridView musiciansDataGridView;
    }
}