using GestToDo.MVC.Areas.Admin.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestToDo.MVC.Areas.Admin.Controllers
{
    [AdminAuthRequired]
    public class HomeController : Controller
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}