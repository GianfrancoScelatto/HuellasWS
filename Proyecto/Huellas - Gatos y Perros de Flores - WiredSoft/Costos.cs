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
        string detalle;

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
                txtMonto.Text = Math.Round(E_Costos.Monto, 2, MidpointRounding.ToEven).ToString();
                txtPagado.Text = Math.Round(E_Costos.Pagado, 2, MidpointRounding.ToEven).ToString();
                txtDetalle.Text = E_Costos.Detalle;
                dtpFechaGasto.Value = E_Costos.FechaGasto;
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
            if (String.IsNullOrWhiteSpace(txtMonto.Text) || String.IsNullOrWhiteSpace(txtPagado.Text) || String.IsNullOrWhiteSpace(txtDetalle.Text))
            {
                msj.MensajeAlerta("Hay campos vacíos.");
            }

            if (Editar == true)
            {
                try
                {
                    detalle += txtDetalle.Text + Environment.NewLine;
                    brC.ModificarGasto(E_Costos.IdGasto, dtpFechaGasto.Value.Date, Convert.ToInt32(cmbTipoGasto.SelectedValue), Convert.ToInt32(cmbEstablecimiento.SelectedValue), 
                                        Convert.ToInt32(cmbAnimal.SelectedValue), Convert.ToDecimal(txtMonto.Text), Convert.ToDecimal(txtPagado.Text), detalle, E_UsuarioAcceso.IdUsuario);
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
                    detalle += txtDetalle.Text + Environment.NewLine;
                    brC.AltaGasto(dtpFechaGasto.Value.Date, Convert.ToInt32(cmbTipoGasto.SelectedValue), Convert.ToInt32(cmbEstablecimiento.SelectedValue), 
                                    Convert.ToInt32(cmbAnimal.SelectedValue), Convert.ToDecimal(txtMonto.Text), Convert.ToDecimal(txtPagado.Text), 
                                    detalle, E_UsuarioAcceso.IdUsuario);
                }

                catch (Exception ex)
                {
                    msj.MensajeError("Ha ocurrido un error: " + ex);
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
