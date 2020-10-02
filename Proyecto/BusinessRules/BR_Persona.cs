using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DataAccess;
namespace BusinessRules
{
    public class BR_Persona
    {
        DA_Persona ObjPersona = new DA_Persona();

        public DataTable ListarPersona()
        {
            DataTable tabla = new DataTable();
            tabla = ObjPersona.ListarPersona();
            return tabla;
        }
        public void AltaPersona(int idPersona, int IdTipoPersona, string Nombre, string Apellido, int Edad, int DNI, string Domicilio, string Localidad, int Codigo_Postal, string Calles, int Altura, string Sexo, int Telefono, int Celular, string Email, string UsuarioFaceIg, bool ListaNegra, string Motivo, byte Deshabilitado)
        {
            ObjPersona.AltaPersona(idPersona, IdTipoPersona, Nombre, Apellido, Edad, DNI, Domicilio, Localidad, Codigo_Postal, Calles, Altura, Sexo, Telefono, Celular, Email, UsuarioFaceIg, ListaNegra, Motivo, Deshabilitado)
        }
        public void ModificarPersona(int idPersona, int IdTipoPersona, string Nombre, string Apellido, int Edad, int DNI, string Domicilio, string Localidad, int Codigo_Postal, string Calles, int Altura, string Sexo, int Telefono, int Celular, string Email, string UsuarioFaceIg, bool ListaNegra, string Motivo, byte Deshabilitado)
        {
            ObjPersona.ModificarPersona(idPersona, IdTipoPersona, Nombre, Apellido, Edad, DNI, Domicilio, Localidad, Codigo_Postal, Calles, Altura, Sexo, Telefono, Celular, Email, UsuarioFaceIg, ListaNegra, Motivo, Deshabilitado);
        }
        public void BorrarPersona(int idPersona, int IdUsuario, int IdMovimiento, bool Deshabilitado, string Descripcion)
        {
            ObjPersona.BajaPersona(idPersona, IdUsuario, IdMovimiento, Deshabilitado, Descripcion);
        }
        public void FiltrarPersona(string Busqueda)
        {
            ObjPersona.FiltrarPersona(Busqueda);
        }
    }
}