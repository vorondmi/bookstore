using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bookstore.Models;
using System.Data.Entity;

namespace Bookstore.DAL
{
    public class ReaderDal : IReaderDal
    {
        readonly IDbContext db;

        public ReaderDal(IDbContext _db)
        {
            db = _db;
        }

        public int delete(Reader entity)
        {
            db.readers.Remove(entity);
            db.SaveChanges();

            return 0;
        }

        public List<Reader> findAll()
        {
            return db.readers.ToList();
        }

        public Reader findByKey(Guid key)
        {
            return db.readers.Where(a => a.id.Equals(key)).FirstOrDefault();
        }

        public int save(Reader entity)
        {
            db.readers.Add(entity);
            db.SaveChanges();

            return 0;
        }

        public int update(Reader entity)
        {
            db.readers.Attach(entity);
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();

            return 0;
        }
    }
}