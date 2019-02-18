using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using test.Models;

namespace test.repositorio
{
    public class user
    {
        private readonly testApplicationEntities entDev;

        public user(testApplicationEntities ent)
        {
            entDev = ent;
        }

        public string getUser(users data)
        {
            try
            {
                var result = entDev.usuarios.First(u => u.username == data.Usuario).username;
                return result;
            }
            catch(Exception ex)
            {
                return "";
            }
        }

        public List<artista> getArtistas()
        {
            return entDev.artista.ToList();
        }

        public  artistas  editArtista(int id)
        {
            var consulta = entDev.artista.Where(u => u.idArtista == id).First();
            artistas result = new artistas
            {
                idArtista = consulta.idArtista,
                nameArtista = consulta.nameArtista
            };

            return result;
            
        }

        public bool artistaEdit(artistas data)
        {
            artista info = new artista
            {
                idArtista = data.idArtista,
                nameArtista = data.nameArtista
            };
            entDev.artista.Attach(info);
            entDev.Entry(info).State = System.Data.Entity.EntityState.Modified;
            entDev.SaveChanges();
            return true;
        }

        public bool deleteArtista(int id)
        {
            try
            {
                var resultAlbum = entDev.album.Where(u => u.idArtista == id).ToList();
                entDev.album.RemoveRange(resultAlbum);
                entDev.SaveChanges();
                var resultArtista = entDev.artista.Where(u => u.idArtista == id).First();
                entDev.artista.Attach(resultArtista);
                entDev.Entry(resultArtista).State = System.Data.Entity.EntityState.Deleted;
                entDev.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
           
        }

        public bool createArtista(artistas data)
        {
            artista info = new artista
            {
                nameArtista = data.nameArtista
            };
            try { 
                entDev.artista.Add(info);
                entDev.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public List<album> getAlbum(int id)
        {
            return entDev.album.Where(u => u.idArtista == id).ToList();
        }

        public album editAlbum(int id)
        {
            var consulta = entDev.album.Where(u => u.idArtista == id).First();
            album result = new album
            {
                idAlbum = consulta.idAlbum,
                nombre = consulta.nombre,
                genero = consulta.genero,
                fecha = consulta.fecha,
                idArtista = consulta.idArtista
            };

            return result;

        }

        public bool editarAlbum(album data)
        {
            album info = new album
            {
                idAlbum = data.idAlbum,
                nombre = data.nombre,
                genero = data.genero,
                fecha = data.fecha,
                idArtista = data.idArtista
            };
            entDev.album.Attach(info);
            entDev.Entry(info).State = System.Data.Entity.EntityState.Modified;
            entDev.SaveChanges();
            return true;
        }

        public bool deleteAlbum(int id)
        {
            var result = entDev.album.Where(u => u.idArtista == id).First();
            entDev.album.Attach(result);
            entDev.Entry(result).State = System.Data.Entity.EntityState.Deleted;
            entDev.SaveChanges();
            return true;
        }

        public List<SelectListItem> obtenerArtistaSelect()
        {
            var artista = entDev.artista.ToList();

             return artista.Select(a => new SelectListItem {
                Value = a.idArtista.ToString(),
                Text = a.nameArtista
             }).ToList();
        }

        public bool crearAlbum(album data)
        {
            album info = new album
            {
                nombre = data.nombre,
                genero = data.genero,
                fecha = Convert.ToDateTime(data.fecha),
                idArtista = data.idArtista
            };
            try
            {
                entDev.album.Add(info);
                entDev.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}