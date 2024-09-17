using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ResultadoAu
    {

        #region Propiedades

        public bool ResultadoOperacion { get; set; }
        public string MensajeAutorizacion { get; set; }
        public List<Autorizacion> ValorDevueltoConsultaAutorizacion { get; set; }

        #endregion

        #region Constructor

        public ResultadoAu()
        {
            ResultadoOperacion = true;
            MensajeAutorizacion = "Operacion realizada con exito";
            ValorDevueltoConsultaAutorizacion = new List<Autorizacion>();
        }

        #endregion

    }
}
