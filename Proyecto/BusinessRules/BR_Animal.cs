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
        public void A_Animal( string TipoAnimal, byte FotoIngreso, byte FotoAdopcion, string NombreAnimal, int Edad, string Sexo, string Castracion, string ColorPelo, string Tamanio, DateTime FechaIngreso)
        {
            ObjAnimal.A_Animal(  TipoAnimal, FotoIngreso, FotoAdopcion, NombreAnimal, Edad, Sexo, Castracion, ColorPelo, Tamanio, FechaIngreso) ;
        }
        public void M_Animal(int IdAnimal, string TipoAnimal, byte FotoIngreso, byte FotoAdopcion, string NombreAnimal, int Edad, string Sexo, string Castracion, string ColorPelo, string Tamanio, int IdVacuna, string Desparacitacion, string Salud, DateTime FechaIngreso)
        {
            ObjAnimal.M_Animal(IdAnimal, TipoAnimal, FotoIngreso, FotoAdopcion, NombreAnimal, Edad, Sexo, Castracion, ColorPelo, Tamanio, IdVacuna, Desparacitacion, Salud, FechaIngreso);
        }
        public void Borrar_Animal(int IdAnimal, int IdUsuario, int IdMovimiento, string EstadoAnimal, string Descripcion)
        {
            ObjAnimal.B_Animal(IdAnimal, IdUsuario,  IdMovimiento,  EstadoAnimal, Descripcion);
        }
        public void Filtrar_Animal(string Busqueda)
        {
            ObjAnimal.Filtrar_Animal(Busqueda);
        }
    }
}
