using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess
{
    public class DA_Animal: DA_Connection
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
                    command.CommandText = "prcListarAnimal";
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader leer = command.ExecuteReader();
                    tabla.Load(leer);
                    connection.Close();
                    return tabla;
                }
            }
        }
        public void AM_Animal(int IdAnimal, string TipoAnimal, byte FotoIngreso, byte FotoAdopcion, string NombreAnimal, int Edad, string Sexo, string Castracion, string ColorPelo, string Tamanio, int IdVacuna, string Desparacitacion, string Salud, DateTime FechaIngreso)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.Parameters.AddWithValue("@IdAnimal", IdAnimal);
                    command.Parameters.AddWithValue("@TipoAnimal", TipoAnimal);
                    command.Parameters.AddWithValue("@FotoIngreso", FotoIngreso);
                    command.Parameters.AddWithValue("@FotoAdopcion", FotoAdopcion);
                    command.Parameters.AddWithValue("@NombreAnimal", NombreAnimal);
                    command.Parameters.AddWithValue("@Edad", Edad);
                    command.Parameters.AddWithValue("@Sexo", Sexo);
                    command.Parameters.AddWithValue("@Castracion", Castracion);
                    command.Parameters.AddWithValue("@ColorPelo", ColorPelo);
                    command.Parameters.AddWithValue("@Tamanio", Tamanio);
                    command.Parameters.AddWithValue("@IdVacuna", IdVacuna);
                    command.Parameters.AddWithValue(" @Desparacitacion", Desparacitacion);
                    command.Parameters.AddWithValue("@Salud", Salud);
                    command.Parameters.AddWithValue("@FechaIngreso", FechaIngreso);
                    command.CommandText = "prcAltaAnimal";
                    command.CommandType = CommandType.StoredProcedure;
                    command.ExecuteNonQuery();
                }
            }
        }
        public void Baja_Animal(int IdAnimal, int IdUsuario, int IdMovimiento)
        {
            using (var connection = GetConnection())
            {
                DataTable tabla = new DataTable();
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.Parameters.AddWithValue("@IdAnimal", IdAnimal);
                    command.Parameters.AddWithValue("@Id_Usuario", IdUsuario);
                    command.Parameters.AddWithValue("@IdMovimiento", IdMovimiento);
                    command.CommandText = "prcBajaAnimal";
                    command.CommandType = CommandType.StoredProcedure;
                    command.ExecuteNonQuery();
                }
            }
        }
        //Confirmacion De aj sobre el tema del filtrado.
        public DataTable Filtrar_Animal(string busqueda)
        {
            using (var connection = GetConnection())
            {
                DataTable tabla = new DataTable();
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.Parameters.AddWithValue("@Busqueda", busqueda);
                    command.CommandText = "prcBuscarAnimal";
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
  
