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

        public void Almacenar(Sedes se) // Guardo la Sede en la DB
        {
            ctx.Sedes.Add(se);
            ctx.SaveChanges();
        }

        public List<Sedes> ObtenerSedes() // Obtengo todas las sedes de la DB
        {
            var sedes = (from s in ctx.Sedes select s).ToList();
            return sedes;
        }

        public Sedes ObtenerSede(int id) // Obtengo una sede en especifico
        {
            var query = from s in ctx.Sedes where s.IdSede == id select s;

            Sedes se = new Sedes();

            foreach (Sedes sede in query)
            {
                se.IdSede = sede.IdSede;
                se.Nombre = sede.Nombre;
                se.Direccion = sede.Direccion;
                se.PrecioGeneral = sede.PrecioGeneral;
            }

            return se;
        }

        public void ActualizarSede(Sedes se)
        {
            // Realizo la consulta para la sede especifica
            var query = from s in ctx.Sedes where s.IdSede == se.IdSede select s;
            
   
            foreach (Sedes s in query) 
            {
                s.Nombre = se.Nombre;
                s.Direccion = se.Direccion;
                s.PrecioGeneral = se.PrecioGeneral;
            }

            ctx.SaveChanges();

        }
    }
}
