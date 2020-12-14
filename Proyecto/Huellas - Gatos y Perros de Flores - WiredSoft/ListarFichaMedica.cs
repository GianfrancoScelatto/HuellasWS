﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entities;
using BusinessRules;

namespace Huellas___Gatos_y_Perros_de_Flores___WiredSoft
{
    public partial class ListarFichaMedica : Form
    {
        BR_FichaMedica brFM = new BR_FichaMedica();
        public ListarFichaMedica()
        {
            InitializeComponent();
        }
        private void ListarFichaMedica_Load(object sender, EventArgs e)
        {
            dgvFichaMedica.DataSource = brFM.ListarFichaMedica2();
            dgvFichaMedica.Columns["IdFichaMedica"].Visible = false;
            dgvFichaMedica.Columns["IdAnimal"].Visible = false;
            dgvFichaMedica.Columns["IdEstablecimiento"].Visible = false;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Form FichaMedica = new FichaMedica();
            FichaMedica.Show();
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            ExportarDatos(dgvFichaMedica);
        }
        public void ExportarDatos(DataGridView DatoListado)
        {
            Microsoft.Office.Interop.Excel.Application exportarexcel = new Microsoft.Office.Interop.Excel.Application();
            exportarexcel.Application.Workbooks.Add(true);
            int IndiceColumna = 0;
            foreach (DataGridViewColumn columna in DatoListado.Columns)
            {
                IndiceColumna++;
                exportarexcel.Cells[1, IndiceColumna] = columna.Name;
            }
            int IndiceFila = 0;
            foreach (DataGridViewRow fila in DatoListado.Rows)
            {
                IndiceFila++;
                IndiceColumna = 0;
                foreach (DataGridViewColumn columna in DatoListado.Columns)
                {
                    IndiceColumna++;
                    exportarexcel.Cells[IndiceFila + 1, IndiceColumna] = fila.Cells[columna.Name].Value;
                }
            }
            exportarexcel.Visible = true;
        }

        private void dgvFichaMedica_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            E_FichaMedica.IdFichaMedica = Convert.ToInt32(dgvFichaMedica.CurrentRow.Cells["IdFichaMedica"].Value);
            E_FichaMedica.IdMascota = Convert.ToInt32(dgvFichaMedica.CurrentRow.Cells["IdAnimal"].Value);
            E_FichaMedica.Fecha = Convert.ToDateTime(dgvFichaMedica.CurrentRow.Cells["Fecha atención"].Value).Date;
            E_FichaMedica.Informe = dgvFichaMedica.CurrentRow.Cells["Informe"].Value.ToString();
            E_FichaMedica.Tratamiento = dgvFichaMedica.CurrentRow.Cells["Tratamiento"].Value.ToString();
            E_FichaMedica.IdVeterinaria = Convert.ToInt32(dgvFichaMedica.CurrentRow.Cells["IdEstablecimiento"].Value);
            E_FichaMedica.Costo = Convert.ToDecimal(dgvFichaMedica.CurrentRow.Cells["Costo"].Value);
        }

        private void dgvFichaMedica_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            dgvFichaMedica.Columns["Costo"].DefaultCellStyle.Format = "N2";
        }
    }
}
