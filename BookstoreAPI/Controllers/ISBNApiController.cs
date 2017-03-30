using BookstoreAPI.BookStoreViewModels;
using System;
using System.Collections.Generic;
using System.Web.Http;
using AutoMapper;
using BookstoreBL;
using BookstoreModels;

namespace BookstoreAPI.Controllers
{
    public class ISBNApiController : ApiController
    {
        readonly IISBNBL isbnBL;

        public ISBNApiController(IISBNBL _isbnBL)
        {
            isbnBL = _isbnBL;
        }

        [HttpGet]
        public IHttpActionResult GetAllISBNs()
        {
            var itemList = isbnBL.GetAllISBNs();

            var itemViewModelList = Mapper.Map<List<ISBNViewModel>>(itemList);

            return Ok(itemViewModelList);
        }

        [HttpGet]
        public IHttpActionResult GetISBNDetailsById(Guid id)
        {
            var item = isbnBL.FindISBNById(id);

            var itemViewModel = Mapper.Map<ISBNViewModel>(item);

            return Ok(itemViewModel);
        }

        [HttpPut]
        public IHttpActionResult Create(ISBNViewModel isbnViewModel)
        {
            var item = Mapper.Map<ISBN>(isbnViewModel);

            isbnBL.CreateISBN(item);

            return Ok();
        }

        [HttpPost]
        public IHttpActionResult Update(ISBNViewModel isbnViewModel)
        {
            var item = Mapper.Map<ISBN>(isbnViewModel);

            isbnBL.UpdateISBN(item);

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult Delete(Guid id)
        {
            isbnBL.DeleteISBNById(id);

            return Ok();
        }
    }
}
