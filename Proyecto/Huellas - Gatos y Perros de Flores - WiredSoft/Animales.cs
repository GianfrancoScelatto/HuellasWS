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
using DataAccess;
using Entities;

namespace Huellas___Gatos_y_Perros_de_Flores___WiredSoft
{
    public partial class Animales : Form
    {
        BR_Vacunas brV = new BR_Vacunas();
        BR_Animal brA = new BR_Animal();
        BR_Seguimiento brS = new BR_Seguimiento();
        BR_FichaMedica brFM = new BR_FichaMedica();
        E_Mensaje eM = new E_Mensaje();
        public bool Editar = false;
        string comment;

        public Animales()
        {
            InitializeComponent();
        }

        private void CargarCombos()
        {
            cmbEspecie.DataSource = brV.ListarEspecie();
            cmbEspecie.DisplayMember = "Especie";
            cmbEspecie.ValueMember = "IdEspecie";

            cmbEstado.DataSource = brA.ListarEstado();
            cmbEstado.DisplayMember = "Estado";
            cmbEstado.ValueMember = "IdEstado";
        }

        private void Mascota_Load(object sender, EventArgs e)
        {
            CargarCombos();
             
            if (E_Animal.Editar == true)
            {
                Editar = true;
                lblIdAnimal.Text = E_Animal.IdAnimal.ToString();
                txtNombre.Text = E_Animal.NombreAnimal;
                cmbEspecie.SelectedValue = E_Animal.IdEspecie;
                dtpIngreso.Value = E_Animal.FechaIngreso.Date;
                txtUbicacion.Text = E_Animal.LugarRescate;
                txtEdad.Text = E_Animal.Edad.ToString();
                dtpFechaNac.Value = E_Animal.FechaNac.Date;
                txtPeso.Text = E_Animal.Peso.ToString();
                txtColor.Text = E_Animal.ColorPelo;
                cmbSexo.SelectedValue = E_Animal.Sexo;
                cmbEstado.SelectedValue = E_Animal.Estado;
                txtComentario.Text = E_Animal.Comentario;
                dtpCastracion.Value = Convert.ToDateTime(E_Animal.FechaCastracion).Date;

                if (E_Animal.Castracion == true)
                {
                    chkCasSi.Checked = true;
                }
                else
                    chkCasNo.Checked = true;

                //if (cmbEstado.Text == "Fallecido")
                //{
                //    dtpFechaF.Enabled = true;
                //}
                //else
                //    dtpFechaF.Enabled = false;

                //dtpFechaF.Value = E_Animal.FechaDefuncion.Date;
                cmbEspecie.SelectedIndex = 0;
                cmbSexo.SelectedIndex = 0;
                cmbEstado.SelectedIndex = 0;
            }
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
                        brA.AltaAnimal(1,Convert.ToInt32(cmbEspecie.SelectedValue), txtUbicacion.Text, Convert.ToByte(picB1.ImageLocation),
                                                        Convert.ToByte(picB2.ImageLocation), txtNombre.Text, Convert.ToInt32(txtEdad.Text), cmbSexo.SelectedText, chkCasSi.Checked, txtColor.Text, Convert.ToDouble(txtPeso.Text),
                                                        txtComentario.Text, Convert.ToInt32(cmbEstado.SelectedValue), dtpIngreso.Value.Date, dtpFechaNac.Value.Date);
                    }
                    else
                        brA.AltaAnimal(1,Convert.ToInt32(cmbEspecie.SelectedValue), txtUbicacion.Text, Convert.ToByte(picB1.ImageLocation),
                                                        Convert.ToByte(picB2.ImageLocation), txtNombre.Text, Convert.ToInt32(txtEdad.Text), cmbSexo.SelectedText, chkCasNo.Checked, txtColor.Text, Convert.ToDouble(txtPeso.Text), txtComentario.Text,
                                                        Convert.ToInt32(cmbEstado.SelectedValue), dtpIngreso.Value.Date, dtpFechaNac.Value.Date);
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
                case 0:
                    btnGuardarDatos.Visible = true;
                    btnCancelarDatos.Visible = true;
                    break;
                case 1:
                    btnGuardarDatos.Visible = true;
                    btnCancelarDatos.Visible = true;
                    break;
                case 2:
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
            


