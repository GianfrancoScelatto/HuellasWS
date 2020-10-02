﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DataAccess
{
    public class DA_Transitante : DA_Connection
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
        public void AltaPersona(int idPersona,int IdTipoPersona, string Nombre, string Apellido, int Edad, int DNI,string Domicilio ,string Localidad, int Codigo_Postal, string Calles, int Altura,string Sexo, int Telefono, int Celular, string Email,string UsuarioFaceIg, bool ListaNegra, string Motivo,byte Deshabilitado)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.Parameters.AddWithValue("@idAdoptante", idPersona);
                    command.Parameters.AddWithValue("@TipoPersona", IdTipoPersona);
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
                    command.Parameters.AddWithValue("@UsuarioFaceIg",UsuarioFaceIg);
                    command.Parameters.AddWithValue("@ListaNegra",ListaNegra);
                    command.Parameters.AddWithValue("@Motivo", Motivo);
                    command.Parameters.AddWithValue("@Deshabilitado", Deshabilitado);
                    command.CommandText = "prc_AltaPersona";
                    //falta agregar los que van al historial, falta crear el de modificar. y la BR y dsp funcionalidad, a su vez tambien faltan los prc en Base Datos
                    command.CommandType = CommandType.StoredProcedure;
                    command.ExecuteNonQuery();
                }
            }
        }
        public void BajaPersona(int IdPersona, int IdUsuario, int IdMovimiento,bool Deshabilitado)
        {
            using (var connection = GetConnection())
            {
                DataTable tabla = new DataTable();
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.Parameters.AddWithValue("@IdPersona", IdPersona);
                    command.Parameters.AddWithValue("@IdUsuario", IdUsuario);
                    command.Parameters.AddWithValue("@IdMovimiento", IdMovimiento);
                    command.Parameters.AddWithValue("@Deshabilitado", Deshabilitado);
                    command.Parameters.AddWithValue("@Descripcion", IdPersona);
                    command.CommandText = "prc_BajaPersona";
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
