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

        public ActionResult ReservasDias(int id)
        {
            if (Session["IdUsuario"] == null)
            {
               
                return RedirectToAction("Login", "Home");
            }
            ViewBag.Dias = servicioReserva.TraerDias();
            return View();
        }
        /// <summary>
        /// lleno el combo sede segun el tipo de 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult ReservasSedes(int id)
        {
            List<Reservas> listaReservas = servicioReserva.TraerReservaTotal();
            List<InfoReserva> listaInfoReserva = new List<InfoReserva>();

            foreach (Reservas reserva in listaReservas)
            {
                InfoReserva infoReserva = new InfoReserva();
                infoReserva.Sede = serviciosSedes.TraerSede(reserva.IdSede).Nombre;
                listaInfoReserva.Add(infoReserva);
            }

            ViewBag.Sedes = serviciosSedes.TraerSedes();
            return View();
        }

        public ActionResult ReservasHorarios(int id)
        {

            ViewBag.Horarios = servicioReserva.TraerHorario();
            return View();
        }

        public ActionResult ClienteReserva(Reservas r)
        {

            ViewBag.TipoDocumento = servicioTipoDoc.TraerTipodocumentos();
            servicioReserva.TraerReserva(r);
            //ViewBag.Peliculas = servicioPelicula.TraerPelicula();   
            return View();
        }
    }
}
