using System.Web.Mvc;

namespace Bookstore.Controllers
{

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        //readonly IAuthorBL authorBL;
        //readonly IBookBL bookBL;
        //readonly IISBNBL isbnBL;
        //readonly IReaderBL readerBL;

        //public HomeController(IAuthorBL _authorBL, IBookBL _bookBL, IISBNBL _isbnBL, IReaderBL _readerBL)
        //{
        //    authorBL = _authorBL;
        //    bookBL = _bookBL;
        //    isbnBL = _isbnBL;
        //    readerBL = _readerBL;
        //}

        //public ActionResult Index()
        //{
        //    return View();
        //}

        //public ActionResult BookInfo()
        //{
        //    var books = bookBL.GetAllBooks();

        //    List<ComplexBookViewModel> bookList = new List<ComplexBookViewModel>();

        //    foreach(var book in books)
        //    {
        //        ComplexBookViewModel bookViewModel = Mapper.Map<ComplexBookViewModel>(book);
        //        bookViewModel.isbn = isbnBL.FindISBNById(book.isbn.id).isbn;
        //        bookViewModel.authorName = authorBL.FindAuthorByKey(book.author.id).authorName;

        //        bookList.Add(bookViewModel);
        //    }

        //    return View(bookList.AsEnumerable<ComplexBookViewModel>());
        //}

        //public ActionResult AuthorInfo()
        //{
        //    var authorsList = authorBL.GetAllAuthors();

        //    List<ComplexAuthorViewModel> authorListView = new List<ComplexAuthorViewModel>();
        //    foreach(var authorItem in authorsList)
        //    {
        //        var authorView = Mapper.Map<ComplexAuthorViewModel>(authorItem);
        //        authorListView.Add(authorView);
        //    }

        //    return View(authorListView);
        //}
    }
}