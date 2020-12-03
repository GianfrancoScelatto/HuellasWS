using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entities;
using BusinessRules;

namespace Huellas___Gatos_y_Perros_de_Flores___WiredSoft
{
    public partial class DetalleTrAd : Form
    {
        BR_Persona brP = new BR_Persona();

        public DetalleTrAd()
        {
            InitializeComponent();
        }

        private void DetalleTrAd_Load(object sender, EventArgs e)
        {
            brP.DetallePersona(E_Animal.Persona);
            lblNombre.Text = E_Persona.NombrePersona + ' ' + E_Persona.ApellidoPersona;
            lblDni.Text = E_Persona.DNI;
            lblDomicilio.Text = E_Persona.Domicilio;
            lblLocalidad.Text = E_Persona.Localidad;
            lblCelular.Text = E_Persona.Celular.ToString();
            lblEmail.Text = E_Persona.Email;
        }
    }
}
