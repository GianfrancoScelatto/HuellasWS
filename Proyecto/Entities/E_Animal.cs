using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class E_Animal
    {
        public int IdAnimal { get; set; }
        public string NombreAnimal { get; set; }
        public int IdEspecie { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string LugarRescate { get; set; }
        public byte FotoIngreso { get; set; }
        public byte FotoAdopcion { get; set; }
        public string Sexo { get; set; }
        public int Edad { get; set; }
        public decimal Peso { get; set; }
        public string Tamaño { get; set; }
        public string ColorPelo { get; set; }
        public bool Castracion { get; set; }
        public DateTime FechaCastracion { get; set; }
        public bool Desparacitacion { get; set; }
        public string Comentario { get; set; }
        public string Salud { get; set; }
        public string Estado { get; set; }
        public int FKEstadoMascota { get; set; }
        public int FKIdTransitante { get; set; }
        public bool Deshabilitado { get; set; }
    }
}
