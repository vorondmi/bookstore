using BookstoreBL.Services.Validation;
using BookstoreDAL;
using BookstoreModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookstoreBL
{
    public class ISBNBL : IISBNBL
    {
        readonly IISBNDal isbnDal;

        readonly IValidationService validationService;

        public ISBNBL(IISBNDal _isbnDal, IValidationService _validationService)
        {
            isbnDal = _isbnDal;
            validationService = _validationService;
        }
        
        public int CreateISBN(ISBN entity)
        {
            if(validationService.EntityIsValid(entity))
            {
                entity.id = Guid.NewGuid();
                isbnDal.SaveISBN(entity);
                return 0;
            }
            
            return -1;
        }

        public int DeleteISBNById(Guid key)
        {
            var itemToDelete = isbnDal.FindISBNById(key);
            isbnDal.DeleteISBN(itemToDelete);

            return 0;
        }

        public List<ISBN> GetAllISBNs()
        {
            return isbnDal.GetAllISBNs();
        }

        public ISBN FindISBNById(Guid id)
        {
            return isbnDal.FindISBNById(id);
        }

        public int UpdateISBN(ISBN entity)
        {
            if (validationService.EntityIsValid(entity))
            {
                isbnDal.UpdateISBN(entity);

                return 0;
            }

            return -1;
        }
    }
}