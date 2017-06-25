using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [MetadataType(typeof(CarteleraMetadata))]
    public partial class Carteleras
    {
        public class CarteleraMetadata
        {
            [Required(ErrorMessage = "Indicar la Sede de la cartelera")]
            public int IdSede { get; set; }

            [Required(ErrorMessage = "Indicar la Pelicula de la cartelera")]
            public int IdPelicula { get; set; }

            [Required(ErrorMessage = "Indicar hora de inicio de cartelera")]
            [Range(8, 14, ErrorMessage = "Hora de Inicio entre las 8 AM y las 14 PM")]
            public int HoraInicio { get; set; }

            [Required(ErrorMessage = "Indicar Fecha de Inicio de cartelera")]
            public System.DateTime FechaInicio { get; set; }

            [Required(ErrorMessage = "Indicar Fecha de Fin de cartelera")]
            public System.DateTime FechaFin { get; set; }

            [Required]
            public int NumeroSala { get; set; }

            [Required]
            public int IdVersion { get; set; }

        }
    }
}
