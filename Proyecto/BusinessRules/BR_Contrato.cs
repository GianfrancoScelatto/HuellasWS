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
        public void AltaContrato(int IdAdoptante, int IdAnimal, string NuevoNombre, DateTime FechaAdopcion, int IdUsuario)
        {
            if (msj.MensajeAcceso(E_Usuario.Rol))
            {
                daC.AltaContrato(IdAdoptante, IdAnimal, NuevoNombre, FechaAdopcion, IdUsuario);
            }

        }

        public void BajaContrato(int IdContrato, int IdUsuario)
        {
            if (msj.MensajeAcceso(E_Usuario.Rol))
            {
                daC.BajaContrato(IdContrato, IdUsuario);
            }
        }
    }
}
