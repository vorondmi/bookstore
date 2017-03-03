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
            var itemList = authorBL.GetAllAuthors();


            var itemListView = Mapper.Map<List<AuthorViewModel>>(itemList);

            

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

            if (authorBL.CreateAuthor(createdItem) == 0)
            {
                return RedirectToAction("Index");
            }

            return View(createdItemView);
        }

        public ActionResult Details(Guid id)
        {
            var itemToDetail = authorBL.FindAuthorByKey(id);

            var itemToDetailView = Mapper.Map<AuthorViewModel>(itemToDetail);

            return View(itemToDetailView);
        }

        public ActionResult Update(Guid id)
        {
            var itemToUpdate = authorBL.FindAuthorByKey(id);

            var itemToUpdateView = Mapper.Map<AuthorViewModel>(itemToUpdate);
            return View(itemToUpdateView);
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

        [HttpPost]
        public ActionResult Update2(string updatedItemView)
        {
         

            return View();
        }

        public ActionResult Delete(Guid id)
        {
            authorBL.DeleteAuthorById(id);

            return RedirectToAction("Index");
        }
    }
}