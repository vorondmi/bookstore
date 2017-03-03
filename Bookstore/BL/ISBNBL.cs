using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bookstore.Models;
using Bookstore.DAL;
using System.ComponentModel.DataAnnotations;

namespace Bookstore.BL
{
    public class ISBNBL : IISBNBL
    {
        readonly IISBNDal isbnDal;

        public ISBNBL(IISBNDal _isbnDal)
        {
            isbnDal = _isbnDal;
        }
        
        public int CreateISBN(ISBN entity)
        {
            if(ValidationService.EntityIsValid(entity))
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
            if (ValidationService.EntityIsValid(entity))
            {
                isbnDal.UpdateISBN(entity);

                return 0;
            }

            return -1;
        }
    }
}