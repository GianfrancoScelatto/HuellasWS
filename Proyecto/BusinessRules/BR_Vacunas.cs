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
    public class BR_Vacunas
    {
        DA_Vacunas daV = new DA_Vacunas();
        E_Mensaje msj = new E_Mensaje();

        public DataTable MostrarVacunas()
        {
            DataTable tabla = new DataTable();
            tabla = daV.ListarVacunas();
            return tabla;
        }

        public void AltaVacuna(string Vacuna, int idEspecie, int FrecuenciaVacunacion, int IdTiempo, string Descripcion, int IdUsuario)
        {
            if (msj.MensajeAcceso(E_UsuarioAcceso.Rol))
            {
                daV.AltaVacuna(Vacuna, idEspecie, FrecuenciaVacunacion,IdTiempo ,Descripcion, IdUsuario);
            }
            
        }

        public void AltaVacunaAnimal(int IdVacuna, int IdAnimal, DateTime FechaAplicacion, DateTime FechaReaplicacion, int IdUsuario)
        {
            daV.AltaVacunaAnimal(IdVacuna, IdAnimal, FechaAplicacion, FechaReaplicacion, IdUsuario);
        }

        public void ModificarVacuna (int idVacuna, string Vacuna, int idEspecie, int FrecuenciaVacunacion, int IdTiempo, string Descripcion, int idUsuario)
        {
            if (msj.MensajeAcceso(E_UsuarioAcceso.Rol))
            {
                daV.ModificarVacuna(idVacuna, Vacuna, idEspecie, FrecuenciaVacunacion, IdTiempo, Descripcion, idUsuario);
            } 
        }

        public void BajaVacuna(int IdVacuna, int IdUsuario)
        {
            if (msj.MensajeAcceso(E_UsuarioAcceso.Rol))
            {
                daV.BajaVacuna(IdVacuna, IdUsuario);
            }
        }

        public void BajaVacunaAnimal(int IdVacunaAnimal, int IdUsuario)
        {
            daV.BajaVacunaAnimal(IdVacunaAnimal, IdUsuario);
        }

        public DataTable BuscarVacuna(string Busqueda)
        {
            DataTable tabla = new DataTable();
            tabla = daV.BuscarVacunas(Busqueda);
            return tabla;
        }

        public DataTable ListarEspecie()
        {
            DataTable tabla = new DataTable();
            tabla = daV.ListarEspecie();
            return tabla;
        }

        public DataTable ListarTiempo()
        {
            DataTable tabla = new DataTable();
            tabla = daV.ListarTiempo();
            return tabla;
        }

        public DataTable ListarComboVacunas(int IdEspecie)
        {
            DataTable tabla = new DataTable();
            tabla = daV.ListarComboVacunas(IdEspecie);
            return tabla;
        }

        public int TraerRevacunacion(int IdVacuna)
        {
            return daV.TraerRevacunacion(IdVacuna);
        }

        public DataTable ListarVacunas(int IdAnimal)
        {
            DataTable tabla = new DataTable();
            tabla = daV.ListarVacunas(IdAnimal);
            return tabla;
        }

        public DataTable FiltrarVacunas(string Vacuna)
        {
            DataTable tabla = new DataTable();
            tabla = daV.FiltrarVacunas(Vacuna);
            return tabla;
        }
    }
}





        
        
   
