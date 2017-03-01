using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bookstore.Models;
using System.Data.Entity;
using Bookstore.ViewModels;
using AutoMapper;

namespace Bookstore.Controllers
{
    public class AuthorsController : Controller
    {
        private BookStoreContext db = new BookStoreContext();

        public ActionResult Index()
        {
            var itemList = db.authors.ToList();

            var itemListView = new List<AuthorViewModel>();

            foreach(var item in itemList)
            {
                itemListView.Add(Mapper.Map<AuthorViewModel>(item));
            }

            return View(itemListView);
        }

        public ActionResult Create()
        {
            return View(new AuthorViewModel());
        }

        [HttpPost]
        public ActionResult Create(AuthorViewModel createdItemView)
        {
            var createdItem = Mapper.Map<Author>(createdItemView);

            createdItem.id = Guid.NewGuid();

            db.authors.Add(createdItem);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Details(Guid id)
        {
            var itemToDetail = db.authors.Where(item => item.id.Equals(id)).FirstOrDefault();

            var itemToDetailView = Mapper.Map<AuthorViewModel>(itemToDetail);

            return View(itemToDetailView);
        }

        public ActionResult Update(Guid id)
        {
            var itemToUpdate = db.authors.Where(item => item.id.Equals(id)).FirstOrDefault();

            var itemToUpdateView = Mapper.Map<AuthorViewModel>(itemToUpdate);
            return View(itemToUpdateView);
        }

        [HttpPost]
        public ActionResult Update(Author updatedItemView)
        {
            var updatedItem = Mapper.Map<Author>(updatedItemView);

            db.authors.Attach(updatedItem);
            db.Entry(updatedItem).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Delete(Guid id)
        {
            Author itemToDelete = db.authors.Where(item => item.id.Equals(id)).FirstOrDefault();
            db.authors.Remove(itemToDelete);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}