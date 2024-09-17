using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Ruta
    {

        #region Propiedades

        public string IDRuta { get; set; }
        public string IDPaquete { get; set; }
        public DateTime Fecha { get; set; }
        public string IDLocalizacion { get; set; }
        
        #endregion

        #region Constructor     

        public Ruta()
        {
            IDRuta = string.Empty;
            IDPaquete = string.Empty;
            Fecha = DateTime.Now;
            IDLocalizacion = string.Empty;
        }

        #endregion

    }
}
