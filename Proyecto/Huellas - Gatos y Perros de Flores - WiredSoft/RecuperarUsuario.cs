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
    public partial class RecuperarUsuario : Form
    {
        BR_Usuario brU = new BR_Usuario();
        E_Mensaje msj = new E_Mensaje();
        public RecuperarUsuario()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtUser.Text) || String.IsNullOrWhiteSpace(txtRespuesta.Text) || 
                String.IsNullOrWhiteSpace(txtContraseña.Text) || String.IsNullOrWhiteSpace(txtValidarContraseña.Text))
            {
                msj.MensajeAlerta("Hay campos vacíos.");
            }
            else if (txtContraseña.Text != txtValidarContraseña.Text)
            {
                msj.MensajeAlerta("Las contraseñas no coinciden.");
            }
            else
            {   
                try
                {
                    string Clave = MD5.EncriptrarClave(txtValidarContraseña.Text);
                    brU.RecuperarUsuario(txtUser.Text, txtRespuesta.Text, Clave);
                    Close();
                }
                catch
                {
                    msj.MensajeError("Los datos ingresados son incorrectos.");
                }
                
            }
        }

        private void txtUser_TextChanged(object sender, EventArgs e)
        {
            cmbPregunta.DataSource = brU.TraerPregunta(txtUser.Text);
            cmbPregunta.DisplayMember = "Pregunta";
            cmbPregunta.ValueMember = "IdPregunta";
        }

        private void chkContraseña_CheckedChanged(object sender, EventArgs e)
        {
            if (chkContraseña.Checked == true)
            {
                txtContraseña.UseSystemPasswordChar = false;
                txtValidarContraseña.UseSystemPasswordChar = false;
            }
            else
            {
                txtContraseña.UseSystemPasswordChar = true;
                txtValidarContraseña.UseSystemPasswordChar = true;
            }
        }
    }
}
