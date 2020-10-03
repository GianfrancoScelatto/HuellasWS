using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DataAccess;

namespace BusinessRules
{
    public class BR_FichaMedica
    {
        DA_FichaMedica daFM = new DA_FichaMedica();
        public DataTable ListarFichaMedica()
        {
            DataTable tabla = new DataTable();
            tabla = daFM.ListarFichaMedica();
            return tabla;
        }

        public DataTable FiltrarFichaMedica(string Nombre, DateTime Fecha)
        {
            DataTable tabla = new DataTable();
            tabla = daFM.FiltrarFichaMedica(Nombre, Fecha);
            return tabla;
        }
    }
}
