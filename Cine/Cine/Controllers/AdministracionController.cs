using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cine.Controllers
{
    public class AdministracionController : Controller
    {
        //
        // GET: /Administracion/

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
            ViewBag.nuevaPelicula = true;
            return View("Peliculas");
        }

        public ActionResult Reportes()
        {
            return View();
        }

        public ActionResult Sedes()
        {
            return View();
        }

    }
}
