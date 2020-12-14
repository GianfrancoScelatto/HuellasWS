using System;
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
    public partial class DesparasitacionVacuna : Form
    {
        BR_Vacunas brV = new BR_Vacunas();
        public DesparasitacionVacuna()
        {
            InitializeComponent();
        }

        private void MostrarRegistrosVacuna()
        {
            dgvVacunas.DataSource = brV.ListarVacunas(E_Animal.IdAnimal);
        }
        private void DesparasitacionVacuna_Load(object sender, EventArgs e)
        {
            MostrarRegistrosVacuna();
            lblAnimal.Text = E_Animal.NombreAnimal;
            dgvVacunas.Columns["IdVM"].Visible = false;
            dgvVacunas.Columns["IdVacuna"].Visible = false;
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            ExportarDatos(dgvVacunas);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Form vacunas = new VacunaAnimal();
            vacunas.ShowDialog();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            E_Vacuna.Editar = true;
            Form vacunas = new VacunaAnimal();
            vacunas.ShowDialog();
            E_Vacuna.Editar = false;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvVacunas.SelectedRows.Count > 0)
            {
                DialogResult preg = MessageBox.Show("¿Desea eliminar esta vacuna?", "WiredSoft", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (preg == DialogResult.OK)
                {
                    brV.BajaVacunaAnimal(Convert.ToInt32(dgvVacunas.CurrentRow.Cells["IdVM"].Value), E_UsuarioAcceso.IdUsuario);
                    MostrarRegistrosVacuna();
                }
            }
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

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            dgvVacunas.DataSource = brV.FiltrarVacunas(txtBuscar.Text);
        }

        private void dgvVacunas_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            E_Vacuna.IdVacunaAnimal = Convert.ToInt32(dgvVacunas.CurrentRow.Cells["IdVM"].Value);
            E_Vacuna.IdVacuna = Convert.ToInt32(dgvVacunas.CurrentRow.Cells["IdVacuna"].Value);
            E_Vacuna.FechaVacunacion = Convert.ToDateTime(dgvVacunas.CurrentRow.Cells["Fecha revacunación"].Value).Date;
        }

        private void btnRecargar_Click(object sender, EventArgs e)
        {
            MostrarRegistrosVacuna();
            dgvVacunas.Update();
            dgvVacunas.Refresh();
        }
    }
}
