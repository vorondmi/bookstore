using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bookstore.Models;
using System.Data.Entity;

namespace Bookstore.DAL
{
    public class AuthorDal : IAuthorDal
    {
        readonly IDbContext db;

        public AuthorDal(IDbContext _db)
        {
            db = _db;
        }

        public int DeleteAuthor(Author entity)
        {
            db.authors.Remove(entity);

            return 0;
        }

        public List<Author> GetAllAuthors()
        {
            return db.authors.ToList();
        }

        public Author FindAuthorById(Guid id)
        {
            return db.authors.Where(a => a.id.Equals(id)).FirstOrDefault();
        }

        public int SaveAuthor(Author entity)
        {
            db.authors.Add(entity);
            db.SaveChanges();

            return 0;
        }

        public int UpdateAuthor(Author entity)
        {
            var entityToUpdate = db.authors.Find(entity.id);
            db.Entry(entityToUpdate).CurrentValues.SetValues(entity);
            db.SaveChanges();

            return 0;
        }
    }
}