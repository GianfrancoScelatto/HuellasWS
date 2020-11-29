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
    public partial class ListaNegra : Form
    {
        BR_Persona brP = new BR_Persona();
        BR_ListaNegra brLN = new BR_ListaNegra();
        E_Mensaje msj = new E_Mensaje();
        public bool Editar = false;
        public ListaNegra()
        {
            InitializeComponent();
        }

        private void ListaNegra_Load(object sender, EventArgs e)
        {
            CargarCombo();

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            {
                if (String.IsNullOrWhiteSpace(txtMotivo.Text))
                {
                    msj.MensajeAlerta("Hay campos vacíos.");
                }

                if (Editar == true)
                {
                    try
                    {
                        //brLN.();
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
                        //brLN.AltaListaNegra();
                    }

                    catch (Exception ex)
                    {
                        msj.MensajeError("Ha ocurrido un error" + ex);
                    }

                }

                Close();

            }

        }
        private void CargarCombo()
        { 
            cmbPersona.DataSource = brP.ComboPersona();
            cmbPersona.DisplayMember = "Nombre";
            cmbPersona.ValueMember = "IdPersona";

        }

    private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult preg = MessageBox.Show("¿Desea cerrar este formulario?", "WiredSoft", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (preg == DialogResult.Yes)
            {
                Close();
            }

        }
    }
}
