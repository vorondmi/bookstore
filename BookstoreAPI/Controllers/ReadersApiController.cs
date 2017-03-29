using System;
using System.Collections.Generic;
using System.Web.Http;
using BookstoreAPI.BookStoreViewModels;
using AutoMapper;
using BookstoreBL;
using BookstoreModels;

namespace BookstoreAPI.Controllers
{
    public class ReadersApiController : ApiController
    {
        readonly IReaderBL readerBL;

        public ReadersApiController(IReaderBL _readerBL)
        {
            readerBL = _readerBL;
        }

        [Route("api/readers")]
        [HttpGet]
        public IEnumerable<ReaderViewModel> GetAllReaders()
        {
            var itemList = readerBL.GetAllReaders();

            var itemViewModelList = Mapper.Map<List<ReaderViewModel>>(itemList);

            return itemViewModelList;
        }

        [Route("api/readers/{id}")]
        [HttpGet]
        public ReaderViewModel GetReaderDetailsById(Guid id)
        {
            var item = readerBL.FindReaderById(id);

            var itemViewModel = Mapper.Map<ReaderViewModel>(item);

            return itemViewModel;
        }

        [Route("api/readers")]
        [HttpPut]
        public int CreateReader(ReaderViewModel itemViewModel)
        {
            var item = Mapper.Map<Reader>(itemViewModel);

            return readerBL.CreateReader(item);
        }

        [Route("api/readers")]
        [HttpPost]
        public int UpdateReader(ReaderViewModel itemViewModel)
        {
            var item = Mapper.Map<Reader>(itemViewModel);

            return readerBL.UpdateReader(item);
        }

        [Route("api/readers/{id}")]
        [HttpDelete]
        public int DeleteReader(Guid id)
        {
            return readerBL.DeleteReaderById(id);
        }
    }
}
