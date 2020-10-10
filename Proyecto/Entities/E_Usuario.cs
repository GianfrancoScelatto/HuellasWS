using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public static class E_Usuario
    {
        public static int IdUsuario { get; set; }
        public static string NombreUsuario { get; set; }
        public static string Nombre { get; set; }
        public static string Apellido { get; set; }
        public static string Dni { get; set; }
        public static int Telefono { get; set; }
        public static int IdPregunta { get; set; }
        public static string RespuestaSeguridad { get; set; }
        public static string Contraseña { get; set; }
        public static int IdRol { get; set; }
        public static string Rol { get; set; }
    }
}
