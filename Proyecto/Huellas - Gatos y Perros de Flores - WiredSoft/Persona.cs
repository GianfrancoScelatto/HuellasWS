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
            cmbTipoPersona.DataSource = brP.ComboTipoPersona();
            cmbTipoPersona.DisplayMember = "TipoPersona";
            cmbTipoPersona.ValueMember = "IdTipoPersona";

            cmbSexo.DataSource = brP.ComboSexo();
            cmbSexo.DisplayMember = "Sexo";
            cmbSexo.ValueMember = "IdSexo";
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
                cmbSexo.SelectedValue = E_Persona.IdSexo.ToString();
                txtTelefono.Text = E_Persona.Telefono.ToString();
                txtUser.Text = E_Persona.UsuarioFaceIg;
                chkListaNegra.Checked = E_Persona.ListaNegra;
                txtMotivo.Text = E_Persona.Motivo;

            }

            //cmbSexo.SelectedIndex = 0;
            //cmbTipoPersona.SelectedIndex = 0;

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtNombre.Text))
            {
                msj.MensajeAlerta("Hay campos vacíos.");
            }
            else
            {
                if (Editar == true)
                {
                    try
                    {
                        brP.ModificarPersona(E_Persona.IdPersona, Convert.ToInt32(cmbTipoPersona.SelectedValue), txtNombre.Text, txtApellido.Text, Convert.ToInt32(txtEdad.Text), txtDNI.Text, txtDomicilio.Text, txtLocalidad.Text, txtCP.Text, txtCalles.Text, Convert.ToInt32(txtAltura.Text), Convert.ToInt32(cmbSexo.SelectedValue), Convert.ToInt32(txtTelefono.Text), Convert.ToInt32(txtCelular.Text), txtMail.Text, txtUser.Text, chkListaNegra.Checked, txtMotivo.Text, E_UsuarioAcceso.IdUsuario);
                        Editar = false;
                    }
                    catch (Exception ex)
                    {
                        msj.MensajeError("Ha ocurrido un error." + ex);
                    }
                }
                else
                {
                    try
                    {
                        brP.AltaPersona(Convert.ToInt32(cmbTipoPersona.SelectedValue), txtNombre.Text, txtApellido.Text, Convert.ToInt32(txtEdad.Text), txtDNI.Text, txtDomicilio.Text, txtLocalidad.Text, txtCP.Text, txtCalles.Text, Convert.ToInt32(txtAltura.Text), Convert.ToInt32 (cmbSexo.SelectedValue), Convert.ToInt32(txtTelefono.Text), Convert.ToInt32(txtCelular.Text), txtMail.Text, txtUser.Text, chkListaNegra.Checked, txtMotivo.Text, E_UsuarioAcceso.IdUsuario);
                    }
                    catch (Exception ex)
                    {
                        msj.MensajeError("Ha ocurrido un error." + ex);
                    }

                }

                Close();
            }
        }


    }

}
    



