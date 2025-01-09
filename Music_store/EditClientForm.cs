using System;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Music_store
{
    public partial class EditClientForm : Form
    {
        public Client Client { get; private set; } // Свойство для измененного клиента

        public EditClientForm(Client client)
        {
            InitializeComponent();
            Client = client;

            // Инициализируем поля формы значениями клиента
            idTextBox.Text = client.id.ToString();
            nameTextBox.Text = client.name;
            surnameTextBox.Text = client.surname;
            birthdayPicker.Value = client.birthday;
            emailTextBox.Text = client.email;
            phoneTextBox.Text = client.phone_number;
        }

        private void Save_Click(object sender, EventArgs e)
        {
            // Обновляем объект Client на основе данных из формы
            if (int.TryParse(idTextBox.Text, out int id))
            {
                Client.id = id;
            }
            else
            {
                MessageBox.Show("ID должен быть числом.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Client.name = nameTextBox.Text;
            Client.surname = surnameTextBox.Text;
            Client.birthday = birthdayPicker.Value;
            Client.email = emailTextBox.Text;
            Client.phone_number = phoneTextBox.Text;

            DialogResult = DialogResult.OK; // Указываем, что изменения подтверждены
            Close();
        }
    }
}
