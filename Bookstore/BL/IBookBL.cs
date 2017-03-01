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
        int create(Book entity);
        Book findByKey(Guid key);
        int delete(Guid key);
        List<Book> findAll();
        int update(Book entity);
    }
}
