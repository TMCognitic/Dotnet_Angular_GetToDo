using GestToDo.Api.Models.Client.Entities;
using GestToDo.Api.Repositories;
using GestToDo.MVC.Infrastructure;
using V = GestToDo.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestToDo.MVC.Controllers
{
    [AuthRequired]
    public class ToDoController : Controller
    {
        private IToDoRepository<ToDo> _repository;

        public ToDoController()
        {
            _repository = ResourceLocator.Instance.ToDoRepository;
        }

        // GET: ToDo
        public ActionResult Index()
        {
            return View(_repository.Get(SessionManager.User.Id).Select(t => new V.ToDo { Title = t.Title, Description = t.Description }));
        }

        // GET: ToDo/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ToDo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ToDo/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ToDo/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ToDo/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ToDo/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ToDo/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
