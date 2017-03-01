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
        List<Book> findAll();
        Book findByKey(Guid key);
        int save(Book entity);
        int update(Book entity);
        int delete(Book entity);
    }
}
