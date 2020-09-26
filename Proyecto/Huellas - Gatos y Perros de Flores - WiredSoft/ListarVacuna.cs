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
        readonly BR_Vacunas ObjBusinessRules = new BR_Vacunas();
        readonly E_Vacuna ObjEntities = new E_Vacuna();
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
            ExportarDatos(dataVacunas);
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
            dataVacunas.DataSource = BR_Vacunas.
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataVacunas.SelectedRows.Count > 0)
            {
                DialogResult opcion;
                opcion = MessageBox.Show("¿Desea eliminar esta vacuna?", "WiredSoft", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (opcion == DialogResult.OK)
                {
                    ObjEntities.IdVacuna = Convert.ToInt32(dataVacunas.CurrentRow.Cells[0].Value.ToString());
                    ObjBusinessRules.Eliminar_Vacuna(ObjEntities);
                    MensajeConfirmacion("Se elimino correctamente la vacuna");
                    MostrarRegistroVacuna();
                }
            }
            else
            {
                MensajeError("Seleccione la vacuna a borrar");
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
    }
}

