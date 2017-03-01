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
        readonly IAuthorDal dal;

        public AuthorBL(IAuthorDal _dal)
        {
            dal = _dal;
        }

        public int create(Author entity)
        {
            dal.save(entity);

            return 0;
        }

        public int delete(Guid key)
        {
            var itemToDelete = dal.findByKey(key);
            dal.delete(itemToDelete);

            return 0;
        }

        public List<Author> findAll()
        {
            return dal.findAll();
        }

        public Author findByKey(Guid key)
        {
            return dal.findByKey(key);
        }

        public int update(Author entity)
        {
            dal.update(entity);

            return 0;
        }
    }
}