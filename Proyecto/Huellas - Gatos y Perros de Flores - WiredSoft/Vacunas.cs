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
        BR_Vacunas brV = new BR_Vacunas();
        E_Mensaje msj = new E_Mensaje();
        string descripcion;
        public bool Editar = false;
        
        public Vacunas()
        {
            InitializeComponent();
        }

        private void ListarEspecies()
        {
            cmbEspecie.DataSource = brV.ListarEspecie();
            cmbEspecie.DisplayMember = "Especie";
            cmbEspecie.ValueMember = "IdEspecie";
        }

        private void Vacunas_Load(object sender, EventArgs e)
        {
            ListarEspecies();

            if (E_Vacuna.Editar == true)
            {
                Editar = true;
                lblID.Text = E_Vacuna.IdVacuna.ToString();
                txtVacuna.Text = E_Vacuna.Vacuna;
                cmbEspecie.SelectedValue = E_Vacuna.IdMascota;
                txtRevacunacion.Text = E_Vacuna.FrecuenciaRevacunacion.ToString();
                txtDescripcion.Text += E_Vacuna.Descripcion + Environment.NewLine;
            }
            cmbEspecie.Items.Insert(-1, "Seleccione un valor");
            cmbRevacunacion.Items.Insert(-1, "Seleccione un valor");
            cmbEspecie.SelectedIndex = -1;
            cmbRevacunacion.SelectedIndex = -1;   
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            int dias = 0;
            
            switch (cmbRevacunacion.SelectedIndex)
            {
                    case 0:
                        dias = Convert.ToInt32(txtRevacunacion.Text) * 365;
                        break;
                    case 1:
                        dias = Convert.ToInt32(txtRevacunacion.Text) * 30;
                        break;
                    case 2:
                        dias = Convert.ToInt32(txtRevacunacion.Text) * 7;
                        break;
                    case 3:
                        dias = Convert.ToInt32(txtRevacunacion.Text);
                        break;
            }
            
            if (String.IsNullOrWhiteSpace(txtVacuna.Text) || cmbEspecie.SelectedIndex == -1 || String.IsNullOrWhiteSpace(txtRevacunacion.Text)
                || cmbRevacunacion.SelectedIndex == -1 || String.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                msj.MensajeAlerta("Hay campos vacíos.");
            }
            else
            {
                descripcion += txtDescripcion.Text + Environment.NewLine;
                if (Editar == true)
                {
                    try
                    {
                        brV.ModificarVacuna(E_Vacuna.IdVacuna, txtVacuna.Text, Convert.ToInt32(cmbEspecie.SelectedValue), dias, descripcion, E_Usuario.IdUsuario);
                        Editar = false;
                    }
                    catch
                    {
                        msj.MensajeError("Ha ocurrido un error.");
                    }
                }
                else
                {
                    try
                    {
                        brV.AltaVacuna(txtVacuna.Text, Convert.ToInt32(cmbEspecie.SelectedValue), dias, descripcion, E_Usuario.IdUsuario);
                    }
                    catch
                    {
                        msj.MensajeError("Ha ocurrido un error.");
                    }
                    
                }
                
                Close();
            }
        }
        
        private void btnCancelar_Click(object sender, EventArgs e)
         {
            if (txtVacuna.TextLength > 0 || txtRevacunacion.TextLength > 0 || txtDescripcion.TextLength > 0)
            {
                DialogResult preg = MessageBox.Show("¿Desea cerrar este formulario?", "WiredSoft", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (preg == DialogResult.Yes)
                {
                    Close();
                }
            }     
        }
    }
}
