using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentacion
{
    public class GestorConexion
    {

        public static bool EnvioCorreo()
        {
            WCFServicio.Service1Client objservicio = null;
            try
            {
                objservicio = new WCFServicio.Service1Client();
                return objservicio.EnvioCorreo();
            }
            finally
            {
                if (objservicio != null)
                    objservicio.Close();
            }

        }
    }
}
