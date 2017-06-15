using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using DAL;

namespace Logica
{
    public class ManejoCarteleras
    {

        PersistenciaCartelera pCartelera = new PersistenciaCartelera();

        public void GuardarCartelera(Carteleras c)
        {
            pCartelera.AlmacenarCartelera(c);
        }

        public bool ValidarCartelera(Carteleras c)
        {
            // Traigo todas las carteleras donde la sede y la sala sean iguales
            List<Carteleras> carteleras = pCartelera.ObtenerCarteleraPorSedeYSala(c.IdSede, c.NumeroSala);

            // Verifico que no haya llegado vacia
            if (carteleras == null)
            {
                return true;
            }

            // Si tengo una cartelera en la misma Sede y Sala verifico que no se crucen las fechas
            foreach(Carteleras cartelera in carteleras)
            {
                // Averiguo si la fecha de inicio se pisa con alguna cartelera
                if(c.FechaInicio >= cartelera.FechaInicio && c.FechaInicio <= cartelera.FechaFin) 
                {
                        return false;
                }

                // Averiguo si la fecha de fin se pisa con alguna cartelera
                if (c.FechaFin <= cartelera.FechaFin && c.FechaFin >= cartelera.FechaInicio)
                {
                    return false;
                }
            }

            return true;
        }

        public List<Carteleras> TraerCarteleras()
        {
            return pCartelera.ObtenerCarteleras();
        }

    }
}
