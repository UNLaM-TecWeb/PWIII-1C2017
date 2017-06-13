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
        ManejoSedes servicioSedes = new ManejoSedes();
        ManejoPeliculas servicioPeliculas = new ManejoPeliculas();
        ManejoReserva ServicioReservas = new ManejoReserva();

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
            ViewBag.Sedes = servicioSedes.TraerSedes();
            return View(servicioPeliculas.TraerPeliculas());
        }

        public ActionResult NuevaPelicula()
        {
            ViewBag.Calificaciones = servicioPeliculas.TraerCalificaciones();
            ViewBag.Sedes = servicioSedes.TraerSedes();
            ViewBag.Generos = servicioPeliculas.TraerGeneros();
            return View();
        }
        
        [HttpPost]
        public ActionResult NuevaPelicula(Peliculas p)
        {
            // Falla la persistencia
            servicioPeliculas.AgregarPelicula(p);
            return RedirectToAction("Peliculas", "Administracion");
        }

        public ActionResult EditarPelicula(int id)
        {
            ViewBag.Generos = servicioPeliculas.TraerGeneros();
            ViewBag.Calificaciones = servicioPeliculas.TraerCalificaciones();
            return View(servicioPeliculas.TraerPelicula(id));
        }

        [HttpPost]
        public ActionResult EditarPelicula(Peliculas p)
        {
            servicioPeliculas.ModificarPelicula(p);
            return RedirectToAction("Peliculas", "Administracion");
        }

        public ActionResult Reportes()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Reportes(FormCollection f)
        {
            DateTime Desde = new DateTime(Convert.ToInt32(f["DesdeAnno"]), Convert.ToInt32(f["DesdeMes"]), Convert.ToInt32(f["DesdeDia"]));
            DateTime Hasta = new DateTime(Convert.ToInt32(f["HastaAnno"]), Convert.ToInt32(f["HastaMes"]), Convert.ToInt32(f["HastaDia"]));
            ServicioReservas.TraerReservas(Desde, Hasta);

            return RedirectToAction("Reportes", "Administracion");
        }

        public ActionResult Sedes()
        {
            ViewBag.Sedes = servicioSedes.TraerSedes(); // Traigo las Sedes de la Base de Datos
            return View();
        }

        [HttpPost]
        public ActionResult Sedes(Sedes s)
        {
            if (!(ModelState.IsValid))
            {
                return RedirectToAction("Sedes", "Administracion");
            }
            
            servicioSedes.GuardarSede(s);

            return RedirectToAction("Sedes", "Administracion");
        }

        public ActionResult EditarSede(int id)
        {
            ViewBag.sede = servicioSedes.TraerSede(id);
            return View();
        }

        [HttpPost]
        public ActionResult EditarSede(Sedes s)
        {
            servicioSedes.ActualizarSede(s);
            return RedirectToAction("Sedes", "Administracion");
        }

    }
}
