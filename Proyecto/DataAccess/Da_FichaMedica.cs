﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess
{
    public class DA_FichaMedica : DA_Connection
    {
        public DataTable ListarFichaMedica()
        {
            using (var connection = GetConnection())
            {
                DataTable tabla = new DataTable();
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "prc_ListarFichaMedica";
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = command.ExecuteReader();
                    tabla.Load(reader);
                    connection.Close();
                    return tabla;
                }
            }
        }

        public DataTable FiltrarFichaMedica(string Nombre, DateTime Fecha)
        {
            using (var connection = GetConnection())
            {
                DataTable tabla = new DataTable();
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "prc_FiltrarFichaMedica";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@NombreAnimal", Nombre);
                    command.Parameters.AddWithValue("@Fecha", Fecha);
                    SqlDataReader reader = command.ExecuteReader();
                    tabla.Load(reader);
                    connection.Close();
                    return tabla;
                }
            }
        }
    }
}
