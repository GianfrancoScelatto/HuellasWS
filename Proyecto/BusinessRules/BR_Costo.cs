using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace BusinessRules
{
    public class BR_Costo
    {
        DA_Costo daC = new DA_Costo();

        public DataTable MostrarCosto()
        {
            DataTable tabla = new DataTable();
            tabla = daC.ListarCosto();
            return tabla;
        }
    }
}
