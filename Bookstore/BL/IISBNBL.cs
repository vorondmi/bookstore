using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bookstore.Models;

namespace Bookstore.BL
{
    public interface IISBNBL
    {
        int create(ISBN entity);
        ISBN findByKey(Guid key);
        int delete(Guid key);
        List<ISBN> findAll();
        int update(ISBN entity);
    }
}
