using Bookstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.BL
{
    public interface IReaderBL
    {
        int create(Reader entity);
        Reader findByKey(Guid key);
        int delete(Guid key);
        List<Reader> findAll();
        int update(Reader entity);
    }
}
