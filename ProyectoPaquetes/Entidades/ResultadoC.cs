using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ResultadoC
    {

        #region Propiedades

        public bool ResultadoOperacion { get; set; }
        public string MensajeCliente { get; set; }
        public List<Cliente> ValorDevueltoConsultaCliente { get; set; }

        #endregion

        #region Constructor

        public ResultadoC()
        {
            ResultadoOperacion = true;
            MensajeCliente = "Operacion realizada con exito";
            ValorDevueltoConsultaCliente = new List<Cliente>();
        }

        #endregion

    }
}
