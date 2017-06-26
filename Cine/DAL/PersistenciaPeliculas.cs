using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

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

        public Generos ObtenerGenero(int id)
        {
            var genero = (from g in ctx.Generos where g.IdGenero == id select g).First();


            return genero;
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

        public Calificaciones ObtenerCalificacion(int id)
        {
            var calificacion = (from c in ctx.Calificaciones where c.IdCalificacion == id select c).First();

            return calificacion;
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

        public Peliculas ObtenerPelicula(int id)
        {
            var query = from p in ctx.Peliculas where p.IdPelicula == id select p;

            Peliculas pel = new Peliculas();
            foreach (Peliculas p in query)
            {
                pel.IdPelicula = p.IdPelicula;
                pel.Nombre = p.Nombre;
                pel.Descripcion = p.Descripcion;
                pel.Imagen = p.Imagen;
                pel.IdCalificacion = p.IdCalificacion;
                pel.IdGenero = p.IdGenero;
                pel.Duracion = p.Duracion;
            }
            return pel;
        }

        public void ActualizarPelicula(Peliculas pe)
        {
            // Realizo la consulta para la pelicula especifica
            var query = from p in ctx.Peliculas where p.IdPelicula == pe.IdPelicula select p;


            foreach (Peliculas p in query)
            {
                p.Nombre = pe.Nombre;
                p.Descripcion = pe.Descripcion;
                p.Imagen = pe.Imagen;
                p.IdCalificacion = pe.IdCalificacion;
                p.IdGenero = pe.IdGenero;
                p.Duracion = pe.Duracion;
            }

            ctx.SaveChanges();

        }
    
        public List<Versiones> ObtenerVersiones()
        {
            var versiones = (from v in ctx.Versiones select v).ToList();

            return versiones;
        }



        //public Peliculas ObtenerPeliculas(Peliculas pe)
        //{
        //    var query = (from p in ctx.Peliculas where p.IdPelicula == pe.IdPelicula select p).ToList();

        //    Peliculas pel = new Peliculas();
        //    foreach (Peliculas p in query)
        //    {
        //        pel.IdPelicula = pe.IdPelicula;
        //        pel.Nombre = pe.Nombre;
        //        pel.Descripcion = pe.Descripcion;
        //        pel.Imagen = pe.Imagen;
        //        pel.IdCalificacion = p.IdCalificacion;
        //        pel.IdGenero = pe.IdGenero;
        //        pel.Duracion = pe.Duracion;
        //    }
        //    return pel;
        //}
    }
}
