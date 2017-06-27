using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class PeliculasInicio
    {
        public int IdCartelera { get; set; }
        public int IdPelicula { get; set; }
        public string Imagen { get; set; }
        public string Nombre { get; set; }
        public string Genero { get; set; }
        public string Calificacion { get; set; }
    }
}