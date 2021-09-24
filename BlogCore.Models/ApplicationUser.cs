using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace BlogCore.Models
{
    // al heredar de IdentityUser vamos añadir estos campos a esa tabla al IdentityUser, los campos que ya tiene esa tabla le agregamos estos mismos tambien.
    // luego vamos a BlogCore.AccesoDatos/Data/ y en el ApplicationDbContext agregamos esta tabla con el DbSet<>.
    public class ApplicationUser : IdentityUser
    {
        [Required(ErrorMessage = "El nombre es obligatorio!")]
        public string Nombre { get; set; }

        public string Direccion { get; set; }

        [Required(ErrorMessage = "La ciudad es obligatoria!")]
        public string Ciudad { get; set; }

        [Required(ErrorMessage = "El pais es obligatorio!")]
        public string Pais { get; set; }
    }
}
