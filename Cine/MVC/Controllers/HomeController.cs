using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Logica;
using Entidades;
using MVC.Models;

namespace MVC.Controllers
{
    public class HomeController : Controller
    {
        ManejoCarteleras servicioCarteleras = new ManejoCarteleras();
        ManejoSedes servicioSedes = new ManejoSedes();
        ManejoPeliculas servicioPeliculas = new ManejoPeliculas();
        ManejoReserva servicioReservas = new ManejoReserva();
        ManejoInicio servicioInicio = new ManejoInicio();
        // GET: /Home/

        public ActionResult Inicio()
        {
            // Traigo todas las carteleras que estarian disponible en este fecha o de aca a un mes
            List<Carteleras> listaCarteleras = servicioCarteleras.TraerCartelerasPorFecha(DateTime.Now);

            // Descarto las carteleras que tienen peliculas repetidas
            List<Carteleras> cartelerasUnicas = servicioInicio.PeliculasSinRepetir(listaCarteleras);
            
            // Instancio mi clase de manejo interno para poder tipar la vista
            List<PeliculasInicio> carteleraInicio = new List<PeliculasInicio>();

            foreach (Carteleras cartelera in cartelerasUnicas)
            {
                PeliculasInicio info = new PeliculasInicio();
                info.IdCartelera = cartelera.IdCartelera;
                info.Imagen = servicioPeliculas.TraerPelicula(cartelera.IdPelicula).Imagen;
                info.Nombre = servicioPeliculas.TraerPelicula(cartelera.IdPelicula).Nombre;
                info.Genero = servicioPeliculas.TraerGenero(servicioPeliculas.TraerPelicula(cartelera.IdPelicula).IdGenero).Nombre;
                info.Calificacion = servicioPeliculas.TraerCalificacion(servicioPeliculas.TraerPelicula(cartelera.IdPelicula).IdCalificacion).Nombre;
                carteleraInicio.Add(info);
            }
            return View(carteleraInicio);
        }

        public ActionResult Login()
        {
            return View();
        }
       
        [HttpPost]
        public ActionResult Login(Usuarios user)
        {
            if (ModelState.IsValid)
            {
                using (MyContext ctx = new MyContext())
                {
                    var log = ctx.Usuarios.Where(a => a.NombreUsuario.Equals(user.NombreUsuario) && a.Password.Equals(user.Password)).FirstOrDefault();
                    if (log != null)
                    {
                        Session["IdUsuario"] = log.IdUsuario.ToString();
                        Session["NombreUsuario"] = log.NombreUsuario;
                        return RedirectToAction("DespuesdelLogin");
                    }
                }

            }
            return View();
        }

        public ActionResult DespuesDelLogin()
        {
            if (Session["IdUsuario"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Inicio");
            }

        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Inicio", "Home");

        }

    }
}
