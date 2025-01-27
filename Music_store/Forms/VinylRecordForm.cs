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
                Padding = new Padding(-10),
                FlowDirection = FlowDirection.LeftToRight,
                WrapContents = true
            };
            this.Controls.Add(flowLayoutPanel);

            // Таблица для отображения данных
            dgvVinyls = new DataGridView
            {
                AutoGenerateColumns = false,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                AllowUserToResizeRows = false,
                ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize,
                ColumnHeadersVisible = true,
                ColumnHeadersHeight = 30,
                Dock = DockStyle.Fill
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
            dgvVinyls.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "LabelNumber", HeaderText = "Номер этикетки" });
            dgvVinyls.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Title", HeaderText = "Название" });
            dgvVinyls.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ReleaseYear", HeaderText = "Год выпуска" });
            dgvVinyls.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "MusicianId", HeaderText = "ID музыканта" });
            dgvVinyls.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "EnsembleId", HeaderText = "ID ансамбля" });
            dgvVinyls.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Genre", HeaderText = "Жанр" });
            dgvVinyls.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "WholesalePrice", HeaderText = "Оптовая цена" });
            dgvVinyls.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "RetailPrice", HeaderText = "Розничная цена" });
            dgvVinyls.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "SoldLastYear", HeaderText = "Продано в прошлом году" });
            dgvVinyls.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "SoldThisYear", HeaderText = "Продано в этом году" });
            dgvVinyls.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Stock", HeaderText = "Остаток" });
        }
        private void ShowEditForm(Vinyl vinyl)
        {
            // Создаём форму с фиксированным размером
            var form = new Form
            {
                Text = vinyl == null ? "Добавить пластинку" : "Редактировать пластинку",
                Size = new Size(400, 620), // Установим фиксированную ширину и высоту
                FormBorderStyle = FormBorderStyle.FixedDialog, // Запрещаем изменение размеров
                MaximizeBox = false, // Убираем кнопку максимизации
                MinimizeBox = false // Убираем кнопку минимизации
            };

            // Панель для размещения элементов
            var panel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(10),
                AutoScroll = true,
                WrapContents = false, // Элементы располагаются вертикально
                FlowDirection = FlowDirection.TopDown
            };
            form.Controls.Add(panel);

            controls = new Dictionary<string, Control>();
            var properties = typeof(Vinyl).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (var property in properties)
            {
                if (property.Name == "Id") continue;

                // Создаём подпись
                var label = new Label
                {
                    Text = property.Name,
                    AutoSize = true,
                    Width = 360
                };

                Control control = null;

                // Создаём соответствующий контрол в зависимости от типа свойства
                if (property.PropertyType == typeof(string))
                {
                    control = new TextBox { Width = 360 };
                }
                else if (property.PropertyType == typeof(decimal))
                {
                    control = new NumericUpDown
                    {
                        Width = 360,
                        DecimalPlaces = 2,
                        Minimum = 0,
                        Maximum = 1000000
                    };
                }
                else if (property.PropertyType == typeof(DateTime))
                {
                    control = new DateTimePicker
                    {
                        Width = 360,
                        Value = DateTime.Now, // Устанавливаем текущую дату по умолчанию
                        MinDate = new DateTime(1753, 1, 1) // SQL Server совместимая минимальная дата
                    };
                }
                else if (property.PropertyType == typeof(int))
                {
                    control = new NumericUpDown
                    {
                        Width = 360,
                        Minimum = 0,
                        Maximum = 1000000
                    };
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
                        else if (control is DateTimePicker dateTimePicker)
                        {
                            if (value is DateTime dateTimeValue && dateTimeValue >= dateTimePicker.MinDate)
                            {
                                dateTimePicker.Value = dateTimeValue;
                            }
                            else
                            {
                                dateTimePicker.Value = DateTime.Now;
                            }
                        }
                    }
                }
            }
            // Кнопка сохранения
            var btnSave = new Button
            {
                Text = "Сохранить",
                AutoSize = true
            };
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

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            ShowEditForm(null);
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (dgvVinyls.SelectedRows.Count > 0)
            {
                var selectedVinyl = dgvVinyls.SelectedRows[0].DataBoundItem as Vinyl;
                if (selectedVinyl != null)
                {
                    ShowEditForm(selectedVinyl);
                }
            }
            else
            {
                MessageBox.Show("Выберите пластинку для редактирования.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (dgvVinyls.SelectedRows.Count > 0)
            {
                var selectedVinyl = dgvVinyls.SelectedRows[0].DataBoundItem as Vinyl;
                if (selectedVinyl != null)
                {
                    var result = MessageBox.Show($"Вы уверены, что хотите удалить пластинку \"{selectedVinyl.Title}\"?",
                                                  "Подтверждение удаления", MessageBoxButtons.YesNo);

                    if (result == DialogResult.Yes)
                    {
                        Database.DeleteVinyl(selectedVinyl.Id);
                        LoadVinyls();
                        MessageBox.Show("Пластинка удалена.", "Удаление", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите пластинку для удаления.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Все изменения сохранены.", "Сохранение", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

}

