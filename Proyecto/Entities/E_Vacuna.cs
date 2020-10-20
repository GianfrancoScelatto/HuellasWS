using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public static class E_Vacuna
    {
        public static int IdVacuna { get; set; }
        public static string Vacuna { get; set; }
        public static int IdMascota { get; set; }
        public static int FrecuenciaRevacunacion { get; set; }
        public static string Descripcion { get; set; }
        public static bool Deshabilitado { get; set; }
        public static bool Editar { get; set; }
    }
}
