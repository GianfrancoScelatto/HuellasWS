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
        public void AltaPersona(int IdTipoPersona, string Nombre, string Apellido, int Edad, string DNI, string Domicilio, string Localidad, string Codigo_Postal, string Calles, int Altura, string Sexo, int Telefono, int Celular, string Email, string UsuarioFaceIg, bool ListaNegra, string Motivo,int IdUsuario)
        {
            ObjPersona.AltaPersona(IdTipoPersona, Nombre, Apellido, Edad, DNI, Domicilio, Localidad, Codigo_Postal, Calles, Altura, Sexo, Telefono, Celular, Email, UsuarioFaceIg, ListaNegra, Motivo,IdUsuario);
        }
        public void ModificarPersona(int idPersona, int IdTipoPersona, string Nombre, string Apellido, int Edad, string DNI, string Domicilio, string Localidad, string Codigo_Postal, string Calles, int Altura, string Sexo, int Telefono, int Celular, string Email, string UsuarioFaceIg, bool ListaNegra, string Motivo, int IdUsuario)
        {
            ObjPersona.ModificarPersona(idPersona, IdTipoPersona, Nombre, Apellido, Edad, DNI, Domicilio, Localidad, Codigo_Postal, Calles, Altura, Sexo, Telefono, Celular, Email, UsuarioFaceIg, ListaNegra, Motivo, IdUsuario);
        }
        public void BajaPersona(int idPersona, int IdUsuario)
        {
            ObjPersona.BajaPersona(idPersona, IdUsuario);
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


    }
}