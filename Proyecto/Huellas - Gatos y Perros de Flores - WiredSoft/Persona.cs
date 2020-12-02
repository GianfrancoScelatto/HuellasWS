using BusinessRules;
using Entities;
using System;
using System.Windows.Forms;

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
                txtApellido.Text = E_Persona.ApellidoPersona;
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
                txtMotivo.Text = E_Persona.Motivo;

                if (E_Persona.ListaNegra == true)
                {
                    chkSi.Checked = true;
                }
                else
                    chkNo.Checked = true;
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
                        if (chkSi.Checked == true)
                        {
                            brP.ModificarPersona(E_Persona.IdPersona, Convert.ToInt32(cmbTipoPersona.SelectedValue), txtNombre.Text, txtApellido.Text, Convert.ToInt32(txtEdad.Text), txtDNI.Text, txtDomicilio.Text, txtLocalidad.Text, txtCP.Text, txtCalles.Text, Convert.ToInt32(txtAltura.Text), Convert.ToInt32(cmbSexo.SelectedValue), Convert.ToInt32(txtTelefono.Text), Convert.ToInt32(txtCelular.Text), txtMail.Text, txtUser.Text, chkSi.Checked, txtMotivo.Text, E_UsuarioAcceso.IdUsuario);
                        }

                        else
                            brP.ModificarPersona(E_Persona.IdPersona, Convert.ToInt32(cmbTipoPersona.SelectedValue), txtNombre.Text, txtApellido.Text, Convert.ToInt32(txtEdad.Text), txtDNI.Text, txtDomicilio.Text, txtLocalidad.Text, txtCP.Text, txtCalles.Text, Convert.ToInt32(txtAltura.Text), Convert.ToInt32(cmbSexo.SelectedValue), Convert.ToInt32(txtTelefono.Text), Convert.ToInt32(txtCelular.Text), txtMail.Text, txtUser.Text, chkNo.Checked, txtMotivo.Text, E_UsuarioAcceso.IdUsuario);
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
                        if (chkSi.Checked == true)
                        {
                            brP.AltaPersona(Convert.ToInt32(cmbTipoPersona.SelectedValue), txtNombre.Text, txtApellido.Text, Convert.ToInt32(txtEdad.Text), txtDNI.Text, txtDomicilio.Text, txtLocalidad.Text, txtCP.Text, txtCalles.Text, Convert.ToInt32(txtAltura.Text), Convert.ToInt32(cmbSexo.SelectedValue), Convert.ToInt32(txtTelefono.Text), Convert.ToInt32(txtCelular.Text), txtMail.Text, txtUser.Text, chkSi.Checked, txtMotivo.Text, E_UsuarioAcceso.IdUsuario);
                        }
                        else
                            brP.AltaPersona(Convert.ToInt32(cmbTipoPersona.SelectedValue), txtNombre.Text, txtApellido.Text, Convert.ToInt32(txtEdad.Text), txtDNI.Text, txtDomicilio.Text, txtLocalidad.Text, txtCP.Text, txtCalles.Text, Convert.ToInt32(txtAltura.Text), Convert.ToInt32(cmbSexo.SelectedValue), Convert.ToInt32(txtTelefono.Text), Convert.ToInt32(txtCelular.Text), txtMail.Text, txtUser.Text, chkNo.Checked, txtMotivo.Text, E_UsuarioAcceso.IdUsuario);
                    }
                    catch (Exception ex)
                    {
                        msj.MensajeError("Ha ocurrido un error." + ex);
                    }

                }

                Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }

}



