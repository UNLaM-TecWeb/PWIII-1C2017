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
       [Required(ErrorMessage = "El usuario es invalido")]
        [StringLength(10, MinimumLength = 5)]
        public string NombreUsuario { get; set; }
    }

    }
}
