using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using test.Models;
using test.repositorio;

namespace test.Controllers
{
    public class AlbumController : Controller
    {
        // GET: Album
        protected readonly testApplicationEntities Ent = new testApplicationEntities();
        public ActionResult Index(string id)
        {
            var repo = new user(Ent);
            var model = repo.getAlbum(int.Parse(id));
            ViewBag.idArtista = id;
            return View(model);
        }

        public ActionResult editarAlbum(string id)
        {
            var repo = new user(Ent);
            var model = repo.editAlbum(int.Parse(id));
            return View(model);
        }

        [HttpPost]
        public ActionResult editarAlbum(album data)
        {
            var repo = new user(Ent);
            if (repo.editarAlbum(data))
            {
                return RedirectToAction("Index", "Album", new { id = data.idArtista });
            }
            else
            {
                return RedirectToAction("editarAlbum", "Album", new { id = data.idArtista });
            }
        }

        public ActionResult eliminarAlbum(string id)
        {
            var repo = new user(Ent);
            var result = repo.deleteAlbum(int.Parse(id));
            return RedirectToAction("Index", "Home");
        }

        public ActionResult crearAlbum(string id)
        {
            var repo = new user(Ent);
            var result = repo.obtenerArtistaSelect();
            ViewBag.artista = result;
            ViewBag.idArtista = id;
            return View();
        }
        [HttpPost]
        public ActionResult crearAlbum(album data)
        {
            if (ModelState.IsValid)
            {
                var repo = new user(Ent);
                if (repo.crearAlbum(data))
                {
                    return RedirectToAction("Index", "Album", new { id = data.idArtista });
                }
                else
                {
                    var result = repo.obtenerArtistaSelect();
                    ViewBag.artista = result;
                    return View();
                }
            }
            else
            {
                return View(data);
            }
        }


    }
}