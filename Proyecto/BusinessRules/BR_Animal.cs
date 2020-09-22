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
        public void AM_Animal(int IdAnimal, string TipoAnimal, byte FotoIngreso, byte FotoAdopcion, string NombreAnimal, int Edad, string Sexo, string Castracion, string ColorPelo, string Tamanio, int IdVacuna, string Desparacitacion, string Salud, DateTime FechaIngreso)
        {
            ObjAnimal.AM_Animal( IdAnimal, TipoAnimal, FotoIngreso, FotoAdopcion, NombreAnimal, Edad, Sexo, Castracion, ColorPelo, Tamanio, IdVacuna, Desparacitacion, Salud, FechaIngreso) ;
        }
        public void Borrar_Animal(int IdAnimal, int IdUsuario, int IdMovimiento)
        {
            ObjAnimal.Baja_Animal(IdAnimal,IdUsuario,IdMovimiento);
        }
        public void Filtrar_Animal(string Busqueda)
        {
            ObjAnimal.Filtrar_Animal(Busqueda);
        }
    }
}
