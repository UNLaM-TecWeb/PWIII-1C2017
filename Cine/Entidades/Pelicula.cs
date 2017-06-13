using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Entidades
{
    [MetadataType(typeof(PeliculaMetaData))]
    public partial class Peliculas
    {
        public class PeliculaMetaData
        {
            [Required]
            [StringLength(30, MinimumLength = 3)]
            public string Nombre { get; set; }

            [Required]
            [StringLength(500, MinimumLength = 5)]
            public string Descripcion { get; set; }

            [Required]
            public string Imagen { get; set; }

            [Required]
            [Range(45, 200, ErrorMessage = "La duracion debe estar entre 45 a 200 minutos")]
            public int Duracion { get; set; }
        }
    }
}
