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
            var itemList = authorBL.findAll();

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

            if (authorBL.create(createdItem) == 0)
            {
                return RedirectToAction("Index");
            }

            return View(createdItemView);
        }

        public ActionResult Details(Guid id)
        {
            var itemToDetail = authorBL.findByKey(id);

            var itemToDetailView = Mapper.Map<AuthorViewModel>(itemToDetail);

            return View(itemToDetailView);
        }

        public ActionResult Update(Guid id)
        {
            var itemToUpdate = authorBL.findByKey(id);

            var itemToUpdateView = Mapper.Map<AuthorViewModel>(itemToUpdate);
            return View(itemToUpdateView);
        }

        [HttpPost]
        public ActionResult Update(Author updatedItemView)
        {
            var updatedItem = Mapper.Map<Author>(updatedItemView);

            if (authorBL.update(updatedItem) == 0)
            {
                return RedirectToAction("Index");
            }

            return View(updatedItemView);
        }

        public ActionResult Delete(Guid id)
        {
            authorBL.delete(id);

            return RedirectToAction("Index");
        }
    }
}