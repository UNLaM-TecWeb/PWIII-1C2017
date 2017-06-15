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


        public List<Carteleras> ObtenerCarteleraPorSedeYSala(int sede, int sala)
        {
            var Query = (from c in ctx.Carteleras where c.IdSede == sede && c.NumeroSala == sala select c).ToList();            
            return Query;
        }

        public List<Carteleras> ObtenerCarteleras()
        {
            var carteleras = (from c in ctx.Carteleras select c).ToList();
            
            return carteleras;
        }

        public List<Carteleras> OBtenerCartelerasPorFecha(/*aca van los parametros de inicio y fin de fecha */)
        {

            return null;
        }

    }
}
