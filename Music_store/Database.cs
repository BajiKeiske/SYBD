using Npgsql;
using System.Collections.Generic;

namespace Music_store
{
    public static class Database
    {
        private const string ConnectionString = "Host=localhost;Port=5432;Database=Music_store;Username=postgres;Password=1111";

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
                            reader.GetString(3)  // instrument
                        ));
                    }
                }
            }
            return musicians;
        }
    }
}
