using Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entidades;

namespace MVC.Controllers
{
    public class PeliculasController : Controller
    {
        //
        // GET: /Peliculas/
        ManejoReserva servicioReserva = new ManejoReserva();
        ManejoSedes serviciosSedes = new ManejoSedes();
        ManejoTipoDocumento servicioTipoDoc = new ManejoTipoDocumento();
        public ActionResult Reservas(int id)
        {
            ViewBag.Versiones = servicioReserva.TraerVersiones(); // Traigo las reserva de la base de datos
            ViewBag.Sedes = serviciosSedes.TraerSedes();
            ViewBag.Dias = servicioReserva.TraerDias();
            ViewBag.Horarios = servicioReserva.TraerHorario();
            return View();
        }
        
        public ActionResult  ClienteReserva (Reservas r)
        {
            ViewBag.TipoDocumento = servicioTipoDoc.TraerTipodocumentos();
            servicioReserva.TraerReserva(r);
            return View();
        }




        



    }
}
