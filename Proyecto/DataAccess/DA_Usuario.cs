using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Entities;

namespace DataAccess
{
    public class DA_Usuario : DA_Connection
    {
        //E_Usuario eU = new E_Usuario();
        public bool AccesoUsuario(string Usuario, string Contraseña)
        {
            using (var conexion = GetConnection())
            {
                conexion.Open();
                using (var Comando = new SqlCommand())
                {
                    Comando.Connection = conexion;
                    Comando.CommandText = "prc_Login";
                    Comando.CommandType = CommandType.StoredProcedure;
                    Comando.Parameters.AddWithValue("@Usuario", Usuario);
                    Comando.Parameters.AddWithValue("@Contraseña", Contraseña);
                    SqlDataReader reader = Comando.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            E_Usuario.IdUsuario = reader.GetInt32(0);
                            E_Usuario.NombreUsuario = reader.GetString(1);
                            E_Usuario.Nombre = reader.GetString(2);
                            E_Usuario.Apellido = reader.GetString(3);
                            E_Usuario.Dni = reader.GetString(4);
                            E_Usuario.Telefono = reader.GetInt32(5);
                            E_Usuario.IdPregunta = reader.GetInt32(6);
                            E_Usuario.RespuestaSeguridad = reader.GetString(7);
                            E_Usuario.Contraseña = reader.GetString(8);
                            E_Usuario.IdRol = reader.GetInt32(9);
                            E_Usuario.Rol = reader.GetString(10);
                        }
                        return true;
                    }
                    else
                    {
                        return false;
                    }
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

        public void ModificarUsuario(int idUsuario, string Usuario, string Nombre, string Apellido, int Dni, int Telefono, int idRol)
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
                    command.Parameters.AddWithValue("@IdRol", idRol);
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

        public DataTable TraerPregunta(string Usuario)
        {
            using (var connection = GetConnection())
            {
                DataTable tabla = new DataTable();
                SqlDataAdapter sdA = new SqlDataAdapter("prc_PreguntaUsuario", connection);
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    sdA.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sdA.SelectCommand.Parameters.AddWithValue("@Usuario", Usuario);
                    sdA.Fill(tabla);
                    connection.Close();
                    return tabla;
                }
            }
        }

        public void RecuperarUsuario(string Usuario, int idPregunta, string Respuesta, string Contraseña)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "prc_RecuperarUsuario";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Usuario", Usuario);
                    command.Parameters.AddWithValue("@IdPregunta", idPregunta);
                    command.Parameters.AddWithValue("@Respuesta", Respuesta);
                    command.Parameters.AddWithValue("@Contraseña", Contraseña);
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

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
    }
}
