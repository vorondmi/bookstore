using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bookstore.Models;
using System.Data.Entity;
using Bookstore.ViewModels;
using AutoMapper;
using Bookstore.BL;

namespace Bookstore.Controllers
{
    public class AuthorsController : Controller
    {
        readonly IAuthorBL authorBL;

        public AuthorsController(IAuthorBL authorBL)
        {
            this.authorBL = authorBL;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Details()
        {
            return View();
        }

        public ActionResult Update()
        {
            //var itemToUpdate = authorBL.FindAuthorByKey(id);

            //var itemToUpdateView = Mapper.Map<AuthorViewModel>(itemToUpdate);
            //return View(itemToUpdateView);
            return View();
        }

        [HttpPost]
        public ActionResult Update(Author updatedItemView)
        {
            var updatedItem = Mapper.Map<Author>(updatedItemView);

            if (authorBL.UpdateAuthor(updatedItem) == 0)
            {
                return RedirectToAction("Index");
            }

            return View(updatedItemView);
        }

        public ActionResult Delete(Guid id)
        {
            authorBL.DeleteAuthorById(id);

            return RedirectToAction("Index");
        }
    }
}