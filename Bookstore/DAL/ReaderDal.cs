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

        public int DeleteReader(Reader entity)
        {
            db.readers.Remove(entity);
            db.SaveChanges();

            return 0;
        }

        public List<Reader> GetAllReaders()
        {
            return db.readers.ToList();
        }

        public Reader FindReaderById(Guid id)
        {
            return db.readers.Where(a => a.id.Equals(id)).FirstOrDefault();
        }

        public int SaveReader(Reader entity)
        {
            db.readers.Add(entity);
            db.SaveChanges();

            return 0;
        }

        public int UpdateReader(Reader entity)
        {
            var entityToUpdate = db.readers.Find(entity.id);
            db.Entry(entityToUpdate).CurrentValues.SetValues(entity);
            db.SaveChanges();

            return 0;
        }
    }
}