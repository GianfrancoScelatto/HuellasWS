using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public static class E_FichaMedica
    {
        public static int IdFichaMedica { get; set; }
        public static DateTime Fecha { get; set; }
        public static string Informe { get; set; }
        public static string Tratamiento { get; set; }
        public static int IdVeterinaria { get; set; }
        public static int IdMascota { get; set; }
        public static decimal Costo { get; set; }
        public static bool Editar { get; set; }
    }
}
