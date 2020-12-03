using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Entities;

namespace DataAccess
{
    public class DA_Vacunas : DA_Connection
    {
        public DataTable ListarVacunas()
        {
            using (var connection = GetConnection())
            {
                DataTable tabla = new DataTable();
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "prc_ListarVacuna";
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader leer = command.ExecuteReader();
                    tabla.Load(leer);
                    connection.Close();
                    return tabla;
                }
            }
        }

        public void AltaVacuna(string Vacuna, int IdEspecie, int FrecuenciaVacunacion,int IdTiempo ,string Descripcion, int IdUsuario)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.Parameters.AddWithValue("@Vacuna", Vacuna);
                    command.Parameters.AddWithValue("@IdEspecie", IdEspecie);
                    command.Parameters.AddWithValue("@Frecuencia", FrecuenciaVacunacion);
                    command.Parameters.AddWithValue("@IdTiempo", IdTiempo);
                    command.Parameters.AddWithValue("@Descripcion", Descripcion);
                    command.Parameters.AddWithValue("@IdUsuario", IdUsuario);
                    command.CommandText = "prc_AltaVacuna";
                    command.CommandType = CommandType.StoredProcedure;
                    command.ExecuteNonQuery();
                }
            }
        }

        public void AltaVacunaAnimal(int IdVacuna, int IdAnimal, DateTime FechaAplicacion, DateTime FechaReaplicacion, int IdUsuario)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.Parameters.AddWithValue("@IdVacuna", IdVacuna);
                    command.Parameters.AddWithValue("@IdAnimal", IdAnimal);
                    command.Parameters.AddWithValue("@FechaAplicacion", FechaAplicacion);
                    command.Parameters.AddWithValue("@FechaReaplicacion", FechaReaplicacion);
                    command.Parameters.AddWithValue("@IdUsuario", IdUsuario);
                    command.CommandText = "prc_AltaVacunaAnimal";
                    command.CommandType = CommandType.StoredProcedure;
                    command.ExecuteNonQuery();
                }
            }
        }

        public void ModificarVacuna(int idVacuna, string Vacuna, int idEspecie, int FrecuenciaVacunacion,int IdTiempo, string Descripcion, int idUsuario)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.Parameters.AddWithValue("@IdVacuna", idVacuna);
                    command.Parameters.AddWithValue("@Vacuna", Vacuna);
                    command.Parameters.AddWithValue("@IdEspecie", idEspecie);
                    command.Parameters.AddWithValue("@Frecuencia", FrecuenciaVacunacion);
                    command.Parameters.AddWithValue("@IdTiempo", IdTiempo);
                    command.Parameters.AddWithValue("@Descripcion", Descripcion);
                    command.Parameters.AddWithValue("@IdUsuario", idUsuario);
                    command.CommandText = "prc_ModificarVacuna";
                    command.CommandType = CommandType.StoredProcedure;
                    command.ExecuteNonQuery();

                }
            }

        }

        public void BajaVacuna(int IdVacuna, int IdUsuario)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.Parameters.AddWithValue("@IdVacuna", IdVacuna);
                    command.Parameters.AddWithValue("@IdUsuario", IdUsuario);
                    command.CommandText = "prc_BajaVacuna";
                    command.CommandType = CommandType.StoredProcedure;
                    command.ExecuteNonQuery();
                }
                                
            }
        }

        public void BajaVacunaAnimal(int IdVacunaAnimal, int IdUsuario)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.Parameters.AddWithValue("@IdVacunaAnimal", IdVacunaAnimal);
                    command.Parameters.AddWithValue("@IdUsuario", IdUsuario);
                    command.CommandText = "prc_BajaVacunaAnimal";
                    command.CommandType = CommandType.StoredProcedure;
                    command.ExecuteNonQuery();
                }
            }
        }

        public DataTable BuscarVacunas(string Busqueda)
        {
            using (var connection = GetConnection())
            {
                DataTable tabla = new DataTable();
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.Parameters.AddWithValue("@Busqueda", Busqueda);
                    command.CommandText = "prc_FiltrarVacuna";
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = command.ExecuteReader();
                    tabla.Load(reader);
                    connection.Close();
                    return tabla;
                }
            }
        
        }
        public DataTable ListarTiempo()
        {
            using (var connection = GetConnection())
            {
                DataTable tabla = new DataTable();
                SqlDataAdapter sdA = new SqlDataAdapter("prc_ListarComboTiempo", connection);
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
        public DataTable ListarEspecie()
        {
            using (var connection = GetConnection())
            {
                DataTable tabla = new DataTable();
                SqlDataAdapter sdA = new SqlDataAdapter("prc_ListarComboEspecie", connection);
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

        public DataTable ListarComboVacunas(int IdEspecie)
        {
            using (var connection = GetConnection())
            {
                DataTable tabla = new DataTable();
                SqlDataAdapter sdA = new SqlDataAdapter("prc_ListarComboVacunas", connection);
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    sdA.SelectCommand.Parameters.AddWithValue("@Especie", IdEspecie);
                    sdA.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sdA.Fill(tabla);
                    connection.Close();
                    return tabla;
                }
            }
        }

        public int TraerRevacunacion(int IdVacuna)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.Parameters.AddWithValue("@IdVacuna", IdVacuna);
                    command.CommandText = "prc_TraerRevacunacion";
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        E_Vacuna.FrecuenciaRevacunacion = reader.GetInt32(0);
                    }
                    return E_Vacuna.FrecuenciaRevacunacion;
                }
            }
        }

        public DataTable ListarVacunas(int IdAnimal)
        {
            using (var connection = GetConnection())
            {
                DataTable tabla = new DataTable();
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.Parameters.AddWithValue("@IdAnimal", IdAnimal);
                    command.CommandText = "prc_ListarVacunasAnimal";
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = command.ExecuteReader();
                    tabla.Load(reader);
                    connection.Close();
                    return tabla;
                }
            }
        }

        public DataTable FiltrarVacunas(string Vacuna)
        {
            using (var connection = GetConnection())
            {
                DataTable tabla = new DataTable();
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.Parameters.AddWithValue("@Vacuna", Vacuna);
                    command.CommandText = "prc_FiltrarVacunasAnimal";
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
