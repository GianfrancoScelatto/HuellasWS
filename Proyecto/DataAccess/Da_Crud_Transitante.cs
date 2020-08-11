using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace DataAccess
{
    public class Da_Crud_Transitante : Da_Connection
    {
        public DataTable ListarAnimal()
        {
            using (var connection = GetConnection())
            {
                DataTable tabla = new DataTable();
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "prc_Historial";
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader leer = command.ExecuteReader();
                    tabla.Load(leer);
                    connection.Close();
                    return tabla;
                }
            }
        }
        public void AM_Transitante(int idTransitante, string Nombre, string Apellido, int Edad, int DNI, string Localidad, string Domicilio, int Codigo_Postal, string Calles, int Altura, bool Sexo, int Telefono, int Celular, string Email, byte Deshabilitado)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.Parameters.AddWithValue("@idAdoptante", idTransitante);
                    command.Parameters.AddWithValue("@Nombre", Nombre);
                    command.Parameters.AddWithValue("@Apellido", Apellido);
                    command.Parameters.AddWithValue("@Edad", Edad);
                    command.Parameters.AddWithValue("@DNI", DNI);
                    command.Parameters.AddWithValue("@Domicilio", Domicilio);
                    command.Parameters.AddWithValue("@Localidad", Localidad);
                    command.Parameters.AddWithValue("@Codigo_Postal", Codigo_Postal);
                    command.Parameters.AddWithValue("@Calles", Calles);
                    command.Parameters.AddWithValue("@Altura", Altura);
                    command.Parameters.AddWithValue("@Sexo", Sexo);
                    command.Parameters.AddWithValue(" @Telefono", Telefono);
                    command.Parameters.AddWithValue("@Celular", Celular);
                    command.Parameters.AddWithValue("@Email", Email);
                    command.Parameters.AddWithValue("@Deshabilitado", Deshabilitado);
                    command.CommandText = "prc_ABM_Adoptante";
                    command.CommandType = CommandType.StoredProcedure;
                    command.ExecuteNonQuery();
                }
            }
        }
        public void BajaTransitante(int IdTransitante, int IdUsuario, int IdMovimiento)
        {
            using (var connection = GetConnection())
            {
                DataTable tabla = new DataTable();
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.Parameters.AddWithValue("@IdTransitante", IdTransitante);
                    command.Parameters.AddWithValue("@Id_Usuario", IdUsuario);
                    command.Parameters.AddWithValue("@IdMovimiento", IdMovimiento);
                    command.CommandText = "prc_ABM_Transitante";
                    command.CommandType = CommandType.StoredProcedure;
                    command.ExecuteNonQuery();
                }
            }
        }

        public DataTable FiltrarTransitante(string busqueda)
        {
            using (var connection = GetConnection())
            {
                DataTable tabla = new DataTable();
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.Parameters.AddWithValue("@Busqueda", busqueda);
                    command.CommandText = "prc_Busqueda_Transitante";
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
