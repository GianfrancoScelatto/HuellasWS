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

        private void ListarCombos()
        {
            cmbEspecie.DataSource = brV.ListarEspecie();
            cmbEspecie.DisplayMember = "Especie";
            cmbEspecie.ValueMember = "IdEspecie";

            cmbRevacunacion.DataSource = brV.ListarTiempo();
            cmbRevacunacion.DisplayMember = "Tiempo";
            cmbRevacunacion.ValueMember = "IdTiempo";
        }

        private void Vacunas_Load(object sender, EventArgs e)
        {
            ListarCombos();

            if (E_Vacuna.Editar == true)
            {
                Editar = true;
                lblID.Text = E_Vacuna.IdVacuna.ToString();
                txtVacuna.Text = E_Vacuna.Vacuna;
                cmbEspecie.SelectedValue = E_Vacuna.IdEspecie;
                cmbRevacunacion.SelectedValue = E_Vacuna.IdTiempo;
                txtDescripcion.Text += E_Vacuna.Descripcion + Environment.NewLine;

                switch (cmbRevacunacion.SelectedIndex)
                {
                    case 0:
                        txtRevacunacion.Text = (E_Vacuna.FrecuenciaRevacunacion / 365).ToString();
                        break;
                    case 1:
                        txtRevacunacion.Text = (E_Vacuna.FrecuenciaRevacunacion / 30).ToString();
                        break;
                    case 2:
                        txtRevacunacion.Text = (E_Vacuna.FrecuenciaRevacunacion / 7).ToString();
                        break;
                    case 3:
                        txtRevacunacion.Text = E_Vacuna.FrecuenciaRevacunacion.ToString();
                        break;
                }   
            }
            else
            { 
                cmbEspecie.SelectedIndex = 0;
                cmbRevacunacion.SelectedIndex = 0;
            }
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
            
            if (String.IsNullOrWhiteSpace(txtVacuna.Text) || String.IsNullOrWhiteSpace(txtRevacunacion.Text))
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
                        brV.ModificarVacuna(E_Vacuna.IdVacuna, txtVacuna.Text, Convert.ToInt32(cmbEspecie.SelectedValue), dias,
                        Convert.ToInt32(cmbRevacunacion.SelectedValue), descripcion, E_UsuarioAcceso.IdUsuario);

                        Editar = false;
                    }
                    catch (Exception ex)
                    {
                        msj.MensajeError("Ha ocurrido un error: " + ex);
                    }
                }
                else
                {
                    try
                    {
                        brV.AltaVacuna(txtVacuna.Text, Convert.ToInt32(cmbEspecie.SelectedValue), dias, 
                        Convert.ToInt32(cmbRevacunacion.SelectedValue), descripcion, E_UsuarioAcceso.IdUsuario);
                    }
                    catch (Exception ex)
                    {
                        msj.MensajeError("Ha ocurrido un error: " + ex);
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
