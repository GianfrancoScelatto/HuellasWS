using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess
{
    public class DA_Usuario : DA_Connection
    {
        public DataTable ListarUsuario()
        {
            DataTable tabla = new DataTable();
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "prc_ListarUsuario";
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader leer = command.ExecuteReader();
                    tabla.Load(leer);
                    connection.Close();
                    return tabla;
                }
            }
        }

        public DataTable FiltrarUsuario(string Usuario)
        {
            DataTable tabla = new DataTable();
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "prc_FiltrarUsuario";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Usuario", Usuario);
                    SqlDataReader leer = command.ExecuteReader();
                    tabla.Load(leer);
                    connection.Close();
                    return tabla;
                }
            }
        }
        public DataTable AccesoUsuario(string Usuario, string Contrasenia)
        {
            using (var connection = GetConnection())
            {
                DataTable tabla = new DataTable();
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "prc_Login";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Usuario", Usuario);
                    command.Parameters.AddWithValue("@Contrasenia", Contrasenia);
                    SqlDataReader leer = command.ExecuteReader();
                    tabla.Load(leer);
                    connection.Close();
                    return tabla;
                }
            }
        }

        public void AltaUsuario(string Usuario, string Nombre, string Apellido, int Dni, int Telefono, int idPregunta, string Respuesta, string Contrasenia, int idRol)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "prc_AltaUsuario";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Usuario", Usuario);
                    command.Parameters.AddWithValue("@Nombre", Nombre);
                    command.Parameters.AddWithValue("@Apellido", Apellido);
                    command.Parameters.AddWithValue("@Dni", Dni);
                    command.Parameters.AddWithValue("@Telefono", Telefono);
                    command.Parameters.AddWithValue("@IdPregunta", idPregunta);
                    command.Parameters.AddWithValue("@Respuesta", Respuesta);
                    command.Parameters.AddWithValue("@Contrasenia", Contrasenia);
                    command.Parameters.AddWithValue("@IdRol", idRol);
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        public void ModificarUsuario(int idUsuario, string Usuario, string Nombre, string Apellido, int Dni, int Telefono, int idPregunta, string Respuesta, string Contrasenia, int idRol)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "prc_ModificarUsuario";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IdUsuario", idUsuario);
                    command.Parameters.AddWithValue("@Usuario", Usuario);
                    command.Parameters.AddWithValue("@Nombre", Nombre);
                    command.Parameters.AddWithValue("@Apellido", Apellido);
                    command.Parameters.AddWithValue("@Dni", Dni);
                    command.Parameters.AddWithValue("@Telefono", Telefono);
                    //command.Parameters.AddWithValue("@IdPregunta", idPregunta);
                    //command.Parameters.AddWithValue("@Respuesta", Respuesta);
                    //command.Parameters.AddWithValue("@Contrasenia", Contrasenia);
                    //command.Parameters.AddWithValue("@IdRol", idRol);
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        public void BajaUsuario(int idUsuario)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "prc_BajaUsuario";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IdUsuario", idUsuario);
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        public void contrasenia()
        {

        }

        public void pregyresp()
        {

        }
    }
}
