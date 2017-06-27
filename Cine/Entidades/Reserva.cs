
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace Entidades
{
   [MetadataType(typeof(ReservaMetadata))]
    public partial class Reservas
    {
       public class ReservaMetadata
       {
           [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "El email es invalido")]
           [Required]
           [StringLength(20)]
           public string Email { get; set; }

           [Required(ErrorMessage = "La cantidad de entrada es requerida")]
           [Range(1, 10, ErrorMessage = "La cantidad maxima de entradas a comprar es 10")]
           public int CantidadEntradas { get; set; }

           [Required(ErrorMessage = "El numero de documento es requerido")]
           [StringLength(20)]
           public string NumeroDocumento { get; set; }
       }

    }
}
