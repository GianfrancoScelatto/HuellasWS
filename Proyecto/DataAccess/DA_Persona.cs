using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess
{
    public class DA_Persona : DA_Connection
    {
        public DataTable ListarPersona()
        {
            using (var connection = GetConnection())
            {
                DataTable tabla = new DataTable();
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "prc_PersonaHistorial";
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader leer = command.ExecuteReader();
                    tabla.Load(leer);
                    connection.Close();
                    return tabla;
                }
            }
        }
        public void AltaPersona( int IdTipoPersona, string Nombre, string Apellido, int Edad, int DNI, string Domicilio, string Localidad, int Codigo_Postal, string Calles, int Altura, string Sexo, int Telefono, int Celular, string Email, string UsuarioFaceIg, bool ListaNegra, string Motivo, byte Deshabilitado)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.Parameters.AddWithValue("@TipoPersona", IdTipoPersona);
                    command.Parameters.AddWithValue("@Nombre", Nombre);
                    command.Parameters.AddWithValue("@Apellido", Apellido);
                    command.Parameters.AddWithValue("@Edad", Edad);
                    command.Parameters.AddWithValue("@DNI", DNI);
                    command.Parameters.AddWithValue("@Domicilio", Domicilio);
                    command.Parameters.AddWithValue("@Localidad", Localidad);
                    command.Parameters.AddWithValue("@Codigo_Postal", Codigo_Postal);
                    command.Parameters.AddWithValue("@Calles", Calles);
                    command.Parameters.AddWithValue("@Altura", Altura);
                    command.Parameters.AddWithValue("@Sexo", Sexo);
                    command.Parameters.AddWithValue(" @Telefono", Telefono);
                    command.Parameters.AddWithValue("@Celular", Celular);
                    command.Parameters.AddWithValue("@Email", Email);
                    command.Parameters.AddWithValue("@UsuarioFaceIg", UsuarioFaceIg);
                    command.Parameters.AddWithValue("@ListaNegra", ListaNegra);
                    command.Parameters.AddWithValue("@Motivo", Motivo);
                    command.Parameters.AddWithValue("@Deshabilitado", Deshabilitado);
                    command.CommandText = "prc_AltaPersona";
                    //y la BR y dsp funcionalidad, a su vez tambien faltan los prc en Base Datos
                    command.CommandType = CommandType.StoredProcedure;
                    command.ExecuteNonQuery();
                }
            }
        }
        public void ModificarPersona(int idPersona, int IdTipoPersona, string Nombre, string Apellido, int Edad, int DNI, string Domicilio, string Localidad, int Codigo_Postal, string Calles, int Altura, string Sexo, int Telefono, int Celular, string Email, string UsuarioFaceIg, bool ListaNegra, string Motivo, byte Deshabilitado)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.Parameters.AddWithValue("@idPersona", idPersona);
                    command.Parameters.AddWithValue("@TipoPersona", IdTipoPersona);
                    command.Parameters.AddWithValue("@Nombre", Nombre);
                    command.Parameters.AddWithValue("@Apellido", Apellido);
                    command.Parameters.AddWithValue("@Edad", Edad);
                    command.Parameters.AddWithValue("@DNI", DNI);
                    command.Parameters.AddWithValue("@Domicilio", Domicilio);
                    command.Parameters.AddWithValue("@Localidad", Localidad);
                    command.Parameters.AddWithValue("@Codigo_Postal", Codigo_Postal);
                    command.Parameters.AddWithValue("@Calles", Calles);
                    command.Parameters.AddWithValue("@Altura", Altura);
                    command.Parameters.AddWithValue("@Sexo", Sexo);
                    command.Parameters.AddWithValue(" @Telefono", Telefono);
                    command.Parameters.AddWithValue("@Celular", Celular);
                    command.Parameters.AddWithValue("@Email", Email);
                    command.Parameters.AddWithValue("@UsuarioFaceIg", UsuarioFaceIg);
                    command.Parameters.AddWithValue("@ListaNegra", ListaNegra);
                    command.Parameters.AddWithValue("@Motivo", Motivo);
                    command.Parameters.AddWithValue("@Deshabilitado", Deshabilitado);
                    command.CommandText = "prc_ModificarPersona";
                    command.CommandType = CommandType.StoredProcedure;
                    command.ExecuteNonQuery();
                }
            }
        }
        public void BajaPersona(int IdPersona, int IdUsuario, int IdMovimiento, string Descripcion, bool Deshabilitado)
        {
            using (var connection = GetConnection())
            {
                DataTable tabla = new DataTable();
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.Parameters.AddWithValue("@IdPersona", IdPersona);
                    command.Parameters.AddWithValue("@IdUsuario", IdUsuario);
                    command.Parameters.AddWithValue("@IdMovimiento", IdMovimiento);
                    command.Parameters.AddWithValue("@Deshabilitado", Deshabilitado);
                    command.Parameters.AddWithValue("@Descripcion", Descripcion);
                    command.CommandText = "prc_BajaPersona";
                    command.CommandType = CommandType.StoredProcedure;
                    command.ExecuteNonQuery();
                }
            }
        }

        public DataTable FiltrarPersona(string Busqueda, string tipoPersona)
        {
            using (var connection = GetConnection())
            {
                DataTable tabla = new DataTable();
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.Parameters.AddWithValue("@Busqueda", Busqueda);
                    command.Parameters.AddWithValue("@TipoPersona", tipoPersona);
                    command.CommandText = "prc_FiltrarPersona";
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = command.ExecuteReader();
                    tabla.Load(reader);
                    connection.Close();
                    return tabla;
                }
            }
        }

        public DataTable DetallePersona(int idPersona)
        {
            using (var connection = GetConnection())
            {
                DataTable tabla = new DataTable();
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.Parameters.AddWithValue("@IdPersona", idPersona);
                    command.CommandText = "prc_DetallePersona";
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.HasRows && reader.Read())
                    {
                        E_Persona.NombrePersona = reader.GetString(0);
                        E_Persona.Domicilio = reader.GetString(1);
                        E_Persona.Localidad = reader.GetString(2);
                        E_Persona.Celular = reader.GetInt32(3);
                        E_Persona.Email = reader.GetString(4);
                    }
                    tabla.Load(reader);
                    connection.Close();
                    return tabla;
                }
            }
        }

        public DataTable ComboPersona()
        {
            using (var connection = GetConnection())
            {
                DataTable tabla = new DataTable();
                SqlDataAdapter sdA = new SqlDataAdapter("prc_ListarComboPersona", connection);
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
