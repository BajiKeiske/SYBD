using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace Music_store
{
    public partial class AddOrEditForm : Form
    {
        private readonly object _entity; // Объект текущей сущности
        private readonly Type _entityType; // Тип сущности
        private readonly Dictionary<string, Control> _controls = new(); // Словарь для привязки свойств к элементам управления

        public AddOrEditForm(Type entityType, object entity = null)
        {
            InitializeComponent();

            _entityType = entityType;
            _entity = entity ?? Activator.CreateInstance(entityType); // Если объект не передан, создаём новый

            // Словарь сопоставления названий сущностей с их переводами
            var entityNamesInRussian = new Dictionary<string, string>
            {
                { "Vinyl", "пластинку" },
                { "Musician", "исполнителя" },
                { "Composition", "композицию" },
                { "Ensemble", "ансамбль" },
                { "Client", "клиента" }
            };

            // Получаем русское имя сущности или оставляем оригинальное, если перевода нет
            var entityNameInRussian = entityNamesInRussian.ContainsKey(_entityType.Name)
                ? entityNamesInRussian[_entityType.Name]
                : _entityType.Name;

            // Устанавливаем заголовок окна
            Text = entity == null
                ? $"Добавить {entityNameInRussian}"
                : $"Редактировать {entityNameInRussian}";

            GenerateFormFields();
        }
        private bool ValidateFields()
        {
            foreach (Control control in this.Controls)
            {
                if (control is TextBox textBox)
                {
                    if (string.IsNullOrWhiteSpace(textBox.Text))
                    {
                        MessageBox.Show("Все текстовые поля должны быть заполнены!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }
            }
            return true;
        }


        // Генерация элементов управления на основе свойств сущности
        private void GenerateFormFields()
        {
            var properties = _entityType.GetProperties()
                .Where(p => p.CanWrite && p.Name != "Id")
                .ToList();

            int labelWidth = 120;
            int controlWidth = 200;
            int yOffset = 10;
            int xLabel = 10;
            int xControl = xLabel + labelWidth + 10;

            foreach (var property in properties)
            {
                // Создаём метку (Label) для каждого свойства
                var label = new Label
                {
                    Text = GetFriendlyName(property.Name),
                    AutoSize = true,
                    Location = new System.Drawing.Point(xLabel, yOffset),
                    Width = labelWidth
                };
                Controls.Add(label);

                // Создаём элемент управления (Control) в зависимости от типа свойства
                var control = CreateControlForProperty(property);

                if (control != null)
                {
                    control.Location = new System.Drawing.Point(xControl, yOffset);
                    control.Width = controlWidth;
                    _controls[property.Name] = control; // Привязываем свойство к элементу управления
                    Controls.Add(control);

                    // Если объект редактируется, заполняем элемент управления значением из объекта
                    var value = property.GetValue(_entity);
                    FillControlWithValue(control, value);

                    yOffset += 40; // Сдвигаем координату для следующего поля
                }
            }

            // Добавляем кнопку "Сохранить"
            var saveButton = new Button
            {
                Text = "Сохранить",
                Width = 100,
                Location = new System.Drawing.Point(xLabel, yOffset + 10)
            };
            saveButton.Click += SaveButton_Click;
            Controls.Add(saveButton);

            // Добавляем кнопку "Отмена"
            var cancelButton = new Button
            {
                Text = "Отмена",
                Width = 100,
                Location = new System.Drawing.Point(xControl, yOffset + 10)
            };
            cancelButton.Click += (sender, args) => DialogResult = DialogResult.Cancel;
            Controls.Add(cancelButton);

            AutoSize = true; // Подгоняем размер формы под содержимое
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
        }

        // Создаёт элемент управления на основе типа свойства
        private Control CreateControlForProperty(PropertyInfo property)
        {
            if (property.PropertyType == typeof(string))
                return new TextBox { Width = 200 };
            if (property.PropertyType == typeof(int) || property.PropertyType == typeof(decimal))
                return new NumericUpDown { Width = 200, Maximum = int.MaxValue };
            if (property.PropertyType == typeof(DateTime))
                return new DateTimePicker { Width = 200 };
            if (property.Name.EndsWith("Id")) // Обработка внешних ключей
                return CreateComboBoxForForeignKey(property.Name);
            return null;
        }

        // Создаёт ComboBox для внешнего ключа
        private ComboBox CreateComboBoxForForeignKey(string propertyName)
        {
            var comboBox = new ComboBox { Width = 200, DropDownStyle = ComboBoxStyle.DropDownList };
            FillComboBox(comboBox, propertyName);
            return comboBox;
        }

        // Заполняет ComboBox данными для внешнего ключа
        private void FillComboBox(ComboBox comboBox, string propertyName)
        {
            try
            {
                if (propertyName == "MusicianId")
                {
                    comboBox.DataSource = Database.GetMusicians();
                    comboBox.DisplayMember = "Name";
                    comboBox.ValueMember = "Id";
                }
                else if (propertyName == "EnsembleId")
                {
                    comboBox.DataSource = Database.GetEnsembles();
                    comboBox.DisplayMember = "EnsembleName";
                }
                else if (propertyName == "CompositionId")
                {
                    comboBox.DataSource = Database.GetCompositions();
                    comboBox.DisplayMember = "Title";
                    comboBox.ValueMember = "Id";
                }
                else if (propertyName == "ClientId")
                {
                    comboBox.DataSource = Database.GetClients();
                    comboBox.DisplayMember = "FullName";
                    comboBox.ValueMember = "Id";
                }
                else
                {
                    throw new ArgumentException($"Неизвестное свойство: {propertyName}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при заполнении ComboBox: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // Заполняет элемент управления значением из объекта
        private void FillControlWithValue(Control control, object value)
        {
            if (control is TextBox textBox)
            {
                textBox.Text = value?.ToString();
            }
            else if (control is NumericUpDown numericUpDown && value is int intValue)
            {
                numericUpDown.Value = intValue;
            }
            else if (control is DateTimePicker dateTimePicker && value is DateTime dateValue)
            {
                if (dateValue < dateTimePicker.MinDate || dateValue > dateTimePicker.MaxDate)
                {
                    dateTimePicker.Value = DateTime.Now;
                }
                else
                {
                    dateTimePicker.Value = dateValue;
                }
            }
            else if (control is ComboBox comboBox && value != null)
            {
                comboBox.SelectedValue = value;
            }
        }
        // Сохранение данных из формы в объект сущности
        private void SaveButton_Click(object sender, EventArgs e)
        {
            foreach (var property in _entityType.GetProperties().Where(p => p.CanWrite))
            {
                if (_controls.TryGetValue(property.Name, out var control))
                {
                    if (control is TextBox textBox)
                    {
                        // Проверка на пустое значение
                        if (string.IsNullOrWhiteSpace(textBox.Text))
                        {
                            string friendlyName = GetFriendlyName(property.Name); // Получаем русское название поля
                            MessageBox.Show($"Поле \"{friendlyName}\" обязательно для заполнения.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return; // Прерываем сохранение
                        }
                        property.SetValue(_entity, textBox.Text);
                    }
                    else if (control is NumericUpDown numericUpDown)
                    {
                        property.SetValue(_entity, Convert.ToInt32(numericUpDown.Value));
                    }
                    else if (control is DateTimePicker dateTimePicker)
                    {
                        property.SetValue(_entity, dateTimePicker.Value);
                    }
                    else if (control is ComboBox comboBox)
                    {
                        property.SetValue(_entity, comboBox.SelectedValue);
                    }
                }
            }

            // Генерация ID только для новых сущностей
            var idProperty = _entityType.GetProperty("Id");
            if (idProperty != null && Convert.ToInt32(idProperty.GetValue(_entity)) == 0)
            {
                string tableName = _entityType.Name + "s"; // Предполагаем имя таблицы по имени класса
                idProperty.SetValue(_entity, Database.FindMaxId(tableName));
            }

            DialogResult = DialogResult.OK;
            Close();
        }



        // Получает заполненный объект сущности
        public object GetEntity()
        {
            return _entity;
        }
        private string GetFriendlyName(string propertyName)
        {
            // Сначала пробуем использовать switch
            var friendlyName = propertyName switch
            {
                "MusicianId" => "Музыкант",
                "EnsembleId" => "Ансамбль",
                "CompositionId" => "Композиция",
                "ClientId" => "Клиент",
                "VinylId" => "Пластинка",
                _ => null // Если нет соответствия, возвращаем null
            };

            // Если в switch нет соответствия, пробуем найти в словаре
            if (friendlyName == null)
            {
                // Словарь для перевода свойств на русский язык
                var fieldNamesInRussian = new Dictionary<string, string>
        {
            { "Name", "Имя" },
            { "Id", "Индекс" },
            { "Surname", "Фамилия" },
            { "Instrument", "Инструмент" },
            { "Date_of_birth", "Дата рождения" },
            { "ReleaseYear", "Год выпуска" },
            { "Birthday", "Дата рождения" },
            { "Phone_number", "Телефонный номер" },
            { "Email", "Почта" },
            { "LabelNumber", "Номер наклейки" },
            { "Title", "Название" },
            { "Genre", "Жанр" },
            { "WholesalePrice", "Оптовая цена" },
            { "RetailPrice", "Розничная цена" },
            { "SoldLastYear", "Продано в прошлом году" },
            { "SoldThisYear", "Продано в текущем году" },
            { "Stock", "Остаток" },
            { "Date_founded", "Дата основания" },

        };

                // Если свойство есть в словаре, возвращаем русское название, иначе возвращаем оригинальное имя
                friendlyName = fieldNamesInRussian.ContainsKey(propertyName)
                    ? fieldNamesInRussian[propertyName]
                    : propertyName;
            }

            return friendlyName;
        }

        private void AddOrEditForm_Load(object sender, EventArgs e)
        {
        }
    }
}