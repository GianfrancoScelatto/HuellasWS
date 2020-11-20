using System;
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
        public void AltaAnimal(int idUsuario, int TipoAnimal, string LugarRescate, byte FotoIngreso, byte FotoAdopcion, string NombreAnimal, int Edad, string Sexo, bool Castracion, string ColorPelo, string Peso, string Comentario, int Estado, DateTime FechaCastracion, DateTime FechaIngreso, DateTime FechaNacimiento)
        {
            ObjAnimal.AltaAnimal(idUsuario, TipoAnimal, LugarRescate, FotoIngreso, FotoAdopcion, NombreAnimal, Edad, Sexo, Castracion, ColorPelo, Peso, Comentario, Estado, FechaCastracion,FechaIngreso, FechaNacimiento);
        }
        public void ModificarAnimal(int IdAnimal, int TipoAnimal, string LugarRescate, byte FotoIngreso, byte FotoAdopcion, string NombreAnimal, int Edad, string Sexo, bool Castracion, string ColorPelo, string Peso, string Comentario, int Estado, DateTime FechaIngreso)
        {
            ObjAnimal.ModificarAnimal(IdAnimal, TipoAnimal, LugarRescate, FotoIngreso, FotoAdopcion, NombreAnimal, Edad, Sexo, Castracion, ColorPelo, Peso, Comentario, Estado, FechaIngreso);
        }
        public void BorrarAnimal(int IdAnimal, int IdUsuario, int IdMovimiento, int EstadoAnimal, string Descripcion, bool Deshabilitado)
        {
            ObjAnimal.BajaAnimal(IdAnimal, IdUsuario, IdMovimiento, EstadoAnimal, Descripcion, Deshabilitado);
        }
        public DataTable FiltrarAnimal(string Busqueda)
        {
            DataTable tabla = new DataTable();
            tabla = ObjAnimal.FiltrarAnimal(Busqueda);
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

        public void ModificarAnimal(int v1, int v2, string text1, byte v3, byte v4, string text2, int v5, string selectedText, bool @checked, string text3, object p, string comment, int v6, DateTime date)
        {
            throw new NotImplementedException();
        }
    }
}
