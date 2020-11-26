using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using System.Data;
using DataAccess;

namespace BusinessRules
{
    public class BR_ListaNegra
    {
        DA_ListaNegra ObjListaNegra = new DA_ListaNegra();
        E_Mensaje msj = new E_Mensaje();

        public DataTable ListarListaNegra()
        {
            DataTable tabla = new DataTable();
            tabla = ObjListaNegra.ListarListaNegra();
            return tabla;
        }
        public void AltaListaNegra(int IdListaNegra, string Nombre, string Apellido, int TelefonoFijo, int Celular, string CorreoElectronico, string Direccion, string Localidad, string Provincia, string Motivo)
        {
            ObjListaNegra.AltaListaNegra(IdListaNegra, Nombre, Apellido, TelefonoFijo, Celular, CorreoElectronico, Direccion, Localidad, Provincia, Motivo);
        }
        public void ModificarListaNegra(int IdListaNegra, string Nombre, string Apellido, int TelefonoFijo, int Celular, string CorreoElectronico, string Direccion, string Localidad, string Provincia, string Motivo)
        {
            ObjListaNegra.ModificarListaNegra(IdListaNegra, Nombre, Apellido, TelefonoFijo, Celular, CorreoElectronico, Direccion, Localidad, Provincia, Motivo);
        }
        public void BajaListaNegra(int IdListaNegra, int IdUsuario)
        {
            ObjListaNegra.BajaListaNegra(IdListaNegra,IdUsuario);
        }
        public DataTable FiltrarListaNegra(string Busqueda)
        {
            DataTable tabla = new DataTable();
            tabla = ObjListaNegra.FiltrarListaNegra(Busqueda);
            return tabla;
        }
    }
}
