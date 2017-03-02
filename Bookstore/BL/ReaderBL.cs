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
        readonly IReaderDal readerDal;

        public ReaderBL(IReaderDal _readerDal)
        {
            readerDal = _readerDal;
        }

        public int create(Reader entity)
        {
            entity.id = Guid.NewGuid();

            readerDal.save(entity);

            return 0;
        }

        public int delete(Guid key)
        {
            var itemToDelete = readerDal.findByKey(key);
            readerDal.delete(itemToDelete);

            return 0;
        }

        public List<Reader> findAll()
        {
            return readerDal.findAll();
        }

        public Reader findByKey(Guid key)
        {
            return readerDal.findByKey(key);
        }

        public int update(Reader entity)
        {
            readerDal.update(entity);

            return 0;
        }
    }
}