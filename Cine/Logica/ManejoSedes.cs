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
    }
}
