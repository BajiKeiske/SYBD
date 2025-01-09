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
    public partial class CompositionsForm : Form
    {
        public CompositionsForm()
        {
            InitializeComponent();
        }

        private void CompositionsForm_Load(object sender, EventArgs e)
        {
            // Загрузка данных о композициях в таблицу или список
            LoadCompositions();
        }
        private void LoadCompositions()
        {
            // Пример загрузки данных из базы
            var compositions = Database.GetCompositions();
            compositionsDataGridView.DataSource = compositions;
        }

        private void editCompositions_Click(object sender, EventArgs e)
        {
            if (compositionsDataGridView.SelectedRows.Count > 0)
            {
                // Получаем выбранную композицию
                var selectedComposition = (Composition)compositionsDataGridView.SelectedRows[0].DataBoundItem;

                // Открываем форму редактирования
                var editForm = new EditCompositionForm(selectedComposition);
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    // Сохраняем изменения в базу данных
                    Database.UpdateComposition(selectedComposition);

                    // Перезагружаем данные в таблице
                    LoadCompositions();
                }
            }
        }

        private void addCompositions_Click(object sender, EventArgs e)
        {
            var addForm = new AddCompositionsForm(); // Открываем форму добавления
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                // Сохраняем новую композицию в базу данных
                Database.AddComposition(addForm.NewCompotition);

                // Обновляем список композиций в DataGridView
                LoadCompositions();
            }
        }

        private void deleteCompositions_Click(object sender, EventArgs e)
        {
            // Удаление композиции
            if (compositionsDataGridView.SelectedRows.Count > 0)
            {
                var selectedComposition = (Musician)compositionsDataGridView.SelectedRows[0].DataBoundItem;
                var result = MessageBox.Show($"Вы уверены, что хотите удалить композицию {selectedComposition.name}?",
                    "Подтверждение", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    Database.DeleteComposition(selectedComposition.id); // Удаление из базы
                    LoadCompositions(); // Перезагрузка списка
                }
            }
            else
            {
                MessageBox.Show("Выберите композицию для удаления.");
            }
        }
    }
}
