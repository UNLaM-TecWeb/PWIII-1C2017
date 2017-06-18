using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [MetadataType(typeof(LoginMetadata))]
    public partial class Usuarios
    {
    public class LoginMetadata
    {
        [Required]
        [StringLength(5, MinimumLength = 5)]
        public string NombreUsuario { get; set; }
    }

    }
}
