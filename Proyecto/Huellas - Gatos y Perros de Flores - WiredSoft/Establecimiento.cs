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
    public partial class Establecimiento : Form

    {
        public bool Editar;
        BR_Establecimiento brE = new BR_Establecimiento();
        E_Mensaje msj = new E_Mensaje();
        public Establecimiento()
        {
            InitializeComponent();
        }


        private void ListarCombos()
        {
            cmbEstablecimiento.DataSource = brE.MostrarEstablecimiento();
            cmbEstablecimiento.DisplayMember = "Establecimiento";
            cmbEstablecimiento.ValueMember = "IdTipoEstablecimiento";
        }

        
        private void Establecimiento_Load(object sender, EventArgs e)
        {
            ListarCombos();
            if (E_Establecimiento.Editar == true)
            {
                
                Editar = true;
                lblD.Text = E_Establecimiento.IdEstablecimiento.ToString();
                txtNombre.Text = E_Establecimiento.Nombre;
                txtHoraAtencion.Text = E_Establecimiento.HorarioAtencion;
                txtLocalidad.Text = E_Establecimiento.Localidad;
                txtCP.Text = E_Establecimiento.CodigoPostal;
                txtAltura.Text = E_Establecimiento.Altura.ToString();
                chkInternacion.Checked = E_Establecimiento.Internacion;
                
            }

            cmbEstablecimiento.SelectedIndex = 0;
        }

    }
}
