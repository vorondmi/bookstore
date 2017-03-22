using AutoMapper;
using Bookstore.BL;
using Bookstore.DAL;
using Bookstore.Models;
using Bookstore.Services.Validation;
using Bookstore.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Bookstore.Controllers
{
    //[RoutePrefix("author")]
    public class AuthorsApiController : ApiController
    {
        readonly IAuthorBL authorBL;

        public AuthorsApiController(IAuthorBL _authorBL)
        {
            authorBL = _authorBL;
        }

        // GET: api/AuthorsApi
        [HttpGet]
        public IEnumerable<AuthorViewModel> GetAllAuthors()
        {
            var itemList = authorBL.GetAllAuthors();

            var itemViewModelList = Mapper.Map<List<AuthorViewModel>>(itemList);

            return itemViewModelList;
        }

        [HttpGet]
        public AuthorViewModel GetAuthorDetailsById(Guid id)
        {
            var item = authorBL.FindAuthorByKey(id);

            var itemViewModel = Mapper.Map<AuthorViewModel>(item);

            return itemViewModel;
        }

        [HttpPut]
        public void CreateAuthor([FromBody]AuthorViewModel itemViewModel)
        {
            var item = Mapper.Map<Author>(itemViewModel);

            authorBL.CreateAuthor(item);
        }

        [HttpPost]
        public void UpdateAuthor([FromBody]AuthorViewModel itemViewModel)
        {
            var item = Mapper.Map<Author>(itemViewModel);

            authorBL.UpdateAuthor(item);
        }

        [HttpDelete]
        public void DeleteAuthor(Guid id)
        {
            authorBL.DeleteAuthorById(id);
        }
    }
}