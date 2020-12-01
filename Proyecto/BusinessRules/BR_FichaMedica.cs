using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DataAccess;

namespace BusinessRules
{
    public class BR_FichaMedica
    {
        DA_FichaMedica daFM = new DA_FichaMedica();
        public DataTable ListarFichaMedica(int IdAnimal)
        {
            DataTable tabla = new DataTable();
            tabla = daFM.ListarFichaMedica(IdAnimal);
            return tabla;
        }
        public DataTable ListarFichaMedica2()
        {
            DataTable tabla = new DataTable();
            tabla = daFM.ListarFichaMedica2();
            return tabla;
        }

        public DataTable FiltrarFichaMedica(string Nombre, DateTime Fecha)
        {
            DataTable tabla = new DataTable();
            tabla = daFM.FiltrarFichaMedica(Nombre, Fecha);
            return tabla;
        }

        public void AltaFichaMedica(int IdAnimal, int idVeterinaria, DateTime Fecha, string Informe, string Tratamiento, decimal Costo)
        {
            daFM.AltaFichaMedica(IdAnimal, idVeterinaria, Fecha, Informe, Tratamiento, Costo);
        }

        public void ModificarFichaMedica(int IdFichaMedica, int IdAnimal, int IdVeterinaria, DateTime Fecha, string Informe, string Tratamiento, decimal Costo)
        {
            daFM.ModificarFichaMedica(IdFichaMedica, IdAnimal, IdVeterinaria, Fecha, Informe, Tratamiento, Costo);
        }

        public void BajaFichaMedica(int IdFichaMedica, int IdRol)
        {
            daFM.BajaFichaMedica(IdFichaMedica, IdRol);
        }
    }
}
