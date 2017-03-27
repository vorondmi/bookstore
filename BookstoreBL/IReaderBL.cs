using BookstoreModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreBL
{
    public interface IReaderBL
    {
        int CreateReader(Reader entity);
        Reader FindReaderById(Guid key);
        int DeleteReaderById(Guid key);
        List<Reader> GetAllReaders();
        int UpdateReader(Reader entity);
    }
}
