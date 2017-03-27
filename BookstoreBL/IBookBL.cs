using BookstoreModels;
using System;
using System.Collections.Generic;

namespace BookstoreBL
{
    public interface IBookBL
    {
        int CreateBook(Book entity, Guid authorID, Guid isbnID, List<Guid> readerIDs);
        Book FindBookById(Guid key);
        int DeleteBookById(Guid key);
        List<Book> GetAllBooks();
        int UpdateBook(Book entity);
        List<Book> GetBooksByAuthorId(Guid authorId);
    }
}
