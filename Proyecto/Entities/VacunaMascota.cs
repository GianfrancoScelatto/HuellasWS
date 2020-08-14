using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class VacunaMascota
    {
        public int IdVM { get; set; }
        public int IdVacuna { get; set; }
        public int IdMascota { get; set; }
        public DateTime FechaRevacunacion { get; set; }
    }
}
