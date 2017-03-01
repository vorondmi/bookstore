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
        readonly IBookBL businessLayer;

        public BooksController(IBookBL _businessLayer)
        {
            businessLayer = _businessLayer;
        }

        public ActionResult Index()
        {
            var itemList = businessLayer.findAll();

            var itemListView = new List<BookViewModel>();

            foreach (var item in itemList)
            {
                itemListView.Add(Mapper.Map<BookViewModel>(item));
            }

            return View(itemListView);
        }

        public ActionResult Create()
        {
            BookViewModel book = new BookViewModel();
            book.authors = db.authors.ToList();
            book.isbns = db.isbns.ToList();

            book.readerCheckBoxes = new List<CheckBoxModel>();
            foreach(Reader r in db.readers.ToList())
            {
                book.readerCheckBoxes.Add(new CheckBoxModel(r.id, r.name, false));
            }

            return View(book);
        }

        [HttpPost]
        public ActionResult Create(BookViewModel createdItemView)
        {
            createdItemView.id = Guid.NewGuid();

            var createdItem = Mapper.Map<Book>(createdItemView);
            createdItem.isbn = db.isbns.Where(i => i.id.Equals(createdItemView.isbnID)).FirstOrDefault();
            createdItem.author = db.authors.Where(a => a.id.Equals(createdItemView.authorID)).FirstOrDefault();

            List<Guid> readerIDs = createdItemView.readerCheckBoxes.Where(r => r.Checked).Select(cb => cb.id).ToList();
            createdItem.readers = db.readers.Where(r => readerIDs.Any(i => i.Equals(r.id))).ToList();

            db.books.Add(createdItem);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Details(Guid id)
        {
            var itemToDetail = db.books.Where(item => item.id.Equals(id)).FirstOrDefault();

            return View(itemToDetail);
        }

        public ActionResult Update(Guid id)
        {
            var itemToUpdate = db.books.Where(item => item.id.Equals(id)).FirstOrDefault();

            var itemToUpdateView = Mapper.Map<BookViewModel>(itemToUpdate);
            itemToUpdateView.authors = db.authors.ToList();

            return View(itemToUpdateView);
        }

        [HttpPost]
        public ActionResult Update(BookViewModel updatedItemView)
        {
            var updatedItem = Mapper.Map<Book>(updatedItemView);

            db.books.Attach(updatedItem);
            db.Entry(updatedItem).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Delete(Guid id)
        {
            Book itemToDelete = db.books.Where(item => item.id.Equals(id)).FirstOrDefault();
            db.books.Remove(itemToDelete);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}