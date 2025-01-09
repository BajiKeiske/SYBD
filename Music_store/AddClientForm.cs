using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Music_store
{
    public partial class AddClientForm : Form
    {
        public Client NewClient { get; private set; }

        public AddClientForm()
        {
            InitializeComponent();

            NewClient = new Client
            {
                id = 0,
                name = "",
                surname = "",
                birthday = DateTime.Now,
                email = "",
                phone_number = "1234567890"
            };
               birthdayPicker.Value = DateTime.Now; // Устанавливаем дату по умолчанию
        }

        private void Save_Click(object sender, EventArgs e)
        {
            // Заполняем объект NewMusician из полей формы
            if (int.TryParse(idTextBox.Text, out int id))
            {
                NewClient.id = id; // Присваиваем ID из текстового поля
            }
            else
            {
                MessageBox.Show("ID должен быть числом.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            NewClient.name = nameTextBox.Text;
            NewClient.surname = surnameTextBox.Text;
            NewClient.birthday = birthdayPicker.Value;
            NewClient.email = emailTextBox.Text;
            NewClient.phone_number = phoneTextBox.Text;


            DialogResult = DialogResult.OK; // Указываем, что изменения подтверждены
            Close();
        }
    }
}
