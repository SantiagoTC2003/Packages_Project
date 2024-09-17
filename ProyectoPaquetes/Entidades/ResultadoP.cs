using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ResultadoP
    {

        #region Propiedades

        public bool ResultadoOperacion { get; set; }
        public string MensajePaquete { get; set; }
        public List<Paquete> ValorDevueltoConsultaPaquete { get; set; }

        #endregion

        #region Constructor

        public ResultadoP()
        {
            ResultadoOperacion = true;
            MensajePaquete = "Operacion realizada con exito";
            ValorDevueltoConsultaPaquete = new List<Paquete>();
        }

        #endregion

    }
}
