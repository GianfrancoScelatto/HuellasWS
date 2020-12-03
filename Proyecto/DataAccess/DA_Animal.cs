using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess
{
    public class DA_Animal : DA_Connection
    {
        public DataTable ListarAnimal()
        {
            using (var connection = GetConnection())
            {
                DataTable tabla = new DataTable();
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "prc_ListarAnimal";
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader leer = command.ExecuteReader();
                    tabla.Load(leer);
                    connection.Close();
                    return tabla;
                }
            }
        }
        public void AltaAnimal(int IdUsuario, int IdPersona, int TipoAnimal, string LugarRescate, string FotoIngreso, string NombreAnimal, int Edad, int Sexo, bool Castracion, string ColorPelo, decimal Peso, string Comentario, int Estado, DateTime? FechaCastracion, DateTime FechaIngreso, DateTime FechaNacimiento, DateTime? FechaDefuncion)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.Parameters.AddWithValue("@NombreAnimal", NombreAnimal);
                    command.Parameters.AddWithValue("@IdUsuario", IdUsuario);
                    command.Parameters.AddWithValue("@IdEspecie", TipoAnimal);
                    command.Parameters.AddWithValue("@IdPersona", IdPersona);
                    command.Parameters.AddWithValue("@FechaIngreso", FechaIngreso);
                    command.Parameters.AddWithValue("@FechaNac", FechaNacimiento);
                    command.Parameters.AddWithValue("@LugarRescate", LugarRescate);
                    command.Parameters.AddWithValue("@ImagenIngreso", FotoIngreso);
                    command.Parameters.AddWithValue("@Sexo", Sexo);
                    command.Parameters.AddWithValue("@Edad", Edad);
                    command.Parameters.AddWithValue("@Peso", Peso);
                    command.Parameters.AddWithValue("@ColorPelo", ColorPelo);
                    command.Parameters.AddWithValue("@Castracion", Castracion);
                    if (FechaCastracion.HasValue) command.Parameters.AddWithValue("@FechaCastracion", FechaCastracion); else command.Parameters.AddWithValue("@FechaCastracion", null);
                    if (FechaDefuncion.HasValue) command.Parameters.AddWithValue("@FechaDefuncion", FechaDefuncion); else command.Parameters.AddWithValue("@FechaDefuncion", null);
                    command.Parameters.AddWithValue("@Comentario", Comentario);
                    command.Parameters.AddWithValue("@EstadoAnimal", Estado);
                    command.CommandText = "prc_AltaAnimal";
                    command.CommandType = CommandType.StoredProcedure;
                    command.ExecuteNonQuery();
                }
            }
        }
        public void ModificarAnimal(int IdUsuario, int IdAnimal, int IdPersona, int TipoAnimal, string LugarRescate, string FotoIngreso, string FotoAdopcion, string NombreAnimal, int Edad, int Sexo, bool Castracion, string ColorPelo, decimal Peso, string Comentario, int Estado, DateTime? FechaCastracion, DateTime? FechaIngreso, DateTime? FechaNacimiento, DateTime? FechaDefuncion)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.Parameters.AddWithValue("@IdUsuario", IdUsuario);
                    command.Parameters.AddWithValue("@IdAnimal", IdAnimal);
                    command.Parameters.AddWithValue("@IdPersona", IdPersona);
                    command.Parameters.AddWithValue("@IdEspecie", TipoAnimal);
                    command.Parameters.AddWithValue("@LugarRescate", LugarRescate);
                    command.Parameters.AddWithValue("@ImagenIngreso", FotoIngreso);
                    command.Parameters.AddWithValue("@ImagenAdopcion", FotoAdopcion);
                    command.Parameters.AddWithValue("@NombreAnimal", NombreAnimal);
                    command.Parameters.AddWithValue("@Edad", Edad);
                    command.Parameters.AddWithValue("@Sexo", Sexo);
                    command.Parameters.AddWithValue("@Castracion", Castracion);
                    command.Parameters.AddWithValue("@ColorPelo", ColorPelo);
                    command.Parameters.AddWithValue("@Peso", Peso);
                    command.Parameters.AddWithValue("@Comentario", Comentario);
                    command.Parameters.AddWithValue("@EstadoAnimal", Estado);
                    command.Parameters.AddWithValue("@FechaIngreso", FechaIngreso);
                    command.Parameters.AddWithValue("@FechaNac", FechaNacimiento);
                    if (FechaCastracion.HasValue) command.Parameters.AddWithValue("@FechaCastracion", FechaCastracion); else command.Parameters.AddWithValue("@FechaCastracion", null);
                    if (FechaDefuncion.HasValue) command.Parameters.AddWithValue("@FechaDefuncion", FechaDefuncion); else command.Parameters.AddWithValue("@FechaDefuncion", null);
                    command.CommandText = "prc_ModificarAnimal";
                    command.CommandType = CommandType.StoredProcedure;
                    command.ExecuteNonQuery();
                }
            }

        }
        public void BajaAnimal(int IdAnimal, int IdUsuario)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.Parameters.AddWithValue("@IdAnimal", IdAnimal);
                    command.Parameters.AddWithValue("@IdUsuario", IdUsuario);
                    command.CommandText = "prc_BajaAnimal";
                    command.CommandType = CommandType.StoredProcedure;
                    command.ExecuteNonQuery();
                }
            }
        }

        public DataTable FiltrarAnimal(string busqueda, string tipoBusqueda)
        {
            using (var connection = GetConnection())
            {
                DataTable tabla = new DataTable();
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.Parameters.AddWithValue("@Busqueda", busqueda);
                    command.Parameters.AddWithValue("@TipoBusqueda", tipoBusqueda);
                    command.CommandText = "prc_FiltrarAnimal";
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = command.ExecuteReader();
                    tabla.Load(reader);
                    connection.Close();
                    return tabla;
                }
            }
        }

        public DataTable ComboAnimal()
        {
            using (var connection = GetConnection())
            {
                DataTable tabla = new DataTable();
                SqlDataAdapter sdA = new SqlDataAdapter("prc_ListarComboAnimal", connection);
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

        public DataTable ListarEstado()
        {
            using (var connection = GetConnection())
            {
                DataTable tabla = new DataTable();
                SqlDataAdapter sdA = new SqlDataAdapter("prc_ListarComboEstado", connection);
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

        public DataTable ListarSexo()
        {
            using (var connection = GetConnection())
            {
                DataTable tabla = new DataTable();
                SqlDataAdapter sdA = new SqlDataAdapter("prc_ListarComboSexoAnimal", connection);
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
  
