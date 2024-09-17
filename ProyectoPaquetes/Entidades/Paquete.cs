using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Paquete
    {

        #region Propiedades

        public string IDPaquete { get; set; }
        public string IDCliente { get; set; }
        public string IDArticulo { get; set; }
        public bool Entregado { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }
        
        #endregion

        #region Constructor     

        public Paquete()
        {
            IDPaquete = string.Empty;
            IDCliente = string.Empty;
            IDArticulo = string.Empty;
            Entregado = false;
            Descripcion = string.Empty;
            Fecha = DateTime.Now;
        }

        #endregion

    }
}
