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
    public partial class ListarAnimales : Form
    {
        BR_Animal brA = new BR_Animal();
        E_Bitacora eB = new E_Bitacora();
        E_Mensaje msj = new E_Mensaje();
        string filtro;

        public ListarAnimales()
        {
            InitializeComponent();
        }

        public void MostrarRegistroAnimal()
        {
            dgvMascotas.DataSource = brA.ListarAnimal();
        }

        private void ListarMascotas_Load(object sender, EventArgs e)
        {
            MostrarRegistroAnimal();
            dgvMascotas.Columns["IdAnimal"].Visible = false;
            dgvMascotas.Columns["IdEspecie"].Visible = false;
            dgvMascotas.Columns["IdPersona"].Visible = false;
            dgvMascotas.Columns["IdEstado"].Visible = false;
            dgvMascotas.Columns["Castracion"].Visible = false;
            chxAdoptados.Checked = true;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Form Animales = new Animales();
            Animales.Show();
        }

        private void BtnExportar_Click(object sender, EventArgs e)
        {
            ExportarDatos(dgvMascotas);
        }
        public void ExportarDatos(DataGridView DatoListado)
        {
            Microsoft.Office.Interop.Excel.Application exportarexcel = new Microsoft.Office.Interop.Excel.Application();
            exportarexcel.Application.Workbooks.Add(true);
            int IndiceColumna = 0;
            foreach(DataGridViewColumn columna in DatoListado.Columns)
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
            if (dgvMascotas.SelectedRows.Count > 0)
            {
                E_Animal.Editar = true;
                Form Animales = new Animales();
                Animales.Show();

                E_Animal.Editar = false;
            }
            else
                msj.MensajeAlerta("Debe seleccionar un animal.");
        }
        
        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvMascotas.SelectedRows.Count > 0)
            {
                DialogResult preg = MessageBox.Show("Quiere eliminar al animal?", "WiredSoft", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (preg == DialogResult.OK)
                {
                    E_Animal.IdAnimal = Convert.ToInt32(dgvMascotas.CurrentRow.Cells["IdAnimal"].Value);
                    brA.BajaAnimal(E_Animal.IdAnimal, E_UsuarioAcceso.IdUsuario);
                    MostrarRegistroAnimal();
                }
            }
            else
            {
                msj.MensajeAlerta("Seleccione el animal a borrar");
            }

        }

        private void chxAdoptados_CheckedChanged(object sender, EventArgs e)
        {
            if (chxAdoptados.Checked == true)
            {
                chxFallecidos.Checked = false;
                chxInternado.Checked = false;
                chxTransito.Checked = false;
                filtro = "Adoptado";
            } 
        }

        private void chxInternados_CheckedChanged(object sender, EventArgs e)
        {
            if (chxInternado.Checked == true)
            {
                chxFallecidos.Checked = false;
                chxAdoptados.Checked = false;
                chxTransito.Checked = false;
                filtro = "Internado";
            }
        }

        private void chxTransito_CheckedChanged(object sender, EventArgs e)
        {
            if (chxTransito.Checked == true)
            {
                chxFallecidos.Checked = false;
                chxInternado.Checked = false;
                chxAdoptados.Checked = false;
                filtro = "En Transito";
            }
        }

        private void chxFallecidos_CheckedChanged(object sender, EventArgs e)
        {
            if (chxFallecidos.Checked == true)
            {
                chxAdoptados.Checked = false;
                chxInternado.Checked = false;
                chxTransito.Checked = false;
                filtro = "Fallecido";
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            brA.FiltrarAnimal(txtBuscar.Text, filtro);
        }

        private void dgvMascotas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            E_Animal.IdAnimal = Convert.ToInt32(dgvMascotas.CurrentRow.Cells["IdAnimal"].Value);
            E_Animal.NombreAnimal = dgvMascotas.CurrentRow.Cells["Nombre animal"].Value.ToString();
            E_Animal.IdEspecie = Convert.ToInt32(dgvMascotas.CurrentRow.Cells["IdEspecie"].Value);
            E_Animal.FechaIngreso = Convert.ToDateTime(dgvMascotas.CurrentRow.Cells["Fecha ingreso"].Value).Date;
            E_Animal.Castracion = Convert.ToBoolean(dgvMascotas.CurrentRow.Cells["Castracion"].Value);
            E_Animal.FechaCastracion = Convert.ToDateTime(dgvMascotas.CurrentRow.Cells["Fecha castracion"].Value).Date;
            E_Animal.LugarRescate = dgvMascotas.CurrentRow.Cells["Lugar de Rescate"].Value.ToString();
            E_Animal.Sexo = dgvMascotas.CurrentRow.Cells["Sexo"].Value.ToString();
            E_Animal.Edad = Convert.ToInt32(dgvMascotas.CurrentRow.Cells["Edad"].Value);
            E_Animal.Peso = Convert.ToDecimal(dgvMascotas.CurrentRow.Cells["Peso"].Value.ToString());
            E_Animal.ColorPelo = dgvMascotas.CurrentRow.Cells["Color"].Value.ToString();
            E_Animal.Estado = Convert.ToInt32(dgvMascotas.CurrentRow.Cells["IdEstado"].Value);
            E_Animal.FechaNac = Convert.ToDateTime(dgvMascotas.CurrentRow.Cells["Fecha nacimiento"].Value).Date;
            E_Animal.Comentario = dgvMascotas.CurrentRow.Cells["Comentario"].Value.ToString();
            E_Animal.Persona = Convert.ToInt32(dgvMascotas.CurrentRow.Cells["IdPersona"].Value);
            E_Animal.FechaDefuncion = Convert.ToDateTime(dgvMascotas.CurrentRow.Cells["Fecha defuncion"].Value);
        }
    }
}
