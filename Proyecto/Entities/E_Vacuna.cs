using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class E_Vacuna
    {
        public int IdVacuna { get; set; }
        public string Vacuna { get; set; }
        public int IdMascota { get; set; }
        public int FrecuenciaRevacunacion { get; set; }
        public string Descripcion { get; set; }
        public bool Deshabilitado { get; set; }
        
    }
}
