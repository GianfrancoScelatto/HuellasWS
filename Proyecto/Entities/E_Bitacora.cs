using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class E_Bitacora
    {
        public int IdHistorial { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaEjecucion { get; set; }
        public int IdMovimiento { get; set; }
        public int IdUsuario { get; set; }

    }
}
