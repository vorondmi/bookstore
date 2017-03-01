using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bookstore.Models;

namespace Bookstore.DAL
{
    public interface IISBNDal
    {
        List<ISBN> findAll();
        ISBN findByKey(Guid key);
        int save(ISBN entity);
        int update(ISBN entity);
        int delete(ISBN entity);
    }
}
