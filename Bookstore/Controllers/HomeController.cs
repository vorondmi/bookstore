using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bookstore.Models;
using Bookstore.ViewModels;
using AutoMapper;

namespace Bookstore.Controllers
{
    
    public class HomeController : Controller
    {
        BookStoreContext db = new BookStoreContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult BookInfo()
        {
            var books = db.books.ToList();

            List<ComplexBookViewModel> bookList = new List<ComplexBookViewModel>();

            foreach(var book in books)
            {
                ComplexBookViewModel bookViewModel = Mapper.Map<ComplexBookViewModel>(book);
                bookViewModel.isbn = db.isbns.Where(i => i.id.Equals(book.isbn.id)).FirstOrDefault().isbn;
                bookViewModel.authorName = db.authors.Where(a => a.id.Equals(book.author.id)).FirstOrDefault().authorName;

                bookList.Add(bookViewModel);
            }

            return View(bookList.AsEnumerable<ComplexBookViewModel>());
        }

        public ActionResult AuthorInfo()
        {
            var authorsList = db.authors.ToList();

            List<ComplexAuthorViewModel> authorListView = new List<ComplexAuthorViewModel>();
            foreach(var authorItem in authorsList)
            {
                var authorView = Mapper.Map<ComplexAuthorViewModel>(authorItem);
                authorListView.Add(authorView);
            }

            return View(authorListView);
        }
    }
}