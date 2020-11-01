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
        E_Mensaje msj = new E_Mensaje();
        
        public ListarEstablecimient()
        {
            InitializeComponent();
        }

        public void MostrarRegistroEstablecimiento()
        {
            dataEstablecimiento.DataSource = brE.MostrarEstablecimiento();
        }

        private void ListarEstablecimient_Load(object sender, EventArgs e)
        {
            MostrarRegistroEstablecimiento();
            dataEstablecimiento.Columns["IdEstablecimiento"].Visible = false;
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
            ExportarDatos(dataEstablecimiento);
        }


        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Form Establecimiento = new Establecimiento();
            Establecimiento.Show();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            E_Establecimiento.Editar = true;
            Form Establecimiento = new Establecimiento();
            Establecimiento.Show();
            E_Establecimiento.Editar = false;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataEstablecimiento.SelectedRows.Count > 0)
            {
                DialogResult preg = MessageBox.Show("¿Desea eliminar esta vacuna?", "WiredSoft", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (preg == DialogResult.OK)
                {
                    brE.BajaEstablecimiento(E_Establecimiento.IdEstablecimiento, E_Usuario.IdUsuario);
                    MostrarRegistroEstablecimiento();
                }
            }
            else
            {
                msj.MensajeError("No se ha seleccionado ninguna vacuna.");
            }
        }





        private void dataEstablecimiento_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            E_Establecimiento.IdEstablecimiento = Convert.ToInt32(dataEstablecimiento.CurrentRow.Cells["IdVacuna"].Value);
            E_Establecimiento.Nombre = dataEstablecimiento.CurrentRow.Cells["Nombre"].Value.ToString();
            E_Establecimiento.IdTipoEstablecimiento = Convert.ToInt32 (dataEstablecimiento.CurrentRow.Cells["Id Establecimiento"].Value);
            E_Establecimiento.HorarioAtencion = dataEstablecimiento.CurrentRow.Cells["Horario de atención"].Value.ToString();
            E_Establecimiento.Calle = dataEstablecimiento.CurrentRow.Cells["Calle"].Value.ToString();
            E_Establecimiento.Altura = Convert.ToInt32(dataEstablecimiento.CurrentRow.Cells["Altura"].Value);
            E_Establecimiento.CodigoPostal = dataEstablecimiento.CurrentRow.Cells["Codigo Postal"].Value.ToString();
            E_Establecimiento.Localidad = dataEstablecimiento.CurrentRow.Cells["Localidad"].Value.ToString();

        }
    }
}
