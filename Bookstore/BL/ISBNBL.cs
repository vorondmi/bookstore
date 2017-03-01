using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bookstore.Models;
using Bookstore.DAL;

namespace Bookstore.BL
{
    public class ISBNBL : IISBNBL
    {
        readonly IISBNDal dal;

        public ISBNBL(IISBNDal _dal)
        {
            dal = _dal;
        }
        
        public int create(ISBN entity)
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

        public List<ISBN> findAll()
        {
            return dal.findAll();
        }

        public ISBN findByKey(Guid key)
        {
            return dal.findByKey(key);
        }

        public int update(ISBN entity)
        {
            dal.update(entity);

            return 0;
        }
    }
}