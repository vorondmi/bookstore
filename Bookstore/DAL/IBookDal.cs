using Bookstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.DAL
{
    public interface IBookDal
    {
        List<Book> GetAllBooks();
        Book FindBookById(Guid key);
        int SaveBook(Book entity);
        int UpdateBook(Book entity);
        int DeleteBook(Book entity);
    }
}
