using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Autorizacion
    {

        #region Propiedades

        public string IDAutorizacion { get; set; }
        public string IDCliente { get; set; }
        public string Nombre { get; set; }
        

        #endregion

        #region Constructor     

        public Autorizacion()
        {
            IDAutorizacion = string.Empty;
            IDCliente = string.Empty;
            Nombre = string.Empty;
        }

        #endregion

    }
}
