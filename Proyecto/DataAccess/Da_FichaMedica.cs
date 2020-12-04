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
        public DataTable ListarFichaMedica(int IdAnimal)
        {
            using (var connection = GetConnection())
            {
                DataTable tabla = new DataTable();
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.Parameters.AddWithValue("@IdAnimal", IdAnimal);
                    command.CommandText = "prc_ListarFichaMedica1";
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = command.ExecuteReader();
                    tabla.Load(reader);
                    connection.Close();
                    return tabla;
                }
            }
        }
        public DataTable ListarFichaMedica2()
        {
            using (var connection = GetConnection())
            {
                DataTable tabla = new DataTable();
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "prc_ListarFichaMedica2";
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

        public void AltaFichaMedica(int IdAnimal, int IdEstablecimiento, DateTime Fecha, string Informe, string Tratamiento, decimal Costo, int IdUsuario)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "prc_AltaFichaMedica";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IdAnimal", IdAnimal);
                    command.Parameters.AddWithValue("@IdEstablecimiento", IdEstablecimiento);
                    command.Parameters.AddWithValue("@FechaAtencion", Fecha);
                    command.Parameters.AddWithValue("@Informe", Informe);
                    command.Parameters.AddWithValue("@Tratamiento", Tratamiento);
                    command.Parameters.AddWithValue("@Costo", Costo);
                    command.Parameters.AddWithValue("@IdUsuario", IdUsuario);
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        public void ModificarFichaMedica(int IdFichaMedica, int IdAnimal, int IdEstablecimiento, DateTime Fecha, string Informe, string Tratamiento, decimal Costo, int IdUsuario)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "prc_ModificarFichaMedica";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IdFichaMedica", IdFichaMedica);
                    command.Parameters.AddWithValue("@IdAnimal", IdAnimal);
                    command.Parameters.AddWithValue("@IdEstablecimiento", IdEstablecimiento);
                    command.Parameters.AddWithValue("@FechaAtencion", Fecha);
                    command.Parameters.AddWithValue("@Informe", Informe);
                    command.Parameters.AddWithValue("@Tratamiento", Tratamiento);
                    command.Parameters.AddWithValue("@Costo", Costo);
                    command.Parameters.AddWithValue("@IdUsuario", IdUsuario);
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        public void BajaFichaMedica(int IdFichaMedica, int IdUsuario)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "prc_BajaFichaMedica";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IdFichaMedica", IdFichaMedica);
                    command.Parameters.AddWithValue("@IdUsuario", IdUsuario);
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }
    }
}
