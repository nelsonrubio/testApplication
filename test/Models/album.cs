using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace test.Models
{
    public class album
    {
        public int idAlbum { get; set; }
        [Required]
        [Display(Name = "Nombre del album")]
        public string nombre { get; set; }
        [Required]
        [Display(Name = "Genero")]
        public string genero { get; set; }
        [Required]
        [Display(Name = "Fecha")]
        public string fecha { get; set; }
        [Required]
        [Display(Name = "Nombre del artista")]
        public int idArtista { get; set; }
    }
}