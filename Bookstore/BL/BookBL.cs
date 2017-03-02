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

        public int create(Book entity, Guid authorID, Guid isbnID, List<Guid> readerIDs)
        {
            entity.id = Guid.NewGuid();

            entity.author = authorBL.findByKey(authorID);
            entity.isbn = isbnBL.findByKey(isbnID);

            //createdItem.readers = db.readers.Where(r => readerIDs.Any(i => i.Equals(r.id))).ToList();
            var readerList = readerBL.findAll();
            entity.readers = readerList.Where(r => readerIDs.Any(i => i.Equals(r.id))).ToList();

            bookDal.save(entity);

            return 0;
        }

        public int delete(Guid key)
        {
            var itemToDelete = bookDal.findByKey(key);
            bookDal.delete(itemToDelete);

            return 0;
        }

        public List<Book> findAll()
        {
            return bookDal.findAll();
        }

        public Book findByKey(Guid key)
        {
            return bookDal.findByKey(key);
        }

        public int update(Book entity)
        {
            bookDal.update(entity);

            return 0;
        }
    }
}