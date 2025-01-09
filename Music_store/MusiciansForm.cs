using Music_store;
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
    public partial class MusiciansForm : Form
    {
        public MusiciansForm()
        {
            InitializeComponent();
        }

        private void MusiciansForm_Load(object sender, EventArgs e)
        {
            // Загрузка данных музыкантов в таблицу или список
            LoadMusicians();
        }

        private void LoadMusicians()
        {
            // Пример загрузки данных из базы
            //musiciansDataGridView.AutoGenerateColumns = false;
            var musicians = Database.GetMusicians();
            musiciansDataGridView.DataSource = musicians;
        }

        private void addMusicianButton_Click(object sender, EventArgs e)
        {
            var addForm = new AddMusicianForm(); // Открываем форму добавления
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                // Сохраняем нового музыканта в базу данных
                Database.AddMusician(addForm.NewMusician);

                // Обновляем список музыкантов в DataGridView
                LoadMusicians();
            }
        }
        private void editMusician_Click(object sender, EventArgs e)
        {
            if (musiciansDataGridView.SelectedRows.Count > 0)
            {
                // Получаем выбранного музыканта
                var selectedMusician = (Musician)musiciansDataGridView.SelectedRows[0].DataBoundItem;

                // Открываем форму редактирования
                var editForm = new EditMusicianForm(selectedMusician);
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    // Сохраняем изменения в базу данных
                    Database.UpdateMusician(selectedMusician);

                    // Перезагружаем данные в таблице
                    LoadMusicians();
                }
            }
            else
            {
                MessageBox.Show("Выберите музыканта для редактирования.");
            }
        }
        private void deleteMusicianButton_Click(object sender, EventArgs e)
        {
            // Удаление музыканта
            if (musiciansDataGridView.SelectedRows.Count > 0)
            {
                var selectedMusician = (Musician)musiciansDataGridView.SelectedRows[0].DataBoundItem;
                var result = MessageBox.Show($"Вы уверены, что хотите удалить музыканта {selectedMusician.name} {selectedMusician.surname}?",
                    "Подтверждение", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    Database.DeleteMusician(selectedMusician.id); // Удаление из базы
                    LoadMusicians(); // Перезагрузка списка
                }
            }
            else
            {
                MessageBox.Show("Выберите музыканта для удаления.");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}




