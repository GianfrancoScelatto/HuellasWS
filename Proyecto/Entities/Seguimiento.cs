using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Seguimiento
    {
        public int IdSeguimiento { get; set; }
        public int IdMascota { get; set; }
        public string Comentario { get; set; }
        public DateTime Fecha { get; set; }
    }
}
