using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class E_Persona
    {
        public int IdPersona { get; set; }
        public int IdTipoPersona { get; set; }
        public string NombrePersona { get; set; }
        public string ApellidoPersona { get; set; }
        public int Edad { get; set; }
        public string DNI { get; set; }
        public string Domicilio { get; set; }
        public string Localidad { get; set; }
        public string CodigoPostal { get; set; }
        public string Calles { get; set; }
        public int Altura { get; set; }
        public string Sexo { get; set; }
        public int Telefono { get; set; }
        public int Celular { get; set; }
        public string Email { get; set; }
        public string UsuarioFaceIg { get; set; }
        public bool ListaNegra { get; set; }
        public string Motivo { get; set; }
        public bool Desabilitado { get; set; }
    }
}
