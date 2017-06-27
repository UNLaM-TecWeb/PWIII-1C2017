using Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entidades;
using MVC.Models;

namespace MVC.Controllers
{
    public class PeliculasController : Controller
    {
        //
        // GET: /Peliculas/
        ManejoReserva servicioReserva = new ManejoReserva();
        ManejoSedes serviciosSedes = new ManejoSedes();
        ManejoTipoDocumento servicioTipoDoc = new ManejoTipoDocumento();
        ManejoPeliculas servicioPelicula = new ManejoPeliculas();
        ManejoCarteleras servicioCarteleras = new ManejoCarteleras();
       

        public ActionResult ReservasVersiones(int id) // Recibo el IdPelicula
        {
            DateTime fecha = DateTime.Now.AddDays(30);

            // Traigo las carteleras en donde figure esa pelicula y este dentro del rango de fecha valido (De hoy a maximo 30 dias de inicio)
            List<Carteleras> listaCarteleras = servicioCarteleras.TraerCarteleraPorPeliculaYFecha(id, fecha, DateTime.Now);

            // Traigo las versiones sin repetir
            List<Versiones> listaVersiones = servicioReserva.ListarVersiones(listaCarteleras);

            ViewBag.Versiones = listaVersiones;
            ViewBag.Pelicula = id;
           
            return View();
        }

        [HttpPost]
        public ActionResult ReservasVersiones(Reservas r) // Recibo IdPelicula, IdVersion
        {
            // En base al Id Pelicula y Id Version, Obtengo las Sedes que la pasan
            List<Carteleras> listaCarteleras = servicioCarteleras.TraerCartelerasPorVersionYPelicula(r.IdVersion, r.IdPelicula);

            // Traigo las Sedes sin repetirlas
            List<Sedes> listaSedes = servicioReserva.ListarSedes(listaCarteleras);

            ViewBag.Version = r.IdVersion;
            ViewBag.Pelicula = r.IdPelicula;
            ViewBag.Sedes = listaSedes;

            return View("ReservasSedes");
        }

        [HttpPost]
        public ActionResult ReservasSedes(Reservas r) 
        {
            // Traigo la Fecha de Inicio y la Fecha de fin de la cartelera
            DateTime FechaInicio = servicioReserva.TraerCarteleraSedePeliculaVersion(r.IdSede, r.IdPelicula, r.IdVersion).FechaInicio;
            DateTime FechaFin = servicioReserva.TraerCarteleraSedePeliculaVersion(r.IdSede, r.IdPelicula, r.IdVersion).FechaFin;

            // Almaceno en una variable las fechas
            List<FormatoDia> listaDias = new List<FormatoDia>();

            // Genero las funciones
            for (var i = FechaInicio; i <= FechaFin; i = i.AddDays(1))
            {
                FormatoDia dia = new FormatoDia();
                dia.id = i.Day.ToString("D2") + i.Month.ToString("D2") + i.Year.ToString();
                dia.fecha = i.ToString("dd/MM/yyyy");
                listaDias.Add(dia);
            }

            ViewBag.Version = r.IdVersion;
            ViewBag.Pelicula = r.IdPelicula;
            ViewBag.Sede = r.IdSede;
            ViewBag.Dias = listaDias;

            return View("ReservasDias");

        }

        [HttpPost]
        public ActionResult ReservasDias(Reservas r)
        {
            // Traigo el horario de inicio de la cartelera
            int HoraInicio = servicioReserva.TraerCarteleraSedePeliculaVersion(r.IdSede, r.IdPelicula, r.IdVersion).HoraInicio;

            // Guardo la duracion de la pelicula
            int DuracionPelicula = servicioPelicula.TraerPelicula(r.IdPelicula).Duracion;

            List<InfoHoraInicio> listaFunciones = new List<InfoHoraInicio>();

            // Genero las funciones
            for (var i = 0; i < 8; i++)
            {
                InfoHoraInicio info = new InfoHoraInicio();

                info.Hora = HoraInicio;
                if (i == 0)
                {
                    info.funcion = "Funcion " + (i + 1) + ": " + HoraInicio + "Hs.";
                }
                else
                {
                    info.funcion = "Funcion " + (i + 1) + ": " + servicioReserva.ArmarHora(HoraInicio, DuracionPelicula) + "Hs.";
                }


                HoraInicio = servicioReserva.ArmarHora(HoraInicio, DuracionPelicula);
                listaFunciones.Add(info);
            }

            ViewBag.Version = r.IdVersion;
            ViewBag.Pelicula = r.IdPelicula;
            ViewBag.Sede = r.IdSede;
            ViewBag.Funciones = listaFunciones;
            return View();
        }

        [HttpPost]
        public ActionResult ReservaHorarios(FormatoDia f)
        {
            // Traigo el horario de inicio de la cartelera
            int HoraInicio = servicioReserva.TraerCarteleraSedePeliculaVersion(f.IdSede, f.IdPelicula, f.IdVersion).HoraInicio;

            // Guardo la duracion de la pelicula
            int DuracionPelicula = servicioPelicula.TraerPelicula(f.IdPelicula).Duracion;

            List<InfoHoraInicio> listaFunciones = new List<InfoHoraInicio>();

            // Genero las funciones
            for (var i = 0; i < 7; i++)
            {
                InfoHoraInicio info = new InfoHoraInicio();

                info.Hora = HoraInicio;
                if (i == 0)
                {
                    info.funcion = "Funcion " + (i + 1) + ": " + HoraInicio + "Hs.";
                }
                else
                {
                    info.funcion = "Funcion " + (i + 1) + ": " + servicioReserva.ArmarHora(HoraInicio, DuracionPelicula).ToString("D2") + "Hs.";
                }

                HoraInicio = servicioReserva.ArmarHora(HoraInicio, DuracionPelicula);

                
                listaFunciones.Add(info);
            }

          

            ViewBag.Horarios = listaFunciones;
            ViewBag.Fecha = f.id;
            ViewBag.Version = f.IdVersion;
            ViewBag.Pelicula = f.IdPelicula;
            ViewBag.Sede = f.IdSede;

            return View("ReservasHorarios");

        }

        [HttpPost]
        public ActionResult ClienteReserva(FormatoDia f)
        {
            // Convierto el id numerico que representaba la fecha en string
            string fechaString = Convert.ToString(f.fecha);

            // Separo la fecha
            string dia = fechaString.Substring(0, 2);
            string mes = fechaString.Substring(2, 2);
            string anio = fechaString.Substring(4, 4);


            // Las agrupo con separadores
            string fechaStringArmada = dia + "/" + mes + "/" + anio;
            // La convierto a Datetime
            DateTime fechaFinal = Convert.ToDateTime(fechaStringArmada);

            // Le agrego la hora
            TimeSpan ts = new TimeSpan(f.Hora, 00, 0);
            fechaFinal = fechaFinal.Date + ts;

            // Instancio una reserva
            Reservas reserva = new Reservas();
            reserva.IdPelicula = f.IdPelicula;
            reserva.IdSede = f.IdSede;
            reserva.IdVersion = f.IdVersion;
            reserva.FechaHoraInicio = fechaFinal;
            TempData["f"] = reserva.FechaHoraInicio;

            ViewBag.Pelicula = servicioPelicula.TraerPelicula(f.IdPelicula);
            ViewBag.Version = servicioReserva.TraerVersion(f.IdVersion).Nombre;
            ViewBag.Sede = serviciosSedes.TraerSede(f.IdSede).Nombre;
            ViewBag.Entrada = serviciosSedes.TraerSede(f.IdSede).PrecioGeneral;
            ViewBag.Genero = servicioPelicula.TraerGenero(servicioPelicula.TraerPelicula(f.IdPelicula).IdGenero).Nombre;
            ViewBag.Calificacion = servicioPelicula.TraerCalificacion(servicioPelicula.TraerPelicula(f.IdPelicula).IdCalificacion).Nombre;
            ViewBag.TipoDocumento = servicioReserva.TraerTiposDocumento();
            
            return View(reserva);
        }

        [HttpPost]
        public ActionResult TerminarReserva(Reservas r)
        {
            r.FechaCarga = DateTime.Now;
            r.FechaHoraInicio = Convert.ToDateTime(TempData["f"]);
            servicioReserva.GuardarReserva(r);
            return RedirectToAction("Inicio", "Home");
        }
    }

}
