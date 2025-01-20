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

            Text = entity == null ? $"Добавить {_entityType.Name}" : $"Редактировать {_entityType.Name}";

            GenerateFormFields(); // Динамическое создание полей ввода
        }

        // Генерация элементов управления на основе свойств сущности
        private void GenerateFormFields()
        {
            var properties = _entityType.GetProperties()
                .Where(p => p.CanWrite && p.Name != "Id") // Сразу исключаем "Id"
                .ToList();

            int yOffset = 10; // Начальный отступ сверху
            foreach (var property in properties)
            {
                // Создаём метку (Label) для каждого свойства
                var label = new Label
                {
                    Text = GetFriendlyName(property.Name),
                    AutoSize = true,
                    Location = new System.Drawing.Point(10, yOffset)
                };
                Controls.Add(label);

                // Создаём элемент управления (Control) в зависимости от типа свойства
                var control = CreateControlForProperty(property);

                if (control != null)
                {
                    control.Location = new System.Drawing.Point(150, yOffset);
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
                Location = new System.Drawing.Point(10, yOffset)
            };
            saveButton.Click += SaveButton_Click;
            Controls.Add(saveButton);

            // Добавляем кнопку "Отмена"
            var cancelButton = new Button
            {
                Text = "Отмена",
                Width = 100,
                Location = new System.Drawing.Point(120, yOffset)
            };
            cancelButton.Click += (sender, args) => DialogResult = DialogResult.Cancel;
            Controls.Add(cancelButton);

            AutoSize = true; // Подгоняем размер формы под содержимое
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
            return null; // Если тип свойства не поддерживается, пропускаем его
        }

        // Заполняет ComboBox для Id свободными значениями
        private void FillAvailableIds(ComboBox comboBox)
        {
            try
            {
                // Получаем список свободных идентификаторов из базы данных
                var availableIds = Database.GetAvailableIdsForEntity(_entityType.Name);

                if (availableIds.Any())
                {
                    comboBox.DataSource = availableIds;
                }
                else
                {
                    comboBox.Items.Add("Нет доступных Id");
                    comboBox.SelectedIndex = 0;
                    comboBox.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке доступных Id: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                    dateTimePicker.Value = DateTime.Now; // Устанавливаем текущую дату, если значение недопустимо
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
                        property.SetValue(_entity, textBox.Text);
                    else if (control is NumericUpDown numericUpDown)
                        property.SetValue(_entity, Convert.ToInt32(numericUpDown.Value));
                    else if (control is DateTimePicker dateTimePicker)
                        property.SetValue(_entity, dateTimePicker.Value);
                    else if (control is ComboBox comboBox)
                        property.SetValue(_entity, comboBox.SelectedValue);
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
        // Преобразует имя свойства в человеко-читаемый формат
        private string GetFriendlyName(string propertyName)
        {
            return propertyName switch
            {
                "MusicianId" => "Музыкант",
                "EnsembleId" => "Ансамбль",
                "CompositionId" => "Композиция",
                "ClientId" => "Клиент",
                _ => propertyName
            };
        }
        private void AddOrEditForm_Load(object sender, EventArgs e)
        {
        }
    }
}
