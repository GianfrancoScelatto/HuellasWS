using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public static class E_Animal
    {
        public static int IdAnimal { get; set; }
        public static string NombreAnimal { get; set; }
        public static int IdEspecie { get; set; }
        public static DateTime FechaIngreso { get; set; }
        public static DateTime FechaNac { get; set; }
        public static string LugarRescate { get; set; }
        public static string FotoIngreso { get; set; }
        public static string FotoAdopcion { get; set; }
        public static int Sexo { get; set; }
        public static int Edad { get; set; }
        public static decimal Peso { get; set; }
        public static string ColorPelo { get; set; }
        public static bool Castracion { get; set; }
        public static DateTime? FechaCastracion { get; set; }
        public static string Comentario { get; set; }
        public static string Salud { get; set; }
        public static int Estado { get; set; }
        public static int Persona { get; set; }
        public static DateTime? FechaDefuncion { get; set; }
        public static bool Deshabilitado { get; set; }
        public static bool Editar { get; set; }
    }
}
