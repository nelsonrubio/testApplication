using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using test.Models;
using test.repositorio;

namespace test.Controllers
{
    public class ArtistasController : Controller
    {
        protected readonly testApplicationEntities Ent = new testApplicationEntities();
        // GET: Artistas
        public ActionResult Index()
        {
            var model = new artistas();
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(artistas data)
        {
            var repo = new user(Ent);
            if (repo.createArtista(data))
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }

        public ActionResult editArtista(string id)
        {
            var repo = new user(Ent);
            var model = repo.editArtista(int.Parse(id));
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(artistas data)
        {
            var repo = new user(Ent);
            var result = repo.artistaEdit(data);
            return RedirectToAction("Index", "Home");
        }

        public ActionResult deleteArtista(string id)
        {
            var repo = new user(Ent);
            var result = repo.deleteArtista(int.Parse(id));
            return RedirectToAction("Index", "Home");
        }

        public ActionResult createArtista()
        {
            var model = new artistas();
            return View(model);
        }

        [HttpPost]
        public ActionResult createArtista(artistas data)
        {
            if (ModelState.IsValid)
            {
                var repo = new user(Ent);
                if (repo.createArtista(data))
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return View();
                }
            } else
            {
                return View(data);
            }
        }
    }
}