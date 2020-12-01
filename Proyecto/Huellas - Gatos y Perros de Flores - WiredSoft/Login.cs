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
    public partial class Login : Form
    {
        BR_Usuario brU = new BR_Usuario();
        E_Mensaje eM = new E_Mensaje();
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void BtnIngresar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtUsuario.Text))
            {
                eM.MensajeAlerta("Debe ingresar su usuario.");
                txtUsuario.Focus();
            }
            else if (String.IsNullOrWhiteSpace(txtContraseña.Text))
            {
                eM.MensajeAlerta("Debe ingresar su contraseña.");
                txtContraseña.Focus();
            }
            else
            {
                //string Clave = MD5.EncriptrarClave(txtContraseña.Text);
                //bool ingreso = brU.AccesoUsuario(txtUsuario.Text, Clave);
                bool ingreso = brU.AccesoUsuario(txtUsuario.Text, txtContraseña.Text);

                if (ingreso == false)
                {
                    eM.MensajeError("Los datos ingresados son erróneos.");
                }
                else
                {
                    MenuInicial menu = new MenuInicial();
                    menu.Show();
                    Hide();
                }
            }
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult preg = MessageBox.Show("¿Desea salir del programa?", "WiredSoft", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (preg == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void chkContraseña_CheckedChanged(object sender, EventArgs e)
        {
            if (chkContraseña.Checked == true)
            {
                txtContraseña.UseSystemPasswordChar = false;
            }
            else
                txtContraseña.UseSystemPasswordChar = true;
        }

        private void lklblContraseña_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RecuperarUsuario recup = new RecuperarUsuario();
            recup.Show();
        }

        private void Login_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BtnIngresar.PerformClick();
                e.SuppressKeyPress = true;
            }
        }

        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            E_Validaciones.SoloLetras(e);
        }

        private void txtContraseña_KeyPress(object sender, KeyPressEventArgs e)
        {
            E_Validaciones.LetrasNumeros(e);
        }
    }
}
