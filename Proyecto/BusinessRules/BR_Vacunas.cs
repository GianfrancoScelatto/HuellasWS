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

        public void Altavacunas(string Vacuna, int IdEspecie, int FrecuenciaVacunacion, string Descripcion)
        {
            VacunasDA.AltaVacunas(Vacuna, IdEspecie, FrecuenciaVacunacion, Descripcion);
        }

        public void ModificarVacuna (int IdVacuna, string Vacuna, int IdEspecie, string FrecuenciaVacunacion, string Descripcion)
        {
            VacunasDA.ModificarVacuna(IdVacuna, Vacuna, IdEspecie, FrecuenciaVacunacion, Descripcion);
        }

        public void BajaVacuna(int IdVacuna, bool Deshabilitado)
        {
            VacunasDA.BajaVacuna(IdVacuna, Deshabilitado);

        }
       
    }

}



        
        
   
