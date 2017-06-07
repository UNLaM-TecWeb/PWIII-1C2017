﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Logica;
using DAL;

namespace MVC.Controllers
{
    public class AdministracionController : Controller
    {
        //
        // GET: /Administracion/

        ManejoSedes servicioSedes = new ManejoSedes();
        ManejoPeliculas servicioPeliculas = new ManejoPeliculas();

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
            ViewBag.Generos = servicioPeliculas.TraerGeneros();
            ViewBag.Calificaciones = servicioPeliculas.TraerCalificaciones();
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
