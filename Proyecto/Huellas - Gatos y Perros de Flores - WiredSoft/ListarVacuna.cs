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
    public partial class ListarVacuna : Form
    {
        BR_Vacunas brV = new BR_Vacunas();
        E_Vacuna eV = new E_Vacuna();
        public ListarVacuna()
        {
            InitializeComponent();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Form Vacunas = new Vacunas();
            Vacunas.Show();
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            ExportarDatos(dgvVacunas);
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

        private void dataVacunas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public void MostrarRegistroVacuna()
        {
            dgvVacunas.DataSource = brV.MostrarVacunas();
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvVacunas.SelectedRows.Count > 0)
            {
                DialogResult opcion;
                opcion = MessageBox.Show("¿Desea eliminar esta vacuna?", "WiredSoft", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (opcion == DialogResult.OK)
                {
                    eV.IdVacuna = Convert.ToInt32(dgvVacunas.CurrentRow.Cells[0].Value.ToString());
                    brV.Eliminar_Vacuna(eV.IdVacuna);//discutir parametros de funcion eliminar
                    MensajeConfirmacion("Se elimino correctamente la vacuna.");
                    MostrarRegistroVacuna();
                }
            }
            else
            {
                MensajeError("No se ha seleccionado ninguna vacuna.");
            }
        }
        public void MensajeConfirmacion(string Mensaje)
        {
            MessageBox.Show(Mensaje, "WiredSoft", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public void MensajeError(string Mensaje)
        {
            MessageBox.Show(Mensaje, "WiredSoft", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Form Vacunas = new Vacunas();
            Vacunas.Show();
        }
    }
}

