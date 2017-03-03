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
        readonly IReaderBL readerBL;

        public ReadersController(IReaderBL _readerBL)
        {
            readerBL = _readerBL;
        }

        public ActionResult Index()
        {
            var itemList = readerBL.GetAllReaders();

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

            if(readerBL.CreateReader(createdItem) == 0)
            {
                return RedirectToAction("Index");
            }

            return View(createdItemView);
        }

        public ActionResult Details(Guid id)
        {
            var itemToDetail = readerBL.FindReaderById(id);

            var itemToDetailView = Mapper.Map<ReaderViewModel>(itemToDetail);

            return View(itemToDetailView);
        }

        public ActionResult Update(Guid id)
        {
            var itemToUpdate = readerBL.FindReaderById(id);

            var itemToUpdateView = Mapper.Map<ReaderViewModel>(itemToUpdate);

            return View(itemToUpdateView);
        }

        [HttpPost]
        public ActionResult Update(ReaderViewModel updatedItemView)
        {
            var updatedItem = Mapper.Map<Reader>(updatedItemView);

            if(readerBL.UpdateReader(updatedItem) == 0)
            {
                return RedirectToAction("Index");
            }

            return View(updatedItemView);
        }

        public ActionResult Delete(Guid id)
        {
            readerBL.DeleteReaderById(id);

            return RedirectToAction("Index");
        }
    }
}