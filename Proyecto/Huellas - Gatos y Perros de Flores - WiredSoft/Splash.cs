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

        private void timerProgreso_Tick(object sender, EventArgs e)
        {
            Hide();
            Form Login = new Login();
            Login.Show();
            timerProgreso.Stop();
        }

        private void Splash_Load(object sender, EventArgs e)
        {
            timerProgreso.Interval = 3000;
            timerProgreso.Start();
        }
    }
}
