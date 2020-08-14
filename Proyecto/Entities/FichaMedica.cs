using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class FichaMedica
    {
        public int IdFichaMedica { get; set; }
        public DateTime Fecha { get; set; }
        public string Informe { get; set; }
        public string Tratamiento { get; set;}
        public int IdVeterinaria { get; set; }
        public int IdMascota { get; set; }
        public decimal Costo {get; set;}
    }
}
