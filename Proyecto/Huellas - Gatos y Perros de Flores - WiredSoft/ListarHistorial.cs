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

namespace Huellas___Gatos_y_Perros_de_Flores___WiredSoft
{
    public partial class ListarHistorial : Form
    {
        BR_Historial brH = new BR_Historial();
        public ListarHistorial()
        {
            InitializeComponent();
        }

        private void ListarHistorial_Load(object sender, EventArgs e)
        {
            dgvHistorial.DataSource = brH.ListarHistorial();
            dgvHistorial.Columns["IdHistorial"].Visible = false;
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            dgvHistorial.DataSource = brH.FiltrarHistorial(txtBuscar.Text);
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
            ExportarDatos(dgvHistorial);
        }
    }
}
