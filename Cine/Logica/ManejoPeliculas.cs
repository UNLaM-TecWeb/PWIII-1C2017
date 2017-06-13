using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entidades;

namespace Logica
{
    public class ManejoPeliculas
    {
        PersistenciaPeliculas pPeliculas = new PersistenciaPeliculas();

        public List<Generos> TraerGeneros()
        {

            return pPeliculas.ObtenerGeneros();
        }

        public List<Peliculas> TraerPeliculas()
        {
            return pPeliculas.ObtenerPeliculas();
        }

        public Peliculas TraerPelicula(int id)
        {
            return pPeliculas.ObtenerPelicula(id);
        }

        public List<Calificaciones> TraerCalificaciones()
        {
            
            return pPeliculas.ObtenerCalificaciones();
        }

        public void AgregarPelicula(Peliculas p)
        {
            pPeliculas.AlmacenarPelicula(p);
        }

        
        public void GuardarPelicula(Peliculas p)
        {
            pPeliculas.AlmacenarPelicula(p);

            return;
                
        }

        public void ModificarPelicula(Peliculas p)
        {
            
            pPeliculas.ActualizarPelicula(p);

            return;
        }
    }
}
