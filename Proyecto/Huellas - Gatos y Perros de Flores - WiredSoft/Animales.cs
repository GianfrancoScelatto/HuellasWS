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
using DataAccess;
using Entities;

namespace Huellas___Gatos_y_Perros_de_Flores___WiredSoft
{
    public partial class Animales : Form
    {
        BR_Animal brA = new BR_Animal();
        BR_Seguimiento brS = new BR_Seguimiento();
        BR_FichaMedica brFM = new BR_FichaMedica();
        E_Animal eA = new E_Animal();
        E_Mensaje eM = new E_Mensaje();
        public bool Editar = false;
        string comment;

        public Animales()
        {
            InitializeComponent();
        }

        private void Mascota_Load(object sender, EventArgs e)
        {
            lblIdAnimal.Text = eA.IdAnimal.ToString();
            txtNombre.Text = eA.NombreAnimal;
            cmbEspecie.SelectedValue = eA.IdEspecie;
            dtpIngreso.Value = eA.FechaIngreso.Date;
            txtUbicacion.Text = eA.LugarRescate;
            txtEdad.Text = eA.Edad.ToString();
            dtpFechaNac.Value = eA.FechaNac.Date;
            txtPeso.Text = eA.Peso.ToString();
            txtColor.Text = eA.ColorPelo;
            cmbSexo.SelectedValue = eA.Sexo;
            cmbEstado.SelectedValue = eA.Estado;
            dtpFechaF.Value = eA.FechaDefuncion.Date;
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtNombre.Text) || String.IsNullOrWhiteSpace(txtUbicacion.Text) || String.IsNullOrWhiteSpace(txtEdad.Text) || String.IsNullOrWhiteSpace(txtPeso.Text) || String.IsNullOrWhiteSpace(txtColor.Text))
            {
                eM.MensajeError("Hay espacios vacíos.");
            }
            else if (Editar == true)
            {
                try
                {
                    comment += txtComentario.Text + Environment.NewLine;

                    if (chkCasSi.Checked == true)
                    {
                        brA.ModificarAnimal(Convert.ToInt32(lblIdAnimal.Text), Convert.ToInt32(cmbEspecie.SelectedValue), txtUbicacion.Text, Convert.ToByte(picB1.ImageLocation),
                                                        Convert.ToByte(picB2.ImageLocation), txtNombre.Text, Convert.ToInt32(txtEdad.Text), cmbSexo.SelectedText, chkCasSi.Checked, txtColor.Text, Convert.ToInt64(txtPeso.Text),
                                                        comment, Convert.ToInt32(cmbEstado.SelectedValue), dtpIngreso.Value.Date);
                    }
                    else
                        brA.ModificarAnimal(Convert.ToInt32(lblIdAnimal.Text), Convert.ToInt32(cmbEspecie.SelectedValue), txtUbicacion.Text, Convert.ToByte(picB1.ImageLocation),
                                                        Convert.ToByte(picB2.ImageLocation), txtNombre.Text, Convert.ToInt32(txtEdad.Text), cmbSexo.SelectedText, chkCasNo.Checked, txtColor.Text, Convert.ToInt64(txtPeso.Text), txtComentario.Text,
                                                        Convert.ToInt32(cmbEstado.SelectedValue), dtpIngreso.Value.Date);

                    LimpiarForm();
                    Editar = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo editar los datos por el siguiente motivo: " + ex);
                }
            }
            else
            {
                try
                {
                    if (chkCasSi.Checked == true)
                    {
                        brA.AltaAnimal(Convert.ToInt32(cmbEspecie.SelectedValue), txtUbicacion.Text, Convert.ToByte(picB1.ImageLocation),
                                                        Convert.ToByte(picB2.ImageLocation), txtNombre.Text, Convert.ToInt32(txtEdad.Text), cmbSexo.SelectedText, chkCasSi.Checked, txtColor.Text, Convert.ToInt64(txtPeso.Text),
                                                        txtComentario.Text, Convert.ToInt32(cmbEstado.SelectedValue), dtpIngreso.Value.Date);
                    }
                    else
                        brA.AltaAnimal(Convert.ToInt32(cmbEspecie.SelectedValue), txtUbicacion.Text, Convert.ToByte(picB1.ImageLocation),
                                                        Convert.ToByte(picB2.ImageLocation), txtNombre.Text, Convert.ToInt32(txtEdad.Text), cmbSexo.SelectedText, chkCasNo.Checked, txtColor.Text, Convert.ToInt64(txtPeso.Text), txtComentario.Text,
                                                        Convert.ToInt32(cmbEstado.SelectedValue), dtpIngreso.Value.Date);
                    LimpiarForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("no se pudo insertar los datos por: " + ex);
                }
            }
        }

        private void btnGuardarSeg_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtDetalle.Text))
            {
                eM.MensajeError("El campo de detalle se encuentra vacío.");
            }
            else
                brS.GuardarSeguimiento(txtDetalle.Text, dtpAcontecimiento.Value.Date);
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

        }

        private void lklblPersona_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form VerMas = new VerMasAnimal();
            VerMas.Show();
        }

        private void LimpiarForm()
        {
            txtBuscar.Clear();
            txtColor.Text = "";
            txtUbicacion.Text = "";
            txtPeso.Clear();
            txtEdad.Clear();
            txtNombre.Clear();
            cmbEspecie.SelectedIndex = 1;
            cmbEstado.SelectedIndex = 1;
            cmbSexo.SelectedIndex = 1;
        }

        private void btnImagen_Click(object sender, EventArgs e)
        {
            OpenFileDialog faI = new OpenFileDialog();
            OpenFileDialog faA = new OpenFileDialog();
            DialogResult rsI = faI.ShowDialog();
            DialogResult rsA = faA.ShowDialog();
            if (rsA == DialogResult.OK && rsI == DialogResult.OK)
            {
                picB1.Image = Image.FromFile(faI.FileName);
                picB1.Image = Image.FromFile(faA.FileName);
            }

        }

        private void tbcDatosMasc_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tbcDatosMasc.SelectedIndex)
            {
                case 1:
                    btnGuardarDatos.Visible = true;
                    btnCancelarDatos.Visible = true;
                    break;
                case 2:
                    btnGuardarDatos.Visible = true;
                    btnCancelarDatos.Visible = true;
                    break;
                case 3:
                    btnGuardarDatos.Visible = false;
                    btnCancelarDatos.Visible = false;
                    break;
            }
        }

        private void dtpFiltro_ValueChanged(object sender, EventArgs e)
        {
            brS.FiltrarSeguimiento(dtpFiltro.Value.Date);
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            brFM.FiltrarFichaMedica(txtBuscar.Text, dtpFichaMedica.Value.Date);
        }

        private void dtpFichaMedica_ValueChanged(object sender, EventArgs e)
        {
            brFM.FiltrarFichaMedica(txtBuscar.Text, dtpFichaMedica.Value.Date);
        }

        
    }
}
            


