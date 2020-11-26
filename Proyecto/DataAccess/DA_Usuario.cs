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
                            E_UsuarioAcceso.IdUsuario = reader.GetInt32(0);
                            E_UsuarioAcceso.NombreUsuario = reader.GetString(1);
                            E_UsuarioAcceso.Nombre = reader.GetString(2);
                            E_UsuarioAcceso.Apellido = reader.GetString(3);
                            E_UsuarioAcceso.Dni = reader.GetString(4);
                            E_UsuarioAcceso.Telefono = reader.GetInt32(5);
                            E_UsuarioAcceso.IdPregunta = reader.GetInt32(6);
                            E_UsuarioAcceso.RespuestaSeguridad = reader.GetString(7);
                            E_UsuarioAcceso.Contraseña = reader.GetString(8);
                            E_UsuarioAcceso.IdRol = reader.GetInt32(9);
                            E_UsuarioAcceso.Rol = reader.GetString(10);
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

        public void AltaUsuario(string Usuario, string Nombre, string Apellido, string Dni, int Telefono, int IdPregunta, string Respuesta, string Contraseña, int IdRol)
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
                    command.Parameters.AddWithValue("@IdPregunta", IdPregunta);
                    command.Parameters.AddWithValue("@Respuesta", Respuesta);
                    command.Parameters.AddWithValue("@Contrasenia", Contraseña);
                    command.Parameters.AddWithValue("@IdRol", IdRol);
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        public void ModificarUsuario(int IdUsuario, string Usuario, string Nombre, string Apellido, string Dni, int Telefono, string Contraseña, int IdRol)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "prc_ModificarUsuario";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IdUsuario", IdUsuario);
                    command.Parameters.AddWithValue("@Usuario", Usuario);
                    command.Parameters.AddWithValue("@Nombre", Nombre);
                    command.Parameters.AddWithValue("@Apellido", Apellido);
                    command.Parameters.AddWithValue("@Dni", Dni);
                    command.Parameters.AddWithValue("@Telefono", Telefono);
                    command.Parameters.AddWithValue("@Contrasenia", Contraseña);
                    command.Parameters.AddWithValue("@IdRol", IdRol);
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        public void BajaUsuario(int IdUsuario, int IdUsuarioAcceso)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "prc_BajaUsuario";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IdUsuario", IdUsuario);
                    command.Parameters.AddWithValue("@IdUsuarioAcceso", IdUsuarioAcceso);
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

        public void RecuperarUsuario(string Usuario, int IdPregunta, string Respuesta, string Contraseña)
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
                    command.Parameters.AddWithValue("@IdPregunta", IdPregunta);
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

        public DataTable FiltrarUsuario(string Usuario, string tipoBusqueda)
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
                    command.Parameters.AddWithValue("@TipoBusqueda", tipoBusqueda);
                    SqlDataReader leer = command.ExecuteReader();
                    tabla.Load(leer);
                    connection.Close();
                    return tabla;
                }
            }
        }

        public DataTable ListarPreguntas()
        {
            using (var connection = GetConnection())
            {
                DataTable tabla = new DataTable();
                SqlDataAdapter sdA = new SqlDataAdapter("prc_ListarComboPregunta", connection);
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    sdA.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sdA.Fill(tabla);
                    connection.Close();
                    return tabla;
                }
            }
        }

        public DataTable ListarRoles()
        {
            using (var connection = GetConnection())
            {
                DataTable tabla = new DataTable();
                SqlDataAdapter sdA = new SqlDataAdapter("prc_ListarComboRol", connection);
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    sdA.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sdA.Fill(tabla);
                    connection.Close();
                    return tabla;
                }
            }
        }
    }
}
