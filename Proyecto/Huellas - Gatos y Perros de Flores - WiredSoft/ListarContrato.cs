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

        private void btnModificar_Click(object sender, EventArgs e)
        {
            
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            //if (dgvContrato.SelectedRows.Count > 0)
            //{
            //    DialogResult preg = MessageBox.Show("¿Desea eliminar este contrato?", "WiredSoft", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            //    if (preg == DialogResult.OK)
            //    {
            //        brC.BajaContrato(E_Contrato IdContrato, E_Usuario.IdUsuario);
            //        MostrarContrato();
            //    }
            //}
            //else
            //{
            //    msj.MensajeError("No se ha seleccionado ninguna vacuna.");
            //}
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {

        }

    }
}
