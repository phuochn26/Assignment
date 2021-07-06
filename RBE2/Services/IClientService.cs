using System;
using System.Collections.Generic;
using RBE2.Models;

namespace RBE2.Services
{
    public interface IClientService
    {
        List<Client> GetList();
        void Create(Client client);
        void Update(Client client);
        void Delete(int id);
    }
}