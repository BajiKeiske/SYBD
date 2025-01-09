namespace Music_store
{
    partial class AddClientForm
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
            save = new System.Windows.Forms.Button();
            birthdayPicker = new System.Windows.Forms.DateTimePicker();
            idTextBox = new System.Windows.Forms.TextBox();
            nameTextBox = new System.Windows.Forms.TextBox();
            surnameTextBox = new System.Windows.Forms.TextBox();
            emailTextBox = new System.Windows.Forms.TextBox();
            phoneTextBox = new System.Windows.Forms.TextBox();
            SuspendLayout();
            // 
            // save
            // 
            save.Location = new System.Drawing.Point(552, 380);
            save.Name = "save";
            save.Size = new System.Drawing.Size(94, 29);
            save.TabIndex = 0;
            save.Text = "Сохранить";
            save.UseVisualStyleBackColor = true;
            save.Click += Save_Click;
            // 
            // birthdayPicker
            // 
            birthdayPicker.Location = new System.Drawing.Point(528, 86);
            birthdayPicker.Name = "birthdayPicker";
            birthdayPicker.Size = new System.Drawing.Size(250, 27);
            birthdayPicker.TabIndex = 1;
            // 
            // idTextBox
            // 
            idTextBox.Location = new System.Drawing.Point(25, 25);
            idTextBox.Name = "idTextBox";
            idTextBox.Size = new System.Drawing.Size(125, 27);
            idTextBox.TabIndex = 2;
            // 
            // nameTextBox
            // 
            nameTextBox.Location = new System.Drawing.Point(156, 25);
            nameTextBox.Name = "nameTextBox";
            nameTextBox.Size = new System.Drawing.Size(125, 27);
            nameTextBox.TabIndex = 3;
            // 
            // surnameTextBox
            // 
            surnameTextBox.Location = new System.Drawing.Point(287, 25);
            surnameTextBox.Name = "surnameTextBox";
            surnameTextBox.Size = new System.Drawing.Size(125, 27);
            surnameTextBox.TabIndex = 4;
            // 
            // emailTextBox
            // 
            emailTextBox.Location = new System.Drawing.Point(418, 25);
            emailTextBox.Name = "emailTextBox";
            emailTextBox.Size = new System.Drawing.Size(125, 27);
            emailTextBox.TabIndex = 5;
            // 
            // phoneTextBox
            // 
            phoneTextBox.Location = new System.Drawing.Point(552, 25);
            phoneTextBox.Name = "phoneTextBox";
            phoneTextBox.Size = new System.Drawing.Size(125, 27);
            phoneTextBox.TabIndex = 6;
            // 
            // AddClientForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new System.Drawing.Size(800, 450);
            Controls.Add(phoneTextBox);
            Controls.Add(emailTextBox);
            Controls.Add(surnameTextBox);
            Controls.Add(nameTextBox);
            Controls.Add(idTextBox);
            Controls.Add(birthdayPicker);
            Controls.Add(save);
            Name = "AddClientForm";
            Text = "Добавление клиента";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button save;
        private System.Windows.Forms.DateTimePicker birthdayPicker;
        private System.Windows.Forms.TextBox idTextBox;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.TextBox surnameTextBox;
        private System.Windows.Forms.TextBox emailTextBox;
        private System.Windows.Forms.TextBox phoneTextBox;
    }
}