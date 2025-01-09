using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Npgsql;

namespace Music_store
{
    public partial class ClientsForm : Form
    {
        public ClientsForm()
        {
            InitializeComponent();
            LoadClients();
        }
        private void ClientsForm_Load(object sender, EventArgs e)
        {
            // Загрузка данных музыкантов в таблицу или список
            LoadClients();
        }
        private void LoadClients()
        {
            // Пример загрузки данных из базы
            //musiciansDataGridView.AutoGenerateColumns = false;
            var clients = Database.GetClients();
            clientsDataGridView.DataSource = clients;

            //clientsDataGridView.Rows.Clear();
            //var clients = Database.GetClients(); // Метод для загрузки данных из базы
            //foreach (var client in clients)
            //{
            //    clientsDataGridView.Rows.Add(client.id, client.name, client.surname, client.birthday, client.email, client.phone_number);
            //}
        }

        private void AddClient_Click(object sender, EventArgs e)
        {
            var addForm = new AddClientForm();
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                Database.AddClient(addForm.NewClient); // Метод для добавления клиента в базу
                LoadClients(); // Обновляем таблицу
            }
        }

        private void EditClient_Click(object sender, EventArgs e)
        {
            if (clientsDataGridView.SelectedRows.Count > 0)
            {
                var selectedRow = clientsDataGridView.SelectedRows[0];
                var client = new Client
                {
                    id = (int)selectedRow.Cells[0].Value,
                    name = (string)selectedRow.Cells[1].Value,
                    surname = (string)selectedRow.Cells[2].Value,
                    birthday = (DateTime)selectedRow.Cells[3].Value,
                    email = (string)selectedRow.Cells[4].Value,
                    phone_number = (string)selectedRow.Cells[5].Value
                };

                var editForm = new EditClientForm(client);
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    Database.UpdateClient(editForm.Client); // Метод для обновления клиента в базе
                    LoadClients(); // Обновляем таблицу
                }
            }
        }

        private void DeleteClient_Click(object sender, EventArgs e)
        {
            if (clientsDataGridView.SelectedRows.Count > 0)
            {
                var selectedRow = clientsDataGridView.SelectedRows[0];
                int clientId = (int)selectedRow.Cells[0].Value;

                var confirmResult = MessageBox.Show("Вы уверены, что хотите удалить этого клиента?", "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirmResult == DialogResult.Yes)
                {
                    Database.DeleteClient(clientId); // Метод для удаления клиента из базы
                    LoadClients();
                }
            }
        }
    }
}
