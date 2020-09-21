using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using DataAccess;


namespace BusinessRules
{
    class Vacunas
    {
        private DA_Vacunas VacunasDA = new DA_Vacunas();

        public DataTable MostrarVacunas()
        {

            DataTable tabla = new DataTable();
            tabla = VacunasDA.ListarVacunas();
            return tabla;
        }

        public void AM_vacunas(int IdVacuna, string Vacuna, int IdEspecie, string FrecuenciaVacunacion, string Descripcion)
        {
            VacunasDA.AM_Vacunas(IdVacuna, Vacuna, IdEspecie, FrecuenciaVacunacion, Descripcion);
        }
    }
}
