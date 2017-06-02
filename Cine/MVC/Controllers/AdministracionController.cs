using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Logica;
using Entidades;

namespace MVC.Controllers
{
    public class AdministracionController : Controller
    {
        //
        // GET: /Administracion/

        ManejoSedes servicioSedes = new ManejoSedes();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Carteleras()
        {
            return View();
        }

        public ActionResult Peliculas()
        {
            return View();
        }

        public ActionResult NuevaPelicula()
        {


            return View("Peliculas");
        }

        public ActionResult Reportes()
        {
            return View();
        }

        public ActionResult Sedes()
        {
            ViewBag.Sedes = servicioSedes.TraerSedes(); // Traigo las Sedes de la Base de Datos
            return View();
        }

        [HttpPost]
        public ActionResult Sedes(Sede s)
        {
            servicioSedes.GuardarSede(s);
            return RedirectToAction("Sedes", "Administracion");
        }

    }
}
