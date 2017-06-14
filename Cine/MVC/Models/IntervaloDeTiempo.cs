using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class IntervaloDeTiempo
    {
        public int DesdeDia { get; set; }
        public int DesdeMes { get; set; }
        public int DesdeAnno { get; set; }

        public int HastaDia { get; set; }
        public int HastaMes { get; set; }
        public int HastaAnno { get; set; }

        public IntervaloDeTiempo()
        {
            DesdeDia = 0;
            DesdeMes = 0;
            DesdeAnno = 0;
            HastaDia = 0;
            HastaMes = 0;
            HastaAnno = 0;
        }

        public IntervaloDeTiempo(int desdeDD, int desdeMM, int desdeAA, int hastaDD, int hastaMM, int hastaAA)
        {
            DesdeDia = desdeDD;
            DesdeMes = desdeMM;
            DesdeAnno = desdeAA;
            HastaDia = hastaDD;
            HastaMes = hastaMM;
            HastaAnno = hastaAA;
        }

    }
}