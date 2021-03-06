﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DataAccess;

namespace BusinessRules
{
    public class BR_Animal
    {
        DA_Animal ObjAnimal = new DA_Animal();

        public DataTable ListarAnimal()
        {
            DataTable tabla = new DataTable();
            tabla = ObjAnimal.ListarAnimal();
            return tabla;
        }
        public void AltaAnimal(int IdUsuario, int IdPersona, int TipoAnimal, string LugarRescate, string FotoIngreso, string NombreAnimal, int Edad, int Sexo, bool Castracion, string ColorPelo, decimal Peso, string Comentario, int Estado, DateTime? FechaCastracion, DateTime FechaIngreso, DateTime FechaNacimiento, DateTime? FechaDefuncion)
        {
            ObjAnimal.AltaAnimal(IdUsuario, IdPersona, TipoAnimal, LugarRescate, FotoIngreso, NombreAnimal, Edad, Sexo, Castracion, ColorPelo, Peso, Comentario, Estado, FechaCastracion, FechaIngreso, FechaNacimiento, FechaDefuncion);
        }
        public void ModificarAnimal(int IdUsuario, int IdAnimal, int IdPersona, int TipoAnimal, string LugarRescate, string FotoIngreso, string FotoAdopcion, string NombreAnimal, int Edad, int Sexo, bool Castracion, string ColorPelo, decimal Peso, string Comentario, int Estado, DateTime? FechaCastracion, DateTime FechaIngreso, DateTime FechaNacimiento, DateTime? FechaDefuncion)
        {
            ObjAnimal.ModificarAnimal(IdUsuario, IdAnimal, IdPersona, TipoAnimal, LugarRescate, FotoIngreso, FotoAdopcion, NombreAnimal, Edad, Sexo, Castracion, ColorPelo, Peso, Comentario, Estado, FechaCastracion, FechaIngreso, FechaNacimiento, FechaDefuncion);
        }
        public void BajaAnimal(int IdAnimal, int IdUsuario)
        {
            ObjAnimal.BajaAnimal(IdAnimal, IdUsuario);
        }
        public DataTable FiltrarAnimal(string Busqueda, string tipoBusqueda)
        {
            DataTable tabla = new DataTable();
            tabla = ObjAnimal.FiltrarAnimal(Busqueda, tipoBusqueda);
            return tabla;
        }

        public DataTable ComboAnimal()
        {
            DataTable tabla = new DataTable();
            tabla = ObjAnimal.ComboAnimal();
            return tabla;
        }

        public DataTable ListarEstado()
        {
            DataTable tabla = new DataTable();
            tabla = ObjAnimal.ListarEstado();
            return tabla;
        }

        public DataTable ListarSexo()
        {
            DataTable tabla = new DataTable();
            tabla = ObjAnimal.ListarSexo();
            return tabla;
        }

        
    }
}
