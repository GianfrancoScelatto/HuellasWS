﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Entities;

namespace Huellas___Gatos_y_Perros_de_Flores___WiredSoft
{
    public partial class MenuInicial : Form
    {
        //Este comando sirve para abrir un form dentro del Form Principal.
        private Form ActivarForm;
        public MenuInicial()
        {
            InitializeComponent();
        }

        private void MenuInicial_Load(object sender, EventArgs e)
        {
            lklblUsuario.Text = E_Usuario.Nombre;
            lblRol.Text = E_Usuario.Rol;
        }

        private void AbirFormHijo(Form FormHijo)
        {
            if (ActivarForm != null)
            {
                ActivarForm.Close();
            }
            ActivarForm = FormHijo;
            FormHijo.TopLevel = false;
            FormHijo.FormBorderStyle = FormBorderStyle.None;
            FormHijo.Dock = DockStyle.Fill;
            panelFormHijo.Controls.Add(FormHijo);
            panelFormHijo.Tag = FormHijo;
            FormHijo.BringToFront();
            FormHijo.Show();
        }
        private void btnMascotas_Click(object sender, EventArgs e)
        {
            AbirFormHijo(new ListarAnimales());
        }

        private void btnTransito_Click(object sender, EventArgs e)
        {
            AbirFormHijo(new ListarPersonas());
        }

        private void btnVeterinaria_Click(object sender, EventArgs e)
        {
            AbirFormHijo(new ListarEstablecimiento());
        }

        private void btnListaNegra_Click(object sender, EventArgs e)
        {
            AbirFormHijo(new ListarListaNegra());
        }

        private void btnVacunas_Click(object sender, EventArgs e)
        {
            AbirFormHijo(new ListarVacunaT());
        }


        private void btnFichasMedicas_Click(object sender, EventArgs e)
        {
            AbirFormHijo(new ListarFichaMedica());
        }

        private void bntContrato_Click(object sender, EventArgs e)
        {
            AbirFormHijo(new ListarContrato());
        }

        private void btnHistorial_Click(object sender, EventArgs e)
        {
            AbirFormHijo(new ListarHistorial());
        }


        private void lklblCerrarSesion_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Close();
            Login login = new Login();
            login.Show();
        }

        private void MenuInicial_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnCosto_Click(object sender, EventArgs e)
        {
           AbirFormHijo(new ListarCostos());
        }

        private void btnHistorial_Click_1(object sender, EventArgs e)
        {
            AbirFormHijo(new ListarHistorial());
        }
    }
}
