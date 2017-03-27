using System;
using System.Collections.Generic;
using System.Linq;
using BookstoreModels;

namespace BookstoreDAL
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
            db.SaveChanges();

            return 0;
        }

        public List<Author> GetAllAuthors()
        {
            return db.authors.ToList();
        }

        public Author FindAuthorById(Guid id)
        {
            var authorList = db.authors.Where(a => a.id.Equals(id)).FirstOrDefault();

            return authorList;
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