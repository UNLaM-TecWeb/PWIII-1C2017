using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entidades;

namespace Logica
{
    public class ManejoReportes
    {
        PersistenciaReserva pReserva = new PersistenciaReserva();

        public List<Reservas> GenerarReporteReservas() // Traigo Todas las Reservas
        {
            return pReserva.ObtenerReservas();
        }

        public List<Reservas> GenerarReporteReservas(DateTime desde, DateTime hasta) // Traigo Todas las Reservas dentro de un intervalo de tiempo
        {
            return pReserva.ObtenerReservas(desde, hasta);
        }

    }
}
