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
    public partial class FichaMedica : Form
    {
        BR_Animal brA = new BR_Animal();
        BR_Establecimiento brE = new BR_Establecimiento();
        BR_FichaMedica brFM = new BR_FichaMedica();
        E_Mensaje msj = new E_Mensaje();
        bool Editar = false;
        string informe, tratamiento;
        public FichaMedica()
        {
            InitializeComponent();
        }

        private void CargarCombos()
        {
            cmbAnimal.DataSource = brA.ComboAnimal();
            cmbAnimal.DisplayMember = "NombreAnimal";
            cmbAnimal.ValueMember = "IdAnimal";

            cmbVet.DataSource = brE.ComboEstablecimiento();
            cmbAnimal.DisplayMember = "Establecimiento";
            cmbAnimal.ValueMember = "IdEstablecimiento";
        }

        private void FichaMedica_Load(object sender, EventArgs e)
        {
            CargarCombos();

            if (E_FichaMedica.Editar == true)
            {
                Editar = true;
                lblIdFM.Text = E_FichaMedica.IdFichaMedica.ToString();
                cmbAnimal.SelectedValue = E_FichaMedica.IdMascota;
                dtpFechaAtencion.Value = E_FichaMedica.Fecha.Date;
                txtInforme.Text = E_FichaMedica.Informe;
                txtTratamiento.Text = E_FichaMedica.Tratamiento;
                cmbVet.SelectedValue = E_FichaMedica.IdVeterinaria;
                txtCosto.Text = E_FichaMedica.Costo.ToString();
            }
            else
            {
                cmbVet.Items.Insert(-1, "Seleccione un valor");
                cmbAnimal.Items.Insert(-1, "Seleccione un valor");
                cmbAnimal.SelectedIndex = -1;
                cmbVet.SelectedIndex = -1;
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            if (txtTratamiento.TextLength > 0 || txtInforme.TextLength > 0 || txtCosto.TextLength > 0)
            {
                DialogResult preg = MessageBox.Show("¿Desea cerrar este formulario?", "WiredSoft", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (preg == DialogResult.OK)
                {
                    Close();
                }
            }
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (cmbAnimal.SelectedIndex == -1 || String.IsNullOrWhiteSpace(txtTratamiento.Text) || String.IsNullOrWhiteSpace(txtInforme.Text)
                || cmbVet.SelectedIndex == -1 || String.IsNullOrWhiteSpace(txtCosto.Text))
            {
                msj.MensajeAlerta("Hay campos vacíos.");
            }
            else
            {
                if (Editar == true)
                {
                    try
                    {
                        tratamiento += txtTratamiento.Text + Environment.NewLine;
                        informe += txtInforme.Text + Environment.NewLine;

                        brFM.ModificarFichaMedica(E_FichaMedica.IdFichaMedica, Convert.ToInt32(cmbAnimal.SelectedValue), Convert.ToInt32(cmbVet.SelectedValue), 
                                                dtpFechaAtencion.Value.Date, informe, tratamiento, Convert.ToDecimal(txtCosto.Text));

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
                        tratamiento += txtTratamiento.Text + Environment.NewLine;
                        informe += txtInforme.Text + Environment.NewLine;

                        brFM.AltaFichaMedica(Convert.ToInt32(cmbAnimal.SelectedValue), Convert.ToInt32(cmbVet.SelectedValue),
                                            dtpFechaAtencion.Value.Date, informe, tratamiento, Convert.ToDecimal(txtCosto.Text));
                    }
                    catch
                    {
                        msj.MensajeError("Ha ocurrido un error.");
                    }
                }
            }
        }
    }
}
