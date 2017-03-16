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

        public IEnumerable<BookViewModel> GetAll()
        {
            var itemList = bookBL.GetAllBooks();

            var itemViewModelList = Mapper.Map<List<BookViewModel>>(itemList);

            return itemViewModelList;
        }

        public BookDetailViewModel GetBookDetailsById(Guid id)
        {
            var item = bookBL.FindBookById(id);

            var itemViewModel = Mapper.Map<BookDetailViewModel>(item);

            return itemViewModel;
        }

        [HttpPost]
        public void Create([FromBody]NewBookViewModel itemViewModel)
        {
            var item = Mapper.Map<Book>(itemViewModel);
            item.release = DateTime.Now;

            bookBL.CreateBook(item, itemViewModel.authorID, itemViewModel.isbnID, itemViewModel.readerIDs.ToList());
        }

        [HttpPost]
        public void Update([FromBody]BookViewModel itemViewModel)
        {
            var item = Mapper.Map<Book>(itemViewModel);

            bookBL.UpdateBook(item);
        }

        [HttpPost]
        public void Delete([FromBody]BookViewModel itemViewModel)
        {
            bookBL.DeleteBookById(itemViewModel.id);
        }

        public BookViewModel GetAuthorsReadersISBNs()
        {
            BookViewModel itemToReturn = new BookViewModel();

            var authorList = authorBL.GetAllAuthors();
            var isbnList = isbnBL.GetAllISBNs();
            var readerList = readerBL.GetAllReaders();

            List<IDStringPair> authorCompressedList = new List<IDStringPair>();
            foreach(var author in authorList)
            {
                authorCompressedList.Add(new IDStringPair(author.id, author.authorName));
            }
            itemToReturn.authors = authorCompressedList;

            List<IDStringPair> isbnCompressedList = new List<IDStringPair>();
            foreach(var isbn in isbnList)
            {
                isbnCompressedList.Add(new IDStringPair(isbn.id, isbn.isbn.ToString()));
            }
            itemToReturn.isbns = isbnCompressedList;

            List<IDStringPair> readerCompressedList = new List<IDStringPair>();
            foreach(var reader in readerList)
            {
                readerCompressedList.Add(new IDStringPair(reader.id, reader.name));
            }
            itemToReturn.readers = readerCompressedList;

            return itemToReturn;
        }
    }
}
