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

    public partial class ListarListaNegra : Form
    {
        BR_ListaNegra brLN = new BR_ListaNegra();
        E_Mensaje msj = new E_Mensaje();
        public ListarListaNegra()
        {
            InitializeComponent();
        }

        public void MostrarRegistroListaNegra()
        {
            dgvListaNegra.DataSource = brLN.ListarListaNegra();
        }

        private void ListarListaNegra_Load(object sender, EventArgs e)
        {
            MostrarRegistroListaNegra();
        }


        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Form ListaNegra = new ListaNegra();
            ListaNegra.Show();
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            ExportarDatos(dgvListaNegra);
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
            if (dgvListaNegra.SelectedRows.Count > 0)
            {
                E_ListaNegra.Editar = true;
                Form ListaNegra = new ListaNegra();
                ListaNegra.Show();

                E_ListaNegra.Editar = false;
            }
            else
                msj.MensajeAlerta("Debe seleccionar una persona.");
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvListaNegra.SelectedRows.Count > 0)
            {
                DialogResult preg = MessageBox.Show("Quiere eliminar a la persona de la lista negra?", "WiredSoft", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (preg == DialogResult.OK)
                {
                    E_ListaNegra.IdListaNegra = Convert.ToInt32(dgvListaNegra.CurrentRow.Cells["IdListaNegra"].Value);
                    brLN.BajaListaNegra(E_ListaNegra.IdListaNegra, E_UsuarioAcceso.IdUsuario);
                    MostrarRegistroListaNegra();
                }
            }
            else
            {
                msj.MensajeAlerta("Seleccione la persona a quitar de la lista negra.");
            }
        }
        
        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            dgvListaNegra.DataSource = brLN.FiltrarListaNegra(txtBuscar.Text);
        }

        private void btnRecargar_Click(object sender, EventArgs e)
        {
            MostrarRegistroListaNegra();
            dgvListaNegra.Refresh();
            dgvListaNegra.Update();
        }
    }
}
