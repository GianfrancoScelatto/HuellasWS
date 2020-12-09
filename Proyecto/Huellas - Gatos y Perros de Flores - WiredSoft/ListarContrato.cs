using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessRules;
using Entities;

namespace Huellas___Gatos_y_Perros_de_Flores___WiredSoft
{
    public partial class ListarContrato : Form
    {
        BR_Contrato brC = new BR_Contrato();
        E_Mensaje msj = new E_Mensaje();
        public ListarContrato()
        {
            InitializeComponent();
        }

        public void MostrarContrato()
        {
            dgvContrato.DataSource = brC.ListarContrato();
        }
        private void ListarContrato_Load(object sender, EventArgs e)
        {
            MostrarContrato();
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Form Contrato = new Contrato();
            Contrato.Show();
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvContrato.SelectedRows.Count > 0)
            {
                DialogResult preg = MessageBox.Show("¿Desea eliminar este contrato?", "WiredSoft", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (preg == DialogResult.OK)
                {
                    brC.BajaContrato(E_Contrato.IdContrato, E_Usuario.IdUsuario, E_Animal.IdAnimal,E_Persona.IdPersona, E_Contrato.NuevoNombre);
                    MostrarContrato();
                }
            }
            else
            {
                msj.MensajeError("No se ha seleccionado ninguna vacuna.");
            }
        }
        private void btnExportar_Click(object sender, EventArgs e)
        {
            ExportarDatos(dgvContrato);
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

        private void btnRecargar_Click(object sender, EventArgs e)
        {
            MostrarContrato();
            dgvContrato.Refresh();
            dgvContrato.Update();
        }
    }
}
