using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bookstore.Models;
using Bookstore.ViewModels;
using System.Data.Entity;
using AutoMapper;
using Bookstore.BL;

namespace Bookstore.Controllers
{
    public class ISBNController : Controller
    {
        readonly IISBNBL isbnBL;

        public ISBNController(IISBNBL _isbnBL)
        {
            isbnBL = _isbnBL;
        }

        public ActionResult Index()
        {
            var itemList = isbnBL.findAll();

            var itemListView = new List<ISBNViewModel>();

            foreach (var item in itemList)
            {
                itemListView.Add(Mapper.Map<ISBNViewModel>(item));
            }

            return View(itemListView);
        }

        public ActionResult Create()
        {
            return View(new ISBNViewModel());
        }

        [HttpPost]
        public ActionResult Create(ISBNViewModel createdItemView)
        {
            var createdItem = Mapper.Map<ISBN>(createdItemView);

            if(isbnBL.create(createdItem) == 0)
            {
                return RedirectToAction("Index");
            }

            return View(createdItemView);
        }

        public ActionResult Details(Guid id)
        {
            var itemToDetail = isbnBL.findByKey(id);

            var itemToDetailView = Mapper.Map<ISBNViewModel>(itemToDetail);

            return View(itemToDetailView);
        }

        public ActionResult Update(Guid id)
        {
            var itemToUpdate = isbnBL.findByKey(id);

            var itemToUpdateView = Mapper.Map<ISBNViewModel>(itemToUpdate);

            return View(itemToUpdateView);
        }

        [HttpPost]
        public ActionResult Update(ISBNViewModel updatedItemView)
        {
            var updatedItem = Mapper.Map<ISBN>(updatedItemView);

            if(isbnBL.update(updatedItem) == 0)
            {
                return RedirectToAction("Index");
            }

            return View(updatedItemView);
        }

        public ActionResult Delete(Guid id)
        {
            isbnBL.delete(id);

            return RedirectToAction("Index");
        }
    }
}