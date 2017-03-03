using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bookstore.Models;
using Bookstore.DAL;
using Bookstore.Services;

namespace Bookstore.BL
{
    public class AuthorBL : IAuthorBL
    {
        readonly IAuthorDal authorDal;
        readonly IValidationService validationService;

        public AuthorBL(IAuthorDal _authorDal, IValidationService _validationService)
        {
            authorDal = _authorDal;
            validationService = _validationService;
        }

        public int CreateAuthor(Author entity)
        {
            if (validationService.EntityIsValid(entity))
            {
                entity.id = Guid.NewGuid();

                authorDal.SaveAuthor(entity);
                return 0;
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
            if (validationService.EntityIsValid(entity))
            {
                authorDal.UpdateAuthor(entity);

                return 0;
            }

            return -1;
        }
    }
}