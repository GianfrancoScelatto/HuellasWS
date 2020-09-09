﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Huellas___Gatos_y_Perros_de_Flores___WiredSoft
{
    public partial class MenuInicial : Form
    {
        public MenuInicial()
        {
            InitializeComponent();
        }

        private void btnMascotas_Click(object sender, EventArgs e)
        {
            AbirFormHijo(new ListarAnimales());
        }

        private void btnTransito_Click(object sender, EventArgs e)
        {
            AbirFormHijo(new ListarPersonas());
        }

        private void btnListaNegra_Click(object sender, EventArgs e)
        {

        }

        private void panelMenuLateral_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnVeterinaria_Click(object sender, EventArgs e)
        {

        }

        private void btnAdoptantes_Click(object sender, EventArgs e)
        {
            AbirFormHijo(new ListarPersonas());
        }

        
        //Este comando sirve para abrir un form dentro del Form Principal.
        private Form ActivarForm = null;
        private void AbirFormHijo(Form FormHijo)
        {
            if (ActivarForm != null)
                ActivarForm.Close();
            ActivarForm = FormHijo;
            FormHijo.TopLevel = false;
            FormHijo.FormBorderStyle = FormBorderStyle.None;
            FormHijo.Dock = DockStyle.Fill;
            panelFormHijo.Controls.Add(FormHijo);
            panelFormHijo.Tag = FormHijo;
            FormHijo.BringToFront();
            FormHijo.Show();


        }

        private void MenuInicial_Load(object sender, EventArgs e)
        {

        }

        private void btnFichasMedicas_Click(object sender, EventArgs e)
        {

        }

        private void panelFormHijo_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
