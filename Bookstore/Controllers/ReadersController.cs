using System;
using System.Linq;
using System.Web.Mvc;
using Bookstore.Models;
using System.Data.Entity;
using Bookstore.ViewModels;
using AutoMapper;
using System.Collections.Generic;
using Bookstore.BL;

namespace Bookstore.Controllers
{
    public class ReadersController : Controller
    {
        readonly IReaderBL businessLayer;

        public ReadersController(IReaderBL _businessLayer)
        {
            businessLayer = _businessLayer;
        }

        public ActionResult Index()
        {
            var itemList = businessLayer.findAll();

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

            businessLayer.create(createdItem);

            return RedirectToAction("Index");
        }

        public ActionResult Details(Guid id)
        {
            var itemToDetail = businessLayer.findByKey(id);

            var itemToDetailView = Mapper.Map<ReaderViewModel>(itemToDetail);

            return View(itemToDetailView);
        }

        public ActionResult Update(Guid id)
        {
            var itemToUpdate = businessLayer.findByKey(id);

            var itemToUpdateView = Mapper.Map<ReaderViewModel>(itemToUpdate);

            return View(itemToUpdateView);
        }

        [HttpPost]
        public ActionResult Update(ReaderViewModel updatedItemView)
        {
            var updatedItem = Mapper.Map<Reader>(updatedItemView);

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