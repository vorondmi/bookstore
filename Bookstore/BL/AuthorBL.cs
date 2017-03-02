using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bookstore.Models;
using Bookstore.DAL;

namespace Bookstore.BL
{
    public class AuthorBL : IAuthorBL
    {
        readonly IAuthorDal authorDal;

        public AuthorBL(IAuthorDal _authorDal)
        {
            authorDal = _authorDal;
        }

        public int create(Author entity)
        {
            entity.id = Guid.NewGuid();

            authorDal.save(entity);

            return 0;
        }

        public int delete(Guid key)
        {
            var itemToDelete = authorDal.findByKey(key);
            authorDal.delete(itemToDelete);

            return 0;
        }

        public List<Author> findAll()
        {
            return authorDal.findAll();
        }

        public Author findByKey(Guid key)
        {
            return authorDal.findByKey(key);
        }

        public int update(Author entity)
        {
            authorDal.update(entity);

            return 0;
        }
    }
}