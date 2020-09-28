using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DataAccess;
namespace BusinessRules
{
    public class BR_Vacunas
    {
        private DA_Vacunas VacunasDA = new DA_Vacunas();

        public DataTable MostrarVacunas()
        {

            DataTable tabla = new DataTable();
            tabla = VacunasDA.ListarVacunas();
            return tabla;
        }

        public void Alta_vacunas(int IdVacuna, string Vacuna, int IdEspecie, string FrecuenciaVacunacion, string Descripcion)
        {
            VacunasDA.Alta_Vacunas(IdVacuna, Vacuna, IdEspecie, FrecuenciaVacunacion, Descripcion);
        }

        public void Modificar_Vacuna (int IdVacuna, string Vacuna, int IdEspecie, string FrecuenciaVacunacion, string Descripcion)
        {
            VacunasDA.Modificar_Vacuna(IdVacuna, Vacuna, IdEspecie, FrecuenciaVacunacion, Descripcion);
        }

        public void Eliminar_Vacuna(int IdVacuna, string Vacuna, int IdEspecie, string FrecuenciaVacunacion, string Descripcion)
        {
            VacunasDA.BajaVacuna(IdVacuna, Vacuna, IdEspecie, FrecuenciaVacunacion, Descripcion);

        }



    }

}



        
        
   
