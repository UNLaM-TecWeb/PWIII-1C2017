using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace Entidades
{
 [MetadataType(typeof(LoginMetadata))]
    public partial class Usuarios
    {
         public class LoginMetadata
         {
             [Required]
             [StringLength(3, MinimumLength = 3)]
             public string NombreUsuario { get; set; }
         }
    }
}
