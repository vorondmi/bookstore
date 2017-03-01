using Bookstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.DAL
{
    public interface IReaderDal
    {
        List<Reader> findAll();
        Reader findByKey(Guid key);
        int save(Reader entity);
        int update(Reader entity);
        int delete(Reader entity);
    }
}
