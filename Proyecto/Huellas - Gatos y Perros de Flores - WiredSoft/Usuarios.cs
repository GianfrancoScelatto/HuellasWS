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
    public partial class Usuarios : Form
    {
        BR_Usuario brU = new BR_Usuario();
        E_Mensaje eM = new E_Mensaje();
        bool Editar = false;
        public Usuarios()
        {
            InitializeComponent();
        }

        private void CargarCombos()
        {
            cboPregunta.DataSource = brU.ListarPreguntas();
            cboPregunta.DisplayMember = "Pregunta";
            cboPregunta.ValueMember = "IdPregunta";

            cboRol.DataSource = brU.ListarRoles();
            cboRol.DisplayMember = "Rol";
            cboRol.ValueMember = "IdRol";
        }

        private void Usuarios_Load(object sender, EventArgs e)
        {
            CargarCombos();

            if (E_UsuarioAcceso.Editar == true)
            {
                Editar = true;
                lblID.Text = E_UsuarioAcceso.IdUsuario.ToString();
                txtUser.Text = E_UsuarioAcceso.NombreUsuario;
                txtNombre.Text = E_UsuarioAcceso.Nombre;
                txtApellido.Text = E_UsuarioAcceso.Apellido;
                txtDNI.Text = E_UsuarioAcceso.Dni;
                txtTelefono.Text = E_UsuarioAcceso.Telefono.ToString();
                cboPregunta.SelectedValue = E_UsuarioAcceso.IdPregunta;
                txtRespuesta.Text = E_UsuarioAcceso.RespuestaSeguridad;
                cboRol.SelectedValue = E_UsuarioAcceso.IdRol;
            }
            else if (E_Usuario.Editar == true)
            {
                Editar = true;
                lblID.Text = E_Usuario.IdUsuario.ToString();
                txtUser.Text = E_Usuario.NombreUsuario;
                txtNombre.Text = E_Usuario.Nombre;
                txtApellido.Text = E_Usuario.Apellido;
                txtDNI.Text = E_Usuario.Dni;
                txtTelefono.Text = E_Usuario.Telefono.ToString();
                cboPregunta.SelectedValue = E_Usuario.IdPregunta;
                txtRespuesta.Text = E_Usuario.RespuestaSeguridad;
                cboRol.SelectedValue = E_Usuario.IdRol;
            }
            else
            {
                cboPregunta.SelectedIndex = 0;
                cboRol.SelectedIndex = 0;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string clave = MD5.EncriptrarClave(txtContraseña.Text);

            if (String.IsNullOrWhiteSpace(txtUser.Text) || String.IsNullOrWhiteSpace(txtNombre.Text) || String.IsNullOrWhiteSpace(txtApellido.Text)
                || String.IsNullOrWhiteSpace(txtDNI.Text) || String.IsNullOrWhiteSpace(txtTelefono.Text) || String.IsNullOrWhiteSpace(txtRespuesta.Text))
            {
                eM.MensajeAlerta("Hay campos vacíos.");
            }
            else if (Editar == true)
            {
                try
                {
                    
                    brU.ModificarUsuario(Convert.ToInt32(lblID.Text), txtUser.Text, txtNombre.Text, txtApellido.Text, txtDNI.Text,
                    Convert.ToInt32(txtTelefono.Text), clave, Convert.ToInt32(cboRol.SelectedValue));

                    Editar = false;
                }
                catch (Exception ex)
                {
                    eM.MensajeError("Ha ocurrido un error: " + ex);
                }
                
            }
            else
            {
                try
                {
                    brU.AltaUsuario(txtUser.Text, txtNombre.Text, txtApellido.Text, txtDNI.Text, Convert.ToInt32(txtTelefono.Text),
                                        Convert.ToInt32(cboPregunta.SelectedValue), txtRespuesta.Text, clave,
                                        Convert.ToInt32(cboRol.SelectedValue));
                }
                catch (Exception ex)
                {
                    eM.MensajeError("Ha ocurrido un error: " + ex);
                }
            }
                
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtUser.Text) || String.IsNullOrWhiteSpace(txtNombre.Text) || String.IsNullOrWhiteSpace(txtApellido.Text)
                || String.IsNullOrWhiteSpace(txtDNI.Text) || String.IsNullOrWhiteSpace(txtTelefono.Text) || String.IsNullOrWhiteSpace(txtRespuesta.Text))
            {
                DialogResult preg = MessageBox.Show("¿Desea cerrar este formulario?", "WiredSoft", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (preg == DialogResult.Yes)
                {
                    Close();
                }
            }
        }
    }
}
