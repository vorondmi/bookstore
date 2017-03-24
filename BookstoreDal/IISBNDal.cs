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
        List<ISBN> GetAllISBNs();
        ISBN FindISBNById(Guid key);
        int SaveISBN(ISBN entity);
        int UpdateISBN(ISBN entity);
        int DeleteISBN(ISBN entity);
    }
}
