using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace test.Models
{
    public class users
    {
        [Required]
        [Display(Name = "Usuario")]
        public string Usuario { get; set; }

    }
}