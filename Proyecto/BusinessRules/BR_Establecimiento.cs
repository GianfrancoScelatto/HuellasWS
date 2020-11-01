using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using System.Data;
using DataAccess;
    public class BR_Establecimiento
    {
        DA_Establecimiento daE = new DA_Establecimiento();
        E_Mensaje msj = new E_Mensaje();
        

        public DataTable MostrarEstablecimiento()
        {
            DataTable tabla = new DataTable();
            tabla = daE.ListarEstablecimiento();
            return tabla;
        }

        public void AltaEstablecimiento(int TipoEstablecimiento, string Nombre, string HorarioAtencion, string Localidad, string CodigoPostal, string Calle, int Altura, bool Internacion, int IdUsuario)
        {
            daE.AltaEstablecimiento(TipoEstablecimiento, Nombre, HorarioAtencion, Localidad, CodigoPostal, Calle, Altura, Internacion, IdUsuario);
        }

        public void ModifcarEstablecimiento(int IdEstablecimiento, int TipoEstablecimiento, string Nombre, string HorarioAtencion, string Localidad, string CodigoPostal, string Calle, int Altura, bool Internacion, int IdUsuario)
        {
            daE.ModificarEstablecimiento(IdEstablecimiento, TipoEstablecimiento, Nombre, HorarioAtencion, Localidad, CodigoPostal, Calle, Altura, Internacion, IdUsuario);
        }

        public void BajaEstablecimiento(int IdEstablecimiento, int IdUsuario)
        {
            if (msj.MensajeAcceso(E_Usuario.Rol))
            {
             daE.BajaVacuna(IdEstablecimiento, IdUsuario);
            }
            
        }

        public DataTable ComboEstablecimiento()
        {
            DataTable tabla = new DataTable();
            tabla = daE.ComboEstablecimiento();
            return tabla;
        }
    }

