using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bookstore.Models;
using Bookstore.DAL;

namespace Bookstore.BL
{
    public class ReaderBL : IReaderBL
    {
        readonly IReaderDal dal;

        public ReaderBL(IReaderDal _dal)
        {
            dal = _dal;
        }

        public int create(Reader entity)
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

        public List<Reader> findAll()
        {
            return dal.findAll();
        }

        public Reader findByKey(Guid key)
        {
            return dal.findByKey(key);
        }

        public int update(Reader entity)
        {
            dal.update(entity);

            return 0;
        }
    }
}