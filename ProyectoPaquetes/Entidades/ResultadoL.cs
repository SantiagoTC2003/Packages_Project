using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ResultadoL
    {

        #region Propiedades

        public bool ResultadoOperacion { get; set; }
        public string MensajeLocalizacion { get; set; }
        public List<Localizacion> ValorDevueltoConsultaLocalizacion { get; set; }

        #endregion

        #region Constructor

        public ResultadoL()
        {
            ResultadoOperacion = true;
            MensajeLocalizacion = "Operacion realizada con exito";
            ValorDevueltoConsultaLocalizacion = new List<Localizacion>();
        }

        #endregion

    }
}
