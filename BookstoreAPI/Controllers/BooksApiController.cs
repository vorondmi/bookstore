using BookstoreAPI.BookStoreViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using AutoMapper;
using BookstoreBL;
using BookstoreModels;

namespace BookstoreAPI.Controllers
{
    [Route(Name = "BookController")]
    public class BooksApiController : ApiController
    {
        readonly IBookBL bookBL;
        readonly IAuthorBL authorBL;
        readonly IISBNBL isbnBL;
        readonly IReaderBL readerBL;

        public BooksApiController(IBookBL _bookBL, IAuthorBL _authorBL, IISBNBL _isbnBL, IReaderBL _readerBL)
        {
            bookBL = _bookBL;
            authorBL = _authorBL;
            isbnBL = _isbnBL;
            readerBL = _readerBL;
        }

        [HttpGet]
        public IHttpActionResult GetAllBooks()
        {
            var itemList = bookBL.GetAllBooks();

            var itemViewModelList = Mapper.Map<List<BookViewModel>>(itemList);

            return Ok(itemViewModelList);
        }

        [HttpGet]
        [Route("api/authors/{authorId}/books")]
        public IHttpActionResult GetBookById(Guid authorId)
        {
            var itemList = bookBL.GetBooksByAuthorId(authorId);

            var itemViewModelList = Mapper.Map<List<BookViewModel>>(itemList);

            return Ok(itemViewModelList);
        }

        [HttpGet]
        public IHttpActionResult GetBookDetailsById(Guid id)
        {
            var item = bookBL.FindBookById(id);

            var itemViewModel = Mapper.Map<BookDetailViewModel>(item);

            return Ok(itemViewModel);
        }

        [HttpPut]
        public IHttpActionResult Create([FromBody]NewBookViewModel itemViewModel)
        {
            var item = Mapper.Map<Book>(itemViewModel);

            bookBL.CreateBook(item, itemViewModel.authorID, itemViewModel.isbnID, itemViewModel.readerIDs.ToList());

            return Ok();
        }

        [HttpPost]
        public IHttpActionResult Update([FromBody]BookViewModel itemViewModel)
        {
            var item = Mapper.Map<Book>(itemViewModel);

            bookBL.UpdateBook(item);

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult Delete(Guid id)
        {
            bookBL.DeleteBookById(id);

            return Ok();
        }
    }
}
