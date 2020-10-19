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
        DA_Establecimiento daE = new DA_Establecimiento();

        public DataTable MostrarEstablecimiento()
        {
            DataTable tabla = new DataTable();
            tabla = daE.ListarEstablecimiento();
            return tabla;
        }

        public void AltaEstablecimiento(int TipoEstablecimiento, string Nombre, string HorarioAtencion, string Localidad, string CodigoPostal, string Calle, int Altura, bool Internacion)
        {
            daE.AltaEstablecimiento(TipoEstablecimiento, Nombre, HorarioAtencion, Localidad, CodigoPostal, Calle, Altura, Internacion);
        }

        public void ModifcarEstablecimiento(int IdEstablecimiento, int TipoEstablecimiento, string Nombre, string HorarioAtencion, string Localidad, string CodigoPostal, string Calle, int Altura, bool Internacion)
        {
            daE.ModificarEstablecimiento(IdEstablecimiento, TipoEstablecimiento, Nombre, HorarioAtencion, Localidad, CodigoPostal, Calle, Altura, Internacion);
        }

        public void BajaEstablecimiento(int IdEstablecimiento, bool Deshabilitado)
        {
            daE.BajaVacuna(IdEstablecimiento, Deshabilitado);
        }

        public DataTable ComboEstablecimiento()
        {
            DataTable tabla = new DataTable();
            tabla = daE.ComboEstablecimiento();
            return tabla;
        }
    }
}
