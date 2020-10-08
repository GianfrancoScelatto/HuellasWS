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

        public void Altavacuna(string Vacuna, int IdEspecie, int FrecuenciaVacunacion, string Descripcion, int IdUsuario, int Movimiento)
        {
            VacunasDA.AltaVacuna(Vacuna, IdEspecie, FrecuenciaVacunacion, Descripcion, IdUsuario, Movimiento);
        }

        public void ModificarVacuna (int IdVacuna, string Vacuna, int IdEspecie, string FrecuenciaVacunacion, string Descripcion)
        {
            VacunasDA.ModificarVacuna(IdVacuna, Vacuna, IdEspecie, FrecuenciaVacunacion, Descripcion);
        }

        public void BajaVacuna(int IdVacuna, int IdUsuario, int IdMovimiento, bool Deshabilitado)
        {
            VacunasDA.BajaVacuna(IdVacuna, IdUsuario, IdMovimiento , Deshabilitado);

        }

        public DataTable ListarEspecie()
        {
            DataTable tabla = new DataTable();
            tabla = VacunasDA.ListarEspecie();
            return tabla;
        }
    }
}





        
        
   
