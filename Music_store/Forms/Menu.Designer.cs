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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu));
            musicians = new System.Windows.Forms.Button();
            compositions = new System.Windows.Forms.Button();
            ensembles = new System.Windows.Forms.Button();
            vinylRecords = new System.Windows.Forms.Button();
            clientele = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // musicians
            // 
            musicians.AccessibleRole = System.Windows.Forms.AccessibleRole.ButtonMenu;
            musicians.BackColor = System.Drawing.SystemColors.ButtonFace;
            musicians.BackgroundImage = (System.Drawing.Image)resources.GetObject("musicians.BackgroundImage");
            musicians.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            musicians.Image = (System.Drawing.Image)resources.GetObject("musicians.Image");
            musicians.Location = new System.Drawing.Point(112, 125);
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
            compositions.BackColor = System.Drawing.SystemColors.ButtonFace;
            compositions.BackgroundImage = (System.Drawing.Image)resources.GetObject("compositions.BackgroundImage");
            compositions.Cursor = System.Windows.Forms.Cursors.Hand;
            compositions.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            compositions.Location = new System.Drawing.Point(112, 298);
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
            ensembles.BackColor = System.Drawing.SystemColors.ButtonFace;
            ensembles.BackgroundImage = (System.Drawing.Image)resources.GetObject("ensembles.BackgroundImage");
            ensembles.Cursor = System.Windows.Forms.Cursors.Hand;
            ensembles.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            ensembles.Location = new System.Drawing.Point(277, 156);
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
            vinylRecords.BackColor = System.Drawing.SystemColors.ButtonFace;
            vinylRecords.BackgroundImage = (System.Drawing.Image)resources.GetObject("vinylRecords.BackgroundImage");
            vinylRecords.Cursor = System.Windows.Forms.Cursors.Hand;
            vinylRecords.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            vinylRecords.Location = new System.Drawing.Point(112, 218);
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
            clientele.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            clientele.BackgroundImage = (System.Drawing.Image)resources.GetObject("clientele.BackgroundImage");
            clientele.Cursor = System.Windows.Forms.Cursors.Hand;
            clientele.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            clientele.Location = new System.Drawing.Point(277, 249);
            clientele.Margin = new System.Windows.Forms.Padding(0);
            clientele.Name = "clientele";
            clientele.Size = new System.Drawing.Size(159, 72);
            clientele.TabIndex = 4;
            clientele.Text = "Клиенты";
            clientele.UseCompatibleTextRendering = true;
            clientele.UseVisualStyleBackColor = false;
            clientele.Click += clientele_Click;
            // 
            // Menu
            // 
            AccessibleRole = System.Windows.Forms.AccessibleRole.PageTabList;
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(996, 682);
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
        }

        #endregion

        private System.Windows.Forms.Button musicians;
        private System.Windows.Forms.Button compositions;
        private System.Windows.Forms.Button ensembles;
        private System.Windows.Forms.Button vinylRecords;
        private System.Windows.Forms.Button clientele;
    }
}

