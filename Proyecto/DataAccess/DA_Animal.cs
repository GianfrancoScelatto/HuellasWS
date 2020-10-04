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
        public void AltaAnimal(int TipoAnimal, string LugarRescate, byte FotoIngreso, byte FotoAdopcion, string NombreAnimal, int Edad, string Sexo, bool Castracion, string ColorPelo, double Peso, string Comentario, int Estado, DateTime FechaIngreso)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.Parameters.AddWithValue("@TipoAnimal", TipoAnimal);
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
                    command.CommandText = "prc_AltaAnimal";
                    command.CommandType = CommandType.StoredProcedure;
                    command.ExecuteNonQuery();
                }
            }
        }
        public void ModificarAnimal(int IdAnimal, int TipoAnimal, string LugarRescate, byte FotoIngreso, byte FotoAdopcion, string NombreAnimal, int Edad, string Sexo, bool Castracion, string ColorPelo, double Peso, string Comentario, int Estado, DateTime FechaIngreso)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.Parameters.AddWithValue("@IdAnimal", IdAnimal);
                    command.Parameters.AddWithValue("@TipoAnimal", TipoAnimal);
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
        public void BajaAnimal(int IdAnimal, int IdUsuario, int IdMovimiento,int EstadoAnimal,string Descripcion, bool Deshabilitado)
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
        //Confirmacion De aj sobre el tema del filtrado.
        public DataTable FiltrarAnimal(string busqueda)
        {
            using (var connection = GetConnection())
            {
                DataTable tabla = new DataTable();
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.Parameters.AddWithValue("@Busqueda", busqueda);
                    command.CommandText = "prc_BuscarAnimal";
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = command.ExecuteReader();
                    tabla.Load(reader);
                    connection.Close();
                    return tabla;
                }
            }
        }
    }
}
  
