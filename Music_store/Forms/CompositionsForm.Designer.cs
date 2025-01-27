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
            EditComposition = new System.Windows.Forms.Button();
            AddComposition = new System.Windows.Forms.Button();
            deleteCompositions = new System.Windows.Forms.Button();
            compositionsDataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)compositionsDataGridView).BeginInit();
            SuspendLayout();
            // 
            // EditComposition
            // 
            EditComposition.BackColor = System.Drawing.SystemColors.ActiveCaption;
            EditComposition.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            EditComposition.Location = new System.Drawing.Point(167, 350);
            EditComposition.Name = "EditComposition";
            EditComposition.Size = new System.Drawing.Size(149, 38);
            EditComposition.TabIndex = 0;
            EditComposition.Text = "Редактировать";
            EditComposition.UseVisualStyleBackColor = false;
            EditComposition.Click += EditComposition_Click;
            // 
            // AddComposition
            // 
            AddComposition.BackColor = System.Drawing.SystemColors.ActiveCaption;
            AddComposition.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            AddComposition.Location = new System.Drawing.Point(12, 350);
            AddComposition.Name = "AddComposition";
            AddComposition.Size = new System.Drawing.Size(149, 38);
            AddComposition.TabIndex = 1;
            AddComposition.Text = "Добавить";
            AddComposition.UseVisualStyleBackColor = false;
            AddComposition.Click += AddComposition_Click;
            // 
            // deleteCompositions
            // 
            deleteCompositions.BackColor = System.Drawing.SystemColors.ActiveCaption;
            deleteCompositions.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            deleteCompositions.Location = new System.Drawing.Point(322, 350);
            deleteCompositions.Name = "deleteCompositions";
            deleteCompositions.Size = new System.Drawing.Size(149, 38);
            deleteCompositions.TabIndex = 2;
            deleteCompositions.Text = "Удалить";
            deleteCompositions.UseVisualStyleBackColor = false;
            deleteCompositions.Click += deleteCompositions_Click;
            // 
            // compositionsDataGridView
            // 
            compositionsDataGridView.BackgroundColor = System.Drawing.Color.LightBlue;
            compositionsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            compositionsDataGridView.Location = new System.Drawing.Point(12, 12);
            compositionsDataGridView.Name = "compositionsDataGridView";
            compositionsDataGridView.ReadOnly = true;
            compositionsDataGridView.RowHeadersWidth = 51;
            compositionsDataGridView.Size = new System.Drawing.Size(786, 312);
            compositionsDataGridView.TabIndex = 3;
            // 
            // CompositionsForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(800, 450);
            Controls.Add(compositionsDataGridView);
            Controls.Add(deleteCompositions);
            Controls.Add(AddComposition);
            Controls.Add(EditComposition);
            Name = "CompositionsForm";
            Text = "Композиции";
            Load += CompositionsForm_Load;
            ((System.ComponentModel.ISupportInitialize)compositionsDataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button EditComposition;
        private System.Windows.Forms.Button AddComposition;
        private System.Windows.Forms.Button deleteCompositions;
        private System.Windows.Forms.DataGridView compositionsDataGridView;
    }
}