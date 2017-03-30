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
        public IHttpActionResult GetAllReaders()
        {
            var itemList = readerBL.GetAllReaders();

            var itemViewModelList = Mapper.Map<List<ReaderViewModel>>(itemList);

            return Ok(itemViewModelList);
        }

        [Route("api/readers/{id}")]
        [HttpGet]
        public IHttpActionResult GetReaderDetailsById(Guid id)
        {
            var item = readerBL.FindReaderById(id);

            var itemViewModel = Mapper.Map<ReaderViewModel>(item);

            return Ok(itemViewModel);
        }

        [Route("api/readers")]
        [HttpPut]
        public IHttpActionResult CreateReader(ReaderViewModel itemViewModel)
        {
            var item = Mapper.Map<Reader>(itemViewModel);

            readerBL.CreateReader(item);

            return Ok();
        }

        [Route("api/readers")]
        [HttpPost]
        public IHttpActionResult UpdateReader(ReaderViewModel itemViewModel)
        {
            var item = Mapper.Map<Reader>(itemViewModel);

            readerBL.UpdateReader(item);

            return Ok();
        }

        [Route("api/readers/{id}")]
        [HttpDelete]
        public IHttpActionResult DeleteReader(Guid id)
        {
            readerBL.DeleteReaderById(id);

            return Ok();
        }
    }
}
