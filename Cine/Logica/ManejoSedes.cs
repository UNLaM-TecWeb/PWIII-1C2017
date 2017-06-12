using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entidades;

namespace Logica
{
    public class ManejoSedes
    {
        PersistenciaSedes pSedes = new PersistenciaSedes();

        public void GuardarSede(Sedes s)
        {
            pSedes.Almacenar(s);
        }

        public void ActualizarSede(Sedes s)
        {
            pSedes.ActualizarSede(s);
        }

        public List<Sedes> TraerSedes() // Traigo Todas las sedes
        {
            return pSedes.ObtenerSedes();
        }

        public Sedes TraerSede(int id) // Traigo una Sede especifica
        {
            return pSedes.ObtenerSede(id);
        }
    }
}
