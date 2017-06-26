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
        public bool LapsoValido(DateTime inicio, DateTime fin)
        {
            var dif = fin - inicio;
            int tiempo = dif.Days;

            if (tiempo <= 30){  return true;  }

            return false;
        }
    }
}
