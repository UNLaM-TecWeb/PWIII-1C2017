using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
     [MetadataType(typeof(ClienteMetadata))]
    public partial  class ClienteReserva
    {
         public class ClienteMetadata
         {
             [Required]
             [StringLength(3, MinimumLength = 3)]
             public string NombreUsuario { get; set; }
         }

    }
}
