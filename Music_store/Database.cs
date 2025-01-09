using Npgsql;
using System.Collections.Generic;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Xml.Linq;

namespace Music_store
{
    public static class Database
    {
        private const string ConnectionString = "Host=localhost;Port=5432;Database=Music_store;Username=postgres;Password=1111;SearchPath=kursach";

        public static List<Musician> GetMusicians()
        {
            var musicians = new List<Musician>();
            using (var connection = new NpgsqlConnection(ConnectionString))
            {
                connection.Open();
                var command = new NpgsqlCommand("SELECT * FROM musicians_catalog", connection);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        musicians.Add(new Musician(
                            reader.GetInt32(0), // id
                            reader.GetString(1), // name
                            reader.GetString(2), // surname
                            reader.GetString(3), // instrument
                            reader.GetDateTime(4) // date_of_birth
                        ));
                    }
                }
            }
            return musicians;
        }
        public static void AddMusician(Musician musician)
        {
            using (var connection = new NpgsqlConnection(ConnectionString))
            {
                connection.Open();

                var command = new NpgsqlCommand(
                    "INSERT INTO kursach.musicians_catalog (id, name, surname, instrument, date_of_birth) VALUES (@id, @name, @surname, @instrument, @date_of_birth)",
                    connection
                );

                // Параметры для защиты от SQL-инъекций
                command.Parameters.AddWithValue("@id", musician.id);
                command.Parameters.AddWithValue("@name", musician.name);
                command.Parameters.AddWithValue("@surname", musician.surname);
                command.Parameters.AddWithValue("@instrument", musician.instrument);
                command.Parameters.AddWithValue("@date_of_birth", musician.date_of_birth);

                command.ExecuteNonQuery(); // Выполняем команду
            }
        }

        public static void UpdateMusician(Musician musician)
        {
            using (var connection = new NpgsqlConnection(ConnectionString))
            {
                connection.Open();
                var command = new NpgsqlCommand(
                    "UPDATE musicians_catalog SET name = @name, surname = @surname, instrument = @instrument, date_of_birth = @date_of_birth WHERE id = @id",
                    connection
                );
                command.Parameters.AddWithValue("@id", musician.id);
                command.Parameters.AddWithValue("@name", musician.name);
                command.Parameters.AddWithValue("@surname", musician.surname);
                command.Parameters.AddWithValue("@instrument", musician.instrument);
                command.Parameters.AddWithValue("@date_of_birth", musician.date_of_birth);
                command.ExecuteNonQuery();
            }
        }
        public static void DeleteMusician(int id)
        {
            using (var connection = new NpgsqlConnection(ConnectionString))
            {
                connection.Open();
                var command = new NpgsqlCommand("DELETE FROM musicians_catalog WHERE id = @id", connection);
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();
            }
        }

                //КЛИЕНТЫ
        public static List<Client> GetClients()
        {
            var clients = new List<Client>();
            using (var connection = new NpgsqlConnection(ConnectionString))
            {
                connection.Open();
                var command = new NpgsqlCommand("SELECT * FROM clients_catalog", connection);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        clients.Add(new Client
                        {
                            surname = reader.GetString(0),
                            name = reader.GetString(1),
                            birthday = reader.GetDateTime(2),
                            phone_number = reader.GetString(3),
                            id = reader.GetInt32(4),
                            email = reader.GetString(5),
                            
                        });
                    }
                }
            }
            return clients;
        }

        public static void AddClient(Client client)
        {
            using (var connection = new NpgsqlConnection(ConnectionString))
            {
                connection.Open();

                var command = new NpgsqlCommand(
                    "INSERT INTO clients_catalog (id, name, surname, birthday, email, phone_number)  VALUES (@id, @name, @surname, @birthday, @email, @phone_number)",
                    connection
                );

                // Параметры для защиты от SQL-инъекций
                command.Parameters.AddWithValue("id", client.id);
                command.Parameters.AddWithValue("name", client.name);
                command.Parameters.AddWithValue("surname", client.surname);
                command.Parameters.AddWithValue("birthday", client.birthday);
                command.Parameters.AddWithValue("phone_number", client.phone_number);
                command.Parameters.AddWithValue("email", client.email);
                command.ExecuteNonQuery();
            }
        }

        public static void UpdateClient(Client client)
        {
            using (var connection = new NpgsqlConnection(ConnectionString))
            {
                connection.Open();
                var command = new NpgsqlCommand(
                    "UPDATE clients_catalog SET name = @name, surname = @surname, birthday = @birthday, email = @email, phone_number = @phone_number WHERE id = @id",
                    connection
                );
                command.Parameters.AddWithValue("id", client.id);
                command.Parameters.AddWithValue("name", client.name);
                command.Parameters.AddWithValue("surname", client.surname);
                command.Parameters.AddWithValue("birthday", client.birthday);
                command.Parameters.AddWithValue("phone_number", client.phone_number);
                command.Parameters.AddWithValue("email", client.email);
                command.ExecuteNonQuery();
            }
        }
        public static void DeleteClient(int clientId)
        {
            using (var connection = new NpgsqlConnection(ConnectionString))
            {
                connection.Open();
                var command = new NpgsqlCommand("DELETE FROM clients_catalog WHERE id = @id", connection);
                command.Parameters.AddWithValue("id", clientId);
                command.ExecuteNonQuery();
            }
        }


        //
        public static List<Composition> GetCompositions()
        {
            var compositions = new List<Composition>();
            using (var connection = new NpgsqlConnection(ConnectionString))
            {
                connection.Open();
                var command = new NpgsqlCommand("SELECT id, name, musician_id, ensemble_id, release_year FROM compositions_catalog", connection);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        compositions.Add(new Composition(
                            reader.GetInt32(0), // id
                            reader.GetString(1), // name
                            reader.GetInt32(2), // musician_id
                            reader.GetInt32(3), // ensemble_id
                            reader.GetDateTime(4) // release_year
                        ));
                    }
                }
            }
            return compositions;
        }
        public static void AddComposition(Composition composition)
        {
            using (var connection = new NpgsqlConnection(ConnectionString))
            {
                connection.Open();
                var command = new NpgsqlCommand(
                    "INSERT INTO compositions_catalog (name, musician_id, ensemble_id, release_year) VALUES (@name, @musician_id, @ensemble_id, @release_year)",
                    connection);
                command.Parameters.AddWithValue("name", composition.Name);
                command.Parameters.AddWithValue("musician_id", composition.MusicianId);
                command.Parameters.AddWithValue("ensemble_id", composition.EnsembleId);
                command.Parameters.AddWithValue("release_year", composition.ReleaseYear);
                command.ExecuteNonQuery();
            }
        }
        public static void UpdateComposition(Composition composition)
        {
            using (var connection = new NpgsqlConnection(ConnectionString))
            {
                connection.Open();
                var command = new NpgsqlCommand(
                    "UPDATE compositions_catalog SET name = @name, musician_id = @musician_id, ensemble_id = @ensemble_id, release_year = @release_year WHERE id = @id",
                    connection);
                command.Parameters.AddWithValue("id", composition.Id);
                command.Parameters.AddWithValue("name", composition.Name);
                command.Parameters.AddWithValue("musician_id", composition.MusicianId);
                command.Parameters.AddWithValue("ensemble_id", composition.EnsembleId);
                command.Parameters.AddWithValue("release_year", composition.ReleaseYear);
                command.ExecuteNonQuery();
            }
        }
        public static void DeleteComposition(int compositionId)
        {
            using (var connection = new NpgsqlConnection(ConnectionString))
            {
                connection.Open();
                var command = new NpgsqlCommand("DELETE FROM compositions_catalog WHERE id = @id", connection);
                command.Parameters.AddWithValue("id", compositionId);
                command.ExecuteNonQuery();
            }
        }

    }
}
