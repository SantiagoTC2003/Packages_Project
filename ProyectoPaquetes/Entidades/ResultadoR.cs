using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ResultadoR
    {

        #region Propiedades

        public bool ResultadoOperacion { get; set; }
        public string MensajeRuta { get; set; }
        public List<Ruta> ValorDevueltoConsultaRuta { get; set; }

        #endregion

        #region Constructor

        public ResultadoR()
        {
            ResultadoOperacion = true;
            MensajeRuta = "Operacion realizada con exito";
            ValorDevueltoConsultaRuta = new List<Ruta>();
        }

        #endregion

    }
}
