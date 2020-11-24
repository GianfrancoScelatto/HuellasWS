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
        public void AltaAnimal(int IdUsuario, int IdPersona, int TipoAnimal, string LugarRescate, string FotoIngreso, string FotoAdopcion, string NombreAnimal, int Edad, string Sexo, bool Castracion, string ColorPelo, decimal Peso, string Comentario, int Estado, DateTime FechaCastracion,DateTime FechaIngreso, DateTime FechaNacimiento)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.Parameters.AddWithValue("@IdUsuario", IdUsuario);
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
                    command.Parameters.AddWithValue("@FechaCastracion", FechaCastracion);
                    command.Parameters.AddWithValue("@FechaIngreso", FechaIngreso);
                    command.Parameters.AddWithValue("@FechaNac", FechaNacimiento);
                    command.CommandText = "prc_AltaAnimal";
                    command.CommandType = CommandType.StoredProcedure;
                    command.ExecuteNonQuery();
                }
            }
        }
        public void ModificarAnimal(int IdAnimal, int IdPersona, int TipoAnimal, string LugarRescate, string FotoIngreso, string FotoAdopcion, string NombreAnimal, int Edad, string Sexo, bool Castracion, string ColorPelo, decimal Peso, string Comentario, int Estado, DateTime FechaIngreso)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.Parameters.AddWithValue("@IdAnimal", IdAnimal);
                    command.Parameters.AddWithValue("@IdPersona", IdPersona);
                    command.Parameters.AddWithValue("@IdEspecie", TipoAnimal);
                    command.Parameters.AddWithValue("@LugarRescate", LugarRescate);
                    command.Parameters.AddWithValue("@FotoIngreso", FotoIngreso);
                    command.Parameters.AddWithValue("@FotoAdopcion", FotoAdopcion);
                    command.Parameters.AddWithValue("@NombreAnimal", NombreAnimal);
                    command.Parameters.AddWithValue("@Edad", Edad);
                    command.Parameters.AddWithValue("@Sexo", Sexo);
                    command.Parameters.AddWithValue("@Castracion", Castracion);
                    command.Parameters.AddWithValue("@ColorPelo", ColorPelo);
                    command.Parameters.AddWithValue("@Peso", Peso);
                    command.Parameters.AddWithValue("@Comentario", Comentario);
                    command.Parameters.AddWithValue("@Estado", Estado);
                    command.Parameters.AddWithValue("@FechaIngreso", FechaIngreso);
                    command.CommandText = "prc_ModificarAnimal";
                    command.CommandType = CommandType.StoredProcedure;
                    command.ExecuteNonQuery();
                }
            }

        }
        public void BajaAnimal(int IdAnimal, int IdUsuario, int IdMovimiento, int EstadoAnimal, string Descripcion, bool Deshabilitado)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.Parameters.AddWithValue("@IdAnimal", IdAnimal);
                    command.Parameters.AddWithValue("@Id_Usuario", IdUsuario);
                    command.Parameters.AddWithValue("@IdMovimiento", IdMovimiento);
                    command.Parameters.AddWithValue("@Estado", EstadoAnimal);
                    command.Parameters.AddWithValue("@Descripcion", Descripcion);
                    command.Parameters.AddWithValue("@Deshabilitado", Deshabilitado);
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
    }
}
  
