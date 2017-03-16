using Bookstore.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Bookstore.ViewModels;
using Bookstore.Models;

namespace Bookstore.Controllers
{
    public class ReadersApiController : ApiController
    {
        readonly IReaderBL readerBL;

        public ReadersApiController(IReaderBL _readerBL)
        {
            readerBL = _readerBL;
        }

        public IEnumerable<ReaderViewModel> GetAll()
        {
            var itemList = readerBL.GetAllReaders();

            var itemViewModelList = Mapper.Map<List<ReaderViewModel>>(itemList);

            return itemViewModelList;
        }

        public ReaderViewModel GetReaderDetailsById(Guid id)
        {
            var item = readerBL.FindReaderById(id);

            var itemViewModel = Mapper.Map<ReaderViewModel>(item);

            return itemViewModel;
        }

        [HttpPost]
        public void Create(ReaderViewModel itemViewModel)
        {
            var item = Mapper.Map<Reader>(itemViewModel);

            readerBL.CreateReader(item);
        }

        [HttpPost]
        public void Update(ReaderViewModel itemViewModel)
        {
            var item = Mapper.Map<Reader>(itemViewModel);

            readerBL.UpdateReader(item);
        }

        [HttpPost]
        public void Delete(ReaderViewModel itemViewModel)
        {
            readerBL.DeleteReaderById(itemViewModel.id);
        }
    }
}
