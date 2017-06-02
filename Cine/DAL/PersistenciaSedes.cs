using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace DAL
{
    public class PersistenciaSedes
    {
        MyContext ctx = new MyContext();

        public void Almacenar(Sede se)
        {
            Sedes sed = new Sedes();
            sed.Nombre = se.Nombre;
            sed.Direccion = se.Direccion;
            sed.PrecioGeneral = se.PrecioGeneral;
            ctx.Sedes.Add(sed);
            ctx.SaveChanges();
        }

        public List<Sede> ObtenerSedes()
        {
            var sedes = (from s in ctx.Sedes select s).ToList();

            List<Sede> listaSedes = new List<Sede>();

            foreach (Sedes sede in sedes)
            {
                Sede se = new Sede();
                se.IdSede = sede.IdSede;
                se.Nombre = sede.Nombre;
                listaSedes.Add(se);
            }

            return listaSedes;
        }
    }
}
