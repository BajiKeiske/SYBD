namespace Music_store
{
    partial class EditMusicianForm
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
            nameTextBox = new System.Windows.Forms.TextBox();
            surnameTextBox = new System.Windows.Forms.TextBox();
            instrumentTextBox = new System.Windows.Forms.TextBox();
            save = new System.Windows.Forms.Button();
            dateOfBirthPicker = new System.Windows.Forms.DateTimePicker();
            SuspendLayout();
            // 
            // nameTextBox
            // 
            nameTextBox.Location = new System.Drawing.Point(12, 26);
            nameTextBox.Name = "nameTextBox";
            nameTextBox.Size = new System.Drawing.Size(125, 27);
            nameTextBox.TabIndex = 0;
            // 
            // surnameTextBox
            // 
            surnameTextBox.Location = new System.Drawing.Point(143, 26);
            surnameTextBox.Name = "surnameTextBox";
            surnameTextBox.Size = new System.Drawing.Size(125, 27);
            surnameTextBox.TabIndex = 1;
            // 
            // instrumentTextBox
            // 
            instrumentTextBox.Location = new System.Drawing.Point(274, 26);
            instrumentTextBox.Name = "instrumentTextBox";
            instrumentTextBox.Size = new System.Drawing.Size(125, 27);
            instrumentTextBox.TabIndex = 2;
            // 
            // save
            // 
            save.Location = new System.Drawing.Point(580, 382);
            save.Name = "save";
            save.Size = new System.Drawing.Size(94, 29);
            save.TabIndex = 4;
            save.Text = "Сохранить";
            save.UseVisualStyleBackColor = true;
            save.Click += save_Click;
            // 
            // dateOfBirthPicker
            // 
            dateOfBirthPicker.Location = new System.Drawing.Point(405, 26);
            dateOfBirthPicker.Name = "dateOfBirthPicker";
            dateOfBirthPicker.Size = new System.Drawing.Size(250, 27);
            dateOfBirthPicker.TabIndex = 5;
            // 
            // EditMusicianForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(800, 450);
            Controls.Add(dateOfBirthPicker);
            Controls.Add(save);
            Controls.Add(instrumentTextBox);
            Controls.Add(surnameTextBox);
            Controls.Add(nameTextBox);
            Name = "EditMusicianForm";
            Text = "Редактирование музыканта";
            Load += EditMusicianForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.TextBox surnameTextBox;
        private System.Windows.Forms.TextBox instrumentTextBox;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.DateTimePicker dateOfBirthPicker;
    }
}