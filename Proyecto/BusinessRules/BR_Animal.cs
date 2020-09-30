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
        readonly DA_Animal ObjAnimal = new DA_Animal();

        public static DataTable ListarAnimal()
        {
            return new DA_Animal().ListarAnimal();
        }
        public void AltaAnimal( int TipoAnimal,string LugarRescate, byte FotoIngreso, byte FotoAdopcion, string NombreAnimal, int Edad, string Sexo, string Castracion, string ColorPelo, DateTime FechaIngreso)
        {
            ObjAnimal.AltaAnimal(  TipoAnimal, LugarRescate,FotoIngreso, FotoAdopcion, NombreAnimal, Edad, Sexo, Castracion, ColorPelo, FechaIngreso) ;
        }
        public void ModificarAnimal(int IdAnimal, int TipoAnimal, string LugarRescate,byte FotoIngreso, byte FotoAdopcion, string NombreAnimal, int Edad, string Sexo, string Castracion, string ColorPelo, int IdVacuna, string Desparacitacion, string Salud, DateTime FechaIngreso)
        {
            ObjAnimal.ModificarAnimal(IdAnimal,TipoAnimal, LugarRescate,FotoIngreso, FotoAdopcion, NombreAnimal, Edad, Sexo, Castracion, ColorPelo, IdVacuna, Desparacitacion, Salud, FechaIngreso);
        }
        public void BorrarAnimal(int IdAnimal, int IdUsuario, int IdMovimiento, string EstadoAnimal, string Descripcion)
        {
            ObjAnimal.BajaAnimal(IdAnimal, IdUsuario,  IdMovimiento,  EstadoAnimal, Descripcion);
        }
        public void FiltrarAnimal(string Busqueda)
        {
            ObjAnimal.FiltrarAnimal(Busqueda);
        }
    }
}
