using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
   public  class E_ListaNegra
    {
        public  string Nombre { get; set; }
        public  string Apellido { get; set; }
        public  int TelefonoFijo { get; set; }
        public int DNI { get; set; }
        public int Celular { get; set; }
        public string CorreoElectronico { get; set; }
        public string Direccion { get; set; }
        public string Localidad { get; set;}
        public string Provincia { get; set; }
        public string Motivo { get; set; }
        public static bool Editar { get; set; }
    }
}
