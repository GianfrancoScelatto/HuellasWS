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
    public partial class Vacunas : Form
    {
        ListarVacuna lstV = new ListarVacuna();
        BR_Vacunas brV = new BR_Vacunas();
        
        public Vacunas()
        {
            InitializeComponent();
        }

        private void Vacunas_Load(object sender, EventArgs e)
        {
            cmbEspecie.SelectedIndex = 1;
            cmbRevacunacion.SelectedIndex = 1;
            
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            int dias = 0;
            
            switch (cmbRevacunacion.SelectedIndex)
            {
                    case 1:
                        dias = Convert.ToInt32(txtRevacunacion.Text) * 365;
                        break;
                    case 2:
                        dias = Convert.ToInt32(txtRevacunacion.Text) * 30;
                        break;
                    case 3:
                        dias = Convert.ToInt32(txtRevacunacion.Text) * 7;
                        break;
                    case 4:
                        dias = Convert.ToInt32(txtRevacunacion.Text);
                        break;
            }
            
            if (String.IsNullOrWhiteSpace(txtVacuna.Text) || String.IsNullOrWhiteSpace(txtRevacunacion.Text) || String.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                MessageBox.Show("", "WiredSoft", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                brV.Altavacunas(txtVacuna.Text, Convert.ToInt32(cmbEspecie.SelectedValue),dias,txtDescripcion.Text,1,1);
            }
             
        }
        
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
            lstV.Show();
        }
    }
}
