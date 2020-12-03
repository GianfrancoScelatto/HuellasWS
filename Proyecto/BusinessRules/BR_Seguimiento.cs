﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DataAccess;

namespace BusinessRules
{
    public class BR_Seguimiento
    {
        DA_Seguimiento daS = new DA_Seguimiento();

        public DataTable ListarSeguimiento(int IdAnimal)
        {
            DataTable tabla = new DataTable();
            tabla = daS.ListarSeguimiento(IdAnimal);
            return tabla;
        }

        public DataTable FiltrarSeguimiento(DateTime Fecha)
        {
            DataTable tabla = new DataTable();
            tabla = daS.FiltrarSeguimiento(Fecha);
            return tabla;
        }

        public void GuardarSeguimiento(int IdAnimal, string Detalle, DateTime Fecha, int IdUsuario)
        {
            daS.GuardarSeguimiento(IdAnimal, Detalle, Fecha, IdUsuario);
        }

        public void BajaSeguimiento(int IdSeguimiento, int IdUsuario)
        {
            daS.BajaSeguimiento(IdSeguimiento, IdUsuario);
        }
    }
}
