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
        public IEnumerable<ISBNViewModel> GetAllISBNs()
        {
            var itemList = isbnBL.GetAllISBNs();

            var itemViewModelList = Mapper.Map<List<ISBNViewModel>>(itemList);

            return itemViewModelList;
        }

        [HttpGet]
        public ISBNViewModel GetISBNDetailsById(Guid id)
        {
            var item = isbnBL.FindISBNById(id);

            var itemViewModel = Mapper.Map<ISBNViewModel>(item);

            return itemViewModel;
        }

        [HttpPut]
        public void Create(ISBNViewModel isbnViewModel)
        {
            var item = Mapper.Map<ISBN>(isbnViewModel);

            isbnBL.CreateISBN(item);
        }

        [HttpPost]
        public void Update(ISBNViewModel isbnViewModel)
        {
            var item = Mapper.Map<ISBN>(isbnViewModel);

            isbnBL.UpdateISBN(item);
        }

        [HttpDelete]
        public void Delete(Guid id)
        {
            isbnBL.DeleteISBNById(id);
        }
    }
}
