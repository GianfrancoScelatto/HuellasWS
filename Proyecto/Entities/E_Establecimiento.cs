using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
   public class E_Establecimiento
    {
        public static int IdEstablecimiento { get; set; }
        public static int IdTipoEstablecimiento { get; set; }
        public static string Nombre { get; set; }
        public static string HorarioAtencion { get; set; }
        public static string Localidad { get; set; }
        public static string CodigoPostal { get; set; }
        public static string Calle { get; set; }
        public static int Altura { get; set; }
        public static bool Internacion { get; set; }
        public static bool Deshabilitado { get; set; }
        public static bool Editar { get; set; }
    }
}
