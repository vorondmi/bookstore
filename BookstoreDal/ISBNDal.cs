using System;
using System.Collections.Generic;
using System.Linq;
using BookstoreModels;

namespace BookstoreDAL
{
    public class ISBNDal : IISBNDal
    {
        readonly IDbContext db;

        public ISBNDal(IDbContext _db)
        {
            db = _db;
        }

        public int SaveISBN(ISBN entity)
        {
            db.isbns.Add(entity);
            db.SaveChanges();

            return 0;
        }

        public int DeleteISBN(ISBN entity)
        {
            db.isbns.Remove(entity);
            db.SaveChanges();

            return 0;
        }

        public List<ISBN> GetAllISBNs()
        {
            return db.isbns.ToList();
        }

        public ISBN FindISBNById(Guid id)
        {
            return db.isbns.Where(i => i.id.Equals(id)).FirstOrDefault();
        }

        public int UpdateISBN(ISBN entity)
        {
            //db.isbns.Attach(entity);
            //db.Entry(entity).State = EntityState.Modified;

            //var entityToUpdate = db.isbns.Find(entity.id);
            //db.isbns.Remove(entityToUpdate);
            //db.isbns.Add(entity);

            //db.isbns.Attach(entity);

            var entityToUpdate = db.isbns.Find(entity.id);
            db.Entry(entityToUpdate).CurrentValues.SetValues(entity);
            db.SaveChanges();

            return 0;
        }
    }
}