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
    public partial class ListarPersonas : Form
    {
        BR_Persona brP = new BR_Persona();
        E_Mensaje msj = new E_Mensaje();
        E_Bitacora eB = new E_Bitacora();
        public ListarPersonas()
        {
            InitializeComponent();
            MostrarRegistroPersona();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Form Persona = new Persona();
            Persona.Show();
        }
        public void MostrarRegistroPersona()
        {
            dgvPersona.DataSource = brP.ListarPersona();
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            ExportarDatos(dgvPersona);
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

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            E_Persona.Editar = true;
            Form Persona = new Persona();
            Persona.Show();
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvPersona.SelectedRows.Count > 0)
            {
                DialogResult preg = MessageBox.Show("¿Desea eliminar esta persona?", "WiredSoft", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (preg == DialogResult.OK)
                {
                    brP.BajaPersona(E_Persona.IdPersona, eB.IdUsuario);//Se discute modificar estos parámetros. 
                    MostrarRegistroPersona();
                }
            }
            else
            {
                msj.MensajeError("No se ha seleccionado ninguna vacuna.");
            }

        }

        private void dgvPersona_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {//Agregar demás parámetros
            E_Persona.IdPersona = Convert.ToInt32(dgvPersona.CurrentRow.Cells["IdPersona"].Value);
        }

        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (rbtnAdoptante.Checked == true)
            {
                brP.FiltrarPersona(txtBuscar.Text, rbtnAdoptante.Text);
            }
            else
                brP.FiltrarPersona(txtBuscar.Text, rbtnTransitante.Text);
        }
    }
}
