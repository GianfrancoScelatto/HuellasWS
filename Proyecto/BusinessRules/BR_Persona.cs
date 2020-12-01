using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DataAccess;
using Entities;
namespace BusinessRules
{

    public class BR_Persona
    {
        DA_Persona ObjPersona = new DA_Persona();
        E_Mensaje msj = new E_Mensaje();

        public DataTable ListarPersona()
        {
            DataTable tabla = new DataTable();
            tabla = ObjPersona.ListarPersona();
            return tabla;
        }
        public void AltaPersona(int IdTipoPersona, string Nombre, string Apellido, int Edad, string DNI, string Domicilio, string Localidad, string CodigoPostal, string Calles, int Altura, int IdSexo, int Telefono, int Celular, string Email, string UsuarioFaceIg, bool ListaNegra, string Motivo,int IdUsuario)
        {
            if (msj.MensajeAcceso(E_UsuarioAcceso.Rol))
            {

                ObjPersona.AltaPersona(IdTipoPersona, Nombre, Apellido, Edad, DNI, Domicilio, Localidad, CodigoPostal, Calles, Altura, IdSexo, Telefono, Celular, Email, UsuarioFaceIg, ListaNegra, Motivo, IdUsuario);
            }
        }
        public void ModificarPersona(int idPersona, int IdTipoPersona, string Nombre, string Apellido, int Edad, string DNI, string Domicilio, string Localidad, string CodigoPostal, string Calles, int Altura, int IdSexo, int Telefono, int Celular, string Email, string UsuarioFaceIg, bool ListaNegra, string Motivo, int IdUsuario)
        {
            if (msj.MensajeAcceso(E_UsuarioAcceso.Rol))
            {
                ObjPersona.ModificarPersona(idPersona, IdTipoPersona, Nombre, Apellido, Edad, DNI, Domicilio, Localidad, CodigoPostal, Calles, Altura, IdSexo, Telefono, Celular, Email, UsuarioFaceIg, ListaNegra, Motivo, IdUsuario);
            }
        }
        public void BajaPersona(int idPersona, int IdUsuario)
        {
            if (msj.MensajeAcceso(E_UsuarioAcceso.Rol))
            {
                ObjPersona.BajaPersona(idPersona, IdUsuario);
            }
        }
        public void FiltrarPersona(string Busqueda, string tipoPersona)
        {
            ObjPersona.FiltrarPersona(Busqueda, tipoPersona);
        }

        public DataTable DetallePersona(int idPersona)
        {
            DataTable tabla = new DataTable();
            tabla = ObjPersona.DetallePersona(idPersona);
            return tabla;
        }

        public DataTable ComboPersona()
        {
            DataTable tabla = new DataTable();
            tabla = ObjPersona.ComboPersona();
            return tabla;
        }

        public DataTable ComboTipoPersona()
        {
            DataTable tabla = new DataTable();
            tabla = ObjPersona.ComboTipoPersona();
            return tabla;
        }

        public DataTable ComboSexo()
        {
            DataTable tabla = new DataTable();
            tabla = ObjPersona.SexoPersona();
            return tabla;
        }

    }
}