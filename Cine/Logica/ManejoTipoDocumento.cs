using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entidades;

namespace Logica
{
    public class ManejoTipoDocumento
    {
        PersistenciaTipoDocumento pTipoDoc = new PersistenciaTipoDocumento();

        public List<TiposDocumentos> TraerTipodocumentos() // Traigo Todas las sedes
        {
            return pTipoDoc.ObtenerTipoDocumentos();
        }
    }
}
