using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess
{
    public class DA_Costo : DA_Connection
    {
        public DataTable ListarCosto()
        {
            using (var connection = GetConnection())
            {
                DataTable tabla = new DataTable();
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "prc_ListarCosto";
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader leer = command.ExecuteReader();
                    tabla.Load(leer);
                    connection.Close();
                    return tabla;
                }
            }
        }

        public void AltaGasto (DateTime FechaGasto, int IdTipoGasto, int IdAnimal, int IdEstablecimiento, decimal Monto, string Detalle, decimal Pagado, int IdUsuario)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.Parameters.AddWithValue("FechaGasto", FechaGasto);
                    command.Parameters.AddWithValue("IdTipoGasto", IdTipoGasto);
                    command.Parameters.AddWithValue("IdAnimal", IdAnimal);
                    command.Parameters.AddWithValue("IdEstablecimiento", IdEstablecimiento);
                    command.Parameters.AddWithValue("Monto", Monto);
                    command.Parameters.AddWithValue("Detalle", Detalle);
                    command.Parameters.AddWithValue("Pagado", Pagado);
                    command.Parameters.AddWithValue("IdUsuario", IdUsuario);
                    command.CommandText = "prc_AltaGasto";
                    command.CommandType = CommandType.StoredProcedure;
                    command.ExecuteNonQuery();
                }
            }
        }

        public void ModificarGasto (int IdGasto, DateTime FechaGasto, int IdTipoGasto, int IdAnimal, int IdEstablecimiento, decimal Monto, string Detalle, decimal Pagado, int IdUsuario)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.Parameters.AddWithValue("IdGasto", IdGasto);
                    command.Parameters.AddWithValue("FechaGasto", FechaGasto);
                    command.Parameters.AddWithValue("IdTipoGasto", IdTipoGasto);
                    command.Parameters.AddWithValue("IdAnimal", IdAnimal);
                    command.Parameters.AddWithValue("IdEstablecimiento", IdEstablecimiento);
                    command.Parameters.AddWithValue("Monto", Monto);
                    command.Parameters.AddWithValue("Detalle", Detalle);
                    command.Parameters.AddWithValue("Pagado", Pagado);
                    command.Parameters.AddWithValue("IdUsuario", IdUsuario);
                    command.CommandText = "prc_ModificarGasto";
                    command.CommandType = CommandType.StoredProcedure;
                    command.ExecuteNonQuery();
                }
            }
        }

        public void BajaGasto(int IdGasto, int IdUsuario)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.Parameters.AddWithValue("@IdGasto", IdGasto);
                    command.Parameters.AddWithValue("@IdUsuario", IdUsuario);
                    command.CommandText = "prc_BajaGasto";
                    command.CommandType = CommandType.StoredProcedure;
                    command.ExecuteNonQuery();

                }

            }

        }

        public DataTable ListarTipoGasto()
        {
            using (var connection = GetConnection())
            {
                DataTable tabla = new DataTable();
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "prc_ComboTipoGasto";
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader leer = command.ExecuteReader();
                    tabla.Load(leer);
                    connection.Close();
                    return tabla;
                }
            }
        }

        public DataTable ListarTipoAnimal()
        {
            using (var connection = GetConnection())
            {
                DataTable tabla = new DataTable();
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "prc_ComboTipoAnimal";
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader leer = command.ExecuteReader();
                    tabla.Load(leer);
                    connection.Close();
                    return tabla;
                }
            }
        }

        public DataTable ListarTipoEstablecimiento()
        {
            using (var connection = GetConnection())
            {
                DataTable tabla = new DataTable();
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "prc_ComboTipoEstablecimiento";
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader leer = command.ExecuteReader();
                    tabla.Load(leer);
                    connection.Close();
                    return tabla;
                }
            }
        }
    }
}
