using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public static class E_Contrato
    {
        public static int IdContrato { get; set; }
        public static int IdAdoptante { get; set; }
        public static int IdAnimal{ get; set; }
        public static string NuevoNombre { get; set; }
        public static DateTime FechaAdopcion { get; set; }
        public static bool Deshabilitao { get; set; }
    }
}
