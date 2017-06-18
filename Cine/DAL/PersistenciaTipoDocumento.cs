using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace DAL
{
    public  class PersistenciaTipoDocumento
    {
        MyContext ctx = new MyContext();


        public List<TiposDocumentos> ObtenerTipoDocumentos()
        {
           
            var tipodoc = (from s in ctx.TiposDocumentos select s).ToList();
            return tipodoc;
        }

    }
}
