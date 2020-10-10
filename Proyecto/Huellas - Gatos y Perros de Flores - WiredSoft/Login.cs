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
                try
                {
                    
                    //string Clave = MD5.EncriptrarClave(txtContraseña.Text);
                    //brU.AccesoUsuario(txtUsuario.Text, Clave);
                    brU.AccesoUsuario(txtUsuario.Text, txtContraseña.Text);
                    pgbIngresar.Visible = true;
                    pgbIngresar.Value = pgbIngresar.Value + 5;
                    tmLogin.Start();
                }
                catch
                {
                    eM.MensajeError("Los datos ingresados son erróneos.");
                }
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
            }
        }

        private void tmLogin_Tick(object sender, EventArgs e)
        {
            pgbIngresar.Value = pgbIngresar.Value + 10;
            
            if (pgbIngresar.Value > 90)
            {
                tmLogin.Stop();
                MenuInicial menu = new MenuInicial();
                menu.Show();
                Hide();
            }
        }
    }
}
