namespace Music_store
{
    partial class AddMusicianForm
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
            dateOfBirthPicker = new System.Windows.Forms.DateTimePicker();
            instrumentTextBox = new System.Windows.Forms.TextBox();
            surnameTextBox = new System.Windows.Forms.TextBox();
            nameTextBox = new System.Windows.Forms.TextBox();
            Save = new System.Windows.Forms.Button();
            idTextBox = new System.Windows.Forms.TextBox();
            SuspendLayout();
            // 
            // dateOfBirthPicker
            // 
            dateOfBirthPicker.Location = new System.Drawing.Point(472, 212);
            dateOfBirthPicker.Name = "dateOfBirthPicker";
            dateOfBirthPicker.Size = new System.Drawing.Size(250, 27);
            dateOfBirthPicker.TabIndex = 9;
            // 
            // instrumentTextBox
            // 
            instrumentTextBox.Location = new System.Drawing.Point(341, 212);
            instrumentTextBox.Name = "instrumentTextBox";
            instrumentTextBox.Size = new System.Drawing.Size(125, 27);
            instrumentTextBox.TabIndex = 8;
            // 
            // surnameTextBox
            // 
            surnameTextBox.Location = new System.Drawing.Point(210, 212);
            surnameTextBox.Name = "surnameTextBox";
            surnameTextBox.Size = new System.Drawing.Size(125, 27);
            surnameTextBox.TabIndex = 7;
            // 
            // nameTextBox
            // 
            nameTextBox.Location = new System.Drawing.Point(79, 212);
            nameTextBox.Name = "nameTextBox";
            nameTextBox.Size = new System.Drawing.Size(125, 27);
            nameTextBox.TabIndex = 6;
            // 
            // Save
            // 
            Save.Location = new System.Drawing.Point(559, 389);
            Save.Name = "Save";
            Save.Size = new System.Drawing.Size(94, 29);
            Save.TabIndex = 10;
            Save.Text = "Сохранить";
            Save.UseVisualStyleBackColor = true;
            Save.Click += Save_Click;
            // 
            // idTextBox
            // 
            idTextBox.Location = new System.Drawing.Point(12, 179);
            idTextBox.Name = "idTextBox";
            idTextBox.Size = new System.Drawing.Size(125, 27);
            idTextBox.TabIndex = 11;
            // 
            // AddMusicianForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(800, 450);
            Controls.Add(idTextBox);
            Controls.Add(Save);
            Controls.Add(dateOfBirthPicker);
            Controls.Add(instrumentTextBox);
            Controls.Add(surnameTextBox);
            Controls.Add(nameTextBox);
            Name = "AddMusicianForm";
            Text = "AddMusicianForm";
            Load += AddMusicianForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateOfBirthPicker;
        private System.Windows.Forms.TextBox instrumentTextBox;
        private System.Windows.Forms.TextBox surnameTextBox;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.TextBox idTextBox;
    }
}