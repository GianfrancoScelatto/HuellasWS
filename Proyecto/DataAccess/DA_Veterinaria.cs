using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;          
namespace DataAccess
{
    class DA_Veterinaria : DA_Connection
    {
        public DataTable ListarVeterinaria()
        {
            using (var conexion = GetConnection())
            {
                DataTable tabla = new DataTable();
                conexion.Open();
                using (var Comando = new SqlCommand())
                {
                    Comando.Connection = conexion;
                    Comando.CommandText = "SELECT IdVeterinaria, Nombre, HorarioAtencion, Localidad, CodigoPostal, Calle, Altura, Internacion FROM Veterinaria ";
                    Comando.CommandType = CommandType.Text;
                    SqlDataReader leer = Comando.ExecuteReader();
                    tabla.Load(leer);
                    conexion.Close();
                    return tabla;
                }
            }
        }
    }
}
