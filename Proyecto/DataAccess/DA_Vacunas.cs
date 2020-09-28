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

        //Alta  de vacunas

        //VER SI IDVACUNA VA COMO PARAMETRO YA QUE ESO LO MANEJA LA BD PREGUNTAR
        public void Alta_Vacunas(string Vacuna, int IdEspecie, string FrecuenciaVacunacion, string Descripcion)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
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

        public void Modificar_Vacuna(int IdVacuna, string Vacuna, int IdEspecie, string FrecuenciaVacunacion, string Descripcion)
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

        //Procedure para Baja logica de Vacunas
        public void BajaVacuna(int IdVacuna, string Vacuna, int IdEspecie, string FrecuenciaVacunacion, string Descripcion)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.Parameters.AddWithValue("@IdVacuna", Vacuna);
                    command.Parameters.AddWithValue("@Vacuna", Vacuna);
                    command.Parameters.AddWithValue("@IdEspecie", IdEspecie);
                    command.Parameters.AddWithValue("@FrecuenciaVacunacion", FrecuenciaVacunacion);
                    command.Parameters.AddWithValue("@Descripcion", Descripcion);
                    command.CommandText = "prc_";
                    command.CommandType = CommandType.StoredProcedure;
                    command.ExecuteNonQuery();

                }
                                
            }

        }

        private DataTable ListarVacunas(string Busqueda)
        {
            using (var connection = GetConnection())
            {
                DataTable tabla = new DataTable();
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.Parameters.AddWithValue("@Busqueda", Busqueda);
                    command.CommandText = "prc_";
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
