using System;
using System.Collections.Generic;
using BookstoreModels;

namespace BookstoreDAL
{
    public interface IBookDal
    {
        List<Book> GetAllBooks();
        Book FindBookById(Guid key);
        int SaveBook(Book entity);
        int UpdateBook(Book entity);
        int DeleteBook(Book entity);
        List<Book> GetBooksByAuthorId(Guid authorId);
    }
}
