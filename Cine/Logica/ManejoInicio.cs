using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using DAL;

namespace Logica
{
    public class ManejoInicio
    {
        public List<Carteleras> PeliculasSinRepetir(List<Carteleras> lista)
        {
            List<Carteleras> cartelerasUnicas = new List<Carteleras>();
            
            foreach(Carteleras cartelera in lista)
            {
                // Si la pelicula no esta repetida la agrego
                if (PeliculaSinRepetir(cartelera, cartelerasUnicas))
                {
                    cartelerasUnicas.Add(cartelera);
                }
            }


            return cartelerasUnicas;
        }

        public bool PeliculaSinRepetir(Carteleras cartelera, List<Carteleras> lista)
        {
            foreach(Carteleras c in lista)
            {
               if(c.IdPelicula == cartelera.IdPelicula)
               {
                   return false;
               }
            }

            return true;
        }
    }


}
