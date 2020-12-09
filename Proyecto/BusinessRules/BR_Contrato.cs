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
        public void AltaContrato(int IdAnimal, string NuevoNombre, int IdUsuario, int IdPersona)
        {
            if (msj.MensajeAcceso(E_UsuarioAcceso.Rol))
            {
                daC.AltaContrato( IdAnimal, NuevoNombre, IdUsuario, IdPersona);
            }

        }

        public void BajaContrato(int IdContrato, int IdUsuario, int IdAnimal, int IdPersona, string NuevoNombre)
        {
            if (msj.MensajeAcceso(E_UsuarioAcceso.Rol))
            {
                daC.BajaContrato(IdContrato, IdUsuario, IdAnimal, IdPersona, NuevoNombre );
            }
        }
    }
}
