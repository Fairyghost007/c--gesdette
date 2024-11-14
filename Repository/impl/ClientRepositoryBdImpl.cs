using Cours.Core;
using Cours.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace Cours.Repository
{
    public class ClientRepositoryBdImpl : IClientRepository
    {
        private readonly IDataAcess _dataAccess;

        public ClientRepositoryBdImpl(IDataAcess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public void Delete(int id)
        {
            using (var conn = _dataAccess.GetConnection())
            {
                string query = "DELETE FROM client WHERE client.id = @id;";
                using (IDbCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = query;
                    cmd.Parameters.Add(new Npgsql.NpgsqlParameter("@id", id)); // Use NpgsqlParameter or MySqlParameter based on connection type
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Client deleted successfully.");
                }
            }
        }

        public Client? FindBySurname(string surname)
        {
            Client? client = null;
            using (var conn = _dataAccess.GetConnection())
            {
                string query = "SELECT * FROM client WHERE surname = @surnom";
                using (IDbCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = query;
                    cmd.Parameters.Add(new Npgsql.NpgsqlParameter("@surnom", surname)); // Parameter type based on connection
                    using (IDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            client = new Client
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("id")),
                                Surnom = reader.GetString(reader.GetOrdinal("surname")),
                                Telephone = reader.GetString(reader.GetOrdinal("telephone")),
                                Adresse = reader.GetString(reader.GetOrdinal("adresse"))
                            };
                        }
                    }
                }
            }
            return client;
        }

        public void Insert(Client entity)
        {
            using (var conn = _dataAccess.GetConnection())
            {
                string query = "INSERT INTO client (surname, telephone, adresse, create_at, update_at) VALUES (@surnom, @telephone, @adresse, @createAt, @updateAt)";
                using (IDbCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = query;
                    cmd.Parameters.Add(new Npgsql.NpgsqlParameter("@surnom", entity.Surnom));
                    cmd.Parameters.Add(new Npgsql.NpgsqlParameter("@telephone", entity.Telephone));
                    cmd.Parameters.Add(new Npgsql.NpgsqlParameter("@adresse", entity.Adresse));
                    cmd.Parameters.Add(new Npgsql.NpgsqlParameter("@createAt", DateTime.Now));
                    cmd.Parameters.Add(new Npgsql.NpgsqlParameter("@updateAt", DateTime.Now));
                    cmd.ExecuteNonQuery();

                    Console.WriteLine("Client added successfully.");
                }
            }
        }

        public List<Client> SelectAll()
        {
            List<Client> clients = new List<Client>();
            using (var conn = _dataAccess.GetConnection())
            {
                string query = "SELECT * FROM client";
                using (IDbCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = query;
                    using (IDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            clients.Add(new Client
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("id")),
                                Surnom = reader.GetString(reader.GetOrdinal("surname")),
                                Telephone = reader.GetString(reader.GetOrdinal("telephone")),
                                Adresse = reader.GetString(reader.GetOrdinal("adresse"))
                            });
                        }
                    }
                }
            }
            return clients;
        }

        public Client? SelectById(int id)
        {
            Client? client = null;
            using (var conn = _dataAccess.GetConnection())
            {
                string query = "SELECT * FROM client WHERE id = @id";
                using (IDbCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = query;
                    cmd.Parameters.Add(new Npgsql.NpgsqlParameter("@id", id));
                    using (IDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            client = new Client
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("id")),
                                Surnom = reader.GetString(reader.GetOrdinal("surname")),
                                Telephone = reader.GetString(reader.GetOrdinal("telephone")),
                                Adresse = reader.GetString(reader.GetOrdinal("adresse"))
                            };
                        }
                    }
                }
            }
            return client;
        }

        public void Update(Client entity)
        {
            using (var conn = _dataAccess.GetConnection())
            {
                string query = "UPDATE client SET adresse = @adresse, surname = @surname, telephone = @telephone WHERE client.id = @id;";
                using (IDbCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = query;
                    cmd.Parameters.Add(new Npgsql.NpgsqlParameter("@id", entity.Id));
                    cmd.Parameters.Add(new Npgsql.NpgsqlParameter("@surname", entity.Surnom));
                    cmd.Parameters.Add(new Npgsql.NpgsqlParameter("@telephone", entity.Telephone));
                    cmd.Parameters.Add(new Npgsql.NpgsqlParameter("@adresse", entity.Adresse));
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Client updated successfully.");
                }
            }
        }
    }
}
