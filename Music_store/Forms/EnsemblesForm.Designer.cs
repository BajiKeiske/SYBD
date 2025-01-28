namespace Music_store
{
    partial class EnsemblesForm
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
            ensemblesDataGridView = new System.Windows.Forms.DataGridView();
            DeleteEnsemble = new System.Windows.Forms.Button();
            AddEnsemble = new System.Windows.Forms.Button();
            EditEnsemble = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)ensemblesDataGridView).BeginInit();
            SuspendLayout();
            // 
            // ensemblesDataGridView
            // 
            ensemblesDataGridView.BackgroundColor = System.Drawing.Color.LightBlue;
            ensemblesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ensemblesDataGridView.GridColor = System.Drawing.SystemColors.Desktop;
            ensemblesDataGridView.Location = new System.Drawing.Point(3, 3);
            ensemblesDataGridView.Name = "ensemblesDataGridView";
            ensemblesDataGridView.ReadOnly = true;
            ensemblesDataGridView.RowHeadersWidth = 51;
            ensemblesDataGridView.Size = new System.Drawing.Size(807, 362);
            ensemblesDataGridView.TabIndex = 0;
            // 
            // DeleteEnsemble
            // 
            DeleteEnsemble.BackColor = System.Drawing.Color.Azure;
            DeleteEnsemble.FlatAppearance.BorderColor = System.Drawing.Color.SkyBlue;
            DeleteEnsemble.FlatAppearance.CheckedBackColor = System.Drawing.Color.SkyBlue;
            DeleteEnsemble.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SkyBlue;
            DeleteEnsemble.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue;
            DeleteEnsemble.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            DeleteEnsemble.Location = new System.Drawing.Point(322, 400);
            DeleteEnsemble.Name = "DeleteEnsemble";
            DeleteEnsemble.Size = new System.Drawing.Size(149, 38);
            DeleteEnsemble.TabIndex = 1;
            DeleteEnsemble.Text = "Удалить";
            DeleteEnsemble.UseVisualStyleBackColor = false;
            DeleteEnsemble.Click += DeleteEnsemble_Click;
            // 
            // AddEnsemble
            // 
            AddEnsemble.BackColor = System.Drawing.Color.Azure;
            AddEnsemble.FlatAppearance.BorderColor = System.Drawing.Color.SkyBlue;
            AddEnsemble.FlatAppearance.CheckedBackColor = System.Drawing.Color.SkyBlue;
            AddEnsemble.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SkyBlue;
            AddEnsemble.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue;
            AddEnsemble.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            AddEnsemble.Location = new System.Drawing.Point(12, 400);
            AddEnsemble.Name = "AddEnsemble";
            AddEnsemble.Size = new System.Drawing.Size(149, 38);
            AddEnsemble.TabIndex = 2;
            AddEnsemble.Text = "Добавить";
            AddEnsemble.UseVisualStyleBackColor = false;
            AddEnsemble.Click += AddEnsemble_Click;
            // 
            // EditEnsemble
            // 
            EditEnsemble.BackColor = System.Drawing.Color.Azure;
            EditEnsemble.FlatAppearance.BorderColor = System.Drawing.Color.SkyBlue;
            EditEnsemble.FlatAppearance.CheckedBackColor = System.Drawing.Color.SkyBlue;
            EditEnsemble.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SkyBlue;
            EditEnsemble.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue;
            EditEnsemble.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            EditEnsemble.Location = new System.Drawing.Point(167, 400);
            EditEnsemble.Name = "EditEnsemble";
            EditEnsemble.Size = new System.Drawing.Size(149, 38);
            EditEnsemble.TabIndex = 3;
            EditEnsemble.Text = "Редактировать";
            EditEnsemble.UseVisualStyleBackColor = false;
            EditEnsemble.Click += EditEnsemble_Click;
            // 
            // EnsemblesForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(859, 527);
            Controls.Add(EditEnsemble);
            Controls.Add(AddEnsemble);
            Controls.Add(DeleteEnsemble);
            Controls.Add(ensemblesDataGridView);
            Name = "EnsemblesForm";
            Text = "Ансамбли";
            Load += EnsemblesForm_Load;
            ((System.ComponentModel.ISupportInitialize)ensemblesDataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.DataGridView ensemblesDataGridView;
        private System.Windows.Forms.Button DeleteEnsemble;
        private System.Windows.Forms.Button AddEnsemble;
        private System.Windows.Forms.Button EditEnsemble;
    }
}