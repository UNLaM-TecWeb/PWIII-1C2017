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
       PersistenciaPeliculas pPelicula = new PersistenciaPeliculas();
       PersistenciaSedes pSede = new PersistenciaSedes();


       public List<Versiones> TraerVersiones()
       {
           return pReserva.ObtenerVersiones();
       }

       public Versiones TraerVersion(int id)
       {
           return pReserva.ObtenerVersion(id);
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

       public void TraerReserva(Reservas r)
       {
           pReserva.ObtenerReserva(r);
       }

       public List<Reservas> TraerReservasPorPeriodo(DateTime i, DateTime f, int p)
       {
           return pReserva.ObtenerReservasPorPeriodo(i, f, p);
       }

       public List<Reservas> TraerReservaTotal()
       {
           return pReserva.ObtenerReserva();
       }
    }
}
