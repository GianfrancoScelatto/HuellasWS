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
        DA_Usuario daU = new DA_Usuario();

        public bool AccesoUsuario(string Usuario, string Contraseña)
        {
            return daU.AccesoUsuario(Usuario, Contraseña);
        }

        public void AltaUsuario(int IdUsuario, string Usuario, string Nombre, string Apellido, string Dni, int Telefono, int IdPregunta, string Respuesta, string Contrasenia, int IdRol)
        {
            daU.AltaUsuario(IdUsuario, Usuario, Nombre, Apellido, Dni, Telefono, IdPregunta, Respuesta, Contrasenia, IdRol);
        }

        public void ModificarUsuario(int IdUsuario, string Usuario, string Nombre, string Apellido, string Dni, int Telefono, int IdPregunta, string Respuesta, string Contraseña, int IdRol)
        {
            daU.ModificarUsuario(IdUsuario, Usuario, Nombre, Apellido, Dni, Telefono,IdPregunta,Respuesta, Contraseña, IdRol);
        }

        public void BajaUsuario(int IdUsuario, int IdUsuarioAcceso)
        {
            daU.BajaUsuario(IdUsuario, IdUsuarioAcceso);
        }

        public DataTable TraerPregunta(string Usuario)
        {
            DataTable tabla = new DataTable();
            tabla = daU.TraerPregunta(Usuario);
            return tabla;
        }

        public void RecuperarUsuario(string Usuario, int idPregunta, string Respuesta, string Contraseña)
        {
            daU.RecuperarUsuario(Usuario, idPregunta, Respuesta, Contraseña);
        }

        public DataTable ListarUsuario()
        {
            DataTable tabla = new DataTable();
            tabla = daU.ListarUsuario();
            return tabla;
        }

        public DataTable FiltrarUsuario(string Usuario, string tipoBusqueda)
        {
            DataTable tabla = new DataTable();
            tabla = daU.FiltrarUsuario(Usuario, tipoBusqueda);
            return tabla;
        }

        public DataTable ListarPreguntas()
        {
            DataTable tabla = new DataTable();
            tabla = daU.ListarPreguntas();
            return tabla;
        }

        public DataTable ListarRoles()
        {
            DataTable tabla = new DataTable();
            tabla = daU.ListarRoles();
            return tabla;
        }
    }
}
