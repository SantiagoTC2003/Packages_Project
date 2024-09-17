using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class SQLPeticiones
    {

        #region Propiedades

        public string PeticionSQL { get; set; }
        public List<SqlParameter> ListaParametros { get; set; }

        #endregion

        #region Constructor

        public SQLPeticiones()
        {
            PeticionSQL = string.Empty;
            ListaParametros = new List<SqlParameter>();
        }

        #endregion

    }
}
