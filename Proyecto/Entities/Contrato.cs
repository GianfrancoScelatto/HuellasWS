using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Contrato
    {
        public int IdContrato { get; set; }
        public int IdAdoptante { get; set; }
        public int IdMascota { get; set; }
        public int Nuevonombre { get; set; }
        public DateTime FechaAdopcion { get; set; }
    }
}
