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
        { "EnsembleForm", "ensembles_catalog" },
        { "Musician", "musiciansDataGridView" },
        { "Composition", "compositionsDataGridView" },
        { "Client", "clientsDataGridView" },
        { "Vinyl", "dgvVinyls" }
    };

        public static string GetTableName(string className)
        {
            if (ClassToTableMap.TryGetValue(className, out var tableName))
            {
                return tableName;
            }
            // Логируем перед выбросом исключения
            Console.WriteLine($"Ошибка: неизвестный класс {className}. Проверьте ClassToTableMap.");
            throw new ArgumentException($"Неизвестный класс: {className}");
        }

        // Пример метода FindMaxId с использованием GetTableName
        public static int FindMaxId(string className)
        {
            using (var connection = new NpgsqlConnection(ConnectionString))
            {
                connection.Open();

                // Получаем имя таблицы через маппинг
                string tableName = GetTableName(className);

                // SQL-запрос для получения максимального значения Id
                string query = $"SELECT COALESCE(MAX(\"Id\"), 0) FROM \"{tableName}\"";
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
                    command.Parameters.AddWithValue("@id", musician.id);
                    command.Parameters.AddWithValue("@name", musician.name);
                    command.Parameters.AddWithValue("@surname", musician.surname);
                    command.Parameters.AddWithValue("@instrument", musician.instrument);
                    command.Parameters.AddWithValue("@date_of_birth", musician.date_of_birth);
                }
            );
        }

        public static void UpdateMusician(Musician musician)
        {
            ExecuteNonQuery(
                "UPDATE musicians_catalog SET name = @name, surname = @surname, instrument = @instrument, date_of_birth = @date_of_birth WHERE id = @id",
                command =>
                {
                    command.Parameters.AddWithValue("@id", musician.id);
                    command.Parameters.AddWithValue("@name", musician.name);
                    command.Parameters.AddWithValue("@surname", musician.surname);
                    command.Parameters.AddWithValue("@instrument", musician.instrument);
                    command.Parameters.AddWithValue("@date_of_birth", musician.date_of_birth);
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
                // Логируйте исключение или выводите его на консоль
                Console.WriteLine($"Ошибка при чтении данных: {ex.Message}");
                throw; // Или обработайте ошибку по-другому
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
                reader.GetDateTime(4)
            ));
        }

        public static void AddComposition(Composition composition)
        {
            ExecuteNonQuery(
                "INSERT INTO compositions_catalog (name, musician_id, ensemble_id, release_year) VALUES (@name, @musician_id, @ensemble_id, @release_year)",
                command =>
                {
                    command.Parameters.AddWithValue("@name", composition.name);
                    command.Parameters.AddWithValue("@musician_id", composition.musicianId);
                    command.Parameters.AddWithValue("@ensemble_id", composition.ensembleId);
                    command.Parameters.AddWithValue("@release_year", composition.releaseYear);
                }
            );
        }

        public static void UpdateComposition(Composition composition)
        {
            ExecuteNonQuery(
                "UPDATE compositions_catalog SET name = @name, musician_id = @musician_id, ensemble_id = @ensemble_id, release_year = @release_year WHERE id = @id",
                command =>
                {
                    command.Parameters.AddWithValue("@id", composition.id);
                    command.Parameters.AddWithValue("@name", composition.name);
                    command.Parameters.AddWithValue("@musician_id", composition.musicianId);
                    command.Parameters.AddWithValue("@ensemble_id", composition.ensembleId);
                    command.Parameters.AddWithValue("@release_year", composition.releaseYear);
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
        public static List<int> GetAvailableIdsForEntity(string entityName)
        {
            using var connection = new NpgsqlConnection("ваша строка подключения");
            connection.Open();

            var query = $@"
            SELECT generate_series(1, MAX(Id)) AS possible_id
            FROM {entityName}
            EXCEPT
            SELECT Id FROM {entityName};
            ";

            using var command = new NpgsqlCommand(query, connection);
            using var reader = command.ExecuteReader();

            var availableIds = new List<int>();
            while (reader.Read())
            {
                availableIds.Add(reader.GetInt32(0));
            }

            return availableIds;
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








        public static void AddCompositionWithProcedure(string title, int musicianId, int ensembleId, DateTime releaseDate)
        {
            using (var connection = new NpgsqlConnection(ConnectionString))
            {
                connection.Open();
                using (var command = new NpgsqlCommand("CALL add_composition(@Title, @MusicianId, @EnsembleId, @ReleaseDate)", connection))
                {
                    command.Parameters.AddWithValue("@Title", title);
                    command.Parameters.AddWithValue("@MusicianId", musicianId);
                    command.Parameters.AddWithValue("@EnsembleId", ensembleId);
                    command.Parameters.AddWithValue("@ReleaseDate", releaseDate);

                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (PostgresException ex)
                    {
                        MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка добавления", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
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
                            StickerNumber = reader.GetString(reader.GetOrdinal("StickerNumber")),
                            Title = reader.GetString(reader.GetOrdinal("Title")),
                            ReleaseDate = reader.GetDateTime(reader.GetOrdinal("ReleaseDate")),
                            WholesalePrice = reader.GetDecimal(reader.GetOrdinal("WholesalePrice")),
                            RetailPrice = reader.GetDecimal(reader.GetOrdinal("RetailPrice")),
                            SoldLastYear = reader.GetInt32(reader.GetOrdinal("SoldLastYear")),
                            SoldThisYear = reader.GetInt32(reader.GetOrdinal("SoldThisYear")),
                            Stock = reader.GetInt32(reader.GetOrdinal("Stock"))
                        });
                    }
                }
            }
            return vinyls;
        }

        // Добавление новой пластинки
        public static void AddVinyl(Vinyl vinyl)
        {
            using (var connection = new NpgsqlConnection(ConnectionString))
            {
                connection.Open();
                var query = @"
                INSERT INTO vinyl_records 
                (StickerNumber, Title, ReleaseDate, WholesalePrice, RetailPrice, SoldLastYear, SoldThisYear, Stock)
                VALUES 
                (@StickerNumber, @Title, @ReleaseDate, @WholesalePrice, @RetailPrice, @SoldLastYear, @SoldThisYear, @Stock)";
                using (var command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@StickerNumber", vinyl.StickerNumber);
                    command.Parameters.AddWithValue("@Title", vinyl.Title);
                    command.Parameters.AddWithValue("@ReleaseDate", vinyl.ReleaseDate);
                    command.Parameters.AddWithValue("@WholesalePrice", vinyl.WholesalePrice);
                    command.Parameters.AddWithValue("@RetailPrice", vinyl.RetailPrice);
                    command.Parameters.AddWithValue("@SoldLastYear", vinyl.SoldLastYear);
                    command.Parameters.AddWithValue("@SoldThisYear", vinyl.SoldThisYear);
                    command.Parameters.AddWithValue("@Stock", vinyl.Stock);
                    command.ExecuteNonQuery();
                }
            }
        }

        // Обновление данных пластинки
        public static void UpdateVinyl(Vinyl vinyl)
        {
            using (var connection = new NpgsqlConnection(ConnectionString))
            {
                connection.Open();
                var query = @"
                UPDATE vinyl_records
                SET StickerNumber = @StickerNumber, 
                    Title = @Title, 
                    ReleaseDate = @ReleaseDate, 
                    WholesalePrice = @WholesalePrice, 
                    RetailPrice = @RetailPrice, 
                    SoldLastYear = @SoldLastYear, 
                    SoldThisYear = @SoldThisYear, 
                    Stock = @Stock
                WHERE Id = @Id";
                using (var command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", vinyl.Id);
                    command.Parameters.AddWithValue("@StickerNumber", vinyl.StickerNumber);
                    command.Parameters.AddWithValue("@Title", vinyl.Title);
                    command.Parameters.AddWithValue("@ReleaseDate", vinyl.ReleaseDate);
                    command.Parameters.AddWithValue("@WholesalePrice", vinyl.WholesalePrice);
                    command.Parameters.AddWithValue("@RetailPrice", vinyl.RetailPrice);
                    command.Parameters.AddWithValue("@SoldLastYear", vinyl.SoldLastYear);
                    command.Parameters.AddWithValue("@SoldThisYear", vinyl.SoldThisYear);
                    command.Parameters.AddWithValue("@Stock", vinyl.Stock);
                    command.ExecuteNonQuery();
                }
            }
        }

        // Удаление пластинки
        public static void DeleteVinyl(int id)
        {
            using (var connection = new NpgsqlConnection(ConnectionString))
            {
                connection.Open();
                var query = "DELETE FROM vinyl_records WHERE Id = @Id";
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
