using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL
{
    public class PersistenciaUsuarios
    {
        MyContext ctx = new MyContext();

        //public List<Entidades.Usuarios> ObtenerUsuario(Entidades.Usuarios usuario)
        //{
        //    //var log = ctx.Usuarios.Where(a => a.NombreUsuario.Equals(usuario.NombreUsuario) && a.Password.Equals(usuario.Password)).FirstOrDefault();
        //    //if (log != null)
        //    //{
        //    //    Session["IdUsuario"] = log.IdUsuario.ToString();
        //    //    Session["NombreUsuario"] = log.NombreUsuario;
        //    //    return RedirectToAction("DespuesdelLogin");
        //    //}
        //    return usuario;
        //}
    }
}
