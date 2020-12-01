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
    public partial class ListarUsuarios : Form
    {
        BR_Usuario brU = new BR_Usuario();
        E_Mensaje msj = new E_Mensaje();
        string filtro;
        
        public ListarUsuarios()
        {
            InitializeComponent();
        }

        private void MostrarRegistroUsuarios()
        {
            dgvUsuarios.DataSource = brU.ListarUsuario();
        }

        private void ListarUsuarios_Load(object sender, EventArgs e)
        {
            MostrarRegistroUsuarios();
            dgvUsuarios.Columns["IdUsuario"].Visible = false;
            dgvUsuarios.Columns["IdRol"].Visible = false;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Form Usuarios = new Usuarios();
            Usuarios.Show();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            E_UsuarioAcceso.Editar = true;
            Form Usuarios = new Usuarios();
            Usuarios.Show();
            E_UsuarioAcceso.Editar = false;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedRows.Count > 0)
            {
                DialogResult preg = MessageBox.Show("¿Quiere eliminar al usuario?", "WiredSoft", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (preg == DialogResult.OK)
                {
                    brU.BajaUsuario(Convert.ToInt32(dgvUsuarios.CurrentRow.Cells["IdUsuario"].Value), E_UsuarioAcceso.IdUsuario);
                    MostrarRegistroUsuarios();
                }
            }
            else
            {
                msj.MensajeAlerta("Seleccione el usuario a borrar");
            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            ExportarDatos(dgvUsuarios);
        }

        private void dgvUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            E_Usuario.IdUsuario = Convert.ToInt32(dgvUsuarios.CurrentRow.Cells["IdUsuario"].Value);
            E_Usuario.IdRol = Convert.ToInt32(dgvUsuarios.CurrentRow.Cells["IdRol"].Value);
            E_Usuario.Rol = dgvUsuarios.CurrentRow.Cells["Rol"].Value.ToString();
            E_Usuario.NombreUsuario = dgvUsuarios.CurrentRow.Cells["Nombre usuario"].Value.ToString();
            E_Usuario.Nombre = dgvUsuarios.CurrentRow.Cells["Nombre"].Value.ToString();
            E_Usuario.Apellido = dgvUsuarios.CurrentRow.Cells["Apellido"].Value.ToString();
            E_Usuario.Dni = dgvUsuarios.CurrentRow.Cells["Dni"].Value.ToString();
            E_Usuario.Telefono = Convert.ToInt32(dgvUsuarios.CurrentRow.Cells["Telefono"].Value);
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

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            brU.FiltrarUsuario(txtBuscar.Text, filtro);
        }

        private void chxUsuario_CheckedChanged(object sender, EventArgs e)
        {
            if (chxUsuario.Checked == true)
            {
                chxNombre.Checked = false;
                filtro = "Usuario";
            }
        }

        private void chxNombre_CheckedChanged(object sender, EventArgs e)
        {
            if (chxNombre.Checked == true)
            {
                chxUsuario.Checked = false;
                filtro = "Nombre";
            }
        }
    }
}
