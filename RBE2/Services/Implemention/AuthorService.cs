using System;
using System.Collections.Generic;
using System.Linq;
using RBE2.Models;

namespace RBE2.Services.Implemention
{
    public class AuthorService : IAuthorService
    {
        private DataContext _dataContext;
        public AuthorService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public List<Author> GetList()
        {
            return _dataContext.Authors.ToList();
        }
        public void Create(Author author)
        {
            using var transation = _dataContext.Database.BeginTransaction();
            try
            {
                var newAuthor = new Author()
                {
                    AuthorName = author.AuthorName,
                };
                _dataContext.Authors.Add(newAuthor);
                _dataContext.SaveChanges();
                transation.Commit();
            }
            catch(Exception)
            {
                return;
            }
        }
        public void Update(Author author)
        {
            using var transation = _dataContext.Database.BeginTransaction();
            try
            {
                var newAuthor = _dataContext.Authors.Find(author.AuthorId);
                newAuthor.AuthorName = author.AuthorName;
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
                _dataContext.Authors.Remove(_dataContext.Authors.Find(id));
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