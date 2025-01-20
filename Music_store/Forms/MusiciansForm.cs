using Music_store.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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
            LoadMusicians();
        }

        private void LoadMusicians()
        {
            var musicians = Database.GetMusicians();
            musiciansDataGridView.DataSource = null;
            musiciansDataGridView.DataSource = musicians;

            var columnHeaders = new Dictionary<string, string>
            {
                { "id", "Индекс" },
                { "name", "Имя" },
                { "surname", "Фамилия" },
                { "instrument", "Инструмент" },
                { "date_of_birth", "Дата рождения" }
            };
            Menu.SetColumnHeaders(musiciansDataGridView, columnHeaders);
        }


        private void AddMusician_Click(object sender, EventArgs e)
        {
            var form = new AddOrEditForm(typeof(Musician));
            if (form.ShowDialog() == DialogResult.OK)
            {
                var newMusician = (Musician)form.GetEntity();
                Database.AddMusician(newMusician); // Добавляем музыканта в базу
                LoadMusicians(); // Обновляем список музыкантов
            }
        }

        private void EditMusician_Click(object sender, EventArgs e)
        {
            if (musiciansDataGridView.SelectedRows.Count > 0)
            {
                var selectedMusician = (Musician)musiciansDataGridView.SelectedRows[0].DataBoundItem;
                var form = new AddOrEditForm(typeof(Musician), selectedMusician);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    Database.UpdateMusician(selectedMusician); // Обновляем данные музыканта в базе
                    LoadMusicians(); // Обновляем список музыкантов
                }
            }
            else
            {
                MessageBox.Show("Выберите музыканта для редактирования.");
            }
        }


        private void deleteMusicianButton_Click(object sender, EventArgs e)
        {
            if (musiciansDataGridView.SelectedRows.Count > 0)
            {
                var selectedMusician = (Musician)musiciansDataGridView.SelectedRows[0].DataBoundItem;

                var result = MessageBox.Show($"Вы уверены, что хотите удалить музыканта {selectedMusician.name} {selectedMusician.surname}?",
                                             "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    Database.DeleteMusician(selectedMusician.id);
                    LoadMusicians();
                }
            }
            else
            {
                MessageBox.Show("Выберите музыканта для удаления.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        //private void EnsemblesButton_Click(object sender, EventArgs e)
        //{
        //    if (musiciansDataGridView.SelectedRows.Count == 0)
        //    {
        //        MessageBox.Show("Пожалуйста, выберите музыканта.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        return;
        //    }

        //    var selectedMusician = (Musician)musiciansDataGridView.SelectedRows[0].DataBoundItem;
        //    var ensemblesForm = new EnsemblesForm(selectedMusician.id);
        //    ensemblesForm.ShowDialog();
        //}
    }
}





