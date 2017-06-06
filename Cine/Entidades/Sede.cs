using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Entidades
{
    public class Sede
    {
        public int IdSede { get; set; }

        [Required(ErrorMessage = "Es necesario ingresar un nombre de sede")]
        [StringLength(25, MinimumLength = 3, ErrorMessage = "La Sede debe tener entre 3 y 25 letras")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Es necesario ingresar una direccion de sede")]
        [StringLength(40, MinimumLength = 3, ErrorMessage = "La Direccion debe tener entre 3 y 40 letras")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "Es necesario ingresar un precio de entrada general")]
        [Range(1, 300, ErrorMessage = "El valor de la entrada debe estar entre 1 y 300")]
        public decimal PrecioGeneral { get; set; }
    }
}
