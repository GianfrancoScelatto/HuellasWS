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
    public partial class ListarCostos : Form
    {
        BR_Costo brC = new BR_Costo();
        E_Mensaje msj = new E_Mensaje();
        public ListarCostos()
        {
            InitializeComponent();
        }
        public void MostrarCostos()
        {
            dgvCosto.DataSource = brC.MostrarCosto();
        }
        private void ListarCostos_Load(object sender, EventArgs e)
        {
            MostrarCostos();
            //dgvCosto.Columns["IdEstablecimiento"].Visible = false;
            //dgvCosto.Columns["IdTipoGasto"].Visible = false;

            //VER ESTO PORQUE ACA SE ROMPE 

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


        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Form Gasto = new Costos();
            Gasto.Show();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            E_Vacuna.Editar = true;
            Form Costo = new Costos();
            Costo.Show();
            E_Costos.Editar = false;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvCosto.SelectedRows.Count > 0)
            {
                DialogResult preg = MessageBox.Show("¿Desea eliminar esta vacuna?", "WiredSoft", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (preg == DialogResult.OK)
                {
                    brC.BajaGasto(E_Costos.IdGasto, E_UsuarioAcceso.IdUsuario);
                    MostrarCostos();
                }
            }
            else
            {
                msj.MensajeError("No se ha seleccionado ninguna vacuna.");
            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            ExportarDatos(dgvCosto);
        }

        private void dgvListarCosto_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            E_Costos.IdGasto = Convert.ToInt32(dgvCosto.CurrentRow.Cells["IdGasto"].Value);
            E_Costos.FechaGasto = Convert.ToDateTime(dgvCosto.CurrentRow.Cells["FechaGasto"].Value).Date;
            E_Costos.IdTipoGasto = Convert.ToInt32(dgvCosto.CurrentRow.Cells["IdTipoGasto"].Value);
            E_Costos.IdEstablecimiento = Convert.ToInt32(dgvCosto.CurrentRow.Cells["IdEstablecimiento"].Value);
            E_Costos.IdAnimal = Convert.ToInt32(dgvCosto.CurrentRow.Cells["IdAnimal"].Value);
            E_Costos.Monto = Convert.ToDecimal(dgvCosto.CurrentRow.Cells["Monto"].Value.ToString());
            E_Costos.Detalle = dgvCosto.CurrentRow.Cells["Detalle"].Value.ToString();
            E_Costos.Pagado = Convert.ToDecimal(dgvCosto.CurrentRow.Cells["Pagado"].Value.ToString());


        }
    }
}
