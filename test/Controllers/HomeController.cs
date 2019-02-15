using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using test.Models;
using test.repositorio;

namespace test.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        protected readonly testApplicationEntities Ent = new testApplicationEntities();
        public ActionResult Index( )
        {
            var repo = new user(Ent);
            var model = repo.getArtistas();
   
            return View(model);
        }

     }
}