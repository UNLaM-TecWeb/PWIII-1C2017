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
       

        public ActionResult ReservasVersiones(int id)
        {
            if (Session["IdUsuario"] == null)
            {
                //TempData["urlController"] = Request.RequestContext.RouteData.Values["controller"].ToString();
                //TempData["urlAction"] = Request.RequestContext.RouteData.Values["action"].ToString();
                return RedirectToAction("Login", "Home");
            }

            ViewBag.Versiones = servicioReserva.TraerVersiones(); // Traigo las reserva de la base de datos
           
            return View();
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
            if (Session["IdUsuario"] == null)
            {
                return RedirectToAction("Login", "Home");
            }

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

            if (Session["IdUsuario"] == null)
            {
                //TempData["urlController"] = Request.RequestContext.RouteData.Values["controller"].ToString();
                //TempData["urlAction"] = Request.RequestContext.RouteData.Values["action"].ToString();
                return RedirectToAction("Login", "Home");
            }

            ViewBag.Horarios = servicioReserva.TraerHorario();
            return View();
        }

        public ActionResult ClienteReserva(Reservas r)
        {

            if (Session["IdUsuario"] == null)
            {
                //TempData["urlController"] = Request.RequestContext.RouteData.Values["controller"].ToString();
                //TempData["urlAction"] = Request.RequestContext.RouteData.Values["action"].ToString();
                return RedirectToAction("Login", "Home");
            }

            ViewBag.TipoDocumento = servicioTipoDoc.TraerTipodocumentos();
            servicioReserva.TraerReserva(r);
            //ViewBag.Peliculas = servicioPelicula.TraerPelicula();   
            return View();
        }
    }
}
