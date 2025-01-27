using Npgsql;
using System.Collections.Generic;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Xml.Linq;
using Music_store.Entities;
using System;
using System.Windows.Forms;

namespace Music_store
{
    public static class Database
    {
        private const string ConnectionString = "Host=localhost;Port=5432;Database=Music_store;Username=postgres;Password=1111;SearchPath=kursach";

        // Общий метод выполнения команд без возврата данных
        private static void ExecuteNonQuery(string query, Action<NpgsqlCommand> addParameters)
        {
            try
            {
                using (var connection = new NpgsqlConnection(ConnectionString))
                {
                    connection.Open();
                    using (var command = new NpgsqlCommand(query, connection))
                    {
                        addParameters?.Invoke(command);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка выполнения запроса: {ex.Message}");
            }
        }

        // Общий метод для получения данных из базы
        private static List<T> ExecuteReader<T>(string query, Func<NpgsqlDataReader, T> map, Action<NpgsqlCommand> addParameters = null)
        {
            var result = new List<T>();
            using (var connection = new NpgsqlConnection(ConnectionString))
            {
                connection.Open();
                using (var command = new NpgsqlCommand(query, connection))
                {
                    addParameters?.Invoke(command);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add(map(reader));
                        }
                    }
                }
            }
            return result;
        }
        
        public static readonly Dictionary<string, string> ClassToTableMap = new()
        {
            { "Ensembles", "ensembles_catalog" },
            { "Musicians", "musicians_catalog" },
            { "Compositions", "compositions_catalog" },
            { "Clients", "clients_catalog" },
            { "Vinyls", "vinyl_record" }
        };

        public static string GetTableName(string className)
        {
            if (ClassToTableMap.TryGetValue(className, out var tableName))
            {
                return tableName;
            }
            Console.WriteLine($"Ошибка: неизвестный класс {className}. Проверьте ClassToTableMap.");
            throw new ArgumentException($"Неизвестный класс: {className}");
        }

        public static int FindMaxId(string className)
        {
            using (var connection = new NpgsqlConnection(ConnectionString))
            {
                connection.Open();

                // Получаем имя таблицы через маппинг
                string tableName = GetTableName(className);

                // SQL-запрос для получения максимального значения Id
                string query = $"SELECT COALESCE(MAX(\"id\"), 0) FROM \"{tableName}\"";
                using (var command = new NpgsqlCommand(query, connection))
                {
                    return Convert.ToInt32(command.ExecuteScalar()) + 1;
                }
            }
        }

        // Музыканты
        public static List<Musician> GetMusicians()
        {
            return ExecuteReader("SELECT * FROM musicians_catalog", reader => new Musician(
                reader.GetInt32(0),
                reader.GetString(1),
                reader.GetString(2),
                reader.GetString(3),
                reader.GetDateTime(4)
            ));
        }

        public static void AddMusician(Musician musician)
        {
            ExecuteNonQuery(
                "INSERT INTO musicians_catalog (id, name, surname, instrument, date_of_birth) VALUES (@id, @name, @surname, @instrument, @date_of_birth)",
                command =>
                {
                    command.Parameters.AddWithValue("@id", musician.Id);
                    command.Parameters.AddWithValue("@name", musician.Name);
                    command.Parameters.AddWithValue("@surname", musician.Surname);
                    command.Parameters.AddWithValue("@instrument", musician.Instrument);
                    command.Parameters.AddWithValue("@date_of_birth", musician.Date_of_birth);
                }
            );
        }

        public static void UpdateMusician(Musician musician)
        {
            ExecuteNonQuery(
                "UPDATE musicians_catalog SET name = @name, surname = @surname, instrument = @instrument, date_of_birth = @date_of_birth WHERE id = @id",
                command =>
                {
                    command.Parameters.AddWithValue("@id", musician.Id);
                    command.Parameters.AddWithValue("@name", musician.Name);
                    command.Parameters.AddWithValue("@surname", musician.Surname);
                    command.Parameters.AddWithValue("@instrument", musician.Instrument);
                    command.Parameters.AddWithValue("@date_of_birth", musician.Date_of_birth);
                }
            );
        }

        public static void DeleteMusician(int id)
        {
            ExecuteNonQuery(
                "DELETE FROM musicians_catalog WHERE id = @id",
                command => command.Parameters.AddWithValue("@id", id)
            );
        }

        // Клиенты
        public static List<Client> GetClients()
        {
            try
            {
                return ExecuteReader("SELECT * FROM clients_catalog", reader => new Client
                {
                    Surname = reader.GetString(0),
                    Name = reader.GetString(1),
                    Birthday = reader.GetDateTime(2),
                    Phone_number = reader.GetString(3),
                    Id = reader.GetInt32(4),
                    Email = reader.GetString(5),

                });
            }
            catch (InvalidCastException ex)
            {
                Console.WriteLine($"Ошибка при чтении данных: {ex.Message}");
                throw; 
            }
        }

        public static void AddClient(Client client)
        {
            ExecuteNonQuery(
                "INSERT INTO clients_catalog (id, name, surname, birthday, email, phone_number) VALUES (@id, @name, @surname, @birthday, @email, @phone_number)",
                command =>
                {
                    command.Parameters.AddWithValue("@id", client.Id);
                    command.Parameters.AddWithValue("@name", client.Name);
                    command.Parameters.AddWithValue("@surname", client.Surname);
                    command.Parameters.AddWithValue("@birthday", client.Birthday);
                    command.Parameters.AddWithValue("@email", client.Email);
                    command.Parameters.AddWithValue("@phone_number", client.Phone_number);
                }
            );
        }

        public static void UpdateClient(Client client)
        {
            ExecuteNonQuery(
                "UPDATE clients_catalog SET name = @name, surname = @surname, birthday = @birthday, email = @email, phone_number = @phone_number WHERE id = @id",
                command =>
                {
                    command.Parameters.AddWithValue("@id", client.Id);
                    command.Parameters.AddWithValue("@name", client.Name);
                    command.Parameters.AddWithValue("@surname", client.Surname);
                    command.Parameters.AddWithValue("@birthday", client.Birthday);
                    command.Parameters.AddWithValue("@email", client.Email);
                    command.Parameters.AddWithValue("@phone_number", client.Phone_number);
                }
            );
        }

        public static void DeleteClient(int clientId)
        {
            ExecuteNonQuery(
                "DELETE FROM clients_catalog WHERE id = @id",
                command => command.Parameters.AddWithValue("@id", clientId)
            );
        }

        // Композиции
        public static List<Composition> GetCompositions()
        {
            return ExecuteReader("SELECT * FROM compositions_catalog", reader => new Composition(
                reader.GetInt32(0),
                reader.GetString(1),
                reader.GetInt32(2),
                reader.GetInt32(3),
                reader.GetInt32(4)
            ));
        }

        public static void AddComposition(Composition composition)
        {
            ExecuteNonQuery(
                "INSERT INTO compositions_catalog (name, musician_id, ensemble_id, release_year) VALUES (@name, @musician_id, @ensemble_id, @release_year)",
                command =>
                {
                    command.Parameters.AddWithValue("@name", composition.Name);
                    command.Parameters.AddWithValue("@musician_id", composition.MusicianId);
                    command.Parameters.AddWithValue("@ensemble_id", composition.EnsembleId);
                    command.Parameters.AddWithValue("@release_year", composition.ReleaseYear);
                }
            );
        }

        public static void UpdateComposition(Composition composition)
        {
            ExecuteNonQuery(
                "UPDATE compositions_catalog SET name = @name, musician_id = @musician_id, ensemble_id = @ensemble_id, release_year = @release_year WHERE id = @id",
                command =>
                {
                    command.Parameters.AddWithValue("@id", composition.Id);
                    command.Parameters.AddWithValue("@name", composition.Name);
                    command.Parameters.AddWithValue("@musician_id", composition.MusicianId);
                    command.Parameters.AddWithValue("@ensemble_id", composition.EnsembleId);
                    command.Parameters.AddWithValue("@release_year", composition.ReleaseYear);
                }
            );
        }

        public static void DeleteComposition(int compositionId)
        {
            ExecuteNonQuery(
                "DELETE FROM compositions_catalog WHERE id = @id",
                command => command.Parameters.AddWithValue("@id", compositionId)
            );
        }

        // Ансамбли
        public static List<Ensemble> GetEnsembles()
        {
            return ExecuteReader("SELECT * FROM ensembles_catalog", reader => new Ensemble
            {
                Id = reader.GetInt32(0),
                Name = reader.GetString(1),
                Date_founded = reader.GetDateTime(2)
            });
        }

        public static List<Ensemble> GetEnsemblesByMusician(int musicianId)
        {
            return ExecuteReader(
                "SELECT * FROM ensembles_catalog WHERE musician_id = @musicianId",
                reader => new Ensemble
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Date_founded = reader.GetDateTime(2)
                },
                command => command.Parameters.AddWithValue("@musicianId", musicianId)
            );
        }

        public static void AddEnsemble(Ensemble ensemble)
        {
            try
            {
                ExecuteNonQuery(
                    "INSERT INTO ensembles_catalog (id, name, date_founded) VALUES (@id, @name, @date_founded)",
                    command =>
                    {
                        command.Parameters.AddWithValue("@id", ensemble.Id);
                        command.Parameters.AddWithValue("@name", ensemble.Name);
                        command.Parameters.AddWithValue("@date_founded", ensemble.Date_founded);
                    }
                );
            }
            catch (PostgresException ex) when (ex.SqlState == "23505") // Код ошибки уникальности
            {
                var nextAvailableId = GetNextAvailableId();
                MessageBox.Show($"ID {ensemble.Id} уже существует. Вы можете использовать ID {nextAvailableId}.", "Ошибка добавления", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private static int GetNextAvailableId()
        {
            using (var connection = new NpgsqlConnection(ConnectionString))
            {
                connection.Open();
                var query = "SELECT COALESCE(MAX(id), 0) + 1 FROM ensembles_catalog";
                using (var command = new NpgsqlCommand(query, connection))
                {
                    return Convert.ToInt32(command.ExecuteScalar());
                }
            }
        }

        // Получает список доступных идентификаторов, которые отсутствуют в таблице базы данных указанной сущности.
        public static List<int> GetAvailableIdsForEntity(string entityName)
{
            try
            {
                using (var connection = new NpgsqlConnection(ConnectionString))
                {
                    connection.Open();

                    var query = $@"
                    SELECT generate_series(1, MAX(Id)) AS possible_id
                    FROM {entityName}
                    EXCEPT
                    SELECT Id FROM {entityName};
                    ";

                    using (var command = new NpgsqlCommand(query, connection))
                    using (var reader = command.ExecuteReader())
                    {
                        var availableIds = new List<int>();
                        while (reader.Read())
                        {
                            availableIds.Add(reader.GetInt32(0));
                        }
                        return availableIds;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка выполнения запроса: {ex.Message}");
                return new List<int>(); // Возвращаем пустой список в случае ошибки
            }
        }
        public static void UpdateEnsemble(Ensemble ensemble)
        {
            ExecuteNonQuery(
                "UPDATE ensembles_catalog SET name = @name, date_founded = @date_founded WHERE id = @id",
                command =>
                {
                    command.Parameters.AddWithValue("@id", ensemble.Id);
                    command.Parameters.AddWithValue("@name", ensemble.Name);
                    command.Parameters.AddWithValue("@date_founded", ensemble.Date_founded);
                }
            );
        }

        public static void DeleteEnsemble(int ensembleId)
        {
            ExecuteNonQuery(
                "DELETE FROM ensembles_catalog WHERE id = @id",
                command => command.Parameters.AddWithValue("@id", ensembleId)
            );
        }








       
        // Получение всех пластинок из базы данных
        public static List<Vinyl> GetVinyls()
        {
            var vinyls = new List<Vinyl>();

            using (var connection = new NpgsqlConnection(ConnectionString))
            {
                connection.Open();
                var query = "SELECT * FROM vinyl_records";
                using (var command = new NpgsqlCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        vinyls.Add(new Vinyl
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            LabelNumber = reader.GetString(reader.GetOrdinal("label_number")),
                            Title = reader.GetString(reader.GetOrdinal("Title")),
                            ReleaseYear = reader.GetInt32(reader.GetOrdinal("Release_year")),
                            MusicianId = reader.GetInt32(reader.GetOrdinal("Musician_id")),
                            EnsembleId = reader.GetInt32(reader.GetOrdinal("Ensemble_id")),
                            Genre = reader.GetString(reader.GetOrdinal("Genre")),
                            WholesalePrice = reader.GetDecimal(reader.GetOrdinal("Wholesale_price")),
                            RetailPrice = reader.GetDecimal(reader.GetOrdinal("Retail_price")),
                            SoldLastYear = reader.GetInt32(reader.GetOrdinal("Sold_last_year")),
                            SoldThisYear = reader.GetInt32(reader.GetOrdinal("Sold_this_year")),
                            Stock = reader.GetInt32(reader.GetOrdinal("Stock")),
                            Image = reader["image"] as byte[] // Проверяем значение на null
                        });
                    }
                }
            }
            return vinyls;
        }

        public static void AddVinyl(Vinyl vinyl)
        {
            using (var connection = new NpgsqlConnection(ConnectionString))
            {
                connection.Open();
                var query = @"
            INSERT INTO vinyl_records 
            (label_number, title, release_year, musician_id, ensemble_id, genre, wholesale_price, retail_price, sold_last_year, sold_this_year, stock, image)
            VALUES 
            (@LabelNumber, @Title, @ReleaseYear, @MusicianId, @EnsembleId, @Genre, @WholesalePrice, @RetailPrice, @SoldLastYear, @SoldThisYear, @Stock, @Image)";
                using (var command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@LabelNumber", vinyl.LabelNumber);
                    command.Parameters.AddWithValue("@Title", vinyl.Title);
                    command.Parameters.AddWithValue("@ReleaseYear", vinyl.ReleaseYear);
                    command.Parameters.AddWithValue("@MusicianId", vinyl.MusicianId);
                    command.Parameters.AddWithValue("@EnsembleId", vinyl.EnsembleId);
                    command.Parameters.AddWithValue("@Genre", vinyl.Genre);
                    command.Parameters.AddWithValue("@WholesalePrice", vinyl.WholesalePrice);
                    command.Parameters.AddWithValue("@RetailPrice", vinyl.RetailPrice);
                    command.Parameters.AddWithValue("@SoldLastYear", vinyl.SoldLastYear);
                    command.Parameters.AddWithValue("@SoldThisYear", vinyl.SoldThisYear);
                    command.Parameters.AddWithValue("@Stock", vinyl.Stock);
                    command.Parameters.AddWithValue("@Image", (object)vinyl.Image ?? DBNull.Value); // Учитываем возможное отсутствие изображения
                    command.ExecuteNonQuery();
                }
            }
        }

        public static void UpdateVinyl(Vinyl vinyl)
        {
            using (var connection = new NpgsqlConnection(ConnectionString))
            {
                connection.Open();
                var query = @"
            UPDATE vinyl_records
            SET label_number = @LabelNumber,
                title = @Title,
                release_year = @ReleaseYear,
                musician_id = @MusicianId,
                ensemble_id = @EnsembleId,
                genre = @Genre,
                wholesale_price = @WholesalePrice,
                retail_price = @RetailPrice,
                sold_last_year = @SoldLastYear,
                sold_this_year = @SoldThisYear,
                stock = @Stock,
                image = @Image
            WHERE id = @Id";
                using (var command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", vinyl.Id);
                    command.Parameters.AddWithValue("@LabelNumber", vinyl.LabelNumber);
                    command.Parameters.AddWithValue("@Title", vinyl.Title);
                    command.Parameters.AddWithValue("@ReleaseYear", vinyl.ReleaseYear);
                    command.Parameters.AddWithValue("@MusicianId", vinyl.MusicianId);
                    command.Parameters.AddWithValue("@EnsembleId", vinyl.EnsembleId);
                    command.Parameters.AddWithValue("@Genre", vinyl.Genre);
                    command.Parameters.AddWithValue("@WholesalePrice", vinyl.WholesalePrice);
                    command.Parameters.AddWithValue("@RetailPrice", vinyl.RetailPrice);
                    command.Parameters.AddWithValue("@SoldLastYear", vinyl.SoldLastYear);
                    command.Parameters.AddWithValue("@SoldThisYear", vinyl.SoldThisYear);
                    command.Parameters.AddWithValue("@Stock", vinyl.Stock);
                    command.Parameters.AddWithValue("@Image", (object)vinyl.Image ?? DBNull.Value);
                    command.ExecuteNonQuery();
                }
            }
        }

        public static void DeleteVinyl(int id)
        {
            using (var connection = new NpgsqlConnection(ConnectionString))
            {
                connection.Open();
                var query = "DELETE FROM vinyl_records WHERE id = @Id";
                using (var command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                }
            }
        }
        //Сохранение изменений списка пластинок
        public static void SaveVinyls(List<Vinyl> vinyls)
        {
            foreach (var vinyl in vinyls)
            {
                if (vinyl.Id == 0)
                    AddVinyl(vinyl);
                else
                    UpdateVinyl(vinyl);
            }
        }
    }
}