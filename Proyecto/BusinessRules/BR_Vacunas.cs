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

        public void AltaVacuna(string Vacuna, int idEspecie, int FrecuenciaVacunacion, string Descripcion, int IdUsuario)
        {
            if (msj.MensajeAcceso(E_Usuario.Rol))
            {
                daV.AltaVacuna(Vacuna, idEspecie, FrecuenciaVacunacion, Descripcion, IdUsuario);
            }
            
        }

        public void ModificarVacuna (int idVacuna, string Vacuna, int idEspecie, int FrecuenciaVacunacion, string Descripcion, int idUsuario)
        {
            if (msj.MensajeAcceso(E_Usuario.Rol))
            {
                daV.ModificarVacuna(idVacuna, Vacuna, idEspecie, FrecuenciaVacunacion, Descripcion, idUsuario);
            } 
        }

        public void BajaVacuna(int IdVacuna, int IdUsuario)
        {
            if (msj.MensajeAcceso(E_Usuario.Rol))
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
    }
}





        
        
   
