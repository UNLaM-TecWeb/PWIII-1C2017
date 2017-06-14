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
    }
}
