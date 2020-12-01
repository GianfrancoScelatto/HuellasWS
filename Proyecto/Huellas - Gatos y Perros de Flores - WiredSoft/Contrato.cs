using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataAccess;
using BusinessRules;
using Entities;

namespace Huellas___Gatos_y_Perros_de_Flores___WiredSoft
{
    public partial class Contrato : Form
    {
        BR_Animal brA = new BR_Animal();
        BR_Persona brP = new BR_Persona();
        BR_Contrato brC = new BR_Contrato();
        E_Mensaje msj = new E_Mensaje();
        public Contrato()
        {
            InitializeComponent();
        }

        private void CargarCombos()
        {
            cmbAnimal.DataSource = brA.ListarAnimal();
            cmbAnimal.DisplayMember = "NombreAnimal";
            cmbAnimal.ValueMember = "IdAnimal";

            cmbPersona.DataSource = brP.ComboPersona();
            cmbPersona.DisplayMember = "Nombre";
            cmbPersona.ValueMember = "IdPersona";
        }

        private void Contrato_Load(object sender, EventArgs e)
        {
            CargarCombos();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtNuevoNombre.Text))
            {
                msj.MensajeAlerta("Hay espacios vacíos.");
            }
            else
            {
                try
                {
                    brC.AltaContrato(Convert.ToInt32(cmbPersona.SelectedValue), Convert.ToInt32(cmbAnimal.SelectedValue), txtNuevoNombre.Text, E_UsuarioAcceso.IdUsuario);
                }

                catch (Exception ex)
                {
                    msj.MensajeError("Ha ocurrido un error" + ex);
                }
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
