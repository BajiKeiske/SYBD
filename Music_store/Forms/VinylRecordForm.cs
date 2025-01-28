using Music_store.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.IO;

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
            CustomizeForm();
        }

        private void CustomizeForm()
        {
            // Изменяем стиль кнопок
            foreach (Control control in this.Controls)
            {
                if (control is FlowLayoutPanel panel)
                {
                    foreach (Control subControl in panel.Controls)
                    {
                        if (subControl is Button button)
                        {
                            button.FlatStyle = FlatStyle.Popup;
                            button.BackColor = Color.Azure;
                        }
                    }
                }
            }

            // Изменяем фон таблицы
            dgvVinyls.BackgroundColor = Color.LightBlue;
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

            // Генерация столбцов таблицы
            dgvVinyls.Columns.Clear();
            dgvVinyls.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "Идентификатор (ID)", Visible = true });
            dgvVinyls.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "LabelNumber", HeaderText = "Номер этикетки" });
            dgvVinyls.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Title", HeaderText = "Название" });
            dgvVinyls.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ReleaseYear", HeaderText = "Год выпуска" });
            dgvVinyls.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "MusicianId", HeaderText = "Идентификатор музыканта" });
            dgvVinyls.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "EnsembleId", HeaderText = "Идентификатор ансамбля" });
            dgvVinyls.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Genre", HeaderText = "Жанр" });
            dgvVinyls.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "WholesalePrice", HeaderText = "Оптовая цена" });
            dgvVinyls.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "RetailPrice", HeaderText = "Розничная цена" });
            dgvVinyls.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "SoldLastYear", HeaderText = "Продано в прошлом году" });
            dgvVinyls.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "SoldThisYear", HeaderText = "Продано в этом году" });
            dgvVinyls.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Stock", HeaderText = "Остаток" });

            // Добавляем колонку для изображения
            var imageColumn = new DataGridViewImageColumn
            {
                DataPropertyName = "Image", // Название свойства в модели Vinyl
                HeaderText = "Изображение",
                ImageLayout = DataGridViewImageCellLayout.Zoom // Масштабирование, чтобы изображение было вписано в ячейку
            };
            dgvVinyls.Columns.Add(imageColumn);

            // Устанавливаем высоту строк для улучшения видимости изображений
            dgvVinyls.RowTemplate.Height = 50; // Увеличиваем высоту строк

            // Устанавливаем источник данных для DataGridView
            dgvVinyls.DataSource = vinyls;
        }

        private void ShowEditForm(Vinyl vinyl)
        {
            if (vinyl == null)
            {
                vinyl = new Vinyl();
            }

            var form = new Form
            {
                Text = vinyl.Id == 0 ? "Добавить пластинку" : "Редактировать пластинку",
                Size = new Size(400, 620),
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false
            };

            var panel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(10),
                AutoScroll = true,
                WrapContents = false,
                FlowDirection = FlowDirection.TopDown
            };
            form.Controls.Add(panel);

            // Словарь для русификации полей
            var fieldLabels = new Dictionary<string, string>
    {
        { "LabelNumber", "Номер этикетки" },
        { "Title", "Название" },
        { "ReleaseYear", "Год выпуска" },
        { "MusicianId", "Идентификатор музыканта" },
        { "EnsembleId", "Идентификатор ансамбля" },
        { "Genre", "Жанр" },
        { "WholesalePrice", "Оптовая цена" },
        { "RetailPrice", "Розничная цена" },
        { "SoldLastYear", "Продано в прошлом году" },
        { "SoldThisYear", "Продано в этом году" },
        { "Stock", "Остаток" },
        { "Image", "Изображение" }
    };

            controls = new Dictionary<string, Control>();
            var properties = typeof(Vinyl).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (var property in properties)
            {
                if (property.Name == "Id") continue;

                var label = new Label
                {
                    Text = fieldLabels.ContainsKey(property.Name) ? fieldLabels[property.Name] : property.Name,
                    AutoSize = true,
                    Width = 360
                };

                Control control = null;

                if (property.PropertyType == typeof(string))
                {
                    control = new TextBox { Width = 360 };
                }
                else if (property.PropertyType == typeof(decimal) || property.PropertyType == typeof(int))
                {
                    control = new NumericUpDown
                    {
                        Width = 360,
                        DecimalPlaces = property.PropertyType == typeof(decimal) ? 2 : 0,
                        Minimum = 0,
                        Maximum = 1000000
                    };
                }
                else if (property.PropertyType == typeof(DateTime))
                {
                    control = new DateTimePicker
                    {
                        Width = 360,
                        Value = DateTime.Now
                    };
                }
                else if (property.PropertyType == typeof(byte[]))
                {
                    var btnUploadImage = new Button
                    {
                        Text = "Загрузить изображение",
                        AutoSize = true
                    };
                    btnUploadImage.Click += (s, e) =>
                    {
                        using (var openFileDialog = new OpenFileDialog
                        {
                            Filter = "Изображения|*.bmp;*.jpg;*.jpeg;*.png;*.gif"
                        })
                        {
                            if (openFileDialog.ShowDialog() == DialogResult.OK)
                            {
                                var imageBytes = File.ReadAllBytes(openFileDialog.FileName);
                                property.SetValue(vinyl, imageBytes);
                                MessageBox.Show("Изображение загружено успешно.", "Загрузка изображения", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    };
                    control = btnUploadImage;
                }

                if (control != null)
                {
                    panel.Controls.Add(label);
                    panel.Controls.Add(control);
                    controls[property.Name] = control;

                    var value = property.GetValue(vinyl);
                    if (control is TextBox textBox) textBox.Text = value?.ToString();
                    else if (control is NumericUpDown numericUpDown) numericUpDown.Value = Convert.ToDecimal(value ?? 0);
                    else if (control is DateTimePicker dateTimePicker && value is DateTime dateTimeValue) dateTimePicker.Value = dateTimeValue;
                }
            }

            var btnSave = new Button
            {
                Text = "Сохранить",
                AutoSize = true
            };
            btnSave.Click += (s, e) =>
            {
                foreach (var property in properties)
                {
                    if (controls.ContainsKey(property.Name))
                    {
                        var control = controls[property.Name];
                        if (control is TextBox textBox)
                        {
                            if (string.IsNullOrWhiteSpace(textBox.Text))
                            {
                                MessageBox.Show($"Поле '{fieldLabels[property.Name]}' обязательно для заполнения.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            property.SetValue(vinyl, textBox.Text);
                        }
                        else if (control is NumericUpDown numericUpDown)
                        {
                            property.SetValue(vinyl, Convert.ChangeType(numericUpDown.Value, property.PropertyType));
                        }
                        else if (control is DateTimePicker dateTimePicker)
                        {
                            property.SetValue(vinyl, dateTimePicker.Value);
                        }
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

