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
    public partial class Persona : Form
    {
        BR_Persona brP = new BR_Persona();
        E_Mensaje eM = new E_Mensaje();
        public bool Editar = false;
        public Persona()
        {
            InitializeComponent();
        }

        private void LimpiarForm()
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtAltura.Clear();
            txtCelular.Clear();
            txtLocalidad.Clear();
            txtDNI.Clear();
            txtMail.Clear();
            cmbSexo.SelectedIndex = 0;
        }
        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            //if (String.IsNullOrWhiteSpace(txtNombre.Text) || String.IsNullOrWhiteSpace(txtApellido.Text) || String.IsNullOrWhiteSpace(txtAltura.Text) || String.IsNullOrWhiteSpace(txtDNI.Text) || String.IsNullOrWhiteSpace(txtMail.Text) || String.IsNullOrWhiteSpace(txtUserFB.Text) || String.IsNullOrWhiteSpace(txtUserIG.Text) || String.IsNullOrWhiteSpace(txtTelefono.Text) || String.IsNullOrWhiteSpace(txtLocalidad.Text) || String.IsNullOrWhiteSpace(txtCalle.Text))
            //{//falta agregar los .text
            //    eM.MensajeError("Hay espacios vacíos.");
            //}
            //else if (Editar == true)
            //{
            //    try
            //    {
            //        if (chkCasSi.Checked == true)//Preguntar esto
            //        {
            //            brP.ModificarPersona();
            //        }
            //        else
            //            brP.ModificarPersona();

            //        LimpiarForm();
            //        Editar = false;
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show("No se pudo editar los datos por el siguiente motivo: " + ex);
            //    }
            //}
            //else
            //{
            //    try
            //    {
            //        if (chkCasSi.Checked == true)
            //        {
            //            brP.AltaPersona(1, txtNombre.Text, txtApellido.Text, txtEdad.Text, txtDNI.Text, txt, txtDNI.Text, txtCalle, txtAltura,, Convert.ToInt32(comboBox1.SelectedValue), txtTelefono.Text, txtCelular.Text, txtMail.Text, txtUserIG.Text);
            //        }
            //        else
            //            brP.AltaPersona(1, txtNombre.Text, txtApellido.Text,txtEdad.Text,txtDNI.Text,txt ,txtDNI.Text,txtCalle,txtAltura,, Convert.ToInt32(comboBox1.SelectedValue),txtTelefono.Text,txtCelular.Text,txtMail.Text,txtUserIG.Text);
            //        LimpiarForm();
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show("no se pudo insertar los datos por: " + ex);
            //    }
            //}

        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
