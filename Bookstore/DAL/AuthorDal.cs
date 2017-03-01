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

        public int delete(Author entity)
        {
            throw new NotImplementedException();
        }

        public List<Author> findAll()
        {
            throw new NotImplementedException();
        }

        public Author findByKey(Guid key)
        {
            throw new NotImplementedException();
        }

        public int save(Author entity)
        {
            throw new NotImplementedException();
        }

        public int update(Author entity)
        {
            db.authors.Attach(entity);
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();

            return 0;
        }
    }
}