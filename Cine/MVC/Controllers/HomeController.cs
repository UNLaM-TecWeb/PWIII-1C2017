using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

using DAL;
using Entidades;

namespace MVC.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Inicio()
        {

            return View();
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
            return RedirectToAction("Login", "Home");

        }

    }
}
