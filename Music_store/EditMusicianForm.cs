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
    public partial class EditMusicianForm : Form
    {
        private Musician musician;

        public EditMusicianForm(Musician musician)
        {
            InitializeComponent();
            this.musician = musician;

            // Заполняем поля формы данными музыканта
            nameTextBox.Text = musician.name;
            surnameTextBox.Text = musician.surname;
            instrumentTextBox.Text = musician.instrument;
            dateOfBirthPicker.Value = musician.date_of_birth;
        }

        private void save_Click(object sender, EventArgs e)
        {
            // Обновляем объект музыканта данными из полей формы
            musician.name = nameTextBox.Text;
            musician.surname = surnameTextBox.Text;
            musician.instrument = instrumentTextBox.Text;
            musician.date_of_birth = dateOfBirthPicker.Value;

            DialogResult = DialogResult.OK; // Указываем, что изменения подтверждены
            Close();
        }

        private void EditMusicianForm_Load(object sender, EventArgs e)
        {

        }
    }
}
