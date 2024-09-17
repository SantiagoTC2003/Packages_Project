using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Cliente
    {

        #region Propiedades

        public string IDCliente { get; set; }
        public string Nombre { get; set; }
        public string Contraseña { get; set; }
        public string CorreoE { get; set; }
        public string Direccion { get; set; }
        public int Dinero { get; set; }
        public string IDPerfil { get; set;  }

        #endregion

        #region Constructor     

        public Cliente()
        {
            IDCliente = string.Empty;
            Nombre = string.Empty;
            Contraseña = string.Empty;
            CorreoE = string.Empty;
            Direccion = string.Empty;
            Dinero = 0;
            IDPerfil = string.Empty;
        }

        #endregion

    }
}
