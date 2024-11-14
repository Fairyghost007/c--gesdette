using System;
using System.Data;
using MySql.Data.MySqlClient;
using Npgsql;
using Cours.Enum;

namespace Cours.Core
{
    public class DataBaseConnection : IDataAcess
    {
        private readonly Database _dbType;
        private IDbConnection? _conn;
        private readonly string _connectionString;

        public DataBaseConnection(Database dbType)
        {
            _dbType = dbType;

            // Use switch case to initialize the connection string
            switch (_dbType)
            {
                case Database.MYSQL:
                    _connectionString = "Server=localhost;Port=3306;Database=gestion_dette_symfony_ism;User ID=root;Password=localhost;";
                    break;

                case Database.POSTGRESQL:
                    _connectionString = "Host=localhost;Port=5432;Database=gesDette3;Username=postgres;Password=ghost;";
                    break;

                default:
                    throw new ArgumentException("Unsupported database type");
            }
        }

        public void CloseConnection()
        {
            if (_conn != null && _conn.State == ConnectionState.Open)
            {
                _conn.Close();
                _conn = null;
            }
        }

        public IDbConnection GetConnection()
        {
            if (_conn == null)
            {
                switch (_dbType)
                {
                    case Database.MYSQL:
                        _conn = new MySqlConnection(_connectionString);
                        break;

                    case Database.POSTGRESQL:
                        _conn = new NpgsqlConnection(_connectionString);
                        break;

                    default:
                        throw new ArgumentException("Unsupported database type");
                }

                _conn.Open();
            }

            return _conn;
        }
    }
}
