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
    public partial class ListarCostos : Form
    {
        BR_Costo brC = new BR_Costo();
        public ListarCostos()
        {
            InitializeComponent();
        }
        public void MostrarCostos()
        {
            dgvCosto.DataSource = brC.MostrarCosto();
        }
        private void ListarCostos_Load(object sender, EventArgs e)
        {
            MostrarCostos();
            
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Form Gasto = new Costos();
            Gasto.Show();
        }
    }
}
