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
    [Route(Name = "ReaderController")]
    public class ReadersApiController : ApiController
    {
        readonly IReaderBL readerBL;

        public ReadersApiController(IReaderBL _readerBL)
        {
            readerBL = _readerBL;
        }

        [HttpGet]
        public IEnumerable<ReaderViewModel> GetAllReaders()
        {
            var itemList = readerBL.GetAllReaders();

            var itemViewModelList = Mapper.Map<List<ReaderViewModel>>(itemList);

            return itemViewModelList;
        }

        [HttpGet]
        public ReaderViewModel GetReaderDetailsById(Guid id)
        {
            var item = readerBL.FindReaderById(id);

            var itemViewModel = Mapper.Map<ReaderViewModel>(item);

            return itemViewModel;
        }

        [HttpPut]
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

        [HttpDelete]
        public void Delete(Guid id)
        {
            readerBL.DeleteReaderById(id);
        }
    }
}
