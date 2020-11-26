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
    public class BR_Costo
    {
        DA_Costo daC = new DA_Costo();
        E_Mensaje msj = new E_Mensaje();

        public DataTable MostrarCosto()
        {
            DataTable tabla = new DataTable();
            tabla = daC.ListarCosto();
            return tabla;
        }

        public void AltaGasto(DateTime FechaGasto, int IdTipoGasto, int IdAnimal, int IdEstablecimiento, decimal Monto, decimal Pagado, string Detalle, int IdUsuario)
        {
            if (msj.MensajeAcceso(E_Usuario.Rol))
            {
                daC.AltaGasto(FechaGasto, IdTipoGasto, IdAnimal, IdEstablecimiento, Monto, Pagado, Detalle,  IdUsuario);
            }
        }

        public void ModificarGasto(int IdGasto, DateTime FechaGasto, int IdTipoGasto, int IdAnimal, int IdEstablecimiento, decimal Monto, decimal Pagado, string Detalle,  int IdUsuario)
        {
            if (msj.MensajeAcceso(E_Usuario.Rol))
            {
                daC.ModificarGasto(IdGasto, FechaGasto, IdTipoGasto, IdAnimal, IdEstablecimiento, Monto, Pagado, Detalle, IdUsuario);
            }
        }

        public void BajaGasto(int IdGasto, int IdUsuario)
        {
            if (msj.MensajeAcceso(E_Usuario.Rol))
            {
                daC.BajaGasto(IdGasto, IdUsuario);
            }
        }

        //Este es para traer el ID para asignar a que animal
        public DataTable MostrarAnimales()
        {
            DataTable tabla = new DataTable();
            tabla = daC.ListarTipoAnimal();
            return tabla;

        }

        //Este es para traer el ID en el combo de Establecimiento
        public DataTable MostrarEstablecimiento()
        {
            DataTable tabla = new DataTable();
            tabla = daC.ListarTipoEstablecimiento();
            return tabla;

        }

        //Este es para traer que tipo de gasto
        public DataTable MostrarTipoGasto()
        {
            DataTable tabla = new DataTable();
            tabla = daC.ListarTipoGasto();
            return tabla;

        }
    }
}
