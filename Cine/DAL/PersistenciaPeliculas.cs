using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PersistenciaPeliculas
    {
        MyContext ctx = new MyContext();

        public List<Genero> ObtenerGeneros()
        {
            var generos = (from g in ctx.Generos select g).ToList();
            List<Genero> listaGeneros = new List<Genero>();

            foreach(Generos genero in generos)
            {
                Genero ge = new Genero();
                ge.IdGenero = genero.IdGenero;
                ge.Nombre = genero.Nombre;
                listaGeneros.Add(ge);
            }
           
            return listaGeneros;
        }

        public List<Calificacion> ObtenerCalificaciones()
        {
            var calificaciones = (from c in ctx.Calificaciones select c).ToList();
            List<Calificacion> listaCalificaciones = new List<Calificacion>();
            
            foreach(Calificaciones calificacion in calificaciones)
            {
                Calificacion cal = new Calificacion();
                cal.IdCalificacion = calificacion.IdCalificacion;
                cal.Nombre = calificacion.Nombre;
                listaCalificaciones.Add(cal);
            }

            return listaCalificaciones;
        }

    }
}
