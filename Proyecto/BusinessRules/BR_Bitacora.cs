using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DataAccess;

namespace BusinessRules
{
    public class BR_Bitacora
    {
        DA_Bitacora bitacora = new DA_Bitacora();

        public DataTable ListarBitacora()
        {
            DataTable tabla = new DataTable();
            tabla = bitacora.ListarBitacora();
            return tabla;
        }
    }
}
