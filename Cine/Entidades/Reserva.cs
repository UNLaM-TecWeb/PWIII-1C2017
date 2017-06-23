
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace Entidades
{
   [MetadataType(typeof(ReservaMetadata))]
    public  partial class Reservas
    {
       public class ReservaMetadata
       {

           public int IdReserva { get; set; }
           [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
           public string Email { get; set; }

           [Required(ErrorMessage = "La cantidad de entrada es requerida")]
           public int CantidadEntradas { get; set; }

           [Required(ErrorMessage = "El numero de documento es requerido")]
           public string NumeroDocumento { get; set; }
       }

    }
}
