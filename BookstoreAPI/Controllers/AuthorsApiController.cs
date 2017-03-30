using AutoMapper;
using BookstoreAPI.BookStoreViewModels;
using BookstoreBL;
using BookstoreModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace BookstoreAPI.Controllers
{
    [RoutePrefix("api/authors/")]
    public class AuthorsApiController : ApiController
    {
        readonly IAuthorBL authorBL;

        public AuthorsApiController(IAuthorBL _authorBL)
        {
            authorBL = _authorBL;
        }

        // GET: api/AuthorsApi
        [HttpGet]
        // [Route("jjjj")]
        public IHttpActionResult GetAllAuthors()
        {
            var itemList = authorBL.GetAllAuthors();

            var itemViewModelList = Mapper.Map<List<AuthorViewModel>>(itemList);

            return Ok(itemViewModelList);
        }

        [HttpGet]
        public IHttpActionResult GetAuthorDetailsById(Guid id)
        {
            if (id == Guid.Empty) //0000-00-00000
            {
                return BadRequest("grybas"); // 400
            }
            var item = authorBL.FindAuthorByKey(id);

            var itemViewModel = Mapper.Map<AuthorViewModel>(item);

            return Ok(itemViewModel); // 200
        }

        [HttpPut]
        public IHttpActionResult CreateAuthor([FromBody]AuthorViewModel itemViewModel)
        {
            var item = Mapper.Map<Author>(itemViewModel);

            authorBL.CreateAuthor(item);

            return Ok();
        }

        [HttpPost]
        public IHttpActionResult UpdateAuthor([FromBody]AuthorViewModel itemViewModel)
        {
            var item = Mapper.Map<Author>(itemViewModel);

            authorBL.UpdateAuthor(item);

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult DeleteAuthor(Guid id)
        {
            authorBL.DeleteAuthorById(id);

            return Ok();
        }
    }
}