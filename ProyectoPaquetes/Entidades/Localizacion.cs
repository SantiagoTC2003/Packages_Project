using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Localizacion
    {

        #region Propiedades

        public string IDLocalizacion { get; set; }
        public string Descripcion { get; set; }
        
        #endregion

        #region Constructor     

        public Localizacion()
        {
            IDLocalizacion = string.Empty;
            Descripcion = string.Empty;
            
        }

        #endregion

    }
}
