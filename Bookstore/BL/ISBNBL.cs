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
        readonly IISBNDal isbnDal;

        public ISBNBL(IISBNDal _isbnDal)
        {
            isbnDal = _isbnDal;
        }
        
        public int create(ISBN entity)
        {
            entity.id = Guid.NewGuid();

            isbnDal.save(entity);

            return 0;
        }

        public int delete(Guid key)
        {
            var itemToDelete = isbnDal.findByKey(key);
            isbnDal.delete(itemToDelete);

            return 0;
        }

        public List<ISBN> findAll()
        {
            return isbnDal.findAll();
        }

        public ISBN findByKey(Guid key)
        {
            return isbnDal.findByKey(key);
        }

        public int update(ISBN entity)
        {
            isbnDal.update(entity);

            return 0;
        }
    }
}