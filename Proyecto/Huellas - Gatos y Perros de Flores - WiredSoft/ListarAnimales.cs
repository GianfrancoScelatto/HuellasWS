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
            dgvMascotas.Columns["Castracion"].Visible = false;
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
                    brA.BorrarAnimal(E_Animal.IdAnimal, E_Usuario.IdUsuario, eB.IdMovimiento, E_Animal.Estado, eB.Descripcion, E_Animal.Deshabilitado);
                    MostrarRegistroAnimal();
                }
            }
            else
            {
                msj.MensajeAlerta("Seleccione el animal a borrar");
            }

        }

        private void DgvMascotas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            E_Animal.IdAnimal = Convert.ToInt32(dgvMascotas.CurrentRow.Cells["IdAnimal"].Value);
            E_Animal.NombreAnimal = dgvMascotas.CurrentRow.Cells["Nombre"].Value.ToString();
            E_Animal.IdEspecie = Convert.ToInt32(dgvMascotas.CurrentRow.Cells["IdEspecie"].Value);
            E_Animal.FechaIngreso = Convert.ToDateTime(dgvMascotas.CurrentRow.Cells["Fecha ingreso"].Value).Date;
            E_Animal.Castracion = Convert.ToBoolean(dgvMascotas.CurrentRow.Cells["Castracion"].Value);
            E_Animal.FechaCastracion = Convert.ToDateTime(dgvMascotas.CurrentRow.Cells["Fecha castracion"].Value).Date;
            E_Animal.LugarRescate = dgvMascotas.CurrentRow.Cells["Lugar de Rescate"].Value.ToString();
            E_Animal.Sexo = dgvMascotas.CurrentRow.Cells["Sexo"].Value.ToString();
            E_Animal.Edad = Convert.ToInt32(dgvMascotas.CurrentRow.Cells["Edad"].Value);
            E_Animal.Peso = (float) (dgvMascotas.CurrentRow.Cells["Peso"].Value);
            E_Animal.ColorPelo = dgvMascotas.CurrentRow.Cells["Color"].Value.ToString();
            E_Animal.Estado = Convert.ToInt32(dgvMascotas.CurrentRow.Cells["Estado"].Value);
            E_Animal.FechaNac = Convert.ToDateTime(dgvMascotas.CurrentRow.Cells["Fecha nacimiento"].Value).Date;
            E_Animal.Comentario = dgvMascotas.CurrentRow.Cells["Comentario"].Value.ToString();
            E_Animal.Persona = Convert.ToInt32(dgvMascotas.CurrentRow.Cells["IdPersona"].Value);
        }
    }
    
}
