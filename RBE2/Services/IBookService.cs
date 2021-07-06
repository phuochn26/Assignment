using System;
using System.Collections.Generic;
using RBE2.Models;

namespace RBE2.Services
{
    public interface IBookService
    {
        List<Book> GetList();
        void Create(Book book);
        void Update(Book book);
        void Delete(int id);
    }
}