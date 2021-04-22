using GestToDo.Api.Models.Client.Entities;
using GestToDo.Api.Repositories;
using GestToDo.MVC.Infrastructure;
using GestToDo.MVC.Models.Forms;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestToDo.MVC.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthRepository<User> _repository;

        public AuthController()
        {
            _repository = ResourceLocator.Instance.AuthRepository;
        }

        // GET: Auth
        public ActionResult Index()
        {
            return RedirectToAction("Login");
        }

        public ActionResult Login()
        {
            
                return View();
                       
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Login(LoginForm form)
        {
            try
            {
                
                if (ModelState.IsValid)
                {
                    try
                    {
                        User user = _repository.Login(form.Email, form.Passwd);
                        if(user is null)
                        {
                            ViewBag.Error = "Email ou mot de passe invalide!";
                            return View(form);
                        }

                        //Session
                        SessionManager.User = user;
                        SessionManager.IsAdmin = true;
                        return RedirectToAction("Index", "ToDo");
                    }
                    catch (DbException)
                    {
                        //Log le message d'erreur
                        ViewBag.Error = "Une erreur est survenue avec la base de données, merci de contact l'adminstrateur du site";
                        return View(form);
                    }
                }

                return View(form);
            }
            catch (Exception ex)
            {
                //Log le message d'erreur
                return View("Error");
            }
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Register()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Register(RegisterForm form)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        User user = new User(form.LastName, form.FirstName, form.Email, form.Passwd);
                        _repository.Register(user);
                        return RedirectToAction("Login");
                    }
                    catch (DbException)
                    {
                        //Log le message d'erreur
                        ViewBag.Error = "Une erreur est survenue avec la base de données, merci de contact l'adminstrateur du site";
                        return View(form);
                    }
                }

                return View(form);
            }
            catch (Exception ex)
            {
                //Log le message d'erreur
                return new HttpStatusCodeResult(500);
            }
        }
    }
}