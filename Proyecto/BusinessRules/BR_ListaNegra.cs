using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using System.Data;
using DataAccess;

namespace BusinessRules
{
    public class BR_ListaNegra
    {
        DA_ListaNegra daL = new DA_ListaNegra();
        E_Mensaje msj = new E_Mensaje();

        public DataTable ListarListaNegra()
        {
            DataTable tabla = new DataTable();
            tabla = daL.ListarListaNegra();
            return tabla;
        }

    }
}
