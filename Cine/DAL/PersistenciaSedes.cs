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

        public void Almacenar(Sede se) // Guardo la Sede en la DB
        {
            Sedes sed = new Sedes();
            sed.Nombre = se.Nombre;
            sed.Direccion = se.Direccion;
            sed.PrecioGeneral = se.PrecioGeneral;
            ctx.Sedes.Add(sed);
            ctx.SaveChanges();
        }

        public List<Sede> ObtenerSedes() // Obtengo todas las sedes de la DB
        {
            var sedes = (from s in ctx.Sedes select s).ToList();

            List<Sede> listaSedes = new List<Sede>();

            foreach (Sedes sede in sedes)
            {
                Sede se = new Sede();
                se.IdSede = sede.IdSede;
                se.Nombre = sede.Nombre;
                se.Direccion = sede.Direccion;
                se.PrecioGeneral = sede.PrecioGeneral;
                listaSedes.Add(se);
            }

            return listaSedes;
        }

        public Sede ObtenerSede(int id) // Obtengo una sede en especifico
        {
            var sedeBuscada = from s in ctx.Sedes where s.IdSede = id select s;

            Sede se = new Sede();

            foreach (Sedes sede in sedeBuscada)
            {
                se.IdSede = sede.IdSede;
                se.Nombre = sede.Nombre;
                se.Direccion = sede.Direccion;
                se.PrecioGeneral = sede.PrecioGeneral;
            }
            return se;
        }
    }
}
