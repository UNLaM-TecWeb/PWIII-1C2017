using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace DAL
{
    public class PersistenciaCartelera
    {
        MyContext ctx = new MyContext();
            
        public void AlmacenarCartelera(Carteleras c)
        {
            ctx.Carteleras.Add(c);
            ctx.SaveChanges();
        }

        public void EliminarCartelera(int id)
        {
            var Query = from c in ctx.Carteleras where c.IdCartelera == id select c;            

            foreach(var cartelera in Query)
            {
                ctx.Carteleras.Remove(cartelera);
            }
            ctx.SaveChanges();

        }

        public void ActualizarCartelera(Carteleras cart)
        {
            // Realizo la consulta para la sede especifica
            var query = (from c in ctx.Carteleras where c.IdCartelera == cart.IdCartelera select c).First();

                query.Domingo = cart.Domingo;
                query.FechaFin = cart.FechaFin;
                query.FechaInicio = cart.FechaInicio;
                query.HoraInicio = cart.HoraInicio;
                query.IdPelicula = cart.IdPelicula;
                query.IdSede = cart.IdSede;
                query.IdVersion = cart.IdVersion;
                query.Jueves = cart.Jueves;
                query.Lunes = cart.Lunes;
                query.Martes = cart.Martes;
                query.Miercoles = cart.Miercoles;
                query.NumeroSala = cart.NumeroSala;
                query.Sabado = cart.Sabado;

            ctx.SaveChanges();

        }

        public List<Carteleras> ObtenerCarteleraPorSedeSalaVersion(int sede, int sala, int version, int pelicula, int cartelera)
        {
            var Query = (from c in ctx.Carteleras where c.IdSede == sede && c.NumeroSala == sala && c.IdPelicula == pelicula && c.IdCartelera != cartelera  && c.IdVersion == version select c).ToList();            
            return Query;
        }

        public List<Carteleras> ObtenerCarteleras()
        {
            var carteleras = (from c in ctx.Carteleras select c).ToList();
            
            return carteleras;
        }

        public List<Carteleras> ObtenerCartelerasSedeSalaFecha(int sede, int sala, DateTime inicio, DateTime fin, int cartelera)
        {
            var Query = (from c in ctx.Carteleras 
                         where c.IdSede == sede && c.IdCartelera != cartelera &&
                               c.NumeroSala == sala && (
                               (c.FechaInicio >= inicio && c.FechaInicio <= fin) || (c.FechaFin <= fin && c.FechaFin >= inicio) )
                         select c).ToList();
           return Query;
        }

        public List<Carteleras> OBtenerCartelerasPorFecha(DateTime fecha)
        {
            DateTime fechaTope = fecha.AddDays(30);
            var Query = (from c in ctx.Carteleras
                         where c.FechaInicio <= fechaTope 
                         where c.FechaFin > fecha
                         select c).ToList();
            return Query;
        }

        public Carteleras ObtenerCartelera(int id)
        {
            var Query = (from c in ctx.Carteleras where c.IdCartelera == id select c).First();

            return Query;
        }

        public List<Carteleras> ObtenerCartelerasPorPeliculaFecha(int id, DateTime limite, DateTime hoy)
        {
            var Query = (from c in ctx.Carteleras 
                                                where 
                                                c.IdPelicula == id &&
                                                (c.FechaInicio >= hoy && c.FechaInicio <= limite) ||
                                                (c.FechaFin <= limite && c.FechaFin >= hoy)
                                                select c).ToList();
            return Query;
        }

        public List<Carteleras> ObtenerCartelerasVersionPelicula(int version, int pelicula)
        {
            
            var Query = (from c in ctx.Carteleras where c.IdVersion == version && c.IdPelicula == pelicula select c).ToList();
            
            return Query;
        }

        public Carteleras ObtenerCarteleraSedePeliculaVersion(int sede, int pelicula, int version)
        {
            var Query = (from c in ctx.Carteleras where c.IdPelicula == pelicula && c.IdSede == sede && c.IdVersion == version select c).First();
            return Query;
        }
    }
}
