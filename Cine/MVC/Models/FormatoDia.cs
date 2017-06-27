using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class FormatoDia
    {
        public string id { get; set; }
        public string fecha { get; set; }
        public int IdSede { get; set; }
        public int IdVersion { get; set; }
        public int IdPelicula { get; set; }
        public int Hora { get; set; }

    }
}