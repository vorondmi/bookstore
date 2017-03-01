using Bookstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.BL
{
    public interface IAuthorBL
    {
        int create(Author entity);
        Author findByKey(Guid key);
        int delete(Guid key);
        List<Author> findAll();
        int update(Author entity);
    }
}
