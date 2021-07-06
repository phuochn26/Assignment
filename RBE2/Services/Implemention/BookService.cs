using System;
using System.Collections.Generic;
using System.Linq;
using RBE2.Models;

namespace RBE2.Services.Implemention
{
    public class BookService : IBookService
    {
        private DataContext _dataContext;
        public BookService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public List<Book> GetList()
        {
            return _dataContext.Books.ToList();
        }
        public void Create(Book book)
        {
            using var transation = _dataContext.Database.BeginTransaction();
            try
            {
                var newBook = new Book()
                {
                    BookName = book.BookName,
                };
                _dataContext.Books.Add(newBook);
                _dataContext.SaveChanges();
                transation.Commit();
            }
            catch(Exception)
            {
                return;
            }
        }
        public void Update(Book book)
        {
            using var transation = _dataContext.Database.BeginTransaction();
            try
            {
                var newBook = _dataContext.Books.Find(book.BookId);
                newBook.BookName = book.BookName;
                newBook.ClientId = book.ClientId;
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
                _dataContext.Books.Remove(_dataContext.Books.Find(id));
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