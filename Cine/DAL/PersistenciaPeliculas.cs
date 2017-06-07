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

        public List<Generos> ObtenerGeneros()
        {
            var generos = (from g in ctx.Generos select g).ToList();
            List<Generos> listaGeneros = new List<Generos>();

            foreach(Generos genero in generos)
            {
                Generos ge = new Generos();
                ge.IdGenero = genero.IdGenero;
                ge.Nombre = genero.Nombre;
                listaGeneros.Add(ge);
            }
           
            return listaGeneros;
        }

        public List<Calificaciones> ObtenerCalificaciones()
        {
            var calificaciones = (from c in ctx.Calificaciones select c).ToList();
            List<Calificaciones> listaCalificaciones = new List<Calificaciones>();
            
            foreach(Calificaciones calificacion in calificaciones)
            {
                Calificaciones cal = new Calificaciones();
                cal.IdCalificacion = calificacion.IdCalificacion;
                cal.Nombre = calificacion.Nombre;
                listaCalificaciones.Add(cal);
            }

            return listaCalificaciones;
        }

        public void AlmacenarPelicula(Peliculas p)
        {
            ctx.Peliculas.Add(p);
            ctx.SaveChanges();
        }

        public List<Peliculas> ObtenerPeliculas()
        {
            var peliculas = (from p in ctx.Peliculas select p).ToList();
            return peliculas;
        }
    }
}
