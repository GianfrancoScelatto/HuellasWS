using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Entities;

namespace DataAccess
{
    public class DA_Login : DA_Connection
    {
        public bool InicioSesion(string Username, string pw)
        {
            E_Usuario user = new E_Usuario();
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "prc_InicioSesion";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@NombreUsuario", Username);
                    command.Parameters.AddWithValue("@Contraseña", pw);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            user.NombreUsuario = reader.GetString(0);
                            user.Contraseña = reader.GetString(1);
                        }
                        return true;
                    }
                    else
                        return false;
                }
            }
        }

    }
}
