using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DataAccess;
namespace BusinessRules
{
    public class BR_Establecimiento
    {
        private DA_Establecimiento EstablecimientoDA = new DA_Establecimiento();

        public DataTable MostrarEstablecimiento()
        {

            DataTable tabla = new DataTable();
            tabla = EstablecimientoDA.ListarEstablecimiento();
            return tabla;
        }

        public void AltaEstablecimiento(int TipoEstablecimiento, string Nombre, string HorarioAtencion, string Localidad, string CodigoPostal, string Calle, int Altura, bool Internacion)
        {
            EstablecimientoDA.AltaEstablecimiento(TipoEstablecimiento, Nombre, HorarioAtencion, Localidad, CodigoPostal, Calle, Altura, Internacion);
        }

        public void ModifcarEstablecimiento(int IdEstablecimiento, int TipoEstablecimiento, string Nombre, string HorarioAtencion, string Localidad, string CodigoPostal, string Calle, int Altura, bool Internacion)
        {
            EstablecimientoDA.ModificarEstablecimiento(IdEstablecimiento, TipoEstablecimiento, Nombre, HorarioAtencion, Localidad, CodigoPostal, Calle, Altura, Internacion);
        }

        public void BajaEstablecimiento(int IdEstablecimiento, bool Deshabilitado)
        {
            EstablecimientoDA.BajaVacuna(IdEstablecimiento, Deshabilitado);
        }
    }
}
