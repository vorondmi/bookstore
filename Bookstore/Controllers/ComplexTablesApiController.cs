using System.Web.Http;

namespace Bookstore.Controllers
{
    public class ComplexTablesApiController : ApiController
    {
        //readonly IBookBL bookBL;
        //readonly IAuthorBL authorBL;
        //readonly IISBNBL isbnBL;
        //readonly IReaderBL readerBL;

        //public ComplexTablesApiController(IBookBL _bookBL, IAuthorBL _authorBL, IISBNBL _isbnBL, IReaderBL _readerBL)
        //{
        //    bookBL = _bookBL;
        //    authorBL = _authorBL;
        //    isbnBL = _isbnBL;
        //    readerBL = _readerBL;
        //}

        //public IEnumerable<ComplexAuthorViewModel> getComplexAuthorView()
        //{
        //    var authorsList = authorBL.GetAllAuthors();

        //    var authorViewList = Mapper.Map<List<ComplexAuthorViewModel>>(authorsList);

        //    return authorViewList;
        //}

        //public IEnumerable<ComplexBookViewModel> getComplexBookView()
        //{
        //    var books = bookBL.GetAllBooks();

        //    List<ComplexBookViewModel> bookList = new List<ComplexBookViewModel>();

        //    foreach (var book in books)
        //    {
        //        ComplexBookViewModel bookViewModel = Mapper.Map<ComplexBookViewModel>(book);
        //        bookViewModel.isbn = isbnBL.FindISBNById(book.isbn.id).isbn;
        //        bookViewModel.authorName = authorBL.FindAuthorByKey(book.author.id).authorName;

        //        bookList.Add(bookViewModel);
        //    }

        //    return bookList;
        //}
    }
}
