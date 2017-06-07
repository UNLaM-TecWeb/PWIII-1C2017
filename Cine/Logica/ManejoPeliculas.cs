using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace Logica
{
    public class ManejoPeliculas
    {
        PersistenciaPeliculas pPeliculas = new PersistenciaPeliculas();

        public List<Generos> TraerGeneros()
        {

            return pPeliculas.ObtenerGeneros();
        }

        public List<Calificaciones> TraerCalificaciones()
        {
            
            return pPeliculas.ObtenerCalificaciones();
        }
    }
}
