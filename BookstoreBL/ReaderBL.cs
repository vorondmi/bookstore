using BookstoreBL;
using BookstoreBL.Services.Validation;
using BookstoreDAL;
using BookstoreModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookstoreBL
{
    public class ReaderBL : IReaderBL
    {
        readonly IReaderDal readerDal;

        readonly IValidationService validationService;

        public ReaderBL(IReaderDal _readerDal, IValidationService _validationService)
        {
            readerDal = _readerDal;
            validationService = _validationService;
        }

        public int CreateReader(Reader entity)
        {
            if (validationService.EntityIsValid(entity))
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
            if (validationService.EntityIsValid(entity))
            {
                readerDal.UpdateReader(entity);

                return 0;
            }

            return -1;
        }
    }
}