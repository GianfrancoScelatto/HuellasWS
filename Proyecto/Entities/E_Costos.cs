using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public static class E_Costos
    {
        public static int IdGasto { get; set; }
        public static DateTime FechaGasto { get; set; }
        public static int IdTipoGasto { get; set; }

        public static int IdEstablecimiento { get; set; }
        public static int IdAnimal { get; set; }
        public static decimal Monto { get; set; }
        public static string Detalle { get; set; }
        public static decimal Pagado { get; set; }
        public static bool Deshabilitado { get; set; }
        public static bool Editar { get; set; }
    }
}
