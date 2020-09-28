﻿using System;
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
                ObjEntities.IdAnimal = Convert.ToInt32(dataMascotas.CurrentRow.Cells["ID"].Value);
                ObjEntities.NombreAnimal = dataMascotas.CurrentRow.Cells["Nombre"].Value.ToString();
                ObjEntities.IdEspecie =Convert.ToInt32(dataMascotas.CurrentRow.Cells["Especie"].Value);
                ObjEntities.FechaIngreso = Convert.ToDateTime(dataMascotas.CurrentRow.Cells["Fecha de rescate"].Value).Date;
                ObjEntities.Castracion= Convert.ToBoolean(dataMascotas.CurrentRow.Cells["Castracion"].Value);
                ObjEntities.FechaCastracion = Convert.ToDateTime(dataMascotas.CurrentRow.Cells["Fecha de Castracion"].Value);
                ObjEntities.LugarRescate = dataMascotas.CurrentRow.Cells["Lugar de Rescate"].Value.ToString();
                ObjEntities.Sexo = dataMascotas.CurrentRow.Cells["Sexo"].Value.ToString();
                ObjEntities.Edad =Convert.ToInt32(dataMascotas.CurrentRow.Cells["Edad"].Value);
                ObjEntities.Peso = Convert.ToDecimal(dataMascotas.CurrentRow.Cells["Peso"].Value);
                ObjEntities.ColorPelo = dataMascotas.CurrentRow.Cells["Color"].Value.ToString();
                ObjEntities.Estado = dataMascotas.CurrentRow.Cells["Estado"].Value.ToString();
            }
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

        private void dataMascotas_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
    
}
