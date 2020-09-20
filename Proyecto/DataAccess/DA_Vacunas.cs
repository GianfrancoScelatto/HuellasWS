using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess
{
    public class DA_Vacunas : DA_Connection
    {
        public DataTable ListarVacunas()
        {
            //procedure para listar vacunas
            using (var connection = GetConnection())
            {
                DataTable tabla = new DataTable();
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "prc_Vacunas";
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader leer = command.ExecuteReader();
                    tabla.Load(leer);
                    connection.Close();
                    return tabla;
                }
            }


        }

        //Alta y modificacion de vacunas
        public void AM_Vacunas(int IdVacuna, string Vacuna, int IdEspecie, string FrecuenciaVacunacion, string Descripcion)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.Parameters.AddWithValue("@IdVacuna", IdVacuna);
                    command.Parameters.AddWithValue("@Vacuna", Vacuna);
                    command.Parameters.AddWithValue("@IdEspecie", IdEspecie);
                    command.Parameters.AddWithValue("@FrecuenciaVacunacion", FrecuenciaVacunacion);
                    command.Parameters.AddWithValue("@Descripcion", Descripcion);
                    command.CommandText = "prc_Vacunas";
                    command.CommandType = CommandType.StoredProcedure;
                    command.ExecuteNonQuery();
                        
                }
            }

        }

    }
}
