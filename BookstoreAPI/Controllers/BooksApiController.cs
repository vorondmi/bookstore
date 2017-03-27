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
        public IEnumerable<BookViewModel> GetAllBooks()
        {
            var itemList = bookBL.GetAllBooks();

            var itemViewModelList = Mapper.Map<List<BookViewModel>>(itemList);

            return itemViewModelList;
        }

        [HttpGet]
        [Route("api/authors/{authorId}/books")]
        public IEnumerable<BookViewModel> Get(Guid authorId)
        {
            var itemList = bookBL.GetBooksByAuthorId(authorId);

            var itemViewModelList = Mapper.Map<List<BookViewModel>>(itemList);

            return itemViewModelList;
        }

        [HttpGet]
        public BookDetailViewModel GetBookDetailsById(Guid id)
        {
            var item = bookBL.FindBookById(id);

            var itemViewModel = Mapper.Map<BookDetailViewModel>(item);

            return itemViewModel;
        }

        [HttpPut]
        public void Create([FromBody]NewBookViewModel itemViewModel)
        {
            var item = Mapper.Map<Book>(itemViewModel);

            bookBL.CreateBook(item, itemViewModel.authorID, itemViewModel.isbnID, itemViewModel.readerIDs.ToList());
        }

        [HttpPost]
        public void Update([FromBody]BookViewModel itemViewModel)
        {
            var item = Mapper.Map<Book>(itemViewModel);

            bookBL.UpdateBook(item);
        }

        [HttpDelete]
        public void Delete(Guid id)
        {
            bookBL.DeleteBookById(id);
        }
    }
}
