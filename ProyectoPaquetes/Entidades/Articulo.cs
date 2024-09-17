using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Articulo
    {

        #region Propiedades

        public string IDArticulo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Precio { get; set; }
        public string Empresa { get; set; }

        #endregion

        #region Constructor     

        public Articulo()
        {
            IDArticulo = string.Empty;
            Nombre = string.Empty;
            Descripcion = string.Empty;
            Precio = 0;
            Empresa = string.Empty;
        }

        #endregion

    }
}
