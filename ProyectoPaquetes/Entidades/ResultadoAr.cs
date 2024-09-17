using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ResultadoAr
    {

        #region Propiedades

        public bool ResultadoOperacion { get; set; }
        public string MensajeArticulo { get; set; }
        public List<Articulo> ValorDevueltoConsultaArticulo { get; set; }

        #endregion

        #region Constructor

        public ResultadoAr()
        {
            ResultadoOperacion = true;
            MensajeArticulo = "Operacion realizada con exito";
            ValorDevueltoConsultaArticulo = new List<Articulo>();
        }

        #endregion

    }
}
