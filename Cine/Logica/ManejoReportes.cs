using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entidades;

namespace Logica
{
    public class DatosReporte
    {
        public int NumeroReserva { get; set; }
        public string Sede { get; set; }
        public string Version { get; set; }
        public string Pelicula { get; set; }
        public decimal Precio { get; set; }

        public DatosReporte() { }
        
        public DatosReporte(int numeroReserva, string sede, string version, string pelicula, decimal precio) 
        { 
            NumeroReserva = NumeroReserva;
            Sede = sede;
            Version = version;
            Pelicula = pelicula;
            Precio = precio;
        }
    }

    public class ManejoReportes
    {
        //PersistenciaReserva pReserva = new PersistenciaReserva
        //public List<Reservas> GenerarReporteReservas() // Traigo Todas las Reservas
        //{
        //    return pReserva.ObtenerReservas();
        //}
        MyContext ctx = new MyContext();

        public List<DatosReporte> GenerarReporteReservas(DateTime desde, DateTime hasta) // Traigo Todas las Reservas dentro de un intervalo de tiempo
        {
            var Reporte = from reserva in ctx.Reservas
                          join sede in ctx.Sedes on reserva equals sede.IdSede
                          join version in ctx.Versiones on reserva equals version.IdVersion
                          join pelicula in ctx.Peliculas on reserva equals pelicula.IdPelicula
                          where reserva.FechaCarga >= desde && reserva.FechaCarga <= hasta
                          select new
                          {
                              NumeroReserva = reserva.IdReserva,
                              Sede = sede.Nombre,
                              Version = version.Nombre,
                              Pelicula = pelicula.Nombre,
                              Precio = (sede.PrecioGeneral * reserva.CantidadEntradas)
                          };

            return Reporte.ToList();
        }

    }
}
