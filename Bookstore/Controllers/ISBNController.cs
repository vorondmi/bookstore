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
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ISBNViewModel createdItemView)
        {
            var createdItem = Mapper.Map<ISBN>(createdItemView);

            if(isbnBL.CreateISBN(createdItem) == 0)
            {
                return RedirectToAction("Index");
            }

            return View(createdItemView);
        }

        public ActionResult Details()
        {
            return View();
        }

        public ActionResult Update(Guid id)
        {
            var itemToUpdate = isbnBL.FindISBNById(id);

            var itemToUpdateView = Mapper.Map<ISBNViewModel>(itemToUpdate);

            return View(itemToUpdateView);
        }

        [HttpPost]
        public ActionResult Update(ISBNViewModel updatedItemView)
        {
            var updatedItem = Mapper.Map<ISBN>(updatedItemView);

            if(isbnBL.UpdateISBN(updatedItem) == 0)
            {
                return RedirectToAction("Index");
            }

            return View(updatedItemView);
        }

        public ActionResult Delete(Guid id)
        {
            isbnBL.DeleteISBNById(id);

            return RedirectToAction("Index");
        }
    }
}