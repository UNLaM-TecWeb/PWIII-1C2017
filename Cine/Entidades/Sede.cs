using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Entidades
{
    [MetadataType(typeof(SedeMetadata))]
    public partial class Sedes
    {
        public class SedeMetadata
        {
            [Required (ErrorMessage = "El nombre de la sede debe tener al menos 3 letras y como maximo 20")]
            [StringLength(20, MinimumLength = 3)]
            public string Nombre { get; set; }

            [Required (ErrorMessage = "La direccion de la sede es requerida.")]
            [StringLength(20, MinimumLength = 3)]
            public string Direccion { get; set; }

            [Required]
            [Range(1, 300, ErrorMessage = "El Precio de la entrada debe estar entre 1 y 300 pesos")]
            public decimal PrecioGeneral { get; set; }
        }
    }
}
