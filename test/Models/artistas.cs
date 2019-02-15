using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace test.Models
{
    public class artistas
    {

        [Required]
        [Display(Name = "Nombre de artista")]
        public string nameArtista { get; set; }
 
        public int idArtista { get; set; }
    }
}