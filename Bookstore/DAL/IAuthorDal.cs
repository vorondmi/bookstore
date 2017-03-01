using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bookstore.Models;

namespace Bookstore.DAL
{
    interface IAuthorDal
    {
        List<Author> findAll();
        Author findByKey(Guid key);
        int save(Author entity);
        int update(Author entity);
        int delete(Author entity);
    }
}
