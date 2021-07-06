using System;
using System.Collections.Generic;
using RBE2.Models;

namespace RBE2.Services
{
    public interface IAuthorService
    {
        List<Author> GetList();
        void Create(Author author);
        void Update(Author author);
        void Delete(int id);
    }
}