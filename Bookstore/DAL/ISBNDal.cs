using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bookstore.Models;
using System.Data.Entity;

namespace Bookstore.DAL
{
    public class ISBNDal : IISBNDal
    {
        readonly IDbContext db;

        public ISBNDal(IDbContext _db)
        {
            db = _db;
        }

        public int save(ISBN entity)
        {
            db.isbns.Add(entity);
            db.SaveChanges();

            return 0;
        }

        public int delete(ISBN entity)
        {
            db.isbns.Remove(entity);
            db.SaveChanges();

            return 0;
        }

        public List<ISBN> findAll()
        {
            return db.isbns.ToList();
        }

        public ISBN findByKey(Guid key)
        {
            return db.isbns.Where(i => i.id.Equals(key)).FirstOrDefault();
        }

        public int update(ISBN entity)
        {
            db.isbns.Attach(entity);
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();

            return 0;
        }
    }
}