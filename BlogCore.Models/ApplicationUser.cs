using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogCore.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required(ErrorMessage = "El nombre es requerido")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La dirección es requerida")]
        [Display(Name = "Dirección")]
        public string Dirección { get; set; }

        [Required(ErrorMessage = "La ciudad es requerida")]
        public string Ciudad { get; set; }

        [Required(ErrorMessage = "El país es requerido")]
        [Display(Name = "País")]
        public string Pais { get; set; }


    }
}
