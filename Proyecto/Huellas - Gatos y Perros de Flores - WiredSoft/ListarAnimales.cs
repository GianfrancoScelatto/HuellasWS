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
        readonly BR_Animal ObjBusinessRules = new BR_Animal();
        readonly E_Animal ObjEntities = new E_Animal();
        public bool Editar = false;
        public ListarAnimales()
        {
            InitializeComponent();
        }

        private void ListarMascotas_Load(object sender, EventArgs e)
        {
            MostrarRegistroAnimal();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form Mascota = new Animales();
            Mascota.Show();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {

        }

        private void BtnExportar_Click(object sender, EventArgs e)
        {
            ExportarDatos(dataMascotas);
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
            dataMascotas.DataSource = BR_Animal.ListarAnimal();
        }
        private void BtnModificar_Click(object sender, EventArgs e)
        {

        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (dataMascotas.SelectedRows.Count > 0)
            {
                DialogResult opcion;
                opcion = MessageBox.Show("Quiere eliminar al animal?", "WiredSoft", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if(opcion== DialogResult.OK)
                {

                    ObjEntities.IdAnimal = Convert.ToInt32(dataMascotas.CurrentRow.Cells[0].Value.ToString());
                    //ObjBusinessRules.Borrar_Animal(ObjEntities);
                    MensajeConfirmacion("Se elimino correctamente al animal");
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

        private void BtnModificar_Click_1(object sender, EventArgs e)
        {
            if (dataMascotas.SelectedRows.Count > 0)
            {
                Editar = true;
                txtNombre.Text = dataMascotas.CurrentRow.Cells["Nombre"].Value.ToString();
                txtEspecie.Text = dataMascotas.CurrentRow.Cells["Especie"].Value.ToString();
                txt.UbicacionText = dataMascotas.CurrentRow.Cells["Ubicacion"].Value.ToString();
                txt.Sexo Text = dataMascotas.CurrentRow.Cells["Sexo"].Value.ToString();
                txt.Edad Text = dataMascotas.CurrentRow.Cells["Edad"].Value.ToString();
                txt.Peso = dataMascotas.CurrentRow.Cells["Peso"].Value.ToString();
                txt.ColorPelo = dataMascotas.CurrentRow.Cells["ColorPelo"].Value.ToString();
                txt.Estado = dataMascotas.CurrentRow.Cells["Estado"].Value.ToString();
            }//No me toma los txt porque estan en otro form y el boton esta por fuera
            else
                MessageBox.Show("seleccione una fila por favor");
        }
        public void MensajeConfirmacion(string Mensaje)
        {
            MessageBox.Show(Mensaje, "WiredSoft",MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public void MensajeError(string Mensaje)
        {
            MessageBox.Show(Mensaje, "WiredSoft", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
    
}
