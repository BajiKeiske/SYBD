namespace Music_store
{
    partial class Menu
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            musicians = new System.Windows.Forms.Button();
            compositions = new System.Windows.Forms.Button();
            ensembles = new System.Windows.Forms.Button();
            vinylRecords = new System.Windows.Forms.Button();
            clientele = new System.Windows.Forms.Button();
            textBox1 = new System.Windows.Forms.TextBox();
            npgsqlDataAdapter1 = new Npgsql.NpgsqlDataAdapter();
            SuspendLayout();
            // 
            // musicians
            // 
            musicians.AccessibleRole = System.Windows.Forms.AccessibleRole.ButtonMenu;
            musicians.BackColor = System.Drawing.Color.Azure;
            musicians.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            musicians.ForeColor = System.Drawing.Color.Black;
            musicians.Location = new System.Drawing.Point(250, 111);
            musicians.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            musicians.Name = "musicians";
            musicians.Size = new System.Drawing.Size(159, 72);
            musicians.TabIndex = 0;
            musicians.Text = "Музыканты";
            musicians.UseCompatibleTextRendering = true;
            musicians.UseVisualStyleBackColor = false;
            musicians.Click += musicians_Click;
            // 
            // compositions
            // 
            compositions.AccessibleRole = System.Windows.Forms.AccessibleRole.ButtonMenu;
            compositions.BackColor = System.Drawing.Color.Azure;
            compositions.Cursor = System.Windows.Forms.Cursors.Hand;
            compositions.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            compositions.ForeColor = System.Drawing.Color.Black;
            compositions.Location = new System.Drawing.Point(338, 202);
            compositions.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            compositions.Name = "compositions";
            compositions.Size = new System.Drawing.Size(159, 72);
            compositions.TabIndex = 1;
            compositions.Text = "Композиции";
            compositions.UseCompatibleTextRendering = true;
            compositions.UseVisualStyleBackColor = false;
            compositions.Click += compositions_Click;
            // 
            // ensembles
            // 
            ensembles.AccessibleRole = System.Windows.Forms.AccessibleRole.ButtonMenu;
            ensembles.BackColor = System.Drawing.Color.Azure;
            ensembles.Cursor = System.Windows.Forms.Cursors.Hand;
            ensembles.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            ensembles.ForeColor = System.Drawing.Color.Black;
            ensembles.Location = new System.Drawing.Point(432, 111);
            ensembles.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            ensembles.Name = "ensembles";
            ensembles.Size = new System.Drawing.Size(159, 72);
            ensembles.TabIndex = 2;
            ensembles.Text = "Ансамбли";
            ensembles.UseCompatibleTextRendering = true;
            ensembles.UseVisualStyleBackColor = false;
            ensembles.Click += ensembles_Click;
            // 
            // vinylRecords
            // 
            vinylRecords.AccessibleRole = System.Windows.Forms.AccessibleRole.ButtonMenu;
            vinylRecords.BackColor = System.Drawing.Color.Azure;
            vinylRecords.Cursor = System.Windows.Forms.Cursors.Hand;
            vinylRecords.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            vinylRecords.ForeColor = System.Drawing.Color.Black;
            vinylRecords.Location = new System.Drawing.Point(529, 202);
            vinylRecords.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            vinylRecords.Name = "vinylRecords";
            vinylRecords.Size = new System.Drawing.Size(159, 72);
            vinylRecords.TabIndex = 3;
            vinylRecords.Text = "Пластинки";
            vinylRecords.UseCompatibleTextRendering = true;
            vinylRecords.UseVisualStyleBackColor = false;
            vinylRecords.Click += vinylRecords_Click;
            // 
            // clientele
            // 
            clientele.AccessibleRole = System.Windows.Forms.AccessibleRole.ButtonMenu;
            clientele.BackColor = System.Drawing.Color.Azure;
            clientele.Cursor = System.Windows.Forms.Cursors.Hand;
            clientele.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            clientele.ForeColor = System.Drawing.Color.Black;
            clientele.Location = new System.Drawing.Point(606, 111);
            clientele.Margin = new System.Windows.Forms.Padding(0);
            clientele.Name = "clientele";
            clientele.Size = new System.Drawing.Size(159, 72);
            clientele.TabIndex = 4;
            clientele.Text = "Клиенты";
            clientele.UseCompatibleTextRendering = true;
            clientele.UseVisualStyleBackColor = false;
            clientele.Click += clientele_Click;
            // 
            // textBox1
            // 
            textBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
            textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            textBox1.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
            textBox1.Location = new System.Drawing.Point(240, 22);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new System.Drawing.Size(543, 62);
            textBox1.TabIndex = 5;
            textBox1.Text = "Выберите действие";
            textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // npgsqlDataAdapter1
            // 
            npgsqlDataAdapter1.DeleteCommand = null;
            npgsqlDataAdapter1.InsertCommand = null;
            npgsqlDataAdapter1.SelectCommand = null;
            npgsqlDataAdapter1.UpdateCommand = null;
            // 
            // Menu
            // 
            AccessibleRole = System.Windows.Forms.AccessibleRole.PageTabList;
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new System.Drawing.Size(1033, 359);
            Controls.Add(textBox1);
            Controls.Add(clientele);
            Controls.Add(vinylRecords);
            Controls.Add(ensembles);
            Controls.Add(compositions);
            Controls.Add(musicians);
            Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            Name = "Menu";
            Text = "Меню";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button musicians;
        private System.Windows.Forms.Button compositions;
        private System.Windows.Forms.Button ensembles;
        private System.Windows.Forms.Button vinylRecords;
        private System.Windows.Forms.Button clientele;
        private System.Windows.Forms.TextBox textBox1;
        private Npgsql.NpgsqlDataAdapter npgsqlDataAdapter1;
    }
}

