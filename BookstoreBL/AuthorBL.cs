using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bookstore.Models;
using Bookstore.DAL;
using Bookstore.Services;
using Bookstore.Services.Validation;
using FluentValidation;
using FluentValidation.Results;

namespace Bookstore.BL
{
    public class AuthorBL : IAuthorBL
    {
        readonly IAuthorDal authorDal;
        //readonly IValidationService validationService;
        readonly IValidator<Author> validator;

        public AuthorBL(IAuthorDal _authorDal, IValidator<Author> _validator)
        {
            authorDal = _authorDal;
            validator = _validator;
        }

        public int CreateAuthor(Author entity)
        {
            //if (validationService.EntityIsValid(entity))
            //{
            //    entity.id = Guid.NewGuid();

            //    authorDal.SaveAuthor(entity);
            //    return 0;
            //}
            var validationResult = validator.Validate(entity);

            if(validationResult.IsValid)
            {
                entity.id = Guid.NewGuid();

                authorDal.SaveAuthor(entity);
                return 0;
                //return new BLResponse<Author>(validationResult.Errors, entity);
            }

            return -1;
        }

        public int DeleteAuthorById(Guid id)
        {
            var itemToDelete = authorDal.FindAuthorById(id);
            authorDal.DeleteAuthor(itemToDelete);

            return 0;
        }

        public List<Author> GetAllAuthors()
        {
            return authorDal.GetAllAuthors();
        }

        public Author FindAuthorByKey(Guid key)
        {
            return authorDal.FindAuthorById(key);
        }

        public int UpdateAuthor(Author entity)
        {
            if (validator.Validate(entity).IsValid)
            {
                authorDal.UpdateAuthor(entity);

                return 0;
            }

            return -1;
        }
    }
}