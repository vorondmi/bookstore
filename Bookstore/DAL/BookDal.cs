using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bookstore.Models;
using System.Data.Entity;

namespace Bookstore.DAL
{
    public class BookDal : IBookDal
    {
        readonly IDbContext db;

        public BookDal(IDbContext _db)
        {
            db = _db;
        }

        public int delete(Book entity)
        {
            db.books.Remove(entity);
            db.SaveChanges();

            return 0;
        }

        public List<Book> findAll()
        {
            return db.books.ToList();
        }

        public Book findByKey(Guid key)
        {
            return db.books.Where(a => a.id.Equals(key)).FirstOrDefault();
        }

        public int save(Book entity)
        {
            db.books.Add(entity);
            db.SaveChanges();

            return 0;
        }

        public int update(Book entity)
        {
            db.books.Attach(entity);
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();

            return 0;
        }
    }
}