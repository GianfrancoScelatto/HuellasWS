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
    public partial class ListarVacunas : Form
    {
        BR_Vacunas brV = new BR_Vacunas();
        E_Mensaje msj = new E_Mensaje();
        
        public ListarVacunas()
        {
            InitializeComponent();
        }

        public void MostrarRegistroVacuna()
        {
            dgvVacunas.DataSource = brV.MostrarVacunas();
        }

        private void ListarVacunaT_Load(object sender, EventArgs e)
        {
            MostrarRegistroVacuna();
            dgvVacunas.Columns["IdVacuna"].Visible = false;
            dgvVacunas.Columns["IdEspecie"].Visible = false;
            dgvVacunas.Columns["IdTiempo"].Visible = false;
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

       

        private void btnExportar_Click(object sender, EventArgs e)
        {
            ExportarDatos(dgvVacunas);
        }


        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Form Vacunas = new Vacunas();
            Vacunas.Show();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvVacunas.SelectedRows.Count > 0)
            {
            E_Vacuna.Editar = true;
            Form Vacunas = new Vacunas();
            Vacunas.ShowDialog();

            E_Vacuna.Editar = false;
            }
            else
                msj.MensajeAlerta("Debe seleccionar una vacuna.");
        }


        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvVacunas.SelectedRows.Count > 0)
            {
                DialogResult preg = MessageBox.Show("¿Desea eliminar esta vacuna?", "WiredSoft", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (preg == DialogResult.OK)
                {
                    brV.BajaVacuna(E_Vacuna.IdVacuna, E_UsuarioAcceso.IdUsuario);
                    MostrarRegistroVacuna();
                }
            }
            else
            {
                msj.MensajeError("No se ha seleccionado ninguna vacuna.");
            }
        }

        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            brV.BuscarVacuna(txtBuscar.Text);
        }

        private void dgvVacunas_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            E_Vacuna.IdVacuna = Convert.ToInt32(dgvVacunas.CurrentRow.Cells["IdVacuna"].Value);
            E_Vacuna.Vacuna = dgvVacunas.CurrentRow.Cells["Vacuna"].Value.ToString();
            E_Vacuna.FrecuenciaRevacunacion = Convert.ToInt32(dgvVacunas.CurrentRow.Cells["Frecuencia"].Value);
            E_Vacuna.Especie = dgvVacunas.CurrentRow.Cells["Especie"].Value.ToString();
            E_Vacuna.IdEspecie = Convert.ToInt32(dgvVacunas.CurrentRow.Cells["IdEspecie"].Value);
            E_Vacuna.IdTiempo = Convert.ToInt32(dgvVacunas.CurrentRow.Cells["IdTiempo"].Value);
            E_Vacuna.Descripcion = dgvVacunas.CurrentRow.Cells["Descripción"].Value.ToString();
        }

        private void btnRecargar_Click(object sender, EventArgs e)
        {
            MostrarRegistroVacuna();
            dgvVacunas.Refresh();
            dgvVacunas.Update();
        }

     
    }
}
