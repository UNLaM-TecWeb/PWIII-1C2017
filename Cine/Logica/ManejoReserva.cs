using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Logica
{
   public class ManejoReserva
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

       public Sedes TraerSede(int id)
       {
           return pSede.ObtenerSede(id);
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

       public List<Reservas> TraerReservaTotal()
       {
           return pReserva.ObtenerReserva();
       }

       public List<Versiones> ListarVersiones(List<Carteleras> carteleras)
       {
           List<Versiones> listaVersiones = new List<Versiones>();

           bool versionValida = true;

           foreach (Carteleras c in carteleras)
           {
               Versiones version = new Versiones();
               version = TraerVersion(c.IdVersion);

               // Recorro las versiones alamacenadas en la lista y chequeo si ya estaba almacenada
               foreach (Versiones ver in listaVersiones)
               {
                   if(version.IdVersion == ver.IdVersion)
                   {
                       versionValida = false;
                   }
               }

               // Si la version no estaba almacenada la guardo
               if (versionValida)
               {
                   listaVersiones.Add(version);
               }
           }

          

           return listaVersiones;
       }

       public List<Sedes> ListarSedes(List<Carteleras> carteleras)
       {
           List<Sedes> listaSedes = new List<Sedes>();

           bool sedeValida = true;

           foreach (Carteleras c in carteleras)
           {
               Sedes sede = new Sedes();
               sede = TraerSede(c.IdSede);

               // Recorro las sedes alamacenadas en la lista y chequeo si ya estaba almacenada
               foreach (Sedes sed in listaSedes)
               {
                   if (sede.IdSede == sed.IdSede)
                   {
                       sedeValida = false;
                   }
               }

               // Si la version no estaba almacenada la guardo
               if (sedeValida)
               {
                   listaSedes.Add(sede);
               }
           }



           return listaSedes;
       }

       public List<Reservas> TraerReservasPorPeriodo(DateTime i, DateTime f, int p)
       {
           return pReserva.ObtenerReservasPorPeriodo(i, f, p);
       }
    }
}
