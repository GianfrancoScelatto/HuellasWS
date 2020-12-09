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
        public void AltaContrato(int IdAnimal, string NuevoNombre, int IdUsuario, int IdPersona)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.Parameters.AddWithValue("@IdPersona", IdPersona);
                    command.Parameters.AddWithValue("@IdAnimal", IdAnimal);
                    command.Parameters.AddWithValue("@NuevoNombre", NuevoNombre);
                    command.Parameters.AddWithValue("@IdUsuario", IdUsuario);
                    command.CommandText = "prc_AltaContrato";
                    command.CommandType = CommandType.StoredProcedure;
                    command.ExecuteNonQuery();

                }
            }
        }
        public void BajaContrato(int IdContrato, int IdUsuario, int IdAnimal, int IdPersona, string NuevoNombre)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.Parameters.AddWithValue("@IdContrato", IdContrato);
                    command.Parameters.AddWithValue("@IdUsuario", IdUsuario);
                    command.Parameters.AddWithValue("@IdAnimal", IdAnimal);
                    command.Parameters.AddWithValue("@IdPersona", IdPersona);
                    command.Parameters.AddWithValue("@NuevoNombre", NuevoNombre);
                    command.CommandText = "prc_BajaContrato";
                    command.CommandType = CommandType.StoredProcedure;
                    command.ExecuteNonQuery();

                }

            }

        }
    }


}


