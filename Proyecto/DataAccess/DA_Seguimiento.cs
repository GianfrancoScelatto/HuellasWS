using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess
{
    public class DA_Seguimiento : DA_Connection
    {
        public DataTable ListarSeguimiento(int IdAnimal)
        {
            using (var connection = GetConnection())
            {
                DataTable tabla = new DataTable();
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "prc_ListarSeguimiento";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IdAnimal", IdAnimal);
                    SqlDataReader reader = command.ExecuteReader();
                    tabla.Load(reader);
                    connection.Close();
                    return tabla;
                }
            }
        }

        public DataTable FiltrarSeguimiento(DateTime Fecha)
        {
            using (var connection = GetConnection())
            {
                DataTable tabla = new DataTable();
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "prc_FiltrarSeguimiento";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Fecha", Fecha);
                    SqlDataReader reader = command.ExecuteReader();
                    tabla.Load(reader);
                    connection.Close();
                    return tabla;
                }
            }
        }

        public void GuardarSeguimiento(int IdAnimal, string Comentario, DateTime Fecha, int IdUsuario)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "prc_GuardarSeguimiento";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IdAnimal", IdAnimal);
                    command.Parameters.AddWithValue("@Comentario", Comentario);
                    command.Parameters.AddWithValue("@FechaDetalle", Fecha);
                    command.Parameters.AddWithValue("@IdUsuario", IdUsuario);
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        public void BajaSeguimiento(int IdSeguimiento, int IdUsuario)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "prc_BajaSeguimiento";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IdSeguimiento", IdSeguimiento);
                    command.Parameters.AddWithValue("@IdUsuario", IdUsuario);
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }
    }
}
