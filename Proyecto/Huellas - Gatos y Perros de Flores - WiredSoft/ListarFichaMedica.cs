using System;
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
    public partial class ListarFichaMedica : Form
    {
        public ListarFichaMedica()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Form FichaMedica = new FichaMedica();
            FichaMedica.Show();
        }
    }
}
