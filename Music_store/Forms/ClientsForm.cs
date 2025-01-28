using Music_store.Entities;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Music_store
{
    public partial class ClientsForm : Form
    {
        public ClientsForm()
        {
            InitializeComponent();
            LoadClients();
        }

        private void LoadClients()
        {
            // Загружаем данные из базы
            var clients = Database.GetClients();
            clientsDataGridView.DataSource = null;
            clientsDataGridView.DataSource = clients;

            // Устанавливаем русские названия столбцов
            var columnHeaders = new Dictionary<string, string>
            {
                { "Id", "Идентификатор" },
                { "Name", "Имя" },
                { "Surname", "Фамилия" },
                { "Birthday", "Дата рождения" },
                { "Email", "Адрес электронной почты" },
                { "Phone_number", "Номер телефона" }
            };
            Menu.SetColumnHeaders(clientsDataGridView, columnHeaders);
        }
        private void AddClient_Click(object sender, EventArgs e)
        {
            var form = new AddOrEditForm(typeof(Client));
            if (form.ShowDialog() == DialogResult.OK)
            {
                var newClient = (Client)form.GetEntity();
                Database.AddClient(newClient);
                LoadClients(); // Обновляем список клиентов
            }
        }
        private void EditClient_Click(object sender, EventArgs e)
        {
            if (clientsDataGridView.SelectedRows.Count > 0)
            {
                var selectedClient = (Client)clientsDataGridView.SelectedRows[0].DataBoundItem;
                var form = new AddOrEditForm(typeof(Client), selectedClient);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    Database.UpdateClient(selectedClient);
                    LoadClients(); // Обновляем список клиентов
                }
            }
        }
        private void DeleteClient_Click(object sender, EventArgs e)
        {
            if (clientsDataGridView.SelectedRows.Count > 0)
            {
                var selectedClient = (Client)clientsDataGridView.SelectedRows[0].DataBoundItem;
                var result = MessageBox.Show($"Вы уверены, что хотите удалить клиента {selectedClient.Name} {selectedClient.Surname}?",
                    "Подтверждение", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    Database.DeleteClient(selectedClient.Id); // Удаляем из базы
                    LoadClients();
                    MessageBox.Show("Клиент удален.", "Удаление", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Выберите клиента для удаления.");
            }
        }

        private void ClientsForm_Load(object sender, EventArgs e)
        {

        }
    }
}

