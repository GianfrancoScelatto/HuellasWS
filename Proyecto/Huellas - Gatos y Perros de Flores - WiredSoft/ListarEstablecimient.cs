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
    public partial class ListarEstablecimient : Form
    {
        BR_Establecimiento brE = new BR_Establecimiento();
        E_Establecimiento eE = new E_Establecimiento();
        
        public ListarEstablecimient()
        {
            InitializeComponent();
        }

        public void MostrarRegistroEstablecimiento()
        {
            dataEstablecimiento.DataSource = brE.MostrarEstablecimiento();
        }





        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Form Establecimiento = new Establecimiento();
            Establecimiento.Show();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Form Establecimiento = new Establecimiento();
            Establecimiento.Show();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataEstablecimiento.SelectedRows.Count > 0)
            {
                DialogResult opcion;
                opcion = MessageBox.Show("¿Desea eliminar este establecimiento", "WiredSoft", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (opcion == DialogResult.OK)
                {
                    eE.IdEstablecimiento = Convert.ToInt32(dataEstablecimiento.CurrentRow.Cells[0].Value.ToString());
                    MensajeConfirmacion("Se eliminó correctamente el establecimiento.");
                    MostrarRegistroEstablecimiento();
                }

                else 
                {
                    MensajeError("No se ha seleccionado ningún establecimiento.");
                }
            }

        }



        private void btnExportar_Click(object sender, EventArgs e)
        {
            ExportarDatos(dataEstablecimiento);
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

        public void MensajeConfirmacion(string Mensaje)
        {
            MessageBox.Show(Mensaje, "WiredSoft", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        public void MensajeError(string Mensaje)
        {
            MessageBox.Show(Mensaje, "WiredSoft", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ListarEstablecimient_Load(object sender, EventArgs e)
        {
            MostrarRegistroEstablecimiento();
        }
    }
}
