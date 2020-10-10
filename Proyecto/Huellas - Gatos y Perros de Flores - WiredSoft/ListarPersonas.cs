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
    public partial class ListarPersonas : Form
    {
        BR_Persona brP = new BR_Persona();
        E_Persona eP = new E_Persona();
        E_Mensaje eM = new E_Mensaje();
        public ListarPersonas()
        {
            InitializeComponent();
            MostrarRegistroPersona();
        }

        private void button1_Click(object sender, EventArgs e)
        {//eliminar void, ya esta en uso
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Form Persona = new Persona();
            Persona.Show();
        }
        public void MostrarRegistroPersona()
        {
            dataPersona.DataSource = brP.ListarPersona();
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            ExportarDatos(dataPersona);
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
            Form Persona = new Persona();
            Persona.Show();
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (dataPersona.SelectedRows.Count > 0)
            {
                DialogResult opcion;
                opcion = MessageBox.Show("¿Desea eliminar esta Persona?", "WiredSoft", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (opcion == DialogResult.OK)
                {

                    eP.IdPersona = Convert.ToInt32(dataPersona.CurrentRow.Cells[0].Value.ToString());
                    //brP.BajaPersona(eP.IdPersona,eP,true);//discutir parametros de funcion eliminar
                    MostrarRegistroPersona();
                }
            }
            else
            {
                eM.MensajeError("No se ha seleccionado ninguna vacuna.");
            }

        }
    }
}
