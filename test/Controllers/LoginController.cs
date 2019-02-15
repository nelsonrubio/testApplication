using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using test.Models;
using test.repositorio;

namespace test.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        protected readonly testApplicationEntities Ent = new testApplicationEntities();
        public ActionResult Index()
        {
            var model = new users();
            return View(model);
        }
        [HttpPost]
        public ActionResult Index(users data)
        {
          
            var repo = new user(Ent);
            var result = repo.getUser(data);
            if(result != "")
            {
                Session["user"] = result;
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}