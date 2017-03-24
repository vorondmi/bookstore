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
using System.Web;
using System.Threading.Tasks;
using System.Net.Http.Headers;

namespace Bookstore.Controllers
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

            //itemViewModel.readers = readerBL.GetAllReaders().Select(r => r.name).ToList();

            return itemViewModel;
        }

        [HttpGet]
        public List<ReaderViewModel> GetBookInfo(Guid id, string parameter1)
        {
            //var readersUrl = this.Url.Link("DefaultApi", new { Controller = parameter1});

            //HttpClient client = new HttpClient();
            //HttpResponseMessage responseMsg = client.GetAsync(readersUrl).Result;

            //var readerList = responseMsg.Content.ReadAsAsync<List<Reader>>().Result;
            //var book = GetBookDetailsById(id);

            //List<Reader> bookReaderList = readerList.Where(rl => book.readers.Any(br => br.Equals(rl.name))).ToList();

            //return bookReaderList;

            switch(parameter1.ToLower())
            {
                case "readers":
                    return GetBookDetailsById(id).readers.ToList();
                default:
                    return null;
            }
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

        //public BookViewModel GetAuthorsReadersISBNs()
        //{
        //    BookViewModel itemToReturn = new BookViewModel();

        //    var authorList = authorBL.GetAllAuthors();
        //    var isbnList = isbnBL.GetAllISBNs();
        //    var readerList = readerBL.GetAllReaders();

        //    List<IDStringPair> authorCompressedList = new List<IDStringPair>();
        //    foreach(var author in authorList)
        //    {
        //        authorCompressedList.Add(new IDStringPair(author.id, author.authorName));
        //    }
        //    itemToReturn.authors = authorCompressedList;

        //    List<IDStringPair> isbnCompressedList = new List<IDStringPair>();
        //    foreach(var isbn in isbnList)
        //    {
        //        isbnCompressedList.Add(new IDStringPair(isbn.id, isbn.isbn.ToString()));
        //    }
        //    itemToReturn.isbns = isbnCompressedList;

        //    List<IDStringPair> readerCompressedList = new List<IDStringPair>();
        //    foreach(var reader in readerList)
        //    {
        //        readerCompressedList.Add(new IDStringPair(reader.id, reader.name));
        //    }
        //    itemToReturn.readers = readerCompressedList;

        //    return itemToReturn;
        //}
    }
}
