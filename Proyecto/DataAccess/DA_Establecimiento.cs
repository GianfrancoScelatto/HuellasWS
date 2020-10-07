using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DataAccess
{
    public class DA_Establecimiento : DA_Connection
    {
		
		public DataTable ListarEstablecimiento()
		{
			using (var connection = GetConnection())

			{
				DataTable tabla = new DataTable();
				connection.Open();
				using (var command = new SqlCommand())
				{
					command.Connection = connection;
					command.CommandText = "prc_ListarEstablecimiento";
					command.CommandType = CommandType.StoredProcedure;
					SqlDataReader leer = command.ExecuteReader();
					tabla.Load(leer);
					connection.Close();
					return tabla;
				}
			}
		}

		//Alta de Establecimiento

		public void AltaEstablecimiento(int TipoEstablecimiento, string Nombre, string HorarioAtencion, string Localidad, string CodigoPostal, string Calle, int Altura, bool Internacion)
		{
			using (var connection = GetConnection())
			{
				connection.Open();
				using (var command = new SqlCommand())
				{
					command.Connection = connection;
					command.Parameters.AddWithValue("@TipoEstablecimiento", TipoEstablecimiento);
					command.Parameters.AddWithValue("@Nombre", Nombre);
					command.Parameters.AddWithValue("@HorarioAtencion", HorarioAtencion);
					command.Parameters.AddWithValue("@Localidad", Localidad);
					command.Parameters.AddWithValue("@CodigoPostar", CodigoPostal);
					command.Parameters.AddWithValue("@Calle", Calle);
					command.Parameters.AddWithValue("@Altura", Altura);
					command.Parameters.AddWithValue("@Internacion", Internacion);
					command.CommandText = "prc_AltaEstablecimiento";
					command.CommandType = CommandType.StoredProcedure;
					command.ExecuteNonQuery();
				}
			}
		}


		//Modificacion 
		public void  ModificarEstablecimiento(int IdEstablecimiento, int TipoEstablecimiento, string Nombre, string HorarioAtencion, string Localidad, string CodigoPostal, string Calle, int Altura, bool Internacion)
		{
			using (var connection = GetConnection())
			{
				connection.Open();
				using (var command = new SqlCommand())
				{
					command.Connection = connection;
					command.Parameters.AddWithValue("@IdEstablecimiento", IdEstablecimiento);
					command.Parameters.AddWithValue("@TipoEstablecimiento", TipoEstablecimiento);
					command.Parameters.AddWithValue("@Nombre", Nombre);
					command.Parameters.AddWithValue("@HorarioAtencion", HorarioAtencion);
					command.Parameters.AddWithValue("@Localidad", Localidad);
					command.Parameters.AddWithValue("@CodigoPostar", CodigoPostal);
					command.Parameters.AddWithValue("@Calle", Calle);
					command.Parameters.AddWithValue("@Altura", Altura);
					command.Parameters.AddWithValue("@Internacion", Internacion);
					command.CommandText = "prc_BajaEstablecimiento";
					command.CommandType = CommandType.StoredProcedure;
				}
			}
		}


		//Baja Establecimiento
		public void BajaVacuna(int IdVacuna, bool Deshabilitado)
		{
			using (var connection = GetConnection())
			{
				connection.Open();
				using (var command = new SqlCommand())
				{
					command.Connection = connection;
					command.Parameters.AddWithValue("@IdEstablecimiento", IdVacuna);
					command.Parameters.AddWithValue("@Deshabilitado", Deshabilitado);
					command.CommandText = "prc_BajaEstablecimiento";
					command.CommandType = CommandType.StoredProcedure;
					command.ExecuteNonQuery();
				}

			}

		}


		private DataTable BuscarEstablecimiento(string Busqueda)
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


		//Para listar los datos de Especie en el combobox de Establecimiento
		//public DataTable ListarEstablecimiento()
		//{
		//    using (var connection = GetConnection())
		//    {
		//        DataTable tabla = new DataTable();
		//        connection.Open();
		//        using (var command = new SqlCommand())
		//        {
		//            command.Connection = connection;
		//            command.CommandText = "prc_ListarTipoEstablecimiento";
		//            command.CommandType = CommandType.StoredProcedure;
		//            SqlDataAdapter sdA = new SqlDataAdapter();
		//            sdA.Fill(tabla);
		//            connection.Close();
		//            return tabla;
		//        }
		//    }
		//}





	}
}
