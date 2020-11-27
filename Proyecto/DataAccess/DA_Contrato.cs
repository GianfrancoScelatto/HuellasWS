using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;


namespace DataAccess
{
    public class DA_Contrato : DA_Connection
    {
        public DataTable ListarContrato()
        {
            using (var connection = GetConnection())
            {
                DataTable tabla = new DataTable();
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "prc_ListarContrato";
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader leer = command.ExecuteReader();
                    tabla.Load(leer);
                    connection.Close();
                    return tabla;
                }
            }
        }
        public void AltaContrato(int IdAdoptante, int IdAnimal, string NuevoNombre, DateTime FechaAdopcion, int IdUsuario)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.Parameters.AddWithValue("@IdAdoptante", IdAdoptante);
                    command.Parameters.AddWithValue("@IdAnimal", IdAnimal);
                    command.Parameters.AddWithValue("@NuevoNombre", NuevoNombre);
                    command.Parameters.AddWithValue("@FechaAdopcion", FechaAdopcion);
                    command.Parameters.AddWithValue("@IdUsuario", IdUsuario);
                    command.CommandText = "prc_AltaContrato";
                    command.CommandType = CommandType.StoredProcedure;
                    command.ExecuteNonQuery();

                }
            }
        }
        public void BajaContrato(int IdContrato, int IdUsuario)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.Parameters.AddWithValue("@IdContrato", IdContrato);
                    command.Parameters.AddWithValue("@IdUsuario", IdUsuario);
                    command.CommandText = "prc_BajaContrato";
                    command.CommandType = CommandType.StoredProcedure;
                    command.ExecuteNonQuery();

                }

            }

        }
    }


}


