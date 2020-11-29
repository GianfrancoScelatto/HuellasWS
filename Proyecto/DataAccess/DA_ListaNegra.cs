using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess
{
    public class DA_ListaNegra : DA_Connection
    {
        public DataTable ListarListaNegra()
        {
            using (var connection = GetConnection())
            {
                DataTable tabla = new DataTable();
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "prc_ListarListaNegra";
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader leer = command.ExecuteReader();
                    tabla.Load(leer);
                    connection.Close();
                    return tabla;

                }
            }
        }
        public void AltaListaNegra(int IdListaNegra, string Motivo)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.Parameters.AddWithValue("@IdListaNegra", IdListaNegra);
                    command.Parameters.AddWithValue("@Motivo", Motivo);
                    command.CommandText = "prc_AltaListaNegra";
                    command.CommandType = CommandType.StoredProcedure;
                    command.ExecuteNonQuery();
                }
            }
        }
        public void BajaListaNegra(int IdUsuario)
        {
            using (var connection = GetConnection())
            {
                DataTable tabla = new DataTable();
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.Parameters.AddWithValue("@IdUsuario", IdUsuario);
                    command.CommandText = "prc_BajaListaNegra";
                    command.CommandType = CommandType.StoredProcedure;
                    command.ExecuteNonQuery();
                }
            }
        }

        public DataTable FiltrarListaNegra(string Busqueda)
        {
            using (var connection = GetConnection())
            {
                DataTable tabla = new DataTable();
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.Parameters.AddWithValue("@Busqueda", Busqueda);
                    command.CommandText = "prc_FiltrarListaNegra";
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
