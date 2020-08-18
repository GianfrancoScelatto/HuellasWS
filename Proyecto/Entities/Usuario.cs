using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class User
    {
        public int IdUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Dni { get; set; }
        public int Telefono { get; set; }
        public int IdPregunta { get; set; }
        public string RespuestaSeguridad { get; set; }
        public string Contraseña { get; set; }
        public int Id_Rol { get; set; }
    }
}
