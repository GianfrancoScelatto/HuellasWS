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
    public class BR_Contrato
    {
        DA_Contrato daC = new DA_Contrato();
        E_Mensaje msj = new E_Mensaje();

        public DataTable ListarContrato()
        {
            DataTable tabla = new DataTable();
            tabla = daC.ListarContrato();
            return tabla;
        }

    }
}
