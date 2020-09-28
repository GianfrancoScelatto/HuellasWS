using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DataAccess;

namespace BusinessRules
{
    public class BR_Usuario
    {
        DA_Usuario ObjUsuario = new DA_Usuario();

        public DataTable ListarUsuario()
        {
            DataTable tabla = new DataTable();
            tabla = ObjUsuario.ListarUsuario();
            return tabla;
        }

        public DataTable FiltrarUsuario(string Usuario)
        {
            DataTable tabla = new DataTable();
            tabla = ObjUsuario.FiltrarUsuario(Usuario);
            return tabla;
        }

        public void AccesoUsuario(string Usuario, string Contrasenia)
        {
            ObjUsuario.AccesoUsuario(Usuario, Contrasenia);
        }

        public void AltaUsuario(string Usuario, string Nombre, string Apellido, int Dni, int Telefono, int idPregunta, string Respuesta, string Contrasenia, int idRol)
        {
            ObjUsuario.AltaUsuario(Usuario, Nombre, Apellido, Dni, Telefono, idPregunta, Respuesta, Contrasenia, idRol);
        }

        public void ModificarUsuario(int idUsuario, string Usuario, string Nombre, string Apellido, int Dni, int Telefono, int idPregunta, string Respuesta, string Contrasenia, int idRol)
        {
            ObjUsuario.ModificarUsuario(idUsuario, Usuario, Nombre, Apellido, Dni, Telefono, idPregunta, Respuesta, Contrasenia, idRol);
        }

        public void BajaUsuario(int idUsuario)
        {
            ObjUsuario.BajaUsuario(idUsuario);
        }
    }
}
