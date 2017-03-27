using BookstoreModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreBL
{
    public interface IISBNBL
    {
        int CreateISBN(ISBN entity);
        ISBN FindISBNById(Guid key);
        int DeleteISBNById(Guid key);
        List<ISBN> GetAllISBNs();
        int UpdateISBN(ISBN entity);
    }
}
