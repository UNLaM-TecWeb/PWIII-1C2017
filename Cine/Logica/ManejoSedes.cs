using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using DAL;

namespace Logica
{
    public class ManejoSedes
    {
        PersistenciaSedes pSedes = new PersistenciaSedes();

        public void GuardarSede(Sede s)
        {
            pSedes.Almacenar(s);
        }

        public List<Sede> TraerSedes() // Traigo Todas las sedes
        {
            List<Sede> listaSedes = new List<Sede>();
            listaSedes = pSedes.ObtenerSedes();

            return listaSedes;
        }

        public Sede TraerSede(int id) // Traigo una Sede especifica
        {
            Sede sede = new Sede();
            sede = pSedes.ObtenerSede(id);
            return sede;
        }
    }
}
