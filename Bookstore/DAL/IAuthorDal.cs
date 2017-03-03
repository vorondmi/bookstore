using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bookstore.Models;

namespace Bookstore.DAL
{
    public interface IAuthorDal
    {
        List<Author> GetAllAuthors();
        Author FindAuthorById(Guid key);
        int SaveAuthor(Author entity);
        int UpdateAuthor(Author entity);
        int DeleteAuthor(Author entity);
    }
}
