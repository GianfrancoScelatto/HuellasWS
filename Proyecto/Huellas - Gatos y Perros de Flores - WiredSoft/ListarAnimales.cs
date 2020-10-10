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
        E_Animal eA = new E_Animal();
        E_Bitacora eB = new E_Bitacora();

        public bool Editar = false;
        public ListarAnimales()
        {
            InitializeComponent();
        }

        private void ListarMascotas_Load(object sender, EventArgs e)
        {
            MostrarRegistroAnimal();
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
        public void MostrarRegistroAnimal()
        {
            dgvMascotas.DataSource = brA.ListarAnimal();
        }
        private void BtnModificar_Click(object sender, EventArgs e)
        {   //esto va en el formulario de animales
            if (dgvMascotas.SelectedRows.Count > 0)
            {

                Editar = true;
                eA.IdAnimal = Convert.ToInt32(dgvMascotas.CurrentRow.Cells["ID"].Value);
                eA.NombreAnimal = dgvMascotas.CurrentRow.Cells["Nombre"].Value.ToString();
                eA.IdEspecie = Convert.ToInt32(dgvMascotas.CurrentRow.Cells["Especie"].Value);
                eA.FechaIngreso = Convert.ToDateTime(dgvMascotas.CurrentRow.Cells["Fecha de rescate"].Value).Date;
                eA.Castracion = Convert.ToBoolean(dgvMascotas.CurrentRow.Cells["Castracion"].Value);
                eA.FechaCastracion = Convert.ToDateTime(dgvMascotas.CurrentRow.Cells["Fecha de Castracion"].Value);
                eA.LugarRescate = dgvMascotas.CurrentRow.Cells["Lugar de Rescate"].Value.ToString();
                eA.Sexo = dgvMascotas.CurrentRow.Cells["Sexo"].Value.ToString();
                eA.Edad = Convert.ToInt32(dgvMascotas.CurrentRow.Cells["Edad"].Value);
                eA.Peso = Convert.ToDouble(dgvMascotas.CurrentRow.Cells["Peso"].Value);
                eA.ColorPelo = dgvMascotas.CurrentRow.Cells["Color"].Value.ToString();
                eA.Estado = Convert.ToInt32(dgvMascotas.CurrentRow.Cells["Estado"].Value);
            }
            else
                MessageBox.Show("seleccione una fila por favor");
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvMascotas.SelectedRows.Count > 0)
            {
                DialogResult opcion;
                opcion = MessageBox.Show("Quiere eliminar al animal?", "WiredSoft", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if(opcion== DialogResult.OK)
                {
                    eA.IdAnimal = Convert.ToInt32(dgvMascotas.CurrentRow.Cells[0].Value.ToString());
                    brA.BorrarAnimal(eA.IdAnimal, E_Usuario.IdUsuario, eB.IdMovimiento, eA.Estado, eB.Descripcion, eA.Deshabilitado);
                    MostrarRegistroAnimal();
                }
            }
            else
            {
                MensajeError("Seleccione el animal a borrar");
            }

        }

        private void DataMascotas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void PanelBotones_Paint(object sender, PaintEventArgs e)
        {

        }
        public void MensajeError(string Mensaje)
        {
            MessageBox.Show(Mensaje, "WiredSoft", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }//hacer clase de mensajes

        private void dataMascotas_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
    
}
