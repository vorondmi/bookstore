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
    public class AuthorsApiController : ApiController
    {
        readonly IAuthorBL authorBL;

        public AuthorsApiController(IAuthorBL _authorBL)
        {
            authorBL = _authorBL;
        }

        [HttpGet]
        public IEnumerable<AuthorViewModel> GetAll()
        {
            var itemList = authorBL.GetAllAuthors();

            var itemViewModelList = Mapper.Map<List<AuthorViewModel>>(itemList);

            return itemViewModelList;
        }

        // GET api/<controller>/5
        public AuthorViewModel GetAuthorDetailsById(Guid id)
        {
            var item = authorBL.FindAuthorByKey(id);

            var itemViewModel = Mapper.Map<AuthorViewModel>(item);

            return itemViewModel;
        }

        [HttpPost]
        public void Create([FromBody]AuthorViewModel itemViewModel)
        {
            var item = Mapper.Map<Author>(itemViewModel);

            authorBL.CreateAuthor(item);
        }

        [HttpPost]
        public void Delete([FromBody]AuthorViewModel itemViewModel)
        {
            authorBL.DeleteAuthorById(itemViewModel.id);
        }
    }
}