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
    public class BR_Establecimiento
    {
        DA_Establecimiento daE = new DA_Establecimiento();
        E_Mensaje msj = new E_Mensaje();
        

        public DataTable MostrarEstablecimiento()
        {
            DataTable tabla = new DataTable();
            tabla = daE.ListarEstablecimiento();
            return tabla;
        }

        public void AltaEstablecimiento(int IdTipoEstablecimiento, string Nombre, string HorarioAtencion, string Localidad, string CodigoPostal, string Calle, int Altura, bool Internacion, int IdUsuario)
        {
            if (msj.MensajeAcceso(E_UsuarioAcceso.Rol))
            {
                daE.AltaEstablecimiento(IdTipoEstablecimiento, Nombre, HorarioAtencion, Localidad, CodigoPostal, Calle, Altura, Internacion, IdUsuario);
            }
        }

        public void ModifcarEstablecimiento(int IdEstablecimiento, int IdTipoEstablecimiento, string Nombre, string HorarioAtencion, string Localidad, string CodigoPostal, string Calle, int Altura, bool Internacion, int IdUsuario)
        {
            if (msj.MensajeAcceso(E_UsuarioAcceso.Rol))
            {
                daE.ModificarEstablecimiento(IdEstablecimiento, IdTipoEstablecimiento, Nombre, HorarioAtencion, Localidad, CodigoPostal, Calle, Altura, Internacion, IdUsuario);
            }
        }

        public void BajaEstablecimiento(int IdEstablecimiento, int IdUsuario)
        {
            if (msj.MensajeAcceso(E_UsuarioAcceso.Rol))
            {
             daE.BajaVacuna(IdEstablecimiento, IdUsuario);
            }
            
        }

        public DataTable ComboEstablecimiento()
        {
            DataTable tabla = new DataTable();
            tabla = daE.ComboEstablecimiento();
            return tabla;
        }
    }
}
