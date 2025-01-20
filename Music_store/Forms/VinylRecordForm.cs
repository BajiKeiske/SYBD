using Music_store.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace Music_store
{
    public partial class VinylRecordForm : Form
    {
        private FlowLayoutPanel flowLayoutPanel;
        private Button btnAdd, btnEdit, btnDelete, btnSave;
        private DataGridView dgvVinyls;
        private Dictionary<string, Control> controls;

        public VinylRecordForm()
        {
            InitializeComponents();
            LoadVinyls();
        }

        private void InitializeComponents()
        {
            this.Text = "Управление пластинками";
            this.Size = new Size(800, 600);

            // Основная панель
            flowLayoutPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Top,
                AutoSize = true,
                Padding = new Padding(10),
                FlowDirection = FlowDirection.LeftToRight,
                WrapContents = true
            };
            this.Controls.Add(flowLayoutPanel);

            // Таблица для отображения данных
            dgvVinyls = new DataGridView
            {
                Dock = DockStyle.Fill,
                AutoGenerateColumns = false,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect
            };
            this.Controls.Add(dgvVinyls);

            // Кнопки управления
            var buttonPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Bottom,
                AutoSize = true,
                Padding = new Padding(10),
                FlowDirection = FlowDirection.LeftToRight
            };
            this.Controls.Add(buttonPanel);

            btnAdd = new Button { Text = "Добавить", AutoSize = true };
            btnAdd.Click += BtnAdd_Click;
            buttonPanel.Controls.Add(btnAdd);

            btnEdit = new Button { Text = "Редактировать", AutoSize = true };
            btnEdit.Click += BtnEdit_Click;
            buttonPanel.Controls.Add(btnEdit);

            btnDelete = new Button { Text = "Удалить", AutoSize = true };
            btnDelete.Click += BtnDelete_Click;
            buttonPanel.Controls.Add(btnDelete);

            btnSave = new Button { Text = "Сохранить", AutoSize = true };
            btnSave.Click += BtnSave_Click;
            buttonPanel.Controls.Add(btnSave);
        }

        private void LoadVinyls()
        {
            // Загружаем данные из базы
            var vinyls = Database.GetVinyls();
            dgvVinyls.DataSource = vinyls;

            // Генерация столбцов таблицы
            dgvVinyls.Columns.Clear();
            dgvVinyls.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "ID", Visible = false });
            dgvVinyls.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "StickerNumber", HeaderText = "Номер наклейки" });
            dgvVinyls.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Title", HeaderText = "Название" });
            dgvVinyls.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ReleaseDate", HeaderText = "Дата выпуска" });
            dgvVinyls.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "WholesalePrice", HeaderText = "Оптовая цена" });
            dgvVinyls.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "RetailPrice", HeaderText = "Розничная цена" });
            dgvVinyls.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "SoldLastYear", HeaderText = "Продано в прошлом году" });
            dgvVinyls.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "SoldThisYear", HeaderText = "Продано в этом году" });
            dgvVinyls.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Stock", HeaderText = "Остаток" });
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            ShowEditForm(null);
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (dgvVinyls.SelectedRows.Count > 0)
            {
                var selectedVinyl = dgvVinyls.SelectedRows[0].DataBoundItem as Vinyl;
                ShowEditForm(selectedVinyl);
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (dgvVinyls.SelectedRows.Count > 0)
            {
                var selectedVinyl = dgvVinyls.SelectedRows[0].DataBoundItem as Vinyl;
                Database.DeleteVinyl(selectedVinyl.Id);
                LoadVinyls();
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            Database.SaveVinyls((List<Vinyl>)dgvVinyls.DataSource);
            MessageBox.Show("Изменения сохранены.");
        }

        private void ShowEditForm(Vinyl vinyl)
        {
            var form = new Form
            {
                Text = vinyl == null ? "Добавить пластинку" : "Редактировать пластинку",
                Size = new Size(400, 400)
            };

            var panel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(10),
                AutoScroll = true
            };
            form.Controls.Add(panel);

            controls = new Dictionary<string, Control>();
            var properties = typeof(Vinyl).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (var property in properties)
            {
                if (property.Name == "Id") continue;

                Control control = null;
                var label = new Label { Text = property.Name, AutoSize = true };

                if (property.PropertyType == typeof(string))
                {
                    control = new TextBox { Width = 200 };
                }
                else if (property.PropertyType == typeof(decimal))
                {
                    control = new NumericUpDown { Width = 200, DecimalPlaces = 2, Minimum = 0, Maximum = 1000000 };
                }
                else if (property.PropertyType == typeof(DateTime))
                {
                    control = new DateTimePicker { Width = 200 };
                }
                else if (property.PropertyType == typeof(int))
                {
                    control = new NumericUpDown { Width = 200, Minimum = 0, Maximum = 1000000 };
                }

                if (control != null)
                {
                    panel.Controls.Add(label);
                    panel.Controls.Add(control);
                    controls[property.Name] = control;

                    if (vinyl != null)
                    {
                        var value = property.GetValue(vinyl);
                        if (control is TextBox textBox) textBox.Text = value?.ToString();
                        else if (control is NumericUpDown numericUpDown) numericUpDown.Value = Convert.ToDecimal(value);
                        else if (control is DateTimePicker dateTimePicker) dateTimePicker.Value = (DateTime)value;
                    }
                }
            }

            var btnSave = new Button { Text = "Сохранить", AutoSize = true };
            btnSave.Click += (s, e) =>
            {
                if (vinyl == null) vinyl = new Vinyl();

                foreach (var property in properties)
                {
                    if (controls.ContainsKey(property.Name))
                    {
                        var control = controls[property.Name];
                        if (control is TextBox textBox) property.SetValue(vinyl, textBox.Text);
                        else if (control is NumericUpDown numericUpDown) property.SetValue(vinyl, Convert.ChangeType(numericUpDown.Value, property.PropertyType));
                        else if (control is DateTimePicker dateTimePicker) property.SetValue(vinyl, dateTimePicker.Value);
                    }
                }

                if (vinyl.Id == 0) Database.AddVinyl(vinyl);
                else Database.UpdateVinyl(vinyl);

                LoadVinyls();
                form.Close();
            };

            panel.Controls.Add(btnSave);
            form.ShowDialog();
        }

        private void InitializeComponent()
        {
            SuspendLayout();
            // 
            // VinylRecordForm
            // 
            ClientSize = new Size(879, 431);
            Name = "VinylRecordForm";
            Load += VinylRecordForm_Load;
            ResumeLayout(false);
        }

        private void VinylRecordForm_Load(object sender, EventArgs e)
        {

        }
    }
}

