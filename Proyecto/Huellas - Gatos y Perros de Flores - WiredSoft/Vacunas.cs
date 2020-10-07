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

        private void ListarEspecies()
        {
            {
                cmbEspecie.DataSource = brV.ListarEspecie();
                cmbEspecie.DisplayMember = "Especie";
                cmbEspecie.ValueMember = "IdEspecie";
            }
        }

        private void Vacunas_Load(object sender, EventArgs e)
        {
            ListarEspecies();
            cmbEspecie.SelectedIndex = 0;
            cmbRevacunacion.SelectedIndex = 0;   
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            int dias = 0;
            
            switch (cmbRevacunacion.SelectedIndex)
            {
                    case 1:
                        dias = Convert.ToInt32(txtRevacunacion.Text) * 30;
                        break;
                    case 2:
                        dias = Convert.ToInt32(txtRevacunacion.Text) * 7;
                        break;
                    case 3:
                        dias = Convert.ToInt32(txtRevacunacion.Text);
                        break;
                    case 4:
                        dias = Convert.ToInt32(txtRevacunacion.Text) * 365;
                        break;
            }
            
            if (String.IsNullOrWhiteSpace(txtVacuna.Text) || String.IsNullOrWhiteSpace(txtRevacunacion.Text) || String.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                MessageBox.Show("", "WiredSoft", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                brV.Altavacuna(txtVacuna.Text, Convert.ToInt32(cmbEspecie.SelectedValue), dias,txtDescripcion.Text,1,1);// problema en el combo
            }
             
        }
        
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
            lstV.Show();
        }
    }
}
