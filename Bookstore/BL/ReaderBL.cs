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

        public int CreateReader(Reader entity)
        {
            if (ValidationService.EntityIsValid(entity))
            {
                entity.id = Guid.NewGuid();

                readerDal.SaveReader(entity);

                return 0;
            }

            return -1;
        }

        public int DeleteReaderById(Guid id)
        {
            var itemToDelete = readerDal.FindReaderById(id);
            readerDal.DeleteReader(itemToDelete);

            return 0;
        }

        public List<Reader> GetAllReaders()
        {
            return readerDal.GetAllReaders();
        }

        public Reader FindReaderById(Guid id)
        {
            return readerDal.FindReaderById(id);
        }

        public int UpdateReader(Reader entity)
        {
            if (ValidationService.EntityIsValid(entity))
            {
                readerDal.UpdateReader(entity);

                return 0;
            }

            return -1;
        }
    }
}