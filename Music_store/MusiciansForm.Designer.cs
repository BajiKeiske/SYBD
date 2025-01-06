namespace Kursach
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
            deleteMusician = new System.Windows.Forms.Button();
            editMusician = new System.Windows.Forms.Button();
            addMusician = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // deleteMusician
            // 
            deleteMusician.Location = new System.Drawing.Point(417, 159);
            deleteMusician.Name = "deleteMusician";
            deleteMusician.Size = new System.Drawing.Size(94, 29);
            deleteMusician.TabIndex = 0;
            deleteMusician.Text = "Удалить музыканта";
            deleteMusician.UseVisualStyleBackColor = true;
            // 
            // editMusician
            // 
            editMusician.Location = new System.Drawing.Point(530, 150);
            editMusician.Name = "editMusician";
            editMusician.Size = new System.Drawing.Size(149, 38);
            editMusician.TabIndex = 1;
            editMusician.Text = "Редактировать";
            editMusician.UseVisualStyleBackColor = true;
            // 
            // addMusician
            // 
            addMusician.Location = new System.Drawing.Point(504, 321);
            addMusician.Name = "addMusician";
            addMusician.Size = new System.Drawing.Size(94, 29);
            addMusician.TabIndex = 2;
            addMusician.Text = "добавить";
            addMusician.UseVisualStyleBackColor = true;
            // 
            // MusiciansForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(800, 450);
            Controls.Add(addMusician);
            Controls.Add(editMusician);
            Controls.Add(deleteMusician);
            Name = "MusiciansForm";
            Text = "MusiciansForm";
            Load += MusiciansForm_Load;
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button deleteMusician;
        private System.Windows.Forms.Button editMusician;
        private System.Windows.Forms.Button addMusician;
    }
}