using System;
using System.Linq;
using System.Web.Mvc;
using Bookstore.Models;
using System.Data.Entity;
using Bookstore.ViewModels;
using AutoMapper;
using System.Collections.Generic;
using Microsoft.Practices.Unity;
using Bookstore.BL;

namespace Bookstore.Controllers
{
    public class BooksController : Controller
    {
        readonly IBookBL bookBL;
        readonly IAuthorBL authorBL;
        readonly IISBNBL isbnBL;
        readonly IReaderBL readerBL;

        public BooksController(IBookBL _bookBL, IAuthorBL _authorBL, IISBNBL _isbnBL, IReaderBL _readerBL)
        {
            bookBL = _bookBL;
            authorBL = _authorBL;
            isbnBL = _isbnBL;
            readerBL = _readerBL;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(BookViewModel createdItemView)
        {
            //var createdItem = Mapper.Map<Book>(createdItemView);

            //List<Guid> readerIDs = createdItemView.readerCheckBoxes.Where(r => r.Checked).Select(cb => cb.id).ToList();
            //if (bookBL.CreateBook(createdItem, createdItemView.authorID, createdItemView.isbnID, readerIDs) == 0)
            //{
            //    return RedirectToAction("Index");
            //}

            //return View(createdItemView);
            return View();
        }

        public ActionResult Details()
        {
            return View();
        }

        public ActionResult Update(Guid id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Update(BookViewModel updatedItemView)
        {
            var updatedItem = Mapper.Map<Book>(updatedItemView);

            if (bookBL.UpdateBook(updatedItem) == 0)
            {
                return RedirectToAction("Index");
            }

            return View(updatedItemView);
        }

        public ActionResult Delete(Guid id)
        {
            bookBL.DeleteBookById(id);

            return RedirectToAction("Index");
        }
    }
}