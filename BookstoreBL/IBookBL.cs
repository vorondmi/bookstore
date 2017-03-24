using Bookstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.BL
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
