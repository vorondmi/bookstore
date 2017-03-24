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

        public ActionResult Index()
        {
            return View("Index");
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
    }
}