using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bookstore.Models;
using Bookstore.DAL;

namespace Bookstore.BL
{
    public class BookBL : IBookBL
    {
        readonly IBookDal bookDal;
        readonly IAuthorBL authorBL;
        readonly IISBNBL isbnBL;
        readonly IReaderBL readerBL;

        public BookBL(IBookDal _bookDal, IAuthorBL _authorBL, IISBNBL _isbnBL, IReaderBL _readerBL)
        {
            bookDal = _bookDal;
            authorBL = _authorBL;
            isbnBL = _isbnBL;
            readerBL = _readerBL;
        }

        public int CreateBook(Book entity, Guid authorID, Guid isbnID, List<Guid> readerIDs)
        {
            if (ValidationService.EntityIsValid(entity))
            {
                entity.id = Guid.NewGuid();

                entity.author = authorBL.FindAuthorByKey(authorID);
                entity.isbn = isbnBL.FindISBNById(isbnID);

                var readerList = readerBL.GetAllReaders();
                entity.readers = readerList.Where(r => readerIDs.Any(i => i.Equals(r.id))).ToList();

                bookDal.SaveBook(entity);

                return 0;
            }

            return -1;
        }

        public int DeleteBookById(Guid id)
        {
            var itemToDelete = bookDal.FindBookById(id);
            bookDal.DeleteBook(itemToDelete);

            return 0;
        }

        public List<Book> GetAllBooks()
        {
            return bookDal.GetAllBooks();
        }

        public Book FindBookById(Guid key)
        {
            return bookDal.FindBookById(key);
        }

        public int UpdateBook(Book entity)
        {
            if (ValidationService.EntityIsValid(entity))
            {
                bookDal.UpdateBook(entity);

                return 0;
            }

            return -1;
        }
    }
}