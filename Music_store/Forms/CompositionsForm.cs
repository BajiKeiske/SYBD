using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Music_store.Entities;

namespace Music_store
{
    public partial class CompositionsForm : Form
    {
        public CompositionsForm()
        {
            InitializeComponent();
        }

        private void CompositionsForm_Load(object sender, EventArgs e)
        {
            // Загрузка данных о композициях в таблицу
            LoadCompositions();
        }

        private void LoadCompositions()
        {
            // Загрузка данных из базы
            var compositions = Database.GetCompositions();
            compositionsDataGridView.DataSource = compositions;
            var columnHeaders = new Dictionary<string, string>
            {
                { "Id", "Индекс" },
                { "Name", "Имя" },
                { "Surname", "Фамилия" },
                { "MusicianId", "Индекс музыканта" },
                { "EnsembleId", "Индекс ансамбля" },
                { "ReleaseYear", "Год выпуска" }
            };
            Menu.SetColumnHeaders(compositionsDataGridView, columnHeaders);
        }

        private void AddComposition_Click(object sender, EventArgs e)
        {
            var form = new AddOrEditForm(typeof(Composition));
            if (form.ShowDialog() == DialogResult.OK)
            {
                var newComposition = (Composition)form.GetEntity();
                Database.AddComposition(newComposition); // Добавляем композицию в базу
                LoadCompositions(); // Обновляем список композиций
            }
        }

        private void EditComposition_Click(object sender, EventArgs e)
        {
            if (compositionsDataGridView.SelectedRows.Count > 0)
            {
                var selectedComposition = (Composition)compositionsDataGridView.SelectedRows[0].DataBoundItem;
                var form = new AddOrEditForm(typeof(Composition), selectedComposition);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    Database.UpdateComposition(selectedComposition); // Обновляем данные композиции в базе
                    LoadCompositions(); // Обновляем список композиций

                }
            }
            else
            {
                MessageBox.Show("Выберите композицию для редактирования.");
            }
        }


        private void deleteCompositions_Click(object sender, EventArgs e)
        {
            if (compositionsDataGridView.SelectedRows.Count > 0)
            {
                // Получаем выбранную композицию
                var selectedComposition = (Composition)compositionsDataGridView.SelectedRows[0].DataBoundItem;

                var result = MessageBox.Show($"Вы уверены, что хотите удалить композицию {selectedComposition.Name}?",
                    "Подтверждение", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    // Удаление из базы данных
                    Database.DeleteComposition(selectedComposition.Id);

                    // Перезагрузка списка
                    LoadCompositions();
                }
            }
            else
            {
                MessageBox.Show("Выберите композицию для удаления.");
            }
        }
    }
}

