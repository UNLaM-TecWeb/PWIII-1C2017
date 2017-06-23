using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace DAL
{
    public class PersistenciaCartelera
    {
        MyContext ctx = new MyContext();
            
        public void AlmacenarCartelera(Carteleras c)
        {
            ctx.Carteleras.Add(c);
            ctx.SaveChanges();
        }

        public void EliminarCartelera(int id)
        {
            var Query = from c in ctx.Carteleras where c.IdCartelera == id select c;            

            foreach(var cartelera in Query)
            {
                ctx.Carteleras.Remove(cartelera);
            }
            ctx.SaveChanges();

        }

        public List<Carteleras> ObtenerCarteleraPorSedeSalaVersion(int sede, int sala, int version)
        {
            var Query = (from c in ctx.Carteleras where c.IdSede == sede && c.NumeroSala == sala && c.IdVersion == version select c).ToList();            
            return Query;
        }

        public List<Carteleras> ObtenerCarteleras()
        {
            var carteleras = (from c in ctx.Carteleras select c).ToList();
            
            return carteleras;
        }

        public List<Carteleras> OBtenerCartelerasPorFecha(DateTime fecha)
        {
            DateTime fechaTope = fecha.AddDays(30);
            var Query = (from c in ctx.Carteleras
                         where c.FechaInicio <= fechaTope 
                         where c.FechaFin > fecha
                         select c).ToList();
            return Query;
        }

    }
}
