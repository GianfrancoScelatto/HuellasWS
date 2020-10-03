using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DataAccess;

namespace BusinessRules
{
    public class BR_Seguimiento
    {
        DA_Seguimiento daS = new DA_Seguimiento();

        public DataTable ListarSeguimiento()
        {
            DataTable tabla = new DataTable();
            tabla = daS.ListarSeguimiento();
            return tabla;
        }

        public DataTable FiltrarSeguimiento(DateTime Fecha)
        {
            DataTable tabla = new DataTable();
            tabla = daS.FiltrarSeguimiento(Fecha);
            return tabla;
        }

        public void GuardarSeguimiento(string Detalle, DateTime Fecha)
        {
            daS.GuardarSeguimiento(Detalle, Fecha);
        }
    }
}
