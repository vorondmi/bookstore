using Bookstore.BL;
using Bookstore.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Bookstore.Models;

namespace Bookstore.Controllers
{
    public class ISBNApiController : ApiController
    {
        readonly IISBNBL isbnBL;

        public ISBNApiController(IISBNBL _isbnBL)
        {
            isbnBL = _isbnBL;
        }

        public IEnumerable<ISBNViewModel> GetAll()
        {
            var itemList = isbnBL.GetAllISBNs();

            var itemViewModelList = Mapper.Map<List<ISBNViewModel>>(itemList);

            return itemViewModelList;
        }

        public ISBNViewModel GetISBNDetailsById(Guid id)
        {
            var item = isbnBL.FindISBNById(id);

            var itemViewModel = Mapper.Map<ISBNViewModel>(item);

            return itemViewModel;
        }

        [HttpPost]
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

        [HttpPost]
        public void Delete(ISBNViewModel itemViewModel)
        {
            isbnBL.DeleteISBNById(itemViewModel.id);
        }
    }
}
