using System;
using System.Collections.Generic;
using System.Linq;
using RBE2.Models;

namespace RBE2.Services.Implemention
{
    public class ClientService : IClientService
    {
        private DataContext _dataContext;
        public ClientService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public List<Client> GetList()
        {
            return _dataContext.Cilents.ToList();
        }
        public void Create(Client client)
        {
            using var transation = _dataContext.Database.BeginTransaction();
            try
            {
                var newClient = new Client()
                {
                    ClientName = client.ClientName,
                    Books = client.Books
                };
                _dataContext.Cilents.Add(newClient);
                _dataContext.SaveChanges();
                transation.Commit();
            }
            catch(Exception)
            {
                return;
            }
        }
        public void Update(Client client)
        {
            using var transation = _dataContext.Database.BeginTransaction();
            try
            {
                var newClient = _dataContext.Cilents.Find(client.ClientId);
                newClient.ClientName = client.ClientName;
                newClient.Books = client.Books;
                _dataContext.SaveChanges();
                transation.Commit();
            }
            catch(Exception)
            {
                return;
            }
        }

        public void Delete(int id)
        {
            using var transation = _dataContext.Database.BeginTransaction();
            try
            {
                _dataContext.Cilents.Remove(_dataContext.Cilents.Find(id));
                _dataContext.SaveChanges();
                transation.Commit();
            }
            catch(Exception)
            {
                return;
            }
        }
    }
}