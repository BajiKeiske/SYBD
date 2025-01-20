using Music_store.Entities;
using System;
using System.Windows.Forms;

namespace Music_store
{
    public partial class EnsemblesForm : Form
    {
        public EnsemblesForm()
        {
            InitializeComponent();
            LoadEnsembles();
        }

        private void LoadEnsembles()
        {
            var ensembles = Database.GetEnsembles(); // Загрузка ансамблей из базы данных
            ensemblesDataGridView.DataSource = ensembles;
        }

        private void AddEnsemble_Click(object sender, EventArgs e)
        {
            var form = new AddOrEditForm(typeof(Ensemble));
            if (form.ShowDialog() == DialogResult.OK)
            {
                var newEnsemble = (Ensemble)form.GetEntity();
                Database.AddEnsemble(newEnsemble); // Добавляем ансамбль в базу
                LoadEnsembles(); // Обновляем список ансамблей
            }
        }

        private void EditEnsemble_Click(object sender, EventArgs e)
        {
            if (ensemblesDataGridView.SelectedRows.Count > 0)
            {
                var selectedEnsemble = (Ensemble)ensemblesDataGridView.SelectedRows[0].DataBoundItem;
                var form = new AddOrEditForm(typeof(Ensemble), selectedEnsemble);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    Database.UpdateEnsemble(selectedEnsemble); // Обновляем данные ансамбля в базе
                    LoadEnsembles(); // Обновляем список ансамблей
                }
            }
            else
            {
                MessageBox.Show("Выберите ансамбль для редактирования.");
            }
        }


        private void DeleteEnsemble_Click(object sender, EventArgs e)
        {
            if (ensemblesDataGridView.SelectedRows.Count > 0)
            {
                var selectedEnsemble = (Ensemble)ensemblesDataGridView.SelectedRows[0].DataBoundItem;
                var result = MessageBox.Show($"Вы уверены, что хотите удалить ансамбль {selectedEnsemble.Name}?",
                    "Подтверждение", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    Database.DeleteEnsemble(selectedEnsemble.Id); // Удаляем из базы
                    LoadEnsembles(); // Перезагружаем список
                }
            }
            else
            {
                MessageBox.Show("Выберите ансамбль для удаления.");
            }
        }

        private void EnsemblesForm_Load(object sender, EventArgs e)
        {

        }

        //private void ViewMusicians_Click(object sender, EventArgs e)
        //{
        //    if (ensemblesDataGridView.SelectedRows.Count > 0)
        //    {
        //        var selectedEnsemble = (Ensemble)ensemblesDataGridView.SelectedRows[0].DataBoundItem;
        //        var musiciansForm = new MusiciansForm(selectedEnsemble.Id);
        //        musiciansForm.ShowDialog(); // Открываем форму музыкантов
        //    }
        //    else
        //    {
        //        MessageBox.Show("Выберите ансамбль для просмотра музыкантов.");
        //    }
        //}
    }
}
