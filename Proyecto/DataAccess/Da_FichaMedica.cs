using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess
{
    public class DA_FichaMedica : DA_Connection
    {
        public DataTable ListarFichaMedica()
        {
            using (var connection = GetConnection())
            {
                DataTable tabla = new DataTable();
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "prc_ListarFichaMedica";
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = command.ExecuteReader();
                    tabla.Load(reader);
                    connection.Close();
                    return tabla;
                }
            }
        }

        public DataTable FiltrarFichaMedica(string Nombre, DateTime Fecha)
        {
            using (var connection = GetConnection())
            {
                DataTable tabla = new DataTable();
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "prc_FiltrarFichaMedica";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@NombreAnimal", Nombre);
                    command.Parameters.AddWithValue("@Fecha", Fecha);
                    SqlDataReader reader = command.ExecuteReader();
                    tabla.Load(reader);
                    connection.Close();
                    return tabla;
                }
            }
        }

        public void AltaFichaMedica(int idAnimal, int idVeterinaria, DateTime Fecha, string Informe, string Tratamiento, decimal Costo)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "prc_AltaFichaMedica";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IdAnimal", idAnimal);
                    command.Parameters.AddWithValue("@IdVeterinaria", idVeterinaria);
                    command.Parameters.AddWithValue("@Fecha", Fecha);
                    command.Parameters.AddWithValue("@Informe", Informe);
                    command.Parameters.AddWithValue("@Tratamiento", Tratamiento);
                    command.Parameters.AddWithValue("@Costo", Costo);
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        public void ModificarFichaMedica(int idAnimal, int idVeterinaria, DateTime Fecha, string Informe, string Tratamiento, decimal Costo)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "prc_ModificarFichaMedica";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IdAnimal", idAnimal);
                    command.Parameters.AddWithValue("@IdVeterinaria", idVeterinaria);
                    command.Parameters.AddWithValue("@Fecha", Fecha);
                    command.Parameters.AddWithValue("@Informe", Informe);
                    command.Parameters.AddWithValue("@Tratamiento", Tratamiento);
                    command.Parameters.AddWithValue("@Costo", Costo);
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        public void BajaFichaMedica(int idFichaMedica, int idRol)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "prc_BajaFichaMedica";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IdFichaMedica", idFichaMedica);
                    command.Parameters.AddWithValue("@IdRol", idRol);
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }
    }
}
