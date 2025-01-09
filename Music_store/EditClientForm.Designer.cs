namespace Music_store
{
    partial class EditClientForm
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
            surnameTextBox = new System.Windows.Forms.TextBox();
            nameTextBox = new System.Windows.Forms.TextBox();
            emailTextBox = new System.Windows.Forms.TextBox();
            phoneTextBox = new System.Windows.Forms.TextBox();
            birthdayPicker = new System.Windows.Forms.DateTimePicker();
            idTextBox = new System.Windows.Forms.TextBox();
            Save = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // surnameTextBox
            // 
            surnameTextBox.Location = new System.Drawing.Point(143, 31);
            surnameTextBox.Name = "surnameTextBox";
            surnameTextBox.Size = new System.Drawing.Size(125, 27);
            surnameTextBox.TabIndex = 1;
            // 
            // nameTextBox
            // 
            nameTextBox.Location = new System.Drawing.Point(274, 31);
            nameTextBox.Name = "nameTextBox";
            nameTextBox.Size = new System.Drawing.Size(125, 27);
            nameTextBox.TabIndex = 2;
            // 
            // emailTextBox
            // 
            emailTextBox.Location = new System.Drawing.Point(405, 31);
            emailTextBox.Name = "emailTextBox";
            emailTextBox.Size = new System.Drawing.Size(125, 27);
            emailTextBox.TabIndex = 3;
            // 
            // phoneTextBox
            // 
            phoneTextBox.Location = new System.Drawing.Point(536, 31);
            phoneTextBox.Name = "phoneTextBox";
            phoneTextBox.Size = new System.Drawing.Size(125, 27);
            phoneTextBox.TabIndex = 4;
            // 
            // birthdayPicker
            // 
            birthdayPicker.Location = new System.Drawing.Point(536, 64);
            birthdayPicker.Name = "birthdayPicker";
            birthdayPicker.Size = new System.Drawing.Size(250, 27);
            birthdayPicker.TabIndex = 5;
            // 
            // idTextBox
            // 
            idTextBox.Location = new System.Drawing.Point(3, 31);
            idTextBox.Name = "idTextBox";
            idTextBox.Size = new System.Drawing.Size(125, 27);
            idTextBox.TabIndex = 6;
            // 
            // Save
            // 
            Save.Location = new System.Drawing.Point(464, 394);
            Save.Name = "Save";
            Save.Size = new System.Drawing.Size(94, 29);
            Save.TabIndex = 7;
            Save.Text = "button1";
            Save.UseVisualStyleBackColor = true;
            Save.Click += Save_Click;
            // 
            // EditClientForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(800, 450);
            Controls.Add(Save);
            Controls.Add(idTextBox);
            Controls.Add(birthdayPicker);
            Controls.Add(phoneTextBox);
            Controls.Add(emailTextBox);
            Controls.Add(nameTextBox);
            Controls.Add(surnameTextBox);
            Name = "EditClientForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.TextBox surnameTextBox;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.TextBox emailTextBox;
        private System.Windows.Forms.TextBox phoneTextBox;
        private System.Windows.Forms.DateTimePicker birthdayPicker;
        private System.Windows.Forms.TextBox idTextBox;
        private System.Windows.Forms.Button Save;
    }
}