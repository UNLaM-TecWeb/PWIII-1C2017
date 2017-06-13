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
            [Required]
            [StringLength(20, MinimumLength = 3)]
            public string Nombre { get; set; }

            [Required]
            public string Direccion { get; set; }

            [Required]
            [Range(1, 300, ErrorMessage = "El precio de la entrada debe estar entre 1 y 300")]  
            public decimal PrecioGeneral { get; set; }
        }
    }
}
