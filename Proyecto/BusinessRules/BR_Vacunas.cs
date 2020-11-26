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
    }
}





        
        
   
