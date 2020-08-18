using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Veterinaria
    {
        public int IdVeterinaria { get; set; }
        public string Nombre { get; set; }
        public string HorarioAtencion { get; set; }
        public string Localidad { get; set; }
        public string CodigoPostal { get; set; }
        public string Calle { get; set; }
        public int Altura { get; set; }
        public bool Internacion { get; set; }
        public bool Desabilitado { get; set; }
    }
}
