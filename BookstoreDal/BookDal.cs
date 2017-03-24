using System;
using System.Collections.Generic;
using System.Linq;
using Bookstore.Models;

namespace Bookstore.DAL
{
    public class BookDal : IBookDal
    {
        readonly IDbContext db;

        public BookDal(IDbContext _db)
        {
            db = _db;
        }

        public int DeleteBook(Book entity)
        {
            db.books.Remove(entity);
            db.SaveChanges();

            return 0;
        }

        public List<Book> GetAllBooks()
        {
            return db.books.ToList();
        }

        public Book FindBookById(Guid id)
        {
            return db.books.Where(a => a.id.Equals(id)).FirstOrDefault();
        }

        public int SaveBook(Book entity)
        {
            db.books.Add(entity);
            db.SaveChanges();

            return 0;
        }

        public int UpdateBook(Book entity)
        {
            var entityToUpdate = db.books.Find(entity.id);
            db.Entry(entityToUpdate).CurrentValues.SetValues(entity);
            db.SaveChanges();

            return 0;
        }

        public List<Book> GetBooksByAuthorId(Guid authorId)
        {
            var authorBooks = db.books.Where(b => b.author.id.Equals(authorId)).ToList();

            return authorBooks;
        }
    }
}