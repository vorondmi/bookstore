﻿using System;
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
        readonly IAuthorBL businessLayer;

        public AuthorsController(IAuthorBL _businessLayer)
        {
            businessLayer = _businessLayer;
        }

        public ActionResult Index()
        {
            var itemList = businessLayer.findAll();

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

            createdItem.id = Guid.NewGuid();

            businessLayer.create(createdItem);

            return RedirectToAction("Index");
        }

        public ActionResult Details(Guid id)
        {
            var itemToDetail = businessLayer.findByKey(id);

            var itemToDetailView = Mapper.Map<AuthorViewModel>(itemToDetail);

            return View(itemToDetailView);
        }

        public ActionResult Update(Guid id)
        {
            var itemToUpdate = businessLayer.findByKey(id);

            var itemToUpdateView = Mapper.Map<AuthorViewModel>(itemToUpdate);
            return View(itemToUpdateView);
        }

        [HttpPost]
        public ActionResult Update(Author updatedItemView)
        {
            var updatedItem = Mapper.Map<Author>(updatedItemView);

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