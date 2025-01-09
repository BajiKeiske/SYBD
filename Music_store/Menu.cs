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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void records_Click(object sender, EventArgs e)
        {
            var recordsForm = new RecordsForm();
            recordsForm.Show();
        }

        private void compositions_Click(object sender, EventArgs e)
        {
            var compositionsForm = new CompositionsForm();
            compositionsForm.Show();
        }

        private void ensembles_Click(object sender, EventArgs e)
        {
            var ensemblesForm = new EnsemblesForm();
            ensemblesForm.Show();
        }

        private void musicians_Click(object sender, EventArgs e)
        {
            var musiciansForm = new MusiciansForm();
            musiciansForm.Show();
        }

        private void clientele_Click(object sender, EventArgs e)
        {
            var clientsForm = new ClientsForm();
            clientsForm.Show();
        }
    }
}
