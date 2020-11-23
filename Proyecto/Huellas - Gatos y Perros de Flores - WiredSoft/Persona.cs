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
        E_Mensaje msj = new E_Mensaje();
        public bool Editar = false;
        public Persona()
        {
            InitializeComponent();
        }


        private void ListarCombos()
        {
            cmbSexo.DataSource = brP.ComboPersona();
            cmbSexo.DisplayMember = "Sexo";
        }


        private void Persona_Load(object sender, EventArgs e)
        {
            ListarCombos();
            if (E_Persona.Editar == true)
            {
                Editar = true;
                lblID.Text = E_Persona.IdPersona.ToString();
                cmbTipoPersona.SelectedValue = E_Persona.IdTipoPersona.ToString();
                txtNombre.Text = E_Persona.NombrePersona;
                txtEdad.Text = E_Persona.Edad.ToString();
                txtDNI.Text = E_Persona.DNI;
                txtDomicilio.Text = E_Persona.Domicilio;
                txtAltura.Text = E_Persona.Altura.ToString();
                txtCP.Text = E_Persona.CodigoPostal;
                txtLocalidad.Text = E_Persona.Localidad;
                txtCalles.Text = E_Persona.Calles;
                txtCelular.Text = E_Persona.Celular.ToString();
                txtMail.Text = E_Persona.Email;
                cmbSexo.SelectedValue = E_Persona.Sexo;
                txtTelefono.Text = E_Persona.Telefono.ToString();
                txtUser.Text = E_Persona.UsuarioFaceIg;

            }

            cmbSexo.SelectedIndex = 0;
            cmbTipoPersona.SelectedIndex = 0;

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtNombre.Text))
            {
                msj.MensajeAlerta("Hay campos vacíos");
            }

            if (Editar == true)
                try
                {
                   
                    brP.ModificarPersona(E_Persona.IdPersona, Convert.ToInt32(cmbTipoPersona.SelectedValue), txtNombre.Text, txtApellido.Text, Convert.ToInt32(txtEdad.Text), txtDNI.Text, txtDomicilio.Text, Convert.ToInt32(txtAltura.Text), txtCP.Text, txtLocalidad.Text, txtCalles.Text, Convert.ToInt32(txtCelular.Text), txtMail.Text, Convert.ToInt32(cmbSexo.SelectedValue), Convert.ToInt32(txtTelefono.Text), txtUser.Text);
                }

                catch (Exception ex)
                {
                    msj.MensajeError("Ha ocurrido un error");
                }
        }


    }

}
    



