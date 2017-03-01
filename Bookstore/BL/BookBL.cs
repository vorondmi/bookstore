using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bookstore.Models;
using Bookstore.DAL;

namespace Bookstore.BL
{
    public class BookBL : IBookBL
    {
        readonly IBookDal dal;

        public BookBL(IBookDal _dal)
        {
            dal = _dal;
        }

        public int create(Book entity)
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

        public List<Book> findAll()
        {
            return dal.findAll();
        }

        public Book findByKey(Guid key)
        {
            return dal.findByKey(key);
        }

        public int update(Book entity)
        {
            dal.update(entity);

            return 0;
        }
    }
}