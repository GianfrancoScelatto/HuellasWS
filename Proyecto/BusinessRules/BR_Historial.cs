using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DataAccess;

namespace BusinessRules
{
    public class BR_Historial
    {
        DA_Historial daH = new DA_Historial();
        public DataTable ListarHistorial()
        {
            DataTable tabla = new DataTable();
            tabla = daH.ListarHistorial();
            return tabla;
        }

        public DataTable FiltrarHistorial(string Usuario)
        {
            DataTable tabla = new DataTable();
            tabla = daH.FiltrarHistorial(Usuario);
            return tabla;
        }
    }
}
