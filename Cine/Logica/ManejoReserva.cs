using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Logica
{
   public  class ManejoReserva
    {
       PersistenciaReserva pReserva = new PersistenciaReserva();
       PersistenciaSedes pSede = new PersistenciaSedes();

       public List<Versiones> TraerVersiones()
       {
           return pReserva.ObtenerVersiones();
       }

       public List<Sedes> TraerSedes()
       {
           return pSede.ObtenerSedes();
       }

       public List<Reservas> TraerDias()
       {
           return pReserva.ObtenerDias();
       }

       public List<Reservas> TraerHorario()
       {
           return pReserva.ObtenerHorarios();
       }
    }
}
