using Cours.Core;
using Cours.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cours.Repository
{
    public class ClientRepositoryEntityFrameworkImpl : IClientRepository
    {
        private readonly DbContext _context;

        public ClientRepositoryEntityFrameworkImpl(DbContext context)
        {
            _context = context;
        }

        public List<Client> SelectAll()
        {
            return _context.Set<Client>().ToList();
        }

        public Client? SelectById(int id)
        {
            return _context.Set<Client>().Find(id);
        }

        public void Insert(Client entity)
        {
            entity.CreateAt = DateTime.Now;
            entity.UpdateAt = DateTime.Now;
            _context.Set<Client>().Add(entity);
            _context.SaveChanges();
        }

        public void Update(Client entity)
        {
            var client = _context.Set<Client>().Find(entity.Id);
            if (client != null)
            {
                client.Surnom = entity.Surnom;
                client.Telephone = entity.Telephone;
                client.Adresse = entity.Adresse;
                client.UpdateAt = DateTime.Now;

                _context.Set<Client>().Update(client);
                _context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var client = _context.Set<Client>().Find(id);
            if (client != null)
            {
                _context.Set<Client>().Remove(client);
                _context.SaveChanges();
            }
        }

        public Client? FindBySurname(string surname)
        {
            return _context.Set<Client>().FirstOrDefault(c => c.Surnom == surname);
        }
    }
}
