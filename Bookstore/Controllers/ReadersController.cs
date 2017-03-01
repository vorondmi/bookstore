using System;
using System.Linq;
using System.Web.Mvc;
using Bookstore.Models;
using System.Data.Entity;
using Bookstore.ViewModels;
using AutoMapper;
using System.Collections.Generic;

namespace Bookstore.Controllers
{
    public class ReadersController : Controller
    {
        private BookStoreContext db = new BookStoreContext();

        public ActionResult Index()
        {
            var itemList = db.readers.ToList();

            var itemListView = new List<ReaderViewModel>();

            foreach (var item in itemList)
            {
                itemListView.Add(Mapper.Map<ReaderViewModel>(item));
            }

            return View(itemListView);
        }

        public ActionResult Create()
        {
            return View(new ReaderViewModel());
        }

        [HttpPost]
        public ActionResult Create(ReaderViewModel createdItemView)
        {
            var createdItem = Mapper.Map<Reader>(createdItemView);

            createdItem.id = Guid.NewGuid();

            db.readers.Add(createdItem);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Details(Guid id)
        {
            var itemToDetail = db.readers.Where(item => item.id.Equals(id)).FirstOrDefault();

            var itemToDetailView = Mapper.Map<ReaderViewModel>(itemToDetail);

            return View(itemToDetailView);
        }

        public ActionResult Update(Guid id)
        {
            var itemToUpdate = db.readers.Where(item => item.id.Equals(id)).FirstOrDefault();

            var itemToUpdateView = Mapper.Map<ReaderViewModel>(itemToUpdate);

            return View(itemToUpdateView);
        }

        [HttpPost]
        public ActionResult Update(ReaderViewModel updatedItemView)
        {
            var updatedItem = Mapper.Map<Reader>(updatedItemView);

            db.readers.Attach(updatedItem);
            db.Entry(updatedItem).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Delete(Guid id)
        {
            Reader itemToDelete = db.readers.Where(item => item.id.Equals(id)).FirstOrDefault();
            db.readers.Remove(itemToDelete);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}