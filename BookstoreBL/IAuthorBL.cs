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
        int CreateAuthor(Author entity);
        Author FindAuthorByKey(Guid key);
        int DeleteAuthorById(Guid key);
        List<Author> GetAllAuthors();
        int UpdateAuthor(Author entity);
    }
}
