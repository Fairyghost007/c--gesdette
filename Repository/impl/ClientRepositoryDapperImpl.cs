using Cours.Core;
using Cours.Models;
using Dapper;
using System.Data;

namespace Cours.Repository
{
    public class ClientRepositoryDapperImpl : IClientRepository
    {
        private readonly IDataAcess dataAcess;

        public ClientRepositoryDapperImpl(IDataAcess dataAcess)
        {
            this.dataAcess = dataAcess;
        }

        public void Delete(int id)
        {
            using (var conn = dataAcess.GetConnection())
            {
                string query = "DELETE FROM client WHERE id = @Id";
                conn.Execute(query, new { Id = id });
                Console.WriteLine("Client deleted successfully.");
            }
        }

        public Client? FindBySurname(string surname)
        {
            using (var conn = dataAcess.GetConnection())
            {
                string query = "SELECT * FROM client WHERE surname = @Surname";
                return conn.QueryFirstOrDefault<Client>(query, new { Surname = surname });
            }
        }

        public void Insert(Client entity)
        {
            using (var conn = dataAcess.GetConnection())
            {
                string query = "INSERT INTO client (surname, telephone, adresse, create_at, update_at) " +
                               "VALUES (@Surname, @Telephone, @Adresse, @CreateAt, @UpdateAt); " +
                               "SELECT LAST_INSERT_ID();";

                var id = conn.ExecuteScalar<int>(query, new
                {
                    Surname = entity.Surnom,
                    Telephone = entity.Telephone,
                    Adresse = entity.Adresse,
                    CreateAt = DateTime.Now,
                    UpdateAt = DateTime.Now
                });

                entity.Id = id;
                Console.WriteLine("Client added successfully.");
            }
        }

        public List<Client> SelectAll()
        {
            using (var conn = dataAcess.GetConnection())
            {
                string query = "SELECT * FROM client";
                return conn.Query<Client>(query).ToList();
            }
        }

        public Client? SelectById(int id)
        {
            using (var conn = dataAcess.GetConnection())
            {
                string query = "SELECT * FROM client WHERE id = @Id";
                return conn.QueryFirstOrDefault<Client>(query, new { Id = id });
            }
        }

        public void Update(Client entity)
        {
            using (var conn = dataAcess.GetConnection())
            {
                string query = "UPDATE client SET surname = @Surname, telephone = @Telephone, adresse = @Adresse WHERE id = @Id";

                conn.Execute(query, new
                {
                    Id = entity.Id,
                    Surname = entity.Surnom,
                    Telephone = entity.Telephone,
                    Adresse = entity.Adresse
                });

                Console.WriteLine("Client updated successfully.");
            }
        }
    }
}
