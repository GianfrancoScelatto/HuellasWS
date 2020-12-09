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
        DA_ListaNegra ObjListaNegra = new DA_ListaNegra();
        E_Mensaje msj = new E_Mensaje();
        

        public DataTable ListarListaNegra()
        {
            DataTable tabla = new DataTable();
            tabla = ObjListaNegra.ListarListaNegra();
            return tabla;
        }
        public void AltaListaNegra(int IdPersona, string Motivo, int IdUsuario)
        {
            if (msj.MensajeAcceso(E_UsuarioAcceso.Rol)) 
            { 
                ObjListaNegra.AltaListaNegra(IdPersona, Motivo, IdUsuario);
            }
        }
        public void ModificarListaNegra(int IdPersona, string Motivo, int IdUsuario)
        {
            if (msj.MensajeAcceso(E_UsuarioAcceso.Rol)) 
            { 
                ObjListaNegra.ModificarListaNegra(IdPersona, Motivo, IdUsuario);
            }
        }
        public void BajaListaNegra(int IdPersona, int IdUsuario)
        {
            if (msj.MensajeAcceso(E_UsuarioAcceso.Rol)) 
            { 
                ObjListaNegra.BajaListaNegra(IdPersona,IdUsuario);
            }
        }
        public DataTable FiltrarListaNegra(string Busqueda)
        {
            DataTable tabla = new DataTable();
            tabla = ObjListaNegra.FiltrarListaNegra(Busqueda);
            return tabla;
        }
    }
}
