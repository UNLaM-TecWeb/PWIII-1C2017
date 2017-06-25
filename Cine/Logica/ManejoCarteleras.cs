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

        //public bool ValidarCartelera(Carteleras c)
        //{
        //    // Traigo todas las carteleras donde la sede, la sala y la version sean iguales
        //    List<Carteleras> carteleras = pCartelera.ObtenerCarteleraPorSedeSalaVersion(c.IdSede, c.NumeroSala, c.IdVersion);

        //    // Verifico que no haya llegado vacia, si llego vacia es por que no hay salas con esas caracteristicas asi que es valida
        //    if (carteleras == null)
        //    {
        //        return true;
        //    }

        //    // Si tengo una cartelera en la misma Sede, Sala y Version verifico que no se crucen las fechas
        //    foreach(Carteleras cartelera in carteleras)
        //    {
        //        // Averiguo si la fecha de inicio se pisa con alguna cartelera
        //        if(c.FechaInicio >= cartelera.FechaInicio && c.FechaInicio <= cartelera.FechaFin) 
        //        {
        //                return false;
        //        }

        //        // Averiguo si la fecha de fin se pisa con alguna cartelera
        //        if (c.FechaFin <= cartelera.FechaFin && c.FechaFin >= cartelera.FechaInicio)
        //        {
        //            return false;
        //        }
        //    }

        //    return true;
        //}

        public bool ValidarCartelera(Carteleras c)
        {
            // Traigo todas las carteleras 
            return true;
        }

        public bool DiaValidoCartelera(Carteleras c)
        {
            // Chequeo si todos los dias estan falsos, es decir, que no fueron seleccionados
            if(c.Lunes == false && c.Martes == false && c.Miercoles == false && c.Jueves == false && c.Viernes == false && c.Sabado == false && c.Domingo == false)
            {
                return false;
            }

            return true;
        }
        
        public List<Carteleras> TraerCarteleras()
        {
            return pCartelera.ObtenerCarteleras();
        }

        public List<Carteleras> TraerCartelerasPorFecha(DateTime fecha)
        {
            return pCartelera.OBtenerCartelerasPorFecha(fecha);
        }

        public void BorrarCartelera(int id)
        {
            pCartelera.EliminarCartelera(id);

        }

    }
}
