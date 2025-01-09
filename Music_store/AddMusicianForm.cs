using System;
using System.Windows.Forms;

namespace Music_store
{
    public partial class AddMusicianForm : Form
    {
        public Musician NewMusician { get; private set; }

        public AddMusicianForm()
        {
            InitializeComponent();

            NewMusician = new Musician
            {
                id = 0,
                name = "",
                surname = "",
                instrument = "",
                date_of_birth = DateTime.Now
            };

            dateOfBirthPicker.Value = DateTime.Now; // Устанавливаем дату по умолчанию
        }

        private void Save_Click(object sender, EventArgs e)
        {
            // Заполняем объект NewMusician из полей формы
            if (int.TryParse(idTextBox.Text, out int id))
            {
                NewMusician.id = id; // Присваиваем ID из текстового поля
            }
            else
            {
                MessageBox.Show("ID должен быть числом.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            NewMusician.name = nameTextBox.Text;
            NewMusician.surname = surnameTextBox.Text;
            NewMusician.instrument = instrumentTextBox.Text;
            NewMusician.date_of_birth = dateOfBirthPicker.Value;

            DialogResult = DialogResult.OK; // Указываем, что изменения подтверждены
            Close();
        }

        private void AddMusicianForm_Load(object sender, EventArgs e)
        {

        }
    }
}

