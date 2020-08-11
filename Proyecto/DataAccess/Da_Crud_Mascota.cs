using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace DataAccess
{
    public class Da_Crud_Mascota : Da_Connection
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
                    command.CommandText = "prc_Historial";
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader leer = command.ExecuteReader();
                    tabla.Load(leer);
                    connection.Close();
                    return tabla;
                }
            }
        }
        public void AM_Animal(int IdMascota, string TipoMascota, byte FotoIngreso, byte FotoAdopcion, string NombreAnimal, int Edad, string Sexo, string Castracion, string ColorPelo, string Tamanio, int IdVacuna, string Desparacitacion, string Salud, DateTime FechaIngreso)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.Parameters.AddWithValue("@idMascota", IdMascota);
                    command.Parameters.AddWithValue("@TipoMascota", TipoMascota);
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
                    command.CommandText = "prc_ABM_Animal";
                    command.CommandType = CommandType.StoredProcedure;
                    command.ExecuteNonQuery();
                }
            }
        }
        public void BajaAnimal(int IdAnimal, int IdUsuario, int IdMovimiento)
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
                    command.CommandText = "prc_ABM_Animal";
                    command.CommandType = CommandType.StoredProcedure;
                    command.ExecuteNonQuery();
                }
            }
        }

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
                    command.CommandText = "prc_Busqueda_Animal";
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
