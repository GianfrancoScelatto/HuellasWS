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

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //revisar el modo de ingreso de la frecuencia de vacuna
            if (String.IsNullOrWhiteSpace(txtVacuna.Text) || 
            {

            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
            lstV.Show();
        }
    }
}
