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
        readonly IISBNBL businessLayer;

        public ISBNController(IISBNBL _businessLayer)
        {
            businessLayer = _businessLayer;
        }

        public ActionResult Index()
        {
            var itemList = businessLayer.findAll();

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
            createdItem.id = Guid.NewGuid();

            businessLayer.create(createdItem);

            return RedirectToAction("Index");
        }

        public ActionResult Details(Guid id)
        {
            var itemToDetail = businessLayer.findByKey(id);

            var itemToDetailView = Mapper.Map<ISBNViewModel>(itemToDetail);

            return View(itemToDetailView);
        }

        public ActionResult Update(Guid id)
        {
            var itemToUpdate = businessLayer.findByKey(id);

            var itemToUpdateView = Mapper.Map<ISBNViewModel>(itemToUpdate);

            return View(itemToUpdateView);
        }

        [HttpPost]
        public ActionResult Update(ISBNViewModel updatedItemView)
        {
            var updatedItem = Mapper.Map<ISBN>(updatedItemView);

            businessLayer.update(updatedItem);

            return RedirectToAction("Index");
        }

        public ActionResult Delete(Guid id)
        {
            businessLayer.delete(id);

            return RedirectToAction("Index");
        }
    }
}