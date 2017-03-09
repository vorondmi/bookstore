using AutoMapper;
using Bookstore.BL;
using Bookstore.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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

        // GET api/<controller>
        //public IEnumerable<AuthorViewModel> GetAll()
        //{
        //    var itemList = authorBL.GetAllAuthors();

        //    var itemListView = Mapper.Map<List<AuthorViewModel>>(itemList);

        //    return itemListView.AsEnumerable<AuthorViewModel>();
        //}

        public IEnumerable<string> GetAll()
        {
            return new string[] { "aaa", "bbb" };
        }

        // GET api/<controller>/5
        public string GetById(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}