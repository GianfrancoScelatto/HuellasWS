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
    public partial class Splash : Form
    {
        public Splash()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            panelProgreso.Width += 3;
            if (panelProgreso.Width >700)
            {
                timerProgreso.Stop();
                MenuInicial menu = new MenuInicial();
                menu.Show();
                this.Hide();

            }
        }
    }
}
