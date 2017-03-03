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
        List<Reader> GetAllReaders();
        Reader FindReaderById(Guid key);
        int SaveReader(Reader entity);
        int UpdateReader(Reader entity);
        int DeleteReader(Reader entity);
    }
}
