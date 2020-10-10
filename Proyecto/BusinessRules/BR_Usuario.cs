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

        public void AltaUsuario(string Usuario, string Nombre, string Apellido, int Dni, int Telefono, int idPregunta, string Respuesta, string Contrasenia, int idRol)
        {
            daU.AltaUsuario(Usuario, Nombre, Apellido, Dni, Telefono, idPregunta, Respuesta, Contrasenia, idRol);
        }

        public void ModificarUsuario(int idUsuario, string Usuario, string Nombre, string Apellido, int Dni, int Telefono, int idRol)
        {
            daU.ModificarUsuario(idUsuario, Usuario, Nombre, Apellido, Dni, Telefono, idRol);
        }

        public void BajaUsuario(int idUsuario)
        {
            daU.BajaUsuario(idUsuario);
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

        public DataTable FiltrarUsuario(string Usuario)
        {
            DataTable tabla = new DataTable();
            tabla = daU.FiltrarUsuario(Usuario);
            return tabla;
        }        
    }
}
