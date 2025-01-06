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

namespace Kursach
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
            // Пример: загрузка музыкантов из базы данных
            //var musicians = Database.GetMusicians();
            //dataGridView1.DataSource = musicians;
        }

        private void addMusician_Click(object sender, EventArgs e)
        {
            // Пример добавления музыканта
            //var addForm = new AddMusicianForm();
            //if (addForm.ShowDialog() == DialogResult.OK)
            //{
            //    LoadMusicians();
            //}
        }

        private void editMusician_Click(object sender, EventArgs e)
        {
            // Пример редактирования выбранного музыканта
            //if (dataGridView1.SelectedRows.Count > 0)
            //{
            //    var selectedMusician = (Musician)dataGridView1.SelectedRows[0].DataBoundItem;
            //    var editForm = new EditMusicianForm(selectedMusician);
            //    if (editForm.ShowDialog() == DialogResult.OK)
            //    {
            //        LoadMusicians();
            //    }
            //}
        }

        private void deleteMusician_Click(object sender, EventArgs e)
        {
            // Пример удаления выбранного музыканта
            //if (dataGridView1.SelectedRows.Count > 0)
            //{
            //    var selectedMusician = (Musician)dataGridView1.SelectedRows[0].DataBoundItem;
            //    Database.DeleteMusician(selectedMusician.Id);
            //    LoadMusicians();
            //}
        }
    }
}


       

