using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using DAL;

namespace Logica
{
    public class ManejoPeliculas
    {
        PersistenciaPeliculas pPeliculas = new PersistenciaPeliculas();

        public List<Genero> TraerGeneros()
        {

            return pPeliculas.ObtenerGeneros();
        }

        public List<Calificacion> TraerCalificaciones()
        {
            
            return pPeliculas.ObtenerCalificaciones();
        }
    }
}
