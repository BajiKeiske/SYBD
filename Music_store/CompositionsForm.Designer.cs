namespace Music_store
{
    partial class CompositionsForm
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
            editCompositions = new System.Windows.Forms.Button();
            addCompositions = new System.Windows.Forms.Button();
            deleteCompositions = new System.Windows.Forms.Button();
            compositionsDataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)compositionsDataGridView).BeginInit();
            SuspendLayout();
            // 
            // editCompositions
            // 
            editCompositions.Location = new System.Drawing.Point(27, 392);
            editCompositions.Name = "editCompositions";
            editCompositions.Size = new System.Drawing.Size(94, 29);
            editCompositions.TabIndex = 0;
            editCompositions.Text = "Редактировать";
            editCompositions.UseVisualStyleBackColor = true;
            editCompositions.Click += editCompositions_Click;
            // 
            // addCompositions
            // 
            addCompositions.Location = new System.Drawing.Point(148, 392);
            addCompositions.Name = "addCompositions";
            addCompositions.Size = new System.Drawing.Size(94, 29);
            addCompositions.TabIndex = 1;
            addCompositions.Text = "Добавить";
            addCompositions.UseVisualStyleBackColor = true;
            addCompositions.Click += addCompositions_Click;
            // 
            // deleteCompositions
            // 
            deleteCompositions.Location = new System.Drawing.Point(268, 392);
            deleteCompositions.Name = "deleteCompositions";
            deleteCompositions.Size = new System.Drawing.Size(94, 29);
            deleteCompositions.TabIndex = 2;
            deleteCompositions.Text = "Удалить";
            deleteCompositions.UseVisualStyleBackColor = true;
            deleteCompositions.Click += deleteCompositions_Click;
            // 
            // compositionsDataGridView
            // 
            compositionsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            compositionsDataGridView.Location = new System.Drawing.Point(12, 12);
            compositionsDataGridView.Name = "compositionsDataGridView";
            compositionsDataGridView.RowHeadersWidth = 51;
            compositionsDataGridView.Size = new System.Drawing.Size(776, 305);
            compositionsDataGridView.TabIndex = 3;
            // 
            // CompositionsForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(800, 450);
            Controls.Add(compositionsDataGridView);
            Controls.Add(deleteCompositions);
            Controls.Add(addCompositions);
            Controls.Add(editCompositions);
            Name = "CompositionsForm";
            Text = "Композиции";
            Load += CompositionsForm_Load;
            ((System.ComponentModel.ISupportInitialize)compositionsDataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button editCompositions;
        private System.Windows.Forms.Button addCompositions;
        private System.Windows.Forms.Button deleteCompositions;
        private System.Windows.Forms.DataGridView compositionsDataGridView;
    }
}