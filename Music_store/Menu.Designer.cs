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
            records = new System.Windows.Forms.Button();
            clientele = new System.Windows.Forms.Button();
            pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // musicians
            // 
            musicians.AccessibleRole = System.Windows.Forms.AccessibleRole.ButtonMenu;
            musicians.BackColor = System.Drawing.SystemColors.ButtonFace;
            musicians.BackgroundImage = (System.Drawing.Image)resources.GetObject("musicians.BackgroundImage");
            musicians.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            musicians.Image = (System.Drawing.Image)resources.GetObject("musicians.Image");
            musicians.Location = new System.Drawing.Point(2, 72);
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
            compositions.Location = new System.Drawing.Point(2, 232);
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
            ensembles.Location = new System.Drawing.Point(2, 312);
            ensembles.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            ensembles.Name = "ensembles";
            ensembles.Size = new System.Drawing.Size(159, 72);
            ensembles.TabIndex = 2;
            ensembles.Text = "Ансамбли";
            ensembles.UseCompatibleTextRendering = true;
            ensembles.UseVisualStyleBackColor = false;
            ensembles.Click += ensembles_Click;
            // 
            // records
            // 
            records.AccessibleRole = System.Windows.Forms.AccessibleRole.ButtonMenu;
            records.BackColor = System.Drawing.SystemColors.ButtonFace;
            records.BackgroundImage = (System.Drawing.Image)resources.GetObject("records.BackgroundImage");
            records.Cursor = System.Windows.Forms.Cursors.Hand;
            records.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            records.Location = new System.Drawing.Point(2, 152);
            records.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            records.Name = "records";
            records.Size = new System.Drawing.Size(159, 72);
            records.TabIndex = 3;
            records.Text = "Пластинки";
            records.UseCompatibleTextRendering = true;
            records.UseVisualStyleBackColor = false;
            records.Click += records_Click;
            // 
            // clientele
            // 
            clientele.AccessibleRole = System.Windows.Forms.AccessibleRole.ButtonMenu;
            clientele.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            clientele.BackgroundImage = (System.Drawing.Image)resources.GetObject("clientele.BackgroundImage");
            clientele.Cursor = System.Windows.Forms.Cursors.Hand;
            clientele.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            clientele.Location = new System.Drawing.Point(2, 388);
            clientele.Margin = new System.Windows.Forms.Padding(0);
            clientele.Name = "clientele";
            clientele.Size = new System.Drawing.Size(159, 72);
            clientele.TabIndex = 4;
            clientele.Text = "Клиенты";
            clientele.UseCompatibleTextRendering = true;
            clientele.UseVisualStyleBackColor = false;
            clientele.Click += clientele_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = System.Drawing.SystemColors.WindowText;
            pictureBox1.InitialImage = (System.Drawing.Image)resources.GetObject("pictureBox1.InitialImage");
            pictureBox1.Location = new System.Drawing.Point(-8, -1);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new System.Drawing.Size(992, 66);
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // Menu
            // 
            AccessibleRole = System.Windows.Forms.AccessibleRole.PageTabList;
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(996, 682);
            Controls.Add(pictureBox1);
            Controls.Add(clientele);
            Controls.Add(records);
            Controls.Add(ensembles);
            Controls.Add(compositions);
            Controls.Add(musicians);
            Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            Name = "Menu";
            Text = "Меню";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button musicians;
        private System.Windows.Forms.Button compositions;
        private System.Windows.Forms.Button ensembles;
        private System.Windows.Forms.Button records;
        private System.Windows.Forms.Button clientele;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

