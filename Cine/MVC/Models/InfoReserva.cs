using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class InfoReserva
    {
        public string Sede { set; get; }
        public string Version { set; get; }
        public string Pelicula { set; get; }
        public decimal Precio { set; get; }
        public int IdVersion { set; get; }
        public int IdCartelera { set; get; }
        public int IdSede { set; get; }
        public int Horarios { get; set; }


    }
}