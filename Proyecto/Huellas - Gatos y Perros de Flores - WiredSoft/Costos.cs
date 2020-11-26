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
    public partial class Costos : Form
    {
        BR_Costo brC = new BR_Costo();
        E_Mensaje msj = new E_Mensaje();
        public bool Editar = false;

        public Costos()
        {
            InitializeComponent();
        }
        public void ListarCombos()
        {
            cmbTipoGasto.DataSource = brC.MostrarTipoGasto();
            cmbTipoGasto.DisplayMember = "TipoGasto";
            cmbTipoGasto.ValueMember = "IdTipoGasto";

            cmbEstablecimiento.DataSource = brC.MostrarEstablecimiento();
            cmbEstablecimiento.DisplayMember = "Nombre";
            cmbEstablecimiento.ValueMember = "IdEstablecimiento";

            cmbAnimal.DataSource = brC.MostrarAnimales();
            cmbAnimal.DisplayMember = "NombreAnimal";
            cmbAnimal.ValueMember = "IdAnimal";
        }


        private void Costos_Load(object sender, EventArgs e)
        {
            ListarCombos();

            if (E_Costos.Editar == true)
            {
                Editar = true;
                lblID.Text = E_Vacuna.IdVacuna.ToString();
                cmbTipoGasto.SelectedValue = E_Costos.IdTipoGasto;
                cmbEstablecimiento.SelectedValue = E_Costos.IdEstablecimiento;
                cmbAnimal.SelectedValue = E_Costos.IdAnimal;
                txtMonto.Text = E_Costos.Monto.ToString();
                txtPagado.Text = E_Costos.Monto.ToString();
                txtDetalle.Text = E_Costos.Detalle;
            }
            else
            {
                cmbTipoGasto.SelectedIndex = 0;
                cmbEstablecimiento.SelectedIndex = 0;
                cmbAnimal.SelectedIndex = 0;
            }    
        }


        private void btnGuardarDatos_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtMonto.Text))
            {
                msj.MensajeAlerta("Hay campos vacíos.");
            }

            if (Editar == true)
            {
                try
                {
                    brC.ModificarGasto(E_Costos.IdGasto, dtpFechaGasto.Value.Date, Convert.ToInt32(cmbTipoGasto.SelectedValue), Convert.ToInt32(cmbEstablecimiento.SelectedValue), Convert.ToInt32(cmbAnimal.SelectedValue), Convert.ToDecimal(txtMonto.Text), Convert.ToDecimal(txtPagado.Text), txtDetalle.Text, E_Usuario.IdUsuario);
                    Editar = false;
                }

                catch (Exception ex)
                {
                    msj.MensajeError("Ha ocurrido un error" + ex);
                }
            }
            else
            {
                try
                {
                    brC.AltaGasto(dtpFechaGasto.Value.Date, Convert.ToInt32(cmbTipoGasto.SelectedValue), Convert.ToInt32(cmbEstablecimiento.SelectedValue), Convert.ToInt32(cmbAnimal.SelectedValue), Convert.ToDecimal(txtMonto.Text), Convert.ToDecimal(txtPagado.Text), txtDetalle.Text, E_Usuario.IdUsuario);
                }

                catch (Exception ex)
                {
                    msj.MensajeError("Ha ocurrido un error" + ex);
                }

            }

                Close();
                
        }

        private void btnCancelarDatos_Click(object sender, EventArgs e)
        {
                DialogResult preg = MessageBox.Show("¿Desea cerrar este formulario?", "WiredSoft", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (preg == DialogResult.Yes)
                {
                    Close();
                }
            
        }


    }
}
