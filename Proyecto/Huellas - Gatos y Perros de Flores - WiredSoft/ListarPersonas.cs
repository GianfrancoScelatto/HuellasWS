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
    public partial class ListarPersonas : Form
    {
        public ListarPersonas()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form Transito = new Persona();
            Transito.Show();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {

        }
    }
}
