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
        BR_Animal ObjBusinessRules = new BR_Animal();
        E_Animal ObjEntities = new E_Animal();
        public bool Editar = false;
        public Animales()
        {
            InitializeComponent();
        }

        private void Mascota_Load(object sender, EventArgs e)
        {

        }

        private void llblPersona_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form VerMas = new VerMasAnimal();
            VerMas.Show();
        }

        public void MensajeConfirmacion(string Mensaje)
        {
            MessageBox.Show(Mensaje, "WiredSoft", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void LimpiarForm()
        {
            txtBuscar.Clear();
            txtColor.Text = "";
            txtUbicacion.Text = "";
            txtPeso.Clear();
            txtEdad.Clear();
            txtNombre.Clear();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtNombre.Text) || String.IsNullOrWhiteSpace(txtUbicacion.Text) || String.IsNullOrWhiteSpace(txtEdad.Text) || String.IsNullOrWhiteSpace(txtPeso.Text) || String.IsNullOrWhiteSpace(txtColor.Text))
            {
                MensajeConfirmacion;
            }
            else if (Editar == true)
            {
                try
                {
                    if (chkCasSi.Checked == true)
                    {
                        ObjBusinessRules.ModificarAnimal(Convert.ToInt32(lblIdAnimal.Text), Convert.ToInt32(cmbEspecie.SelectedValue), txtUbicacion.Text, Convert.ToByte(picB1.ImageLocation),
                                                        Convert.ToByte(picB2.ImageLocation), txtNombre.Text, Convert.ToInt32(txtEdad.Text), cmbSexo.SelectedText, chkCasSi.Checked, txtColor.Text, Convert.ToInt64(txtPeso.Text),
                                                        txtComentario.Text, Convert.ToInt32(cmbEstado.SelectedValue), dtpIngreso.Value.Date);
                    }
                    else
                        ObjBusinessRules.ModificarAnimal(Convert.ToInt32(lblIdAnimal.Text), Convert.ToInt32(cmbEspecie.SelectedValue), txtUbicacion.Text, Convert.ToByte(picB1.ImageLocation),
                                                        Convert.ToByte(picB2.ImageLocation), txtNombre.Text, Convert.ToInt32(txtEdad.Text), cmbSexo.SelectedText, chkCasNo.Checked, txtColor.Text, Convert.ToInt64(txtPeso.Text), txtComentario.Text,
                                                        Convert.ToInt32(cmbEstado.SelectedValue), dtpIngreso.Value.Date);

                    MessageBox.Show("se edito correctamente");
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
                        ObjBusinessRules.AltaAnimal(Convert.ToInt32(cmbEspecie.SelectedValue), txtUbicacion.Text, Convert.ToByte(picB1.ImageLocation),
                                                        Convert.ToByte(picB2.ImageLocation), txtNombre.Text, Convert.ToInt32(txtEdad.Text), cmbSexo.SelectedText, chkCasSi.Checked, txtColor.Text, Convert.ToInt64(txtPeso.Text),
                                                        txtComentario.Text, Convert.ToInt32(cmbEstado.SelectedValue), dtpIngreso.Value.Date);
                    }
                    else
                        ObjBusinessRules.AltaAnimal(Convert.ToInt32(cmbEspecie.SelectedValue), txtUbicacion.Text, Convert.ToByte(picB1.ImageLocation),
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
    }
}
            


