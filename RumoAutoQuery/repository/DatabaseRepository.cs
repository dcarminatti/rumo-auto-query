using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;

namespace RumoAutoQuery.repository
{
    internal class DatabaseRepository
    {
        private readonly string source = "source";
        private readonly string user = "user";
        private readonly string password = "password";
        private readonly string _connectionString;

        public DatabaseRepository()
        {
            this._connectionString = $"Data Source={source};User Id={user};Password={password};";
        }

        public List<String> findAllByProductKey(List<string> productKeys)
        {
            List<String> result = new List<string>();

            using (var connection = new OracleConnection(this._connectionString))
            {
                connection.Open();

                string stringProductKeys = string.Join(",", productKeys);

                var command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM table WHERE key IN (:productKeys)";
                command.Parameters.Add(new OracleParameter("productKeys", stringProductKeys));

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(reader.GetString(0));
                    }
                }
            }

            return result;
        }
    }
}
